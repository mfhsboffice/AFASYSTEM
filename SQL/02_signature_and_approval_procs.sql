/* ============================================================================
   FILE 02 - SIGNATURE & APPROVAL PROCEDURES
   AFA_NonIFS_* covering: user-department mapping, signature node CRUD,
   default signature initialisation, position resolution, the pivoted
   signature grid, and the approval inbox.
   ============================================================================ */

SECTION 7 - USER DEPARTMENT MAPPING
   ============================================================================ */

IF OBJECT_ID('dbo.AFA_NonIFS_GetUserDepartmentList_Proc','P') IS NOT NULL DROP PROC dbo.AFA_NonIFS_GetUserDepartmentList_Proc;
IF OBJECT_ID('dbo.AFA_NonIFS_GetUserDepartment_Proc','P')     IS NOT NULL DROP PROC dbo.AFA_NonIFS_GetUserDepartment_Proc;
IF OBJECT_ID('dbo.AFA_NonIFS_SaveUserDepartment_Proc','P')    IS NOT NULL DROP PROC dbo.AFA_NonIFS_SaveUserDepartment_Proc;
IF OBJECT_ID('dbo.AFA_NonIFS_DeleteUserDepartment_Proc','P')  IS NOT NULL DROP PROC dbo.AFA_NonIFS_DeleteUserDepartment_Proc;
GO


/* ============================================================
   1. USERS WITH THEIR DEPARTMENTS (for the grid)
   One row per user, departments concatenated into a single text.
   FOR XML PATH is used instead of STRING_AGG so the script still
   runs on SQL Server versions below 2017.
   ============================================================ */
CREATE PROC dbo.AFA_NonIFS_GetUserDepartmentList_Proc
    @Keyword varchar(100)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @key varchar(100) = ISNULL(LTRIM(RTRIM(@Keyword)),'');

    SELECT
         u.NIK
        ,ISNULL(RTRIM(g.Nama), RTRIM(h.Name)) AS NAMA
        ,COUNT(*)                             AS TOTAL_DEPT
        ,STUFF((
            SELECT ', ' + d2.DEPT_NAME + ' (' + d2.PREFIX + ')'
            FROM   dbo.AFA_DEPARTMENT_USER u2
            JOIN   dbo.AFA_DEPARTMENT      d2 ON d2.DEPT_ID = u2.DEPT_ID
            WHERE  u2.NIK = u.NIK
            ORDER  BY d2.DEPT_NAME
            FOR XML PATH(''), TYPE).value('.','varchar(max)'), 1, 2, '') AS DEPARTMENTS
    FROM   dbo.AFA_DEPARTMENT_USER u
    LEFT   JOIN dbo.AFA_Employee_GTAS g ON RTRIM(g.NIK) = u.NIK
    LEFT   JOIN dbo.User_H            h ON h.UserID     = u.NIK
    WHERE  @key = ''
        OR u.NIK LIKE '%' + @key + '%'
        OR g.Nama LIKE '%' + @key + '%'
        OR h.Name LIKE '%' + @key + '%'
    GROUP  BY u.NIK, g.Nama, h.Name
    ORDER  BY ISNULL(RTRIM(g.Nama), RTRIM(h.Name));
END;
GO


/* ============================================================
   2. DEPARTMENTS OF ONE USER (fills the checked combo)
   ============================================================ */
CREATE PROC dbo.AFA_NonIFS_GetUserDepartment_Proc
    @Nik varchar(10)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT d.DEPT_ID, d.DEPT_NAME, d.PREFIX,
           d.DEPT_NAME + ' (' + d.PREFIX + ')' AS DISPLAY_NAME
    FROM   dbo.AFA_DEPARTMENT_USER u
    JOIN   dbo.AFA_DEPARTMENT      d ON d.DEPT_ID = u.DEPT_ID
    WHERE  u.NIK = @Nik
    ORDER  BY d.DEPT_NAME;
END;
GO


/* ============================================================
   3. SAVE THE MAPPING
   @DeptIds holds DEPT_ID values separated by commas, e.g. '1,7,23'.
   The old rows are deleted and rewritten - simpler and safer than
   working out the difference row by row.

   The string is split with XML rather than STRING_SPLIT, so the
   script does not depend on compatibility level 130 or above.
   ============================================================ */
CREATE PROC dbo.AFA_NonIFS_SaveUserDepartment_Proc
    @Nik      varchar(10),
    @DeptIds  varchar(max),
    @NikUpdate varchar(50),
    @Pc       varchar(50),
    @Status   varchar(10)  OUTPUT,
    @Message  varchar(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET @Status = 'FAILED'; SET @Message = '';

    DECLARE @xml xml, @cnt int, @invalid int;

    DECLARE @ids TABLE (DEPT_ID int PRIMARY KEY);

    BEGIN TRY
        SET @Nik = LTRIM(RTRIM(ISNULL(@Nik,'')));

        IF @Nik = '' BEGIN SET @Message = 'NIK is required.'; RETURN; END

        -- the user must exist in the employee master or the app user master
        IF NOT EXISTS (SELECT 1 FROM dbo.AFA_Employee_GTAS WHERE RTRIM(NIK) = @Nik)
           AND NOT EXISTS (SELECT 1 FROM dbo.User_H WHERE UserID = @Nik)
        BEGIN SET @Message = 'NIK not found in the employee master.'; RETURN; END

        IF ISNULL(@DeptIds,'') = ''
        BEGIN SET @Message = 'At least one department must be selected.'; RETURN; END

        SET @xml = CAST('<i>' + REPLACE(@DeptIds, ',', '</i><i>') + '</i>' AS xml);

        INSERT INTO @ids (DEPT_ID)
        SELECT DISTINCT TRY_CAST(LTRIM(RTRIM(x.i.value('.','varchar(20)'))) AS int)
        FROM   @xml.nodes('/i') AS x(i)
        WHERE  TRY_CAST(LTRIM(RTRIM(x.i.value('.','varchar(20)'))) AS int) IS NOT NULL;

        SELECT @cnt = COUNT(*) FROM @ids;
        IF @cnt = 0 BEGIN SET @Message = 'The department list is not valid.'; RETURN; END

        SELECT @invalid = COUNT(*)
        FROM   @ids i
        WHERE  NOT EXISTS (SELECT 1 FROM dbo.AFA_DEPARTMENT d
                           WHERE d.DEPT_ID = i.DEPT_ID AND d.IS_ACTIVE = 1);

        IF @invalid > 0
        BEGIN SET @Message = 'One or more departments were not found or are inactive.'; RETURN; END

        BEGIN TRANSACTION;

        DELETE FROM dbo.AFA_DEPARTMENT_USER WHERE NIK = @Nik;

        INSERT INTO dbo.AFA_DEPARTMENT_USER (DEPT_ID, NIK)
        SELECT DEPT_ID, @Nik FROM @ids;

        COMMIT TRANSACTION;

        SET @Status  = 'SUCCESS';
        SET @Message = 'Mapping saved. ' + CAST(@cnt AS varchar(10)) + ' department(s) for NIK ' + @Nik;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        SET @Status  = 'FAILED';
        SET @Message = LEFT(ERROR_MESSAGE(), 255);
    END CATCH
END;
GO


/* ============================================================
   4. REMOVE ALL MAPPINGS FOR ONE USER
   ============================================================ */
CREATE PROC dbo.AFA_NonIFS_DeleteUserDepartment_Proc
    @Nik     varchar(10),
    @Status  varchar(10)  OUTPUT,
    @Message varchar(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET @Status = 'FAILED'; SET @Message = '';

    BEGIN TRY
        DELETE FROM dbo.AFA_DEPARTMENT_USER WHERE NIK = LTRIM(RTRIM(@Nik));

        IF @@ROWCOUNT = 0
        BEGIN SET @Message = 'There is no mapping for that NIK.'; RETURN; END

        SET @Status  = 'SUCCESS';
        SET @Message = 'Mapping deleted.';
    END TRY
    BEGIN CATCH
        SET @Status  = 'FAILED';
        SET @Message = LEFT(ERROR_MESSAGE(), 255);
    END CATCH
END;
GO


/* ============================================================================


SECTION 8 - SIGNATURE SUPPORT
   ============================================================================ */

IF OBJECT_ID('dbo.AFA_NonIFS_GetSignature_Proc','P')    IS NOT NULL DROP PROC dbo.AFA_NonIFS_GetSignature_Proc;
IF OBJECT_ID('dbo.AFA_NonIFS_UpdatePriority_Proc','P')  IS NOT NULL DROP PROC dbo.AFA_NonIFS_UpdatePriority_Proc;
IF OBJECT_ID('dbo.AFA_NonIFS_GetForSignature_Proc','P') IS NOT NULL DROP PROC dbo.AFA_NonIFS_GetForSignature_Proc;
GO


/* ============================================================
   1. HEADER + DETAIL FOR THE SIGNATURE FORM
   One flat row so the form can fill its read-only fields in a
   single call. Detail columns differ per AFA type, so only the
   values every type shares are returned here plus the headline
   amount.
   ============================================================ */
CREATE PROC dbo.AFA_NonIFS_GetForSignature_Proc
    @AfaNo varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
         h.AFA_NO
        ,h.AFA_NO_APPROVAL
        ,h.AFA_TYPE
        ,t.NAME              AS AFA_TYPE_NAME
        ,h.SUBJECT
        ,h.PURPOSES
        ,h.BG_EXPLANATION
        ,h.CURCODE
        ,h.AMT
        ,h.AMT_JPY
        ,h.PRIORITY
        ,h.PRIORITY_REASON
        ,h.STS
        ,h.SRI_STS
        ,h.REF_REG
        ,h.BUDGET_STS
        ,h.AFA_PER_FROM
        ,h.AFA_PER_TO
        ,h.DEPT_ID
        ,d.DEPT_NAME
        ,h.USERID            AS CREATED_NIK
        ,h.DATECREATE
    FROM   dbo.AFA_NON_IFS h
    LEFT   JOIN dbo.AFA_TYPE       t ON t.CODE    = h.AFA_TYPE
    LEFT   JOIN dbo.AFA_DEPARTMENT d ON d.DEPT_ID = h.DEPT_ID
    WHERE  h.AFA_NO = @AfaNo;
END;
GO


/* ============================================================
   2. SIGNATURE NODES OF ONE DOCUMENT
   Ordered by AFA_Jenis_Urut: Dir(1) Supp(2) Budget(3) Auth(4).
   Returns every node including the empty placeholders, so the
   grid can show the full approval tree.
   ============================================================ */
CREATE PROC dbo.AFA_NonIFS_GetSignature_Proc
    @AfaNo varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
         s.TYPE
        ,j.urut              AS URUT
        ,s.ID
        ,RTRIM(ISNULL(s.NIK,''))  AS NIK
        ,RTRIM(ISNULL(s.NAMA,'')) AS NAMA
        ,ISNULL(s.JAB,'')         AS JAB
        ,ISNULL(s.STS,'')         AS STS
        ,s.DATEAPP
        ,s.Reason
    FROM   dbo.AFA_SIGNATURE s
    LEFT   JOIN dbo.AFA_Jenis_Urut j ON j.Jenis = s.TYPE
    WHERE  s.AFA_NO = @AfaNo
    ORDER  BY j.urut, s.ID;
END;
GO


/* ============================================================
   3. UPDATE PRIORITY
   Priority is set on the Signature form, not on the E-Form, so
   it needs its own procedure. Allowed while the document is
   still Draft or Planned - once approved the label is frozen.
   ============================================================ */
CREATE PROC dbo.AFA_NonIFS_UpdatePriority_Proc
    @AfaNo    varchar(50),
    @Priority tinyint,
    @Reason   varchar(500),
    @Nik      varchar(50),
    @Pc       varchar(50),
    @Status   varchar(10)  OUTPUT,
    @Message  varchar(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET @Status = 'FAILED'; SET @Message = '';

    DECLARE @sts varchar(50);

    BEGIN TRY
        IF @Priority > 3
        BEGIN SET @Message = 'Priority must be between 0 and 3.'; RETURN; END

        SELECT @sts = STS FROM dbo.AFA_NON_IFS WHERE AFA_NO = @AfaNo;

        IF @sts IS NULL
        BEGIN SET @Message = 'AFA not found.'; RETURN; END

        IF @sts NOT IN ('Draft','Planned')
        BEGIN SET @Message = 'Priority can only be changed while the AFA is Draft or Planned.'; RETURN; END

        UPDATE dbo.AFA_NON_IFS
        SET PRIORITY        = @Priority,
            PRIORITY_REASON = @Reason,
            USERUPDATE      = @Nik,
            DATEUPDATE      = GETDATE()
        WHERE AFA_NO = @AfaNo;

        INSERT INTO dbo.AFA_Log (ID, Type, NIK, PC, DateCreate, AFA)
        VALUES (GETDATE(), 'Set Priority', @Nik, @Pc, GETDATE(), @AfaNo);

        SET @Status  = 'SUCCESS';
        SET @Message = 'Priority updated.';
    END TRY
    BEGIN CATCH
        SET @Status  = 'FAILED';
        SET @Message = LEFT(ERROR_MESSAGE(), 255);
    END CATCH
END;
GO


/* ============================================================================


   SECTION 9 - DEFAULT SIGNATURE AND SRI APPLICATION
   ============================================================================ */

/* ----------------------------------------------------------------------------
   Default authorised signer per rule row.
   Columns are created in section 1; this only seeds them.
   ---------------------------------------------------------------------------- */

UPDATE dbo.AFA_SRI_RULE
SET    AUTH1_JAB = 'President Director'
WHERE  AUTH1_JAB IS NULL;
GO



/* ------------------------------------------------------------
   4. RESOLVE A POSITION TO A PERSON
   User_H.Jab is free text and inconsistent ('PRES DIRECTOR',
   'PRESIDENT DIRECTOR', 'DIERCTOR'), so matching uses a
   normalised form with punctuation and spaces removed.
   Comparison is case-insensitive through the collation.

   Only active users are considered. When more than one person
   holds a position the lowest UserID wins - deterministic, but
   it means duplicates need cleaning up in User_H.
   ------------------------------------------------------------ */

IF OBJECT_ID('dbo.AFA_NonIFS_ResolveJab_Fn','FN') IS NOT NULL
    DROP FUNCTION dbo.AFA_NonIFS_ResolveJab_Fn;
GO

CREATE FUNCTION dbo.AFA_NonIFS_ResolveJab_Fn (@Jab varchar(50))
RETURNS varchar(10)
AS
BEGIN
    DECLARE @norm varchar(50), @nik varchar(10);

    SET @norm = REPLACE(REPLACE(REPLACE(LTRIM(RTRIM(ISNULL(@Jab,''))), '.', ''), ' ', ''), '&', '');

    IF @norm = '' RETURN NULL;

    SELECT TOP 1 @nik = RTRIM(u.UserID)
    FROM   dbo.User_H u
    WHERE  ISNULL(u.Aktif,'') = 'Y'
      AND  REPLACE(REPLACE(REPLACE(LTRIM(RTRIM(ISNULL(u.Jab,''))), '.', ''), ' ', ''), '&', '') = @norm
    ORDER  BY u.UserID;

    RETURN @nik;
END;
GO


/* ------------------------------------------------------------
   5. INITIALISE THE SIGNATURE NODES
   Creates the grid the drafter fills in and pre-fills what can
   be resolved automatically:

     Budget 1 - the shared Budget Control account
     Auth 1   - AUTH1_JAB of the matching AFA_SRI_RULE row
     Auth 2   - AUTH2_JAB, when the rule row sets one

   Existing nodes are never touched, so calling this again on a
   saved document is harmless.
   ------------------------------------------------------------ */

IF OBJECT_ID('dbo.AFA_NonIFS_InitSignature_Proc','P') IS NOT NULL
    DROP PROC dbo.AFA_NonIFS_InitSignature_Proc;
GO

CREATE PROC dbo.AFA_NonIFS_InitSignature_Proc
    @AfaNo   varchar(50),
    @MaxRow  int,
    @Nik     varchar(50),
    @Pc      varchar(50),
    @Status  varchar(10)  OUTPUT,
    @Message varchar(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET @Status = 'FAILED'; SET @Message = '';

    DECLARE @type varchar(10), @sub varchar(10), @created int = 0,
            @jab1 varchar(50), @jab2 varchar(50),
            @nik1 varchar(10), @nik2 varchar(10), @nikBudget varchar(10),
            @warn varchar(200) = '';

    DECLARE @slot TABLE (JENIS varchar(50), ID int, NIK varchar(10));

    BEGIN TRY
        SELECT @type = AFA_TYPE FROM dbo.AFA_NON_IFS WHERE AFA_NO = @AfaNo;
        IF @type IS NULL BEGIN SET @Message = 'AFA not found.'; RETURN; END

        IF ISNULL(@MaxRow,0) <= 0 SET @MaxRow = 10;

        /* sub-type exists for INF and DAA only */
        IF @type = 'INF'
            SELECT @sub = SUB_TYPE FROM dbo.AFA_NON_IFS_INF WHERE AFA_NO = @AfaNo;
        ELSE IF @type = 'DAA'
            SELECT TOP 1 @sub = SUB_TYPE FROM dbo.AFA_NON_IFS_DAA WHERE AFA_NO = @AfaNo ORDER BY SEQ;

        SET @sub = ISNULL(@sub, '*');

        SELECT TOP 1 @jab1 = AUTH1_JAB, @jab2 = AUTH2_JAB
        FROM   dbo.AFA_SRI_RULE
        WHERE  AFA_TYPE = @type AND IS_ACTIVE = 1
          AND  SUB_TYPE IN (@sub, '*')
        ORDER  BY CASE WHEN SUB_TYPE = @sub THEN 0 ELSE 1 END;

        SET @nik1 = dbo.AFA_NonIFS_ResolveJab_Fn(@jab1);
        SET @nik2 = dbo.AFA_NonIFS_ResolveJab_Fn(@jab2);

        -- Budget Control is resolved the same way as the authorised
        -- approvers, from the position master
        SET @nikBudget = dbo.AFA_NonIFS_ResolveJab_Fn('Budget Controler');

        IF @nikBudget IS NULL
            SELECT TOP 1 @nikBudget = RTRIM(UserID)
            FROM   dbo.User_H
            WHERE  ISNULL(Aktif,'') = 'Y' AND ISNULL(Budget,'') = 'Y'
            ORDER  BY UserID;

        /* every jenis gets @MaxRow slots, except Budget which has one */
        ;WITH nums AS (
            SELECT TOP (@MaxRow) ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS n
            FROM   sys.all_objects
        )
        INSERT INTO @slot (JENIS, ID, NIK)
        SELECT j.Jenis, n.n,
               CASE
                   WHEN j.Jenis = 'Budget' AND n.n = 1 THEN @nikBudget
                   WHEN j.Jenis = 'Auth'   AND n.n = 1 THEN @nik1
                   WHEN j.Jenis = 'Auth'   AND n.n = 2 THEN @nik2
               END
        FROM   dbo.AFA_Jenis_Urut j
        CROSS  JOIN nums n
        WHERE  j.Jenis <> 'Budget' OR n.n = 1;

        BEGIN TRANSACTION;

        INSERT INTO dbo.AFA_SIGNATURE
            (AFA_NO, TYPE, ID, NIK, NAMA, JAB, STS, DateCreate, PCCreate, UserCreate)
        SELECT
             @AfaNo
            ,s.JENIS
            ,s.ID
            ,ISNULL(s.NIK, '')
            ,ISNULL(RTRIM(u.Name), '')
            ,ISNULL(RTRIM(u.Jab), '')
            ,CASE WHEN ISNULL(s.NIK,'') = '' THEN '' ELSE 'Send' END
            ,GETDATE()
            ,@Pc
            ,@Nik
        FROM   @slot s
        LEFT   JOIN dbo.User_H u ON RTRIM(u.UserID) = s.NIK
        WHERE  NOT EXISTS (SELECT 1 FROM dbo.AFA_SIGNATURE e
                           WHERE e.AFA_NO = @AfaNo AND e.TYPE = s.JENIS AND e.ID = s.ID);

        SET @created = @@ROWCOUNT;

        COMMIT TRANSACTION;

        /* an unresolved default looks like an intentionally empty
           node, so report it rather than letting it pass unnoticed */
        IF ISNULL(@jab1,'') <> '' AND @nik1 IS NULL
            SET @warn = @warn + ' No active user holds the position ' + @jab1 + '.';

        IF ISNULL(@jab2,'') <> '' AND @nik2 IS NULL
            SET @warn = @warn + ' No active user holds the position ' + @jab2 + '.';

        SET @Status  = 'SUCCESS';
        SET @Message = LEFT(CAST(@created AS varchar(10)) +
                            ' signature node(s) prepared.' + @warn, 255);
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        SET @Status  = 'FAILED';
        SET @Message = LEFT(ERROR_MESSAGE(), 255);
    END CATCH
END;
GO


/* ------------------------------------------------------------
   6. DATA QUALITY CHECKS - run these before go-live
   ------------------------------------------------------------ */

-- 6a. Signing positions that no active user currently holds.
--     Anything listed here can never be filled in automatically.
SELECT j.Jabatan, j.urut
FROM   dbo.AFA_JAB_SIGN j
WHERE  j.Jabatan <> ''
  AND  dbo.AFA_NonIFS_ResolveJab_Fn(j.Jabatan) IS NULL
ORDER  BY j.urut DESC;

-- 6b. Positions used in User_H that are missing from the signing
--     master. 'DIERCTOR' is a typo worth fixing; the rest may
--     simply be positions that never sign.
SELECT DISTINCT RTRIM(u.Jab) AS JAB_IN_USER_H
FROM   dbo.User_H u
WHERE  ISNULL(u.Aktif,'') = 'Y'
  AND  ISNULL(u.Jab,'') <> ''
  AND  NOT EXISTS (
        SELECT 1 FROM dbo.AFA_JAB_SIGN j
        WHERE REPLACE(REPLACE(REPLACE(j.Jabatan,'.',''),' ',''),'&','')
            = REPLACE(REPLACE(REPLACE(u.Jab,'.',''),' ',''),'&',''))
ORDER  BY 1;

-- 6c. More than one active user on the same signing position.
--     The procedure picks the lowest UserID, so duplicates are
--     worth reviewing.
SELECT RTRIM(u.Jab) AS JAB, COUNT(*) AS TOTAL_USER
FROM   dbo.User_H u
WHERE  ISNULL(u.Aktif,'') = 'Y' AND ISNULL(u.Jab,'') <> ''
GROUP  BY RTRIM(u.Jab)
HAVING COUNT(*) > 1
ORDER  BY COUNT(*) DESC;


/* ----------------------------------------------------------------------------
   Apply the SRI rule to a saved document, so the drafter sees the label
   right after saving instead of only after submitting. The label is
   written again at submit time, which is when it is frozen.
   ---------------------------------------------------------------------------- */

IF OBJECT_ID('dbo.AFA_NonIFS_ApplySRI_Proc','P') IS NOT NULL
    DROP PROC dbo.AFA_NonIFS_ApplySRI_Proc;
GO

CREATE PROC dbo.AFA_NonIFS_ApplySRI_Proc
    @AfaNo   varchar(50),
    @Status  varchar(10)  OUTPUT,
    @Message varchar(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET @Status = 'FAILED'; SET @Message = '';

    DECLARE @st varchar(10), @msg varchar(255),
            @sri varchar(20), @ref varchar(100);

    DECLARE @eval TABLE (SRI_STS varchar(20), REF_REG varchar(100));

    BEGIN TRY
        INSERT INTO @eval
        EXEC dbo.AFA_NonIFS_EvaluateSRI_Proc @AfaNo = @AfaNo,
             @Status = @st OUTPUT, @Message = @msg OUTPUT;

        IF @st <> 'SUCCESS' BEGIN SET @Message = @msg; RETURN; END

        SELECT TOP 1 @sri = SRI_STS, @ref = REF_REG FROM @eval;

        UPDATE dbo.AFA_NON_IFS
        SET SRI_STS = @sri,
            REF_REG = ISNULL(REF_REG, @ref)
        WHERE AFA_NO = @AfaNo AND STS IN ('Draft','Planned');

        SELECT @sri AS SRI_STS, @ref AS REF_REG;

        SET @Status  = 'SUCCESS';
        SET @Message = 'SRI: ' + @sri;
    END TRY
    BEGIN CATCH
        SET @Status  = 'FAILED';
        SET @Message = LEFT(ERROR_MESSAGE(), 255);
    END CATCH
END;
GO


/* ============================================================================
   SECTION 10 - DATA QUALITY CHECKS
   Run these once after deployment. None of them change data.
   ============================================================================ */

-- 10a. Default signer positions that no active user currently holds.
--      Anything listed here can never be filled in automatically.
SELECT DISTINCT r.AUTH1_JAB AS POSITION_WITHOUT_USER
FROM   dbo.AFA_SRI_RULE r
WHERE  ISNULL(r.AUTH1_JAB,'') <> ''
  AND  dbo.AFA_NonIFS_ResolveJab_Fn(r.AUTH1_JAB) IS NULL
UNION
SELECT DISTINCT r.AUTH2_JAB
FROM   dbo.AFA_SRI_RULE r
WHERE  ISNULL(r.AUTH2_JAB,'') <> ''
  AND  dbo.AFA_NonIFS_ResolveJab_Fn(r.AUTH2_JAB) IS NULL;

-- 10b. Positions referenced by the rules that are not in AFA_JAB_SIGN.
--      There is no foreign key on those columns, so this is the check
--      that replaces it.
SELECT DISTINCT r.AUTH1_JAB AS POSITION_NOT_IN_MASTER
FROM   dbo.AFA_SRI_RULE r
WHERE  ISNULL(r.AUTH1_JAB,'') <> ''
  AND  NOT EXISTS (SELECT 1 FROM dbo.AFA_JAB_SIGN j WHERE j.Jabatan = r.AUTH1_JAB);

-- 10c. Signing positions held by more than one active user. The resolver
--      picks the lowest UserID, so duplicates are worth reviewing.
SELECT RTRIM(u.Jab) AS JAB, COUNT(*) AS TOTAL_USER
FROM   dbo.User_H u
WHERE  ISNULL(u.Aktif,'') = 'Y' AND ISNULL(u.Jab,'') <> ''
GROUP  BY RTRIM(u.Jab)
HAVING COUNT(*) > 1
ORDER  BY COUNT(*) DESC;

-- 10d. Did the Budget Control account resolve?
SELECT ISNULL(dbo.AFA_NonIFS_ResolveJab_Fn('Budget Controler'),
              (SELECT TOP 1 RTRIM(UserID) FROM dbo.User_H
               WHERE ISNULL(Aktif,'') = 'Y' AND ISNULL(Budget,'') = 'Y'
               ORDER BY UserID)) AS BUDGET_CONTROL_NIK;


IF OBJECT_ID('dbo.AFA_NonIFS_GetSignatureGrid_Proc','P') IS NOT NULL
    DROP PROC dbo.AFA_NonIFS_GetSignatureGrid_Proc;
GO

CREATE PROC dbo.AFA_NonIFS_GetSignatureGrid_Proc
    @AfaNo  varchar(50),
    @MaxRow int
AS
BEGIN
    SET NOCOUNT ON;

    IF ISNULL(@MaxRow,0) <= 0 SET @MaxRow = 10;

    ;WITH nums AS (
        SELECT TOP (@MaxRow) ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS Urut
        FROM   sys.all_objects
    )
    SELECT
         n.Urut
        ,ISNULL(RTRIM(a.NIK),'')  AS Auth_NIK
        ,ISNULL(RTRIM(a.NAMA),'') AS Authorized
        ,ISNULL(a.JAB,'')         AS Auth_Jab
        ,ISNULL(a.STS,'')         AS Sts_Auth
        ,a.DATEAPP                AS App_Auth
        ,ISNULL(RTRIM(s.NIK),'')  AS Supp_NIK
        ,ISNULL(RTRIM(s.NAMA),'') AS Supporting
        ,ISNULL(s.JAB,'')         AS Supp_Jab
        ,ISNULL(s.STS,'')         AS Sts_Supp
        ,s.DATEAPP                AS App_Supp
        ,ISNULL(RTRIM(d.NIK),'')  AS Dir_NIK
        ,ISNULL(RTRIM(d.NAMA),'') AS Direct
        ,ISNULL(d.JAB,'')         AS Dir_Jab
        ,ISNULL(d.STS,'')         AS Sts_Dir
        ,d.DATEAPP                AS App_Dir
    FROM   nums n
    LEFT   JOIN dbo.AFA_SIGNATURE a ON a.AFA_NO = @AfaNo AND a.TYPE = 'Auth'   AND a.ID = n.Urut
    LEFT   JOIN dbo.AFA_SIGNATURE s ON s.AFA_NO = @AfaNo AND s.TYPE = 'Supp'   AND s.ID = n.Urut
    LEFT   JOIN dbo.AFA_SIGNATURE d ON d.AFA_NO = @AfaNo AND d.TYPE = 'Dir'    AND d.ID = n.Urut
    ORDER  BY n.Urut;

    /* second result set: the Budget node, shown read-only on the form */
    SELECT TOP 1
         ISNULL(RTRIM(b.NIK),'')  AS Budget_NIK
        ,ISNULL(RTRIM(b.NAMA),'') AS Budget_Name
        ,ISNULL(b.JAB,'')         AS Budget_Jab
        ,ISNULL(b.STS,'')         AS Sts_Budget
    FROM   dbo.AFA_SIGNATURE b
    WHERE  b.AFA_NO = @AfaNo AND b.TYPE = 'Budget'
    ORDER  BY b.ID;
END;
GO


/* ----------------------------------------------------------------------------
   Approval inbox for one person, across all four AFA types. Scoped by
   NIK, not by department: signing authority is not tied to a single
   department, so restricting by department would hide documents this
   person is legitimately named on.

   Only nodes on documents already sent (STS = 'Planned') are returned -
   see the fix above for why that check matters here.
   ---------------------------------------------------------------------------- */

IF OBJECT_ID('dbo.AFA_NonIFS_GetPendingApproval_Proc','P') IS NOT NULL
    DROP PROC dbo.AFA_NonIFS_GetPendingApproval_Proc;
GO

CREATE PROC dbo.AFA_NonIFS_GetPendingApproval_Proc
    @Nik varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
         s.AFA_NO
        ,s.TYPE                AS JENIS
        ,s.ID
        ,h.AFA_TYPE
        ,t.NAME                AS AFA_TYPE_NAME
        ,sub.SUB_TYPE_NAME
        ,d.DEPT_NAME
        ,h.SUBJECT
        ,h.CURCODE
        ,h.AMT
        ,h.AMT_JPY
        ,h.SRI_STS
        ,h.PRIORITY
        ,CASE h.PRIORITY WHEN 1 THEN 'Important'
                         WHEN 2 THEN 'Urgent'
                         WHEN 3 THEN 'Top Priority'
                         ELSE '' END AS PRIORITY_LABEL
        ,h.USERID              AS CREATED_NIK
        ,u.Name                AS CREATED_BY
        ,h.DATECREATE          AS CREATED_DATE
        ,DATEDIFF(day, h.DATECREATE, GETDATE()) AS DAYS_WAITING
    FROM   dbo.AFA_SIGNATURE s
    JOIN   dbo.AFA_NON_IFS   h ON h.AFA_NO = s.AFA_NO
    LEFT   JOIN dbo.AFA_TYPE t ON t.CODE    = h.AFA_TYPE
    LEFT   JOIN dbo.AFA_DEPARTMENT d ON d.DEPT_ID = h.DEPT_ID
    LEFT   JOIN dbo.User_H  u ON u.UserID  = h.USERID
    OUTER  APPLY (
        SELECT TOP 1 x.SUB_TYPE_NAME
        FROM (
            SELECT i.AFA_NO, sb.NAME AS SUB_TYPE_NAME
            FROM   dbo.AFA_NON_IFS_INF i
            LEFT   JOIN dbo.AFA_SUB_TYPE sb ON sb.AFA_TYPE = 'INF' AND sb.CODE = i.SUB_TYPE
            UNION ALL
            SELECT dd.AFA_NO, sb.NAME
            FROM   dbo.AFA_NON_IFS_DAA dd
            LEFT   JOIN dbo.AFA_SUB_TYPE sb ON sb.AFA_TYPE = 'DAA' AND sb.CODE = dd.SUB_TYPE
        ) x
        WHERE  x.AFA_NO = h.AFA_NO
    ) sub
    WHERE  s.NIK = @Nik
      AND  s.STS = 'Send'
      AND  h.STS = 'Planned'
    ORDER  BY h.PRIORITY DESC, h.DATECREATE ASC;
END;
GO
