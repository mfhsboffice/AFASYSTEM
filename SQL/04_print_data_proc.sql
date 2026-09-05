/* ============================================================================
   FILE 04 - PRINT / VIEW DATA PROCEDURE
   AFA_NonIFS_GetPrintData_Proc - 4 result sets (header, signature, detail,
   attachments) feeding the XtraReport renderer. Attachments are listed for
   the viewer, never inlined into the printed document.
   ============================================================================ */

IF OBJECT_ID('dbo.AFA_NonIFS_GetPrintData_Proc','P') IS NOT NULL
    DROP PROC dbo.AFA_NonIFS_GetPrintData_Proc;
GO

CREATE PROC dbo.AFA_NonIFS_GetPrintData_Proc
    @AfaNo varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    /* ========================================================================
       1. HEADER
       ======================================================================== */
    SELECT
         h.AFA_NO
        ,ISNULL(h.AFA_NO_APPROVAL,'')                      AS AFA_NO_APPROVAL
        ,h.AFA_TYPE
        ,ISNULL(t.NAME,'')                                 AS AFA_TYPE_NAME
        ,ISNULL(sub.SUB_TYPE_NAME,'')                      AS SUB_TYPE_NAME
        ,ISNULL(d.DEPT_NAME,'')                            AS DEPT_NAME
        ,ISNULL(d.PREFIX,'')                               AS DEPT_PREFIX
        ,ISNULL(l.NAME,'')                                 AS LOCATION_NAME
        ,ISNULL(h.SUBJECT,'')                              AS SUBJECT
        ,ISNULL(h.PURPOSES,'')                             AS PURPOSES
        ,ISNULL(h.BG_EXPLANATION,'')                       AS BG_EXPLANATION
        ,ISNULL(h.NOTETEXT,'')                             AS NOTETEXT

        /* dates as text: the report should not have to know a locale */
        ,ISNULL(CONVERT(varchar(12), h.AFA_DATE, 113),'')          AS AFA_DATE
        ,ISNULL(CONVERT(varchar(12), h.AFA_APPROVAL_DATE, 113),'') AS AFA_APPROVAL_DATE
        ,ISNULL(CONVERT(varchar(12), h.FINANCE_DATE, 113),'')      AS FINANCE_DATE

        /* one line, the way the printed form shows it */
        ,CASE
            WHEN h.AFA_PER_FROM IS NULL AND h.AFA_PER_TO IS NULL THEN ''
            WHEN h.AFA_PER_TO IS NULL THEN CONVERT(varchar(12), h.AFA_PER_FROM, 113)
            WHEN h.AFA_PER_FROM IS NULL THEN CONVERT(varchar(12), h.AFA_PER_TO, 113)
            ELSE CONVERT(varchar(12), h.AFA_PER_FROM, 113) + ' s/d ' +
                 CONVERT(varchar(12), h.AFA_PER_TO, 113)
         END                                               AS SCHEDULE

        ,ISNULL(h.CURCODE,'')                              AS CURCODE
        ,ISNULL(h.AMT,0)                                   AS AMT
        ,ISNULL(h.AMT_JPY,0)                               AS AMT_JPY

        /* the legacy document prints this at the very top */
        ,'SRI AFA : ' + CASE WHEN ISNULL(h.SRI_STS,'') = 'Need'
                             THEN 'NEED' ELSE 'NO NEED' END AS SRI_LABEL
        ,ISNULL(h.SRI_STS,'')                              AS SRI_STS
        ,ISNULL(h.REF_REG,'')                              AS REF_REG

        ,ISNULL(h.BUDGET_STS,'')                           AS BUDGET_STS
        ,ISNULL(bc.Name, ISNULL(h.BUDGET_CHECK_BY,''))     AS BUDGET_CHECK_BY
        ,CASE WHEN h.BUDGET_CHECK_DATE IS NULL THEN ''
              ELSE CONVERT(varchar(12), h.BUDGET_CHECK_DATE, 113) + ' ' +
                   SUBSTRING(CONVERT(varchar(20), h.BUDGET_CHECK_DATE, 100), 13, 8)
         END                                               AS BUDGET_CHECK_DATE

        ,h.STS
        ,ISNULL(cu.Name, ISNULL(h.USERID,''))              AS CREATED_BY
        ,CONVERT(varchar(12), h.DATECREATE, 113)           AS CREATED_DATE
    FROM   dbo.AFA_NON_IFS h
    LEFT   JOIN dbo.AFA_TYPE       t  ON t.CODE    = h.AFA_TYPE
    LEFT   JOIN dbo.AFA_LOCATION   l  ON l.CODE    = h.AFA_LOCATION
    LEFT   JOIN dbo.AFA_DEPARTMENT d  ON d.DEPT_ID = h.DEPT_ID
    LEFT   JOIN dbo.User_H         cu ON cu.UserID = h.USERID
    LEFT   JOIN dbo.User_H         bc ON bc.UserID = h.BUDGET_CHECK_BY
    OUTER  APPLY (
        SELECT TOP 1 s.NAME AS SUB_TYPE_NAME
        FROM (
            SELECT AFA_NO, SUB_TYPE, AFA_TYPE FROM dbo.AFA_NON_IFS_INF
            UNION ALL
            SELECT AFA_NO, SUB_TYPE, AFA_TYPE FROM dbo.AFA_NON_IFS_DAA
        ) x
        LEFT JOIN dbo.AFA_SUB_TYPE s
               ON s.AFA_TYPE = x.AFA_TYPE AND s.CODE = x.SUB_TYPE
        WHERE x.AFA_NO = h.AFA_NO
    ) sub
    WHERE  h.AFA_NO = @AfaNo;


    /* ========================================================================
       2. SIGNATURE
       One row per slot, Authorized / Supporting / Direct side by side, the
       way the printed form lays them out. Slots where all three are empty
       are dropped, so the document does not print blank rows.

       The position and the name are already joined into one string, and
       the approval line is already worded, because that wording differs
       for Skip - it carries the reason with it.
       ======================================================================== */
    ;WITH nums AS (
        SELECT TOP (10) ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS Urut
        FROM   sys.all_objects
    )
    SELECT
         n.Urut
        ,CASE WHEN ISNULL(a.NIK,'') = '' THEN ''
              ELSE ISNULL(a.JAB,'') + ': ' + RTRIM(ISNULL(a.NAMA,'')) END AS Auth
        ,CASE WHEN a.STS = 'App'  THEN 'Approved ' + ISNULL(CONVERT(varchar(12), a.DATEAPP, 113),'') + ' ' +
                                       SUBSTRING(CONVERT(varchar(20), a.DATEAPP, 100), 13, 8)
              WHEN a.STS = 'Skip' THEN 'Skip: ' + ISNULL(a.Reason,'')
              ELSE '' END                                                AS Auth_App

        ,CASE WHEN ISNULL(s.NIK,'') = '' THEN ''
              ELSE ISNULL(s.JAB,'') + ': ' + RTRIM(ISNULL(s.NAMA,'')) END AS Supp
        ,CASE WHEN s.STS = 'App'  THEN 'Approved ' + ISNULL(CONVERT(varchar(12), s.DATEAPP, 113),'') + ' ' +
                                       SUBSTRING(CONVERT(varchar(20), s.DATEAPP, 100), 13, 8)
              WHEN s.STS = 'Skip' THEN 'Skip: ' + ISNULL(s.Reason,'')
              ELSE '' END                                                AS Supp_App

        ,CASE WHEN ISNULL(dr.NIK,'') = '' THEN ''
              ELSE ISNULL(dr.JAB,'') + ': ' + RTRIM(ISNULL(dr.NAMA,'')) END AS Dir
        ,CASE WHEN dr.STS = 'App'  THEN 'Approved ' + ISNULL(CONVERT(varchar(12), dr.DATEAPP, 113),'') + ' ' +
                                        SUBSTRING(CONVERT(varchar(20), dr.DATEAPP, 100), 13, 8)
              WHEN dr.STS = 'Skip' THEN 'Skip: ' + ISNULL(dr.Reason,'')
              ELSE '' END                                                AS Dir_App
    FROM   nums n
    LEFT   JOIN dbo.AFA_SIGNATURE a  ON a.AFA_NO  = @AfaNo AND a.TYPE  = 'Auth' AND a.ID  = n.Urut
    LEFT   JOIN dbo.AFA_SIGNATURE s  ON s.AFA_NO  = @AfaNo AND s.TYPE  = 'Supp' AND s.ID  = n.Urut
    LEFT   JOIN dbo.AFA_SIGNATURE dr ON dr.AFA_NO = @AfaNo AND dr.TYPE = 'Dir'  AND dr.ID = n.Urut
    WHERE  ISNULL(a.NIK,'') <> '' OR ISNULL(s.NIK,'') <> '' OR ISNULL(dr.NIK,'') <> ''
    ORDER  BY n.Urut;


    /* ========================================================================
       3. DETAIL
       Uniform shape for every AFA type:

         GRP        groups the lines of one asset or one budget item
         GRP_LABEL  the heading printed above that group
         SEQ        line order inside the group
         LABEL      what is printed on the left
         AMOUNT     the figure printed on the right, NULL when there is none
         IS_BOLD    totals and results, so the report does not have to
                    guess which lines matter

       A report that consumes this needs one detail band and one group
       header - no conditional layout per AFA type.
       ======================================================================== */
    DECLARE @type varchar(10);
    SELECT @type = AFA_TYPE FROM dbo.AFA_NON_IFS WHERE AFA_NO = @AfaNo;

    IF @type = 'INF'
    BEGIN
        SELECT
             1                                     AS GRP
            ,''                                    AS GRP_LABEL
            ,1                                     AS SEQ
            ,'Estimate Cost'                       AS LABEL
            ,i.ESTIMATE_COST                       AS AMOUNT
            ,CAST(1 AS bit)                        AS IS_BOLD
        FROM dbo.AFA_NON_IFS_INF i
        WHERE i.AFA_NO = @AfaNo;
    END

    ELSE IF @type = 'DAA'
    BEGIN
        /* A Disposal document holds exactly one row (no per-asset detail
           columns - the asset is described in Background & Explanation
           and the cover attachment instead), so the group label comes
           from the sub-type name rather than an asset number/description
           that no longer exists. */
        SELECT GRP, GRP_LABEL, SEQ, LABEL, AMOUNT, IS_BOLD
        FROM (
            SELECT 1 AS GRP, 'Disposal - ' + ISNULL(s.NAME,'') AS GRP_LABEL,
                   1 AS SEQ, 'Acquisition' AS LABEL, d.ACQUISITION AS AMOUNT, CAST(0 AS bit) AS IS_BOLD
            FROM dbo.AFA_NON_IFS_DAA d
            LEFT JOIN dbo.AFA_SUB_TYPE s ON s.AFA_TYPE = 'DAA' AND s.CODE = d.SUB_TYPE
            WHERE d.AFA_NO = @AfaNo
            UNION ALL
            SELECT 1, 'Disposal - ' + ISNULL(s.NAME,''),
                   2, 'Accumulation Depreciation', d.ACCUM_DEPRECIATION, CAST(0 AS bit)
            FROM dbo.AFA_NON_IFS_DAA d
            LEFT JOIN dbo.AFA_SUB_TYPE s ON s.AFA_TYPE = 'DAA' AND s.CODE = d.SUB_TYPE
            WHERE d.AFA_NO = @AfaNo
            UNION ALL
            SELECT 1, 'Disposal - ' + ISNULL(s.NAME,''),
                   3, 'Book Value', d.BOOK_VALUE, CAST(1 AS bit)
            FROM dbo.AFA_NON_IFS_DAA d
            LEFT JOIN dbo.AFA_SUB_TYPE s ON s.AFA_TYPE = 'DAA' AND s.CODE = d.SUB_TYPE
            WHERE d.AFA_NO = @AfaNo
            UNION ALL
            SELECT 1, 'Disposal - ' + ISNULL(s.NAME,''),
                   4, 'Resell Value Estimation', d.RESELL_VALUE, CAST(0 AS bit)
            FROM dbo.AFA_NON_IFS_DAA d
            LEFT JOIN dbo.AFA_SUB_TYPE s ON s.AFA_TYPE = 'DAA' AND s.CODE = d.SUB_TYPE
            WHERE d.AFA_NO = @AfaNo
            UNION ALL
            SELECT 1, 'Disposal - ' + ISNULL(s.NAME,''),
                   5, 'Profit / Loss', d.PROFIT_LOSS, CAST(1 AS bit)
            FROM dbo.AFA_NON_IFS_DAA d
            LEFT JOIN dbo.AFA_SUB_TYPE s ON s.AFA_TYPE = 'DAA' AND s.CODE = d.SUB_TYPE
            WHERE d.AFA_NO = @AfaNo
        ) x
        ORDER BY SEQ;
    END

    ELSE IF @type = 'BRE'
    BEGIN
        /* Source items print their shortage, target items print what they
           receive and what is left. Source rows come first so the document
           reads in the order the money moves. */
        SELECT GRP, GRP_LABEL, SEQ, LABEL, AMOUNT, IS_BOLD
        FROM (
            SELECT b.SEQ AS GRP,
                   CASE WHEN b.ITEM_ROLE = 'Source' THEN 'Budget Item (From): '
                        ELSE 'Budget Item (To): ' END +
                   b.BUDGET_ITEM_CODE + ' - ' + ISNULL(b.BUDGET_ITEM_NAME,'') AS GRP_LABEL,
                   1 AS SEQ, 'Budget Amount' AS LABEL, b.BUDGET_AMOUNT AS AMOUNT,
                   CAST(0 AS bit) AS IS_BOLD, b.ITEM_ROLE
            FROM dbo.AFA_NON_IFS_BRE b WHERE b.AFA_NO = @AfaNo
            UNION ALL
            SELECT b.SEQ,
                   CASE WHEN b.ITEM_ROLE = 'Source' THEN 'Budget Item (From): '
                        ELSE 'Budget Item (To): ' END +
                   b.BUDGET_ITEM_CODE + ' - ' + ISNULL(b.BUDGET_ITEM_NAME,''),
                   2,
                   CASE WHEN b.ITEM_ROLE = 'Source' THEN 'Actual Up From This Application'
                        ELSE 'Actual Up To This Application' END,
                   b.ACTUAL_UP, CAST(0 AS bit), b.ITEM_ROLE
            FROM dbo.AFA_NON_IFS_BRE b WHERE b.AFA_NO = @AfaNo
            UNION ALL
            SELECT b.SEQ,
                   'Budget Item (From): ' + b.BUDGET_ITEM_CODE + ' - ' + ISNULL(b.BUDGET_ITEM_NAME,''),
                   3, 'Estimation', b.ESTIMATION, CAST(0 AS bit), b.ITEM_ROLE
            FROM dbo.AFA_NON_IFS_BRE b WHERE b.AFA_NO = @AfaNo AND b.ITEM_ROLE = 'Source'
            UNION ALL
            SELECT b.SEQ,
                   'Budget Item (From): ' + b.BUDGET_ITEM_CODE + ' - ' + ISNULL(b.BUDGET_ITEM_NAME,''),
                   4, 'Shortage', b.SHORTAGE, CAST(1 AS bit), b.ITEM_ROLE
            FROM dbo.AFA_NON_IFS_BRE b WHERE b.AFA_NO = @AfaNo AND b.ITEM_ROLE = 'Source'
            UNION ALL
            SELECT b.SEQ,
                   'Budget Item (To): ' + b.BUDGET_ITEM_CODE + ' - ' + ISNULL(b.BUDGET_ITEM_NAME,''),
                   3, 'Reclass Amount', b.RECLASS_AMOUNT, CAST(0 AS bit), b.ITEM_ROLE
            FROM dbo.AFA_NON_IFS_BRE b WHERE b.AFA_NO = @AfaNo AND b.ITEM_ROLE = 'Target'
            UNION ALL
            SELECT b.SEQ,
                   'Budget Item (To): ' + b.BUDGET_ITEM_CODE + ' - ' + ISNULL(b.BUDGET_ITEM_NAME,''),
                   4, 'Balance', b.BALANCE, CAST(1 AS bit), b.ITEM_ROLE
            FROM dbo.AFA_NON_IFS_BRE b WHERE b.AFA_NO = @AfaNo AND b.ITEM_ROLE = 'Target'
        ) x
        ORDER BY CASE WHEN ITEM_ROLE = 'Source' THEN 0 ELSE 1 END, GRP, SEQ;
    END

    ELSE IF @type = 'ADD'
    BEGIN
        SELECT GRP, GRP_LABEL, SEQ, LABEL, AMOUNT, IS_BOLD
        FROM (
            SELECT a.SEQ AS GRP,
                   'Budget Item: ' + a.BUDGET_ITEM_CODE + ' - ' + ISNULL(a.BUDGET_ITEM_NAME,'') AS GRP_LABEL,
                   1 AS SEQ, 'Budget Amount' AS LABEL, a.BUDGET_AMOUNT AS AMOUNT,
                   CAST(0 AS bit) AS IS_BOLD
            FROM dbo.AFA_NON_IFS_ADD a WHERE a.AFA_NO = @AfaNo
            UNION ALL
            SELECT a.SEQ,
                   'Budget Item: ' + a.BUDGET_ITEM_CODE + ' - ' + ISNULL(a.BUDGET_ITEM_NAME,''),
                   2, 'Actual Up To This Application', a.ACTUAL_UP, CAST(0 AS bit)
            FROM dbo.AFA_NON_IFS_ADD a WHERE a.AFA_NO = @AfaNo
            UNION ALL
            SELECT a.SEQ,
                   'Budget Item: ' + a.BUDGET_ITEM_CODE + ' - ' + ISNULL(a.BUDGET_ITEM_NAME,''),
                   3, 'Estimation', a.ESTIMATION, CAST(0 AS bit)
            FROM dbo.AFA_NON_IFS_ADD a WHERE a.AFA_NO = @AfaNo
            UNION ALL
            SELECT a.SEQ,
                   'Budget Item: ' + a.BUDGET_ITEM_CODE + ' - ' + ISNULL(a.BUDGET_ITEM_NAME,''),
                   4, 'Shortage', a.SHORTAGE, CAST(1 AS bit)
            FROM dbo.AFA_NON_IFS_ADD a WHERE a.AFA_NO = @AfaNo
        ) x
        ORDER BY GRP, SEQ;
    END

    ELSE
    BEGIN
        /* Unknown type: return the empty shape rather than nothing, so the
           report still binds and prints the header and signatures. */
        SELECT CAST(NULL AS int)           AS GRP,
               CAST(NULL AS varchar(600))  AS GRP_LABEL,
               CAST(NULL AS int)           AS SEQ,
               CAST(NULL AS varchar(100))  AS LABEL,
               CAST(NULL AS numeric(18,3)) AS AMOUNT,
               CAST(NULL AS bit)           AS IS_BOLD
        WHERE  1 = 0;
    END


    /* ========================================================================
       4. ATTACHMENTS
       Listed so the viewer can offer them; the printed document itself
       does not include them.
       ======================================================================== */
    SELECT SEQ, TYPE, FILE_PATH, ISNULL(CAPTION,'') AS CAPTION
    FROM   dbo.AFA_NON_IFS_ATTACHMENT
    WHERE  AFA_NO = @AfaNo
    ORDER  BY TYPE DESC, SEQ;
END;
GO
