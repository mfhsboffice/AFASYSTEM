/* ============================================================================
   FILE 01 - HEADER, DETAIL & WORKFLOW PROCEDURES
   AFA_NonIFS_* covering: number/approval-number generation, header save,
   per-type detail save, recalculation, attachments, SRI, submit, approve/
   skip/un-approve, budget check/uncheck, cancel, IFS lookup, sub-type and
   employee lookups, monitoring list.
   ============================================================================ */

SECTION 5 - CORE PROCEDURES
   ============================================================================ */

/* ---- drop previous versions ---- */
IF OBJECT_ID('dbo.AFA_NonIFS_GenerateNumber_Proc','P')   IS NOT NULL DROP PROC dbo.AFA_NonIFS_GenerateNumber_Proc;
IF OBJECT_ID('dbo.AFA_NonIFS_SaveHeader_Proc','P')       IS NOT NULL DROP PROC dbo.AFA_NonIFS_SaveHeader_Proc;
IF OBJECT_ID('dbo.AFA_NonIFS_Signature_Proc','P')        IS NOT NULL DROP PROC dbo.AFA_NonIFS_Signature_Proc;
IF OBJECT_ID('dbo.AFA_NonIFS_GetBudgetFromIFS_Proc','P') IS NOT NULL DROP PROC dbo.AFA_NonIFS_GetBudgetFromIFS_Proc;
IF OBJECT_ID('dbo.AFA_NonIFS_SaveDetail_INF_Proc','P')   IS NOT NULL DROP PROC dbo.AFA_NonIFS_SaveDetail_INF_Proc;
IF OBJECT_ID('dbo.AFA_NonIFS_SaveDetail_DAA_Proc','P')   IS NOT NULL DROP PROC dbo.AFA_NonIFS_SaveDetail_DAA_Proc;
IF OBJECT_ID('dbo.AFA_NonIFS_SaveDetail_BRE_Proc','P')   IS NOT NULL DROP PROC dbo.AFA_NonIFS_SaveDetail_BRE_Proc;
IF OBJECT_ID('dbo.AFA_NonIFS_SaveDetail_ADD_Proc','P')   IS NOT NULL DROP PROC dbo.AFA_NonIFS_SaveDetail_ADD_Proc;
IF OBJECT_ID('dbo.AFA_NonIFS_DeleteDetail_Proc','P')     IS NOT NULL DROP PROC dbo.AFA_NonIFS_DeleteDetail_Proc;
IF OBJECT_ID('dbo.AFA_NonIFS_SaveAttachment_Proc','P')   IS NOT NULL DROP PROC dbo.AFA_NonIFS_SaveAttachment_Proc;
IF OBJECT_ID('dbo.AFA_NonIFS_DeleteAttachment_Proc','P') IS NOT NULL DROP PROC dbo.AFA_NonIFS_DeleteAttachment_Proc;
IF OBJECT_ID('dbo.AFA_NonIFS_Recalc_Proc','P')           IS NOT NULL DROP PROC dbo.AFA_NonIFS_Recalc_Proc;
IF OBJECT_ID('dbo.AFA_NonIFS_EvaluateSRI_Proc','P')      IS NOT NULL DROP PROC dbo.AFA_NonIFS_EvaluateSRI_Proc;
IF OBJECT_ID('dbo.AFA_NonIFS_Submit_Proc','P')           IS NOT NULL DROP PROC dbo.AFA_NonIFS_Submit_Proc;
IF OBJECT_ID('dbo.AFA_NonIFS_App_Proc','P')              IS NOT NULL DROP PROC dbo.AFA_NonIFS_App_Proc;
IF OBJECT_ID('dbo.AFA_NonIFS_Skip_Proc','P')             IS NOT NULL DROP PROC dbo.AFA_NonIFS_Skip_Proc;
IF OBJECT_ID('dbo.AFA_NonIFS_BudgetCheck_Proc','P')      IS NOT NULL DROP PROC dbo.AFA_NonIFS_BudgetCheck_Proc;
IF OBJECT_ID('dbo.AFA_NonIFS_Cancel_Proc','P')           IS NOT NULL DROP PROC dbo.AFA_NonIFS_Cancel_Proc;
GO


/* ============================================================
   1. GENERATE NUMBER
   Called from SaveHeader rather than by the application directly.
   The result comes back as a result set so a preview can be read
   with ExecuteStoredProcedureQueryWithStatus when needed.
   ============================================================ */
CREATE PROC dbo.AFA_NonIFS_GenerateNumber_Proc
    @DeptId     int,
    @AfaType    varchar(10),
    @BudgetYear int,
    @RefDate    date,
    @Commit     bit,
    @Status     varchar(10)  OUTPUT,
    @Message    varchar(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET @Status = 'FAILED'; SET @Message = '';

    DECLARE @Prefix varchar(10), @Year int, @Month int, @MonthText varchar(2),
            @YY varchar(2), @BYY varchar(2), @SeqText varchar(10),
            @Seq int, @OwnTran bit = 0, @AfaNo varchar(50);

    BEGIN TRY
        SET @RefDate = ISNULL(@RefDate, CAST(GETDATE() AS date));
        SET @Year  = YEAR(@RefDate);
        SET @Month = MONTH(@RefDate);

        SELECT @Prefix = PREFIX FROM dbo.AFA_DEPARTMENT
        WHERE DEPT_ID = @DeptId AND IS_ACTIVE = 1;

        IF @Prefix IS NULL
        BEGIN SET @Message = 'Department not found or inactive.'; RETURN; END

        IF NOT EXISTS (SELECT 1 FROM dbo.AFA_TYPE WHERE CODE = @AfaType AND IS_ACTIVE = 1)
        BEGIN SET @Message = 'AFA type not found or inactive.'; RETURN; END

        -- Zero-padded numeric month (01-12), not the Roman-numeral alias
        -- from AFA_Bulan_Alias. That table is read-only/shared with the
        -- legacy Expense/Investment module and stays untouched; this
        -- module simply stops depending on it for month formatting.
        SET @MonthText = RIGHT('0' + CAST(@Month AS varchar(2)), 2);

        IF @Commit = 0
        BEGIN
            SELECT @Seq = LAST_SEQ + 1 FROM dbo.AFA_NON_IFS_SEQ
            WHERE AFA_TYPE = @AfaType AND PERIOD_YEAR = @Year;
            SET @Seq = ISNULL(@Seq, 1);
        END
        ELSE
        BEGIN
            IF @@TRANCOUNT = 0 BEGIN BEGIN TRANSACTION; SET @OwnTran = 1; END

            UPDATE s WITH (UPDLOCK, HOLDLOCK)
            SET @Seq = s.LAST_SEQ + 1, s.LAST_SEQ = s.LAST_SEQ + 1, s.DATEUPDATE = GETDATE()
            FROM dbo.AFA_NON_IFS_SEQ s
            WHERE s.AFA_TYPE = @AfaType AND s.PERIOD_YEAR = @Year;

            IF @Seq IS NULL
            BEGIN
                INSERT INTO dbo.AFA_NON_IFS_SEQ (AFA_TYPE, PERIOD_YEAR, LAST_SEQ, DATEUPDATE)
                VALUES (@AfaType, @Year, 1, GETDATE());
                SET @Seq = 1;
            END

            IF @OwnTran = 1 COMMIT TRANSACTION;
        END

        SET @YY      = RIGHT(CAST(@Year AS varchar(4)), 2);
        SET @BYY     = RIGHT(CAST(@BudgetYear AS varchar(4)), 2);
        SET @SeqText = RIGHT('000' + CAST(@Seq AS varchar(10)), 3);

        SET @AfaNo = @Prefix + '/' + @AfaType + '/' + @SeqText + '/' + @MonthText + '/' + @YY  + '/' + @BYY;

        SELECT @AfaNo AS AFA_NO, @Seq AS SEQ;

        SET @Status  = 'SUCCESS';
        SET @Message = 'AFA number generated.';
    END TRY
    BEGIN CATCH
        IF @OwnTran = 1 AND XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        SET @Status  = 'FAILED';
        SET @Message = LEFT(ERROR_MESSAGE(), 255);
    END CATCH
END;
GO


/* ============================================================
   2b. GENERATE APPROVAL NUMBER
   Called only from App_Proc, at the instant a document becomes fully
   approved - never at creation. AFA_NO_APPROVAL is a genuine sequence:
   once issued, a value is never reused, even if the approval is later
   undone. Month/year reflect the approval date, not the document's
   creation date.
   ============================================================ */

IF OBJECT_ID('dbo.AFA_NonIFS_GenerateApprovalNumber_Proc','P') IS NOT NULL
    DROP PROC dbo.AFA_NonIFS_GenerateApprovalNumber_Proc;
GO

CREATE PROC dbo.AFA_NonIFS_GenerateApprovalNumber_Proc
    @AfaType        varchar(10),
    @BudgetYear     varchar(10),
    @RefDate        date,
    @Status         varchar(10)  OUTPUT,
    @Message        varchar(255) OUTPUT,
    @AfaNoApproval  varchar(50)  OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET @Status = 'FAILED'; SET @Message = ''; SET @AfaNoApproval = NULL;

    DECLARE @Year int, @Month int, @MonthText varchar(2),
            @YY varchar(2), @BYY varchar(2), @SeqText varchar(10),
            @Seq int, @OwnTran bit = 0;

    BEGIN TRY
        SET @RefDate = ISNULL(@RefDate, CAST(GETDATE() AS date));
        SET @Year  = YEAR(@RefDate);
        SET @Month = MONTH(@RefDate);

        -- Zero-padded numeric month (01-12), matching
        -- AFA_NonIFS_GenerateNumber_Proc - see the comment there for why
        -- AFA_Bulan_Alias (read-only/shared with the legacy module) is no
        -- longer used here.
        SET @MonthText = RIGHT('0' + CAST(@Month AS varchar(2)), 2);

        IF @@TRANCOUNT = 0 BEGIN BEGIN TRANSACTION; SET @OwnTran = 1; END

        UPDATE s WITH (UPDLOCK, HOLDLOCK)
        SET @Seq = s.LAST_SEQ + 1, s.LAST_SEQ = s.LAST_SEQ + 1, s.DATEUPDATE = GETDATE()
        FROM dbo.AFA_NON_IFS_APPROVAL_SEQ s
        WHERE s.AFA_TYPE = @AfaType AND s.PERIOD_YEAR = @Year;

        IF @Seq IS NULL
        BEGIN
            INSERT INTO dbo.AFA_NON_IFS_APPROVAL_SEQ (AFA_TYPE, PERIOD_YEAR, LAST_SEQ, DATEUPDATE)
            VALUES (@AfaType, @Year, 1, GETDATE());
            SET @Seq = 1;
        END

        IF @OwnTran = 1 COMMIT TRANSACTION;

        SET @YY      = RIGHT(CAST(@Year AS varchar(4)), 2);
        SET @BYY     = RIGHT(CAST(ISNULL(@BudgetYear, @Year) AS varchar(4)), 2);
        SET @SeqText = RIGHT('000' + CAST(@Seq AS varchar(10)), 3);

        SET @AfaNoApproval = 'SRI/' + @AfaType + '/' + @SeqText + '/' + @MonthText + '/' + @BYY + '/' + @YY;

        SET @Status  = 'SUCCESS';
        SET @Message = 'Approval number generated.';
    END TRY
    BEGIN CATCH
        IF @OwnTran = 1 AND XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        SET @Status  = 'FAILED';
        SET @Message = LEFT(ERROR_MESSAGE(), 255);
    END CATCH
END;
GO


CREATE PROC dbo.AFA_NonIFS_SaveHeader_Proc
    @AfaNo          varchar(50),
    @AfaType        varchar(10),
    @AfaLocation    varchar(10),
    @DeptId         int,
    @BudgetYear     varchar(10),
    @BudgetRev      varchar(10),
    @Subject        varchar(500),
    @Purposes       varchar(max),
    @BgExplanation  varchar(max),
    @Notetext       varchar(max),
    @Curcode        varchar(10),
    @Priority       tinyint,
    @PriorityReason varchar(500),
    @PerFrom        date,
    @PerTo          date,
    @Nik            varchar(50),
    @Pc             varchar(50),
    @Status         varchar(10)  OUTPUT,
    @Message        varchar(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET @Status = 'FAILED'; SET @Message = '';

    DECLARE @tglnow datetime = GETDATE(), @isNew bit = 0,
            @rateCur numeric(18,9), @rateJpy numeric(18,9), @rate numeric(18,9),
            @st varchar(10), @msg varchar(255);

    DECLARE @gen TABLE (AFA_NO varchar(50), SEQ int);

    BEGIN TRY
        IF ISNULL(@AfaLocation,'') = ''
        BEGIN SET @Message = 'Location is required.'; RETURN; END

        IF ISNULL(@BudgetYear,'') = ''
        BEGIN SET @Message = 'Budget Year is required.'; RETURN; END

        IF @PerFrom IS NOT NULL AND @PerTo IS NOT NULL AND @PerTo < @PerFrom
        BEGIN SET @Message = 'Schedule To cannot be earlier than Schedule From.'; RETURN; END

        IF @Curcode = 'JPY'
            SET @rate = 1;
        ELSE
        BEGIN
            SELECT TOP 1 @rateCur = CUR_RATE FROM dbo.BUDGET_CURR_RATE
            WHERE B_YEAR = @BudgetYear AND CURCODE = @Curcode
              AND (ISNULL(@BudgetRev,'') = '' OR B_REV = @BudgetRev)
            ORDER BY TRY_CAST(B_REV AS int) DESC;

            SELECT TOP 1 @rateJpy = CUR_RATE FROM dbo.BUDGET_CURR_RATE
            WHERE B_YEAR = @BudgetYear AND CURCODE = 'JPY'
              AND (ISNULL(@BudgetRev,'') = '' OR B_REV = @BudgetRev)
            ORDER BY TRY_CAST(B_REV AS int) DESC;

            SET @rate = CASE WHEN ISNULL(@rateJpy,0) = 0 THEN NULL
                             ELSE @rateCur / @rateJpy END;
        END

        BEGIN TRANSACTION;

        IF ISNULL(@AfaNo,'') = ''
        BEGIN
            SET @isNew = 1;

            INSERT INTO @gen
            EXEC dbo.AFA_NonIFS_GenerateNumber_Proc
                 @DeptId = @DeptId, @AfaType = @AfaType, @BudgetYear = @BudgetYear,
                 @RefDate = NULL, @Commit = 1,
                 @Status = @st OUTPUT, @Message = @msg OUTPUT;

            IF @st <> 'SUCCESS'
            BEGIN ROLLBACK TRANSACTION; SET @Message = @msg; RETURN; END

            SELECT TOP 1 @AfaNo = AFA_NO FROM @gen;

            -- AFA_NO_APPROVAL starts NULL: it is only ever issued by
            -- AFA_NonIFS_App_Proc, at the moment of final approval
            INSERT INTO dbo.AFA_NON_IFS
                (AFA_NO, AFA_NO_APPROVAL, AFA_TYPE, AFA_LOCATION, DEPT_ID,
                 BUDGET_YEAR, BUDGET_REV, SUBJECT, PURPOSES, BG_EXPLANATION, NOTETEXT,
                 CURCODE, CUR_RATE, RATE_DATE, PRIORITY, PRIORITY_REASON,
                 AFA_DATE, AFA_PER_FROM, AFA_PER_TO, STS, USERID, PC, DATECREATE)
            VALUES
                (@AfaNo, NULL, @AfaType, @AfaLocation, @DeptId,
                 @BudgetYear, @BudgetRev, @Subject, @Purposes, @BgExplanation, @Notetext,
                 @Curcode, @rate, CAST(@tglnow AS date), @Priority, @PriorityReason,
                 CAST(@tglnow AS date), @PerFrom, @PerTo, 'Draft', @Nik, @Pc, @tglnow);
        END
        ELSE
        BEGIN
            IF NOT EXISTS (SELECT 1 FROM dbo.AFA_NON_IFS WHERE AFA_NO = @AfaNo)
            BEGIN ROLLBACK TRANSACTION; SET @Message = 'AFA not found.'; RETURN; END

            IF EXISTS (SELECT 1 FROM dbo.AFA_NON_IFS
                       WHERE AFA_NO = @AfaNo AND STS IN ('Approved','Cancelled'))
            BEGIN ROLLBACK TRANSACTION; SET @Message = 'AFA is closed and can no longer be edited.'; RETURN; END

            UPDATE dbo.AFA_NON_IFS
            SET AFA_LOCATION = @AfaLocation, BUDGET_YEAR = @BudgetYear, BUDGET_REV = @BudgetRev,
                SUBJECT = @Subject, PURPOSES = @Purposes, BG_EXPLANATION = @BgExplanation,
                NOTETEXT = @Notetext, CURCODE = @Curcode, CUR_RATE = @rate,
                PRIORITY = @Priority, PRIORITY_REASON = @PriorityReason,
                AFA_PER_FROM = @PerFrom, AFA_PER_TO = @PerTo,
                USERUPDATE = @Nik, DATEUPDATE = @tglnow
            WHERE AFA_NO = @AfaNo;

            UPDATE dbo.AFA_NON_IFS SET BUDGET_STS = 'Unchecked'
            WHERE AFA_NO = @AfaNo AND BUDGET_STS = 'Checked';
        END

        INSERT INTO dbo.AFA_Log (ID, Type, NIK, PC, DateCreate, AFA)
        VALUES (@tglnow, CASE WHEN @isNew = 1 THEN 'Create' ELSE 'Update' END,
                @Nik, @Pc, @tglnow, @AfaNo);

        COMMIT TRANSACTION;

        SELECT @AfaNo AS AFA_NO;

        SET @Status  = 'SUCCESS';
        SET @Message = CASE WHEN @rate IS NULL
                            THEN 'Saved. Note: no exchange rate from ' + @Curcode + ' to JPY was found.'
                            ELSE 'Saved. AFA No: ' + @AfaNo END;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        SET @Status  = 'FAILED';
        SET @Message = LEFT(ERROR_MESSAGE(), 255);
    END CATCH
END;
GO


CREATE PROC dbo.AFA_NonIFS_Signature_Proc
    @AfaNo     varchar(50),
    @Jenis     varchar(50),
    @Id        numeric(18,0),
    @Nik       varchar(10),
    @Jab       varchar(50),
    @NikCreate varchar(50),
    @Pc        varchar(50),
    @Status    varchar(10)  OUTPUT,
    @Message   varchar(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET @Status = 'FAILED'; SET @Message = '';

    DECLARE @tglnow datetime = GETDATE(), @nama varchar(250);

    BEGIN TRY
        IF NOT EXISTS (SELECT 1 FROM dbo.AFA_NON_IFS WHERE AFA_NO = @AfaNo)
        BEGIN SET @Message = 'AFA not found.'; RETURN; END

        IF NOT EXISTS (SELECT 1 FROM dbo.AFA_Jenis_Urut WHERE Jenis = @Jenis)
        BEGIN SET @Message = 'Signature type is not valid.'; RETURN; END

        IF EXISTS (SELECT 1 FROM dbo.AFA_SIGNATURE
                   WHERE AFA_NO = @AfaNo AND TYPE = @Jenis AND ID = @Id AND STS = 'App')
        BEGIN SET @Message = 'This node is already approved and cannot be changed.'; RETURN; END

        SET @Nik = LTRIM(RTRIM(ISNULL(@Nik,'')));

        -- NIK in AFA_Employee_GTAS is stored with a trailing space
        SELECT TOP 1 @nama = RTRIM(Nama) FROM dbo.AFA_Employee_GTAS WHERE RTRIM(NIK) = @Nik;
        IF @nama IS NULL SELECT TOP 1 @nama = RTRIM(Name) FROM dbo.User_H WHERE UserID = @Nik;

        BEGIN TRANSACTION;

        DELETE FROM dbo.AFA_SIGNATURE
        WHERE AFA_NO = @AfaNo AND TYPE = @Jenis AND ID = @Id AND ISNULL(STS,'') <> 'App';

        INSERT INTO dbo.AFA_SIGNATURE
            (AFA_NO, TYPE, ID, NIK, NAMA, JAB, STS, DateCreate, PCCreate, UserCreate)
        VALUES
            (@AfaNo, @Jenis, @Id, @Nik, ISNULL(@nama,''), @Jab,
             CASE WHEN @Nik = '' THEN '' ELSE 'Send' END,
             @tglnow, @Pc, @NikCreate);

        COMMIT TRANSACTION;

        SET @Status  = 'SUCCESS';
        SET @Message = 'Signature saved.';
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        SET @Status  = 'FAILED';
        SET @Message = LEFT(ERROR_MESSAGE(), 255);
    END CATCH
END;
GO


/* ============================================================
   4. RECALC - roll the detail rows up into the header
   ============================================================ */
CREATE PROC dbo.AFA_NonIFS_Recalc_Proc
    @AfaNo   varchar(50),
    @Status  varchar(10)  OUTPUT,
    @Message varchar(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET @Status = 'FAILED'; SET @Message = '';

    DECLARE @type varchar(10), @amt numeric(18,3), @rate numeric(18,9);

    BEGIN TRY
        SELECT @type = AFA_TYPE, @rate = ISNULL(CUR_RATE,1)
        FROM dbo.AFA_NON_IFS WHERE AFA_NO = @AfaNo;

        IF @type IS NULL BEGIN SET @Message = 'AFA not found.'; RETURN; END

        IF @type = 'BRE'
        BEGIN
            UPDATE s SET s.SHORTAGE = s.BUDGET_AMOUNT - s.ACTUAL_UP - ISNULL(s.ESTIMATION,0)
            FROM dbo.AFA_NON_IFS_BRE s
            WHERE s.AFA_NO = @AfaNo AND s.ITEM_ROLE = 'Source';

            UPDATE t
            SET t.RECLASS_AMOUNT = ABS(ISNULL(src.SHORTAGE,0)),
                t.BALANCE        = t.BUDGET_AMOUNT - t.ACTUAL_UP - ABS(ISNULL(src.SHORTAGE,0))
            FROM dbo.AFA_NON_IFS_BRE t
            JOIN dbo.AFA_NON_IFS_BRE src ON src.AFA_NO = t.AFA_NO AND src.SEQ = t.RECLASS_FROM_SEQ
            WHERE t.AFA_NO = @AfaNo AND t.ITEM_ROLE = 'Target';
        END

        SELECT @amt =
            CASE @type
                WHEN 'INF' THEN (SELECT ESTIMATE_COST FROM dbo.AFA_NON_IFS_INF WHERE AFA_NO = @AfaNo)
                WHEN 'DAA' THEN (SELECT SUM(PROFIT_LOSS) FROM dbo.AFA_NON_IFS_DAA WHERE AFA_NO = @AfaNo)
                WHEN 'BRE' THEN (SELECT SUM(ABS(ISNULL(SHORTAGE,0))) FROM dbo.AFA_NON_IFS_BRE
                                 WHERE AFA_NO = @AfaNo AND ITEM_ROLE = 'Source')
                WHEN 'ADD' THEN (SELECT SUM(ABS(SHORTAGE)) FROM dbo.AFA_NON_IFS_ADD WHERE AFA_NO = @AfaNo)
            END;

        UPDATE dbo.AFA_NON_IFS
        SET AMT = ISNULL(@amt,0), AMT_JPY = ISNULL(@amt,0) * @rate
        WHERE AFA_NO = @AfaNo;

        SET @Status  = 'SUCCESS';
        SET @Message = 'Totals recalculated.';
    END TRY
    BEGIN CATCH
        SET @Status  = 'FAILED';
        SET @Message = LEFT(ERROR_MESSAGE(), 255);
    END CATCH
END;
GO


/* ============================================================
   5. DETAIL INF
   ============================================================ */
CREATE PROC dbo.AFA_NonIFS_SaveDetail_INF_Proc
    @AfaNo        varchar(50),
    @SubType      varchar(10),
    @CodeBudget   varchar(50),
    @EstimateCost numeric(18,3),
    @Nik          varchar(50),
    @Pc           varchar(50),
    @Status       varchar(10)  OUTPUT,
    @Message      varchar(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET @Status = 'FAILED'; SET @Message = '';

    DECLARE @st varchar(10), @msg varchar(255);

    BEGIN TRY
        IF NOT EXISTS (SELECT 1 FROM dbo.AFA_NON_IFS WHERE AFA_NO = @AfaNo AND AFA_TYPE = 'INF')
        BEGIN SET @Message = 'AFA not found, or it is not an Information document.'; RETURN; END

        IF EXISTS (SELECT 1 FROM dbo.AFA_NON_IFS WHERE AFA_NO = @AfaNo AND STS <> 'Draft')
        BEGIN SET @Message = 'AFA is no longer in Draft status.'; RETURN; END

        IF NOT EXISTS (SELECT 1 FROM dbo.AFA_SUB_TYPE
                       WHERE AFA_TYPE = 'INF' AND CODE = @SubType AND IS_ACTIVE = 1)
        BEGIN SET @Message = 'Sub-type is not valid for Information.'; RETURN; END

        -- Code Budget is optional: C&B confirmed it is not required even
        -- for Donation / Membership in this module

        BEGIN TRANSACTION;

        IF EXISTS (SELECT 1 FROM dbo.AFA_NON_IFS_INF WHERE AFA_NO = @AfaNo)
            UPDATE dbo.AFA_NON_IFS_INF
            SET SUB_TYPE = @SubType, CODE_BUDGET = @CodeBudget,
                ESTIMATE_COST = ISNULL(@EstimateCost,0)
            WHERE AFA_NO = @AfaNo;
        ELSE
            INSERT INTO dbo.AFA_NON_IFS_INF (AFA_NO, SUB_TYPE, CODE_BUDGET, ESTIMATE_COST)
            VALUES (@AfaNo, @SubType, @CodeBudget, ISNULL(@EstimateCost,0));

        EXEC dbo.AFA_NonIFS_Recalc_Proc @AfaNo = @AfaNo,
             @Status = @st OUTPUT, @Message = @msg OUTPUT;

        COMMIT TRANSACTION;

        SET @Status  = 'SUCCESS';
        SET @Message = 'Detail saved.';
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        SET @Status  = 'FAILED';
        SET @Message = LEFT(ERROR_MESSAGE(), 255);
    END CATCH
END;
GO


/* ============================================================
   6. DETAIL DAA
   Pass @Seq = 0 for a new row.
   ============================================================ */
CREATE PROC dbo.AFA_NonIFS_SaveDetail_DAA_Proc
    @AfaNo       varchar(50),
    @SubType     varchar(10),        -- FA / INV, decides the SRI threshold
    @Acquisition numeric(18,3),
    @AccumDep    numeric(18,3),
    @ResellValue numeric(18,3),
    @Nik         varchar(50),
    @Pc          varchar(50),
    @Status      varchar(10)  OUTPUT,
    @Message     varchar(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET @Status = 'FAILED'; SET @Message = '';

    DECLARE @st varchar(10), @msg varchar(255);

    -- a Disposal document holds exactly one row; the asset itself is
    -- described in Background & Explanation and in the cover attachment
    DECLARE @Seq int = 1;

    BEGIN TRY
        IF NOT EXISTS (SELECT 1 FROM dbo.AFA_NON_IFS WHERE AFA_NO = @AfaNo AND AFA_TYPE = 'DAA')
        BEGIN SET @Message = 'AFA not found, or it is not a Disposal document.'; RETURN; END

        IF EXISTS (SELECT 1 FROM dbo.AFA_NON_IFS WHERE AFA_NO = @AfaNo AND STS <> 'Draft')
        BEGIN SET @Message = 'AFA is no longer in Draft status.'; RETURN; END

        IF NOT EXISTS (SELECT 1 FROM dbo.AFA_SUB_TYPE
                       WHERE AFA_TYPE = 'DAA' AND CODE = @SubType AND IS_ACTIVE = 1)
        BEGIN SET @Message = 'Sub-type is not valid for Disposal.'; RETURN; END

        IF ISNULL(@AccumDep,0) > ISNULL(@Acquisition,0)
        BEGIN SET @Message = 'Accumulation Depreciation cannot exceed Acquisition.'; RETURN; END

        BEGIN TRANSACTION;

        IF EXISTS (SELECT 1 FROM dbo.AFA_NON_IFS_DAA WHERE AFA_NO = @AfaNo AND SEQ = @Seq)
            UPDATE dbo.AFA_NON_IFS_DAA
            SET SUB_TYPE           = @SubType,
                ACQUISITION        = ISNULL(@Acquisition,0),
                ACCUM_DEPRECIATION = ISNULL(@AccumDep,0),
                RESELL_VALUE       = ISNULL(@ResellValue,0)
            WHERE AFA_NO = @AfaNo AND SEQ = @Seq;
        ELSE
            INSERT INTO dbo.AFA_NON_IFS_DAA
                (AFA_NO, SEQ, SUB_TYPE, ACQUISITION, ACCUM_DEPRECIATION, RESELL_VALUE)
            VALUES
                (@AfaNo, @Seq, @SubType,
                 ISNULL(@Acquisition,0), ISNULL(@AccumDep,0), ISNULL(@ResellValue,0));

        -- Book Value and Profit/Loss are persisted computed columns,
        -- already correct by the time Recalc rolls them into the header
        EXEC dbo.AFA_NonIFS_Recalc_Proc @AfaNo = @AfaNo,
             @Status = @st OUTPUT, @Message = @msg OUTPUT;

        COMMIT TRANSACTION;

        SET @Status  = 'SUCCESS';
        SET @Message = 'Detail saved.';
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        SET @Status  = 'FAILED';
        SET @Message = LEFT(ERROR_MESSAGE(), 255);
    END CATCH
END;
GO

/* ============================================================
   7. DETAIL BRE
   Pass @Seq = 0 for a new row and @ReclassFromSeq = 0 for a Source
   row. Budget figures come from the application, which looked them
   up beforehand, so OPENQUERY never runs inside the save
   transaction and cannot hold the number counter.
   ============================================================ */
CREATE PROC dbo.AFA_NonIFS_SaveDetail_BRE_Proc
    @AfaNo          varchar(50),
    @Seq            int,
    @ItemRole       varchar(10),        -- Source / Target
    @BudgetItemCode varchar(50),
    @BudgetItemName varchar(500),
    @Cc             varchar(50),
    @Contract       varchar(50),
    @BudgetAmount   numeric(18,3),
    @ActualUp       numeric(18,3),
    @Estimation     numeric(18,3),
    @ReclassFromSeq int,
    @Nik            varchar(50),
    @Pc             varchar(50),
    @Status         varchar(10)  OUTPUT,
    @Message        varchar(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET @Status = 'FAILED'; SET @Message = '';

    DECLARE @st varchar(10), @msg varchar(255);

    BEGIN TRY
        IF NOT EXISTS (SELECT 1 FROM dbo.AFA_NON_IFS WHERE AFA_NO = @AfaNo AND AFA_TYPE = 'BRE')
        BEGIN SET @Message = 'AFA not found, or it is not a Reclass Budget document.'; RETURN; END

        IF EXISTS (SELECT 1 FROM dbo.AFA_NON_IFS WHERE AFA_NO = @AfaNo AND STS <> 'Draft')
        BEGIN SET @Message = 'AFA is no longer in Draft status.'; RETURN; END

        IF @ItemRole NOT IN ('Source','Target')
        BEGIN SET @Message = 'Item role must be Source or Target.'; RETURN; END

        IF ISNULL(@BudgetItemCode,'') = ''
        BEGIN SET @Message = 'Budget Item is required.'; RETURN; END

        IF @ItemRole = 'Source' AND @Estimation IS NULL
        BEGIN SET @Message = 'Estimation is required for a source item.'; RETURN; END

        IF @ItemRole = 'Target'
        BEGIN
            IF ISNULL(@ReclassFromSeq,0) = 0
            BEGIN SET @Message = 'A target item must reference a source item.'; RETURN; END

            IF NOT EXISTS (SELECT 1 FROM dbo.AFA_NON_IFS_BRE
                           WHERE AFA_NO = @AfaNo AND SEQ = @ReclassFromSeq AND ITEM_ROLE = 'Source')
            BEGIN SET @Message = 'The referenced source item was not found.'; RETURN; END
        END
        ELSE
            SET @ReclassFromSeq = NULL;

        BEGIN TRANSACTION;

        IF ISNULL(@Seq,0) = 0
            SELECT @Seq = ISNULL(MAX(SEQ),0) + 1 FROM dbo.AFA_NON_IFS_BRE WHERE AFA_NO = @AfaNo;

        IF EXISTS (SELECT 1 FROM dbo.AFA_NON_IFS_BRE WHERE AFA_NO = @AfaNo AND SEQ = @Seq)
            UPDATE dbo.AFA_NON_IFS_BRE
            SET ITEM_ROLE = @ItemRole, BUDGET_ITEM_CODE = @BudgetItemCode,
                BUDGET_ITEM_NAME = @BudgetItemName, CC = @Cc, CONTRACT = @Contract,
                BUDGET_AMOUNT = ISNULL(@BudgetAmount,0), ACTUAL_UP = ISNULL(@ActualUp,0),
                ESTIMATION = @Estimation, RECLASS_FROM_SEQ = @ReclassFromSeq,
                IFS_SYNC_DATE = GETDATE()
            WHERE AFA_NO = @AfaNo AND SEQ = @Seq;
        ELSE
            INSERT INTO dbo.AFA_NON_IFS_BRE
                (AFA_NO, SEQ, ITEM_ROLE, BUDGET_ITEM_CODE, BUDGET_ITEM_NAME, CC, CONTRACT,
                 BUDGET_AMOUNT, ACTUAL_UP, ESTIMATION, RECLASS_FROM_SEQ, IFS_SYNC_DATE)
            VALUES
                (@AfaNo, @Seq, @ItemRole, @BudgetItemCode, @BudgetItemName, @Cc, @Contract,
                 ISNULL(@BudgetAmount,0), ISNULL(@ActualUp,0), @Estimation, @ReclassFromSeq, GETDATE());

        EXEC dbo.AFA_NonIFS_Recalc_Proc @AfaNo = @AfaNo,
             @Status = @st OUTPUT, @Message = @msg OUTPUT;

        COMMIT TRANSACTION;

        SELECT @Seq AS SEQ;

        SET @Status  = 'SUCCESS';
        SET @Message = 'Detail saved. Baris ke-' + CAST(@Seq AS varchar(10));
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        SET @Status  = 'FAILED';
        SET @Message = LEFT(ERROR_MESSAGE(), 255);
    END CATCH
END;
GO


/* ============================================================
   8. DETAIL ADD
   ============================================================ */
CREATE PROC dbo.AFA_NonIFS_SaveDetail_ADD_Proc
    @AfaNo          varchar(50),
    @Seq            int,
    @BudgetItemCode varchar(50),
    @BudgetItemName varchar(500),
    @Cc             varchar(50),
    @Contract       varchar(50),
    @BudgetAmount   numeric(18,3),
    @ActualUp       numeric(18,3),
    @Estimation     numeric(18,3),
    @Nik            varchar(50),
    @Pc             varchar(50),
    @Status         varchar(10)  OUTPUT,
    @Message        varchar(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET @Status = 'FAILED'; SET @Message = '';

    DECLARE @st varchar(10), @msg varchar(255);

    BEGIN TRY
        IF NOT EXISTS (SELECT 1 FROM dbo.AFA_NON_IFS WHERE AFA_NO = @AfaNo AND AFA_TYPE = 'ADD')
        BEGIN SET @Message = 'AFA not found, or it is not an Additional Budget document.'; RETURN; END

        IF EXISTS (SELECT 1 FROM dbo.AFA_NON_IFS WHERE AFA_NO = @AfaNo AND STS <> 'Draft')
        BEGIN SET @Message = 'AFA is no longer in Draft status.'; RETURN; END

        IF ISNULL(@BudgetItemCode,'') = ''
        BEGIN SET @Message = 'Budget Item is required.'; RETURN; END

        BEGIN TRANSACTION;

        IF ISNULL(@Seq,0) = 0
            SELECT @Seq = ISNULL(MAX(SEQ),0) + 1 FROM dbo.AFA_NON_IFS_ADD WHERE AFA_NO = @AfaNo;

        IF EXISTS (SELECT 1 FROM dbo.AFA_NON_IFS_ADD WHERE AFA_NO = @AfaNo AND SEQ = @Seq)
            UPDATE dbo.AFA_NON_IFS_ADD
            SET BUDGET_ITEM_CODE = @BudgetItemCode, BUDGET_ITEM_NAME = @BudgetItemName,
                CC = @Cc, CONTRACT = @Contract,
                BUDGET_AMOUNT = ISNULL(@BudgetAmount,0), ACTUAL_UP = ISNULL(@ActualUp,0),
                ESTIMATION = ISNULL(@Estimation,0), IFS_SYNC_DATE = GETDATE()
            WHERE AFA_NO = @AfaNo AND SEQ = @Seq;
        ELSE
            INSERT INTO dbo.AFA_NON_IFS_ADD
                (AFA_NO, SEQ, BUDGET_ITEM_CODE, BUDGET_ITEM_NAME, CC, CONTRACT,
                 BUDGET_AMOUNT, ACTUAL_UP, ESTIMATION, IFS_SYNC_DATE)
            VALUES
                (@AfaNo, @Seq, @BudgetItemCode, @BudgetItemName, @Cc, @Contract,
                 ISNULL(@BudgetAmount,0), ISNULL(@ActualUp,0), ISNULL(@Estimation,0), GETDATE());

        EXEC dbo.AFA_NonIFS_Recalc_Proc @AfaNo = @AfaNo,
             @Status = @st OUTPUT, @Message = @msg OUTPUT;

        COMMIT TRANSACTION;

        SELECT @Seq AS SEQ;

        SET @Status  = 'SUCCESS';
        SET @Message = 'Detail saved. Baris ke-' + CAST(@Seq AS varchar(10));
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        SET @Status  = 'FAILED';
        SET @Message = LEFT(ERROR_MESSAGE(), 255);
    END CATCH
END;
GO


/* ============================================================
   9. DELETE DETAIL
   ============================================================ */
CREATE PROC dbo.AFA_NonIFS_DeleteDetail_Proc
    @AfaNo   varchar(50),
    @Seq     int,
    @Nik     varchar(50),
    @Pc      varchar(50),
    @Status  varchar(10)  OUTPUT,
    @Message varchar(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET @Status = 'FAILED'; SET @Message = '';

    DECLARE @type varchar(10), @st varchar(10), @msg varchar(255);

    BEGIN TRY
        SELECT @type = AFA_TYPE FROM dbo.AFA_NON_IFS WHERE AFA_NO = @AfaNo AND STS = 'Draft';
        IF @type IS NULL
        BEGIN SET @Message = 'AFA not found, or it is no longer in Draft status.'; RETURN; END

        IF @type = 'BRE' AND EXISTS (SELECT 1 FROM dbo.AFA_NON_IFS_BRE
                                     WHERE AFA_NO = @AfaNo AND RECLASS_FROM_SEQ = @Seq)
        BEGIN SET @Message = 'Cannot delete: a target item still references this row.'; RETURN; END

        BEGIN TRANSACTION;

        IF @type = 'DAA'
            DELETE FROM dbo.AFA_NON_IFS_DAA WHERE AFA_NO = @AfaNo AND SEQ = @Seq;
        ELSE IF @type = 'ADD'
            DELETE FROM dbo.AFA_NON_IFS_ADD WHERE AFA_NO = @AfaNo AND SEQ = @Seq;
        ELSE IF @type = 'BRE'
            DELETE FROM dbo.AFA_NON_IFS_BRE WHERE AFA_NO = @AfaNo AND SEQ = @Seq;
        ELSE
            DELETE FROM dbo.AFA_NON_IFS_INF WHERE AFA_NO = @AfaNo;

        EXEC dbo.AFA_NonIFS_Recalc_Proc @AfaNo = @AfaNo,
             @Status = @st OUTPUT, @Message = @msg OUTPUT;

        COMMIT TRANSACTION;

        SET @Status  = 'SUCCESS';
        SET @Message = 'Detail deleted.';
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        SET @Status  = 'FAILED';
        SET @Message = LEFT(ERROR_MESSAGE(), 255);
    END CATCH
END;
GO


/* ============================================================
   10. ATTACHMENT
   ============================================================ */
CREATE PROC dbo.AFA_NonIFS_SaveAttachment_Proc
    @AfaNo    varchar(50),
    @Seq      int,
    @Type     varchar(20),        -- Cover / Lampiran
    @FilePath varchar(500),
    @Caption  varchar(500),
    @Nik      varchar(50),
    @Status   varchar(10)  OUTPUT,
    @Message  varchar(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET @Status = 'FAILED'; SET @Message = '';

    BEGIN TRY
        IF NOT EXISTS (SELECT 1 FROM dbo.AFA_NON_IFS WHERE AFA_NO = @AfaNo)
        BEGIN SET @Message = 'AFA not found.'; RETURN; END

        IF EXISTS (SELECT 1 FROM dbo.AFA_NON_IFS WHERE AFA_NO = @AfaNo AND STS = 'Cancelled')
        BEGIN SET @Message = 'AFA has already been cancelled.'; RETURN; END

        IF ISNULL(@FilePath,'') = ''
        BEGIN SET @Message = 'Please choose a file.'; RETURN; END

        BEGIN TRANSACTION;

        -- only one Cover per AFA, so an existing one is replaced
        IF @Type = 'Cover' AND ISNULL(@Seq,0) = 0
            SELECT @Seq = SEQ FROM dbo.AFA_NON_IFS_ATTACHMENT
            WHERE AFA_NO = @AfaNo AND TYPE = 'Cover';

        IF ISNULL(@Seq,0) = 0
            SELECT @Seq = ISNULL(MAX(SEQ),0) + 1 FROM dbo.AFA_NON_IFS_ATTACHMENT WHERE AFA_NO = @AfaNo;

        IF EXISTS (SELECT 1 FROM dbo.AFA_NON_IFS_ATTACHMENT WHERE AFA_NO = @AfaNo AND SEQ = @Seq)
            UPDATE dbo.AFA_NON_IFS_ATTACHMENT
            SET TYPE = @Type, FILE_PATH = @FilePath, CAPTION = @Caption, NIK = @Nik
            WHERE AFA_NO = @AfaNo AND SEQ = @Seq;
        ELSE
            INSERT INTO dbo.AFA_NON_IFS_ATTACHMENT (AFA_NO, SEQ, TYPE, FILE_PATH, CAPTION, NIK)
            VALUES (@AfaNo, @Seq, @Type, @FilePath, @Caption, @Nik);

        COMMIT TRANSACTION;

        SELECT @Seq AS SEQ;

        SET @Status  = 'SUCCESS';
        SET @Message = 'Attachment saved.';
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        SET @Status  = 'FAILED';
        SET @Message = LEFT(ERROR_MESSAGE(), 255);
    END CATCH
END;
GO

CREATE PROC dbo.AFA_NonIFS_DeleteAttachment_Proc
    @AfaNo   varchar(50),
    @Seq     int,
    @Status  varchar(10)  OUTPUT,
    @Message varchar(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET @Status = 'FAILED'; SET @Message = '';

    BEGIN TRY
        DELETE FROM dbo.AFA_NON_IFS_ATTACHMENT WHERE AFA_NO = @AfaNo AND SEQ = @Seq;

        IF @@ROWCOUNT = 0 BEGIN SET @Message = 'Attachment not found.'; RETURN; END

        SET @Status  = 'SUCCESS';
        SET @Message = 'Attachment deleted.';
    END TRY
    BEGIN CATCH
        SET @Status  = 'FAILED';
        SET @Message = LEFT(ERROR_MESSAGE(), 255);
    END CATCH
END;
GO


/* ============================================================
   11. EVALUATE SRI
   Menghasilkan label SRI Need / No Need dan teks Ref. Reg.
   ============================================================ */
CREATE PROC dbo.AFA_NonIFS_EvaluateSRI_Proc
    @AfaNo   varchar(50),
    @Status  varchar(10)  OUTPUT,
    @Message varchar(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET @Status = 'FAILED'; SET @Message = '';

    DECLARE @type varchar(10), @sub varchar(10), @amt numeric(18,3),
            @always bit, @thr numeric(18,3), @ref varchar(100), @sri varchar(20);

    BEGIN TRY
        SELECT @type = AFA_TYPE, @amt = AMT_JPY
        FROM dbo.AFA_NON_IFS WHERE AFA_NO = @AfaNo;

        IF @type IS NULL BEGIN SET @Message = 'AFA not found.'; RETURN; END

        IF @type = 'INF'
            SELECT @sub = SUB_TYPE FROM dbo.AFA_NON_IFS_INF WHERE AFA_NO = @AfaNo;
        ELSE IF @type = 'DAA'
            -- a Disposal document holds exactly one row (no per-asset detail),
            -- so a plain lookup is enough - no "lowest threshold" tie-break needed
            SELECT @sub = SUB_TYPE FROM dbo.AFA_NON_IFS_DAA WHERE AFA_NO = @AfaNo;
        ELSE
            SET @sub = '*';

        /* The exact sub-type wins; the wildcard row is the fallback for
           types without a sub-type, and for documents whose detail row
           has not been saved yet. */
        SELECT TOP 1 @always = SRI_ALWAYS, @thr = SRI_THRESHOLD, @ref = REF_REG
        FROM   dbo.AFA_SRI_RULE
        WHERE  AFA_TYPE = @type AND IS_ACTIVE = 1
          AND  SUB_TYPE IN (ISNULL(@sub,'*'), '*')
        ORDER  BY CASE WHEN SUB_TYPE = ISNULL(@sub,'*') THEN 0 ELSE 1 END;

        IF @always IS NULL
        BEGIN SET @Message = 'No SRI rule exists for ' + @type + '/' + ISNULL(@sub,''); RETURN; END

        SET @sri = CASE WHEN @always = 1 THEN 'Need'
                        WHEN @thr IS NOT NULL AND ISNULL(@amt,0) > @thr THEN 'Need'
                        ELSE 'No Need' END;

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


/* ============================================================
   12. SUBMIT
   The SRI label is frozen here so it cannot change if the exchange
   rate or the rule master is edited after the document circulates.
   ============================================================ */
CREATE PROC dbo.AFA_NonIFS_Submit_Proc
    @AfaNo   varchar(50),
    @Nik     varchar(50),
    @Pc      varchar(50),
    @Status  varchar(10)  OUTPUT,
    @Message varchar(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET @Status = 'FAILED'; SET @Message = '';

    DECLARE @tglnow datetime = GETDATE(), @type varchar(10), @sts varchar(50),
            @rows int, @st varchar(10), @msg varchar(255),
            @sri varchar(20), @ref varchar(100);

    DECLARE @eval TABLE (SRI_STS varchar(20), REF_REG varchar(100));

    BEGIN TRY
        SELECT @type = AFA_TYPE, @sts = STS FROM dbo.AFA_NON_IFS WHERE AFA_NO = @AfaNo;

        IF @type IS NULL   BEGIN SET @Message = 'AFA not found.'; RETURN; END
        IF @sts <> 'Draft' BEGIN SET @Message = 'AFA has already been submitted.'; RETURN; END

        EXEC dbo.AFA_NonIFS_Recalc_Proc @AfaNo = @AfaNo,
             @Status = @st OUTPUT, @Message = @msg OUTPUT;

        SET @rows =
            CASE @type
                WHEN 'INF' THEN (SELECT COUNT(*) FROM dbo.AFA_NON_IFS_INF WHERE AFA_NO = @AfaNo)
                WHEN 'DAA' THEN (SELECT COUNT(*) FROM dbo.AFA_NON_IFS_DAA WHERE AFA_NO = @AfaNo)
                WHEN 'BRE' THEN (SELECT COUNT(*) FROM dbo.AFA_NON_IFS_BRE WHERE AFA_NO = @AfaNo)
                WHEN 'ADD' THEN (SELECT COUNT(*) FROM dbo.AFA_NON_IFS_ADD WHERE AFA_NO = @AfaNo)
            END;

        IF ISNULL(@rows,0) = 0 BEGIN SET @Message = 'The detail rows are still empty.'; RETURN; END

        IF @type = 'BRE'
           AND (NOT EXISTS (SELECT 1 FROM dbo.AFA_NON_IFS_BRE WHERE AFA_NO = @AfaNo AND ITEM_ROLE = 'Source')
             OR NOT EXISTS (SELECT 1 FROM dbo.AFA_NON_IFS_BRE WHERE AFA_NO = @AfaNo AND ITEM_ROLE = 'Target'))
        BEGIN SET @Message = 'Reclass needs both a source and a target budget item.'; RETURN; END

        IF NOT EXISTS (SELECT 1 FROM dbo.AFA_SIGNATURE
                       WHERE AFA_NO = @AfaNo AND ISNULL(NIK,'') <> '')
        BEGIN SET @Message = 'No approver has been assigned yet.'; RETURN; END

        INSERT INTO @eval
        EXEC dbo.AFA_NonIFS_EvaluateSRI_Proc @AfaNo = @AfaNo,
             @Status = @st OUTPUT, @Message = @msg OUTPUT;

        IF @st <> 'SUCCESS' BEGIN SET @Message = @msg; RETURN; END

        SELECT TOP 1 @sri = SRI_STS, @ref = REF_REG FROM @eval;

        BEGIN TRANSACTION;

        UPDATE dbo.AFA_NON_IFS
        SET STS = 'Planned', SRI_STS = @sri, REF_REG = ISNULL(REF_REG, @ref),
            DATEUPDATE = @tglnow, USERUPDATE = @Nik
        WHERE AFA_NO = @AfaNo;

        INSERT INTO dbo.AFA_Log (ID, Type, NIK, PC, DateCreate, AFA)
        VALUES (@tglnow, 'Submit', @Nik, @Pc, @tglnow, @AfaNo);

        COMMIT TRANSACTION;

        -- TODO EMAIL: notify the next approver

        SET @Status  = 'SUCCESS';
        SET @Message = 'Submitted. AFA ' + @AfaNo + ' (SRI ' + @sri + ')';
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        SET @Status  = 'FAILED';
        SET @Message = LEFT(ERROR_MESSAGE(), 255);
    END CATCH
END;
GO


/* ============================================================
   13. APPROVE / UNAPPROVE
   @Type is 'APP' or 'UNAPP'.

   Both branches check the header's own STS before touching a node.
   Without this check, an approver could act on a document that is
   still Draft: the default nodes (Auth, Budget) are filled in and
   marked 'Send' the moment a document is created, well before the
   drafter has pressed Send at all.
   ============================================================ */
CREATE PROC dbo.AFA_NonIFS_App_Proc
    @AfaNo   varchar(50),
    @Jenis   varchar(50),
    @Nik     varchar(50),
    @Pc      varchar(50),
    @Type    varchar(20),
    @Reason  varchar(500),
    @Status  varchar(10)  OUTPUT,
    @Message varchar(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET @Status = 'FAILED'; SET @Message = '';

    DECLARE @tglnow datetime = GETDATE(), @remaining int, @unapp varchar(5),
            @headerSts varchar(50), @headerType varchar(10), @headerBudgetYear varchar(10),
            @st varchar(10), @msg varchar(255), @afaNoApproval varchar(50);

    BEGIN TRY
        SELECT @headerSts = STS, @headerType = AFA_TYPE, @headerBudgetYear = BUDGET_YEAR
        FROM   dbo.AFA_NON_IFS WHERE AFA_NO = @AfaNo;

        IF @headerSts IS NULL
        BEGIN SET @Message = 'AFA not found in this module.'; RETURN; END

        IF @Type = 'APP'
        BEGIN
            IF @headerSts <> 'Planned'
            BEGIN SET @Message = 'This document has not been sent for approval yet.'; RETURN; END

            IF NOT EXISTS (SELECT 1 FROM dbo.AFA_SIGNATURE
                           WHERE AFA_NO = @AfaNo AND TYPE = @Jenis AND NIK = @Nik AND STS = 'Send')
            BEGIN SET @Message = 'Approve failed: this document is not waiting for you.'; RETURN; END

            -- Sequential routing: Dir -> Supp -> Budget -> Auth. Reject the
            -- approval outright if an earlier-in-sequence node type still
            -- has an unresolved assigned node on this document - this is
            -- the real gate; AFA_NonIFS_GetPendingApproval_Proc filtering
            -- the inbox is what keeps the UI from offering it in the first
            -- place, but this check holds even if this procedure is ever
            -- called directly.
            IF EXISTS (
                SELECT 1 FROM dbo.AFA_SIGNATURE p
                WHERE p.AFA_NO = @AfaNo
                  AND ISNULL(p.NIK,'') <> ''
                  AND p.STS NOT IN ('App','Skip')
                  AND CASE p.TYPE WHEN 'Dir' THEN 1 WHEN 'Supp' THEN 2 WHEN 'Budget' THEN 3 WHEN 'Auth' THEN 4 ELSE 99 END
                    < CASE @Jenis WHEN 'Dir' THEN 1 WHEN 'Supp' THEN 2 WHEN 'Budget' THEN 3 WHEN 'Auth' THEN 4 ELSE 99 END
            )
            BEGIN SET @Message = 'This node cannot be approved yet - an earlier approval stage (Dir / Supp / Budget) has not been completed.'; RETURN; END

            BEGIN TRANSACTION;

            UPDATE dbo.AFA_SIGNATURE
            SET STS = 'App', PCAPP = @Pc, DATEAPP = @tglnow, ttdApp = 'Y', Reason = @Reason
            WHERE AFA_NO = @AfaNo AND TYPE = @Jenis AND NIK = @Nik AND STS = 'Send';

            SELECT @remaining = COUNT(*) FROM dbo.AFA_SIGNATURE
            WHERE AFA_NO = @AfaNo AND ISNULL(NIK,'') <> '' AND STS NOT IN ('App','Skip');

            IF @remaining = 0
            BEGIN
                -- the approval number is a sequence: it is only ever
                -- minted here, at the instant the document becomes fully
                -- approved, never at creation and never reused afterwards
                EXEC dbo.AFA_NonIFS_GenerateApprovalNumber_Proc
                     @AfaType = @headerType, @BudgetYear = @headerBudgetYear, @RefDate = NULL,
                     @Status = @st OUTPUT, @Message = @msg OUTPUT,
                     @AfaNoApproval = @afaNoApproval OUTPUT;

                IF @st <> 'SUCCESS'
                BEGIN ROLLBACK TRANSACTION; SET @Message = @msg; RETURN; END

                UPDATE dbo.AFA_NON_IFS
                SET STS = 'Approved', AFA_APPROVAL_DATE = CAST(@tglnow AS date),
                    AFA_NO_APPROVAL = @afaNoApproval, DATEUPDATE = @tglnow
                WHERE AFA_NO = @AfaNo;
            END

            INSERT INTO dbo.AFA_Log (ID, Type, NIK, PC, DateCreate, AFA)
            VALUES (@tglnow, 'Approve', @Nik, @Pc, @tglnow, @AfaNo);

            COMMIT TRANSACTION;

            -- TODO EMAIL: notify the next approver when @remaining > 0

            SET @Status  = 'SUCCESS';
            SET @Message = CASE WHEN @remaining = 0
                                THEN 'Approved. AFA ' + @AfaNo + ' is now fully approved (' + ISNULL(@afaNoApproval,'') + ').'
                                ELSE 'Approved. AFA ' + @AfaNo END;
        END
        ELSE IF @Type = 'UNAPP'
        BEGIN
            IF @headerSts NOT IN ('Planned','Approved')
            BEGIN SET @Message = 'This document is not in a state that can be un-approved.'; RETURN; END

            SELECT @unapp = UnApp FROM dbo.User_H WHERE UserID = @Nik;
            IF ISNULL(@unapp,'T') <> 'Y'
            BEGIN SET @Message = 'You do not have un-approve rights.'; RETURN; END

            IF NOT EXISTS (SELECT 1 FROM dbo.AFA_SIGNATURE
                           WHERE AFA_NO = @AfaNo AND TYPE = @Jenis AND NIK = @Nik AND STS IN ('App','Skip'))
            BEGIN SET @Message = 'Un-approve failed: this node was never approved.'; RETURN; END

            BEGIN TRANSACTION;

            UPDATE dbo.AFA_SIGNATURE
            SET STS = 'Send', PCAPP = NULL, DATEAPP = NULL, ttdApp = 'T', Reason = @Reason
            WHERE AFA_NO = @AfaNo AND TYPE = @Jenis AND NIK = @Nik AND STS IN ('App','Skip');

            -- releasing the approval: the number is cleared, not kept for
            -- reuse. If this document reaches final approval again later,
            -- AFA_NonIFS_GenerateApprovalNumber_Proc hands out the next
            -- value in the counter - never this one again.
            UPDATE dbo.AFA_NON_IFS
            SET STS = 'Planned', AFA_APPROVAL_DATE = NULL, AFA_NO_APPROVAL = NULL, DATEUPDATE = @tglnow
            WHERE AFA_NO = @AfaNo AND STS = 'Approved';

            INSERT INTO dbo.AFA_Log (ID, Type, NIK, PC, DateCreate, AFA)
            VALUES (@tglnow, 'Un Approve', @Nik, @Pc, @tglnow, @AfaNo);

            COMMIT TRANSACTION;

            SET @Status  = 'SUCCESS';
            SET @Message = 'Un-approved. AFA ' + @AfaNo + '. The approval number has been released.';
        END
        ELSE
            SET @Message = 'Unknown action type.';
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        SET @Status  = 'FAILED';
        SET @Message = LEFT(ERROR_MESSAGE(), 255);
    END CATCH
END;
GO


CREATE PROC dbo.AFA_NonIFS_Skip_Proc
    @AfaNo   varchar(50),
    @Jenis   varchar(50),
    @Id      numeric(18,0),
    @Nik     varchar(50),
    @Pc      varchar(50),
    @Reason  varchar(500),
    @Status  varchar(10)  OUTPUT,
    @Message varchar(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET @Status = 'FAILED'; SET @Message = '';

    DECLARE @tglnow datetime = GETDATE(), @remaining int;

    BEGIN TRY
        IF ISNULL(@Reason,'') = ''
        BEGIN SET @Message = 'A reason is required when skipping an approver.'; RETURN; END

        IF NOT EXISTS (SELECT 1 FROM dbo.AFA_NON_IFS WHERE AFA_NO = @AfaNo)
        BEGIN SET @Message = 'AFA not found in this module.'; RETURN; END

        IF NOT EXISTS (SELECT 1 FROM dbo.AFA_SIGNATURE
                       WHERE AFA_NO = @AfaNo AND TYPE = @Jenis AND ID = @Id AND STS = 'Send')
        BEGIN SET @Message = 'This node is not waiting for approval.'; RETURN; END

        -- Same Dir -> Supp -> Budget -> Auth sequence enforced in
        -- AFA_NonIFS_App_Proc: skipping out of turn would bypass the
        -- routing order just as approving out of turn would.
        IF EXISTS (
            SELECT 1 FROM dbo.AFA_SIGNATURE p
            WHERE p.AFA_NO = @AfaNo
              AND ISNULL(p.NIK,'') <> ''
              AND p.STS NOT IN ('App','Skip')
              AND CASE p.TYPE WHEN 'Dir' THEN 1 WHEN 'Supp' THEN 2 WHEN 'Budget' THEN 3 WHEN 'Auth' THEN 4 ELSE 99 END
                < CASE @Jenis WHEN 'Dir' THEN 1 WHEN 'Supp' THEN 2 WHEN 'Budget' THEN 3 WHEN 'Auth' THEN 4 ELSE 99 END
        )
        BEGIN SET @Message = 'This node cannot be skipped yet - an earlier approval stage (Dir / Supp / Budget) has not been completed.'; RETURN; END

        BEGIN TRANSACTION;

        UPDATE dbo.AFA_SIGNATURE
        SET STS = 'Skip', DATEAPP = @tglnow, PCAPP = @Pc, Reason = @Reason
        WHERE AFA_NO = @AfaNo AND TYPE = @Jenis AND ID = @Id AND STS = 'Send';

        SELECT @remaining = COUNT(*) FROM dbo.AFA_SIGNATURE
        WHERE AFA_NO = @AfaNo AND ISNULL(NIK,'') <> '' AND STS NOT IN ('App','Skip');

        IF @remaining = 0
            UPDATE dbo.AFA_NON_IFS
            SET STS = 'Approved', AFA_APPROVAL_DATE = CAST(@tglnow AS date), DATEUPDATE = @tglnow
            WHERE AFA_NO = @AfaNo;

        INSERT INTO dbo.AFA_Log (ID, Type, NIK, PC, DateCreate, AFA)
        VALUES (@tglnow, 'Skip', @Nik, @Pc, @tglnow, @AfaNo);

        COMMIT TRANSACTION;

        SET @Status  = 'SUCCESS';
        SET @Message = 'Approver skipped. AFA ' + @AfaNo;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        SET @Status  = 'FAILED';
        SET @Message = LEFT(ERROR_MESSAGE(), 255);
    END CATCH
END;
GO


/* ============================================================
   15. BUDGET CONTROL CHECK / UNCHECK
   @Type is 'CHECK' or 'UNCHECK'
   ============================================================ */
CREATE PROC dbo.AFA_NonIFS_BudgetCheck_Proc
    @AfaNo   varchar(50),
    @Nik     varchar(50),
    @Pc      varchar(50),
    @Type    varchar(20),
    @Reason  varchar(500),
    @Status  varchar(10)  OUTPUT,
    @Message varchar(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET @Status = 'FAILED'; SET @Message = '';

    DECLARE @tglnow datetime = GETDATE(), @cur varchar(20), @budget varchar(5);

    BEGIN TRY
        SELECT @cur = BUDGET_STS FROM dbo.AFA_NON_IFS WHERE AFA_NO = @AfaNo;
        IF @@ROWCOUNT = 0 BEGIN SET @Message = 'AFA not found.'; RETURN; END

        -- Budget Control rights follow the legacy user master
        SELECT @budget = Budget FROM dbo.User_H WHERE UserID = @Nik;
        IF ISNULL(@budget,'T') <> 'Y'
        BEGIN SET @Message = 'You do not have Budget Control rights.'; RETURN; END

        IF @Type = 'CHECK' AND ISNULL(@cur,'') = 'Checked'
        BEGIN SET @Message = 'AFA is already Checked.'; RETURN; END

        IF @Type = 'UNCHECK' AND ISNULL(@cur,'') <> 'Checked'
        BEGIN SET @Message = 'AFA is not in Checked status.'; RETURN; END

        IF @Type NOT IN ('CHECK','UNCHECK')
        BEGIN SET @Message = 'Unknown action type.'; RETURN; END

        BEGIN TRANSACTION;

        UPDATE dbo.AFA_NON_IFS
        SET BUDGET_STS = CASE WHEN @Type = 'CHECK' THEN 'Checked' ELSE 'Unchecked' END,
            BUDGET_CHECK_BY = @Nik, BUDGET_CHECK_DATE = @tglnow
        WHERE AFA_NO = @AfaNo;

        -- unchecking releases the Budget node so the revision loop can run again
        IF @Type = 'UNCHECK'
            UPDATE dbo.AFA_SIGNATURE
            SET STS = 'Send', DATEAPP = NULL, PCAPP = NULL, ttdApp = 'T', Reason = @Reason
            WHERE AFA_NO = @AfaNo AND TYPE = 'Budget' AND STS = 'App';

        INSERT INTO dbo.AFA_Log (ID, Type, NIK, PC, DateCreate, AFA)
        VALUES (@tglnow, CASE WHEN @Type = 'CHECK' THEN 'Budget Check' ELSE 'Budget Uncheck' END,
                @Nik, @Pc, @tglnow, @AfaNo);

        COMMIT TRANSACTION;

        SET @Status  = 'SUCCESS';
        SET @Message = CASE WHEN @Type = 'CHECK'
                            THEN 'Budget checked. AFA ' + @AfaNo
                            ELSE 'Budget unchecked. AFA ' + @AfaNo END;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        SET @Status  = 'FAILED';
        SET @Message = LEFT(ERROR_MESSAGE(), 255);
    END CATCH
END;
GO


/* ============================================================
   16. CANCEL
   AFA_SIGNATURE has no foreign key to our header, so the nodes are
   cleaned up explicitly. Their status goes back to '' to keep the
   shared table's vocabulary the same as the legacy module's.
   ============================================================ */
CREATE PROC dbo.AFA_NonIFS_Cancel_Proc
    @AfaNo   varchar(50),
    @Nik     varchar(50),
    @Pc      varchar(50),
    @Reason  varchar(500),
    @Status  varchar(10)  OUTPUT,
    @Message varchar(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET @Status = 'FAILED'; SET @Message = '';

    DECLARE @tglnow datetime = GETDATE(), @sts varchar(50);

    BEGIN TRY
        SELECT @sts = STS FROM dbo.AFA_NON_IFS WHERE AFA_NO = @AfaNo;

        IF @sts IS NULL       BEGIN SET @Message = 'AFA not found.'; RETURN; END
        IF @sts = 'Approved'  BEGIN SET @Message = 'An approved AFA cannot be cancelled.'; RETURN; END
        IF @sts = 'Cancelled' BEGIN SET @Message = 'AFA has already been cancelled.'; RETURN; END

        BEGIN TRANSACTION;

        UPDATE dbo.AFA_NON_IFS
        SET STS = 'Cancelled', DATEUPDATE = @tglnow, USERUPDATE = @Nik
        WHERE AFA_NO = @AfaNo;

        UPDATE dbo.AFA_SIGNATURE
        SET STS = '', DATEAPP = NULL, PCAPP = NULL, ttdApp = NULL, Reason = @Reason
        WHERE AFA_NO = @AfaNo AND ISNULL(STS,'') NOT IN ('App','Skip');

        INSERT INTO dbo.AFA_Log (ID, Type, NIK, PC, DateCreate, AFA)
        VALUES (@tglnow, 'Cancel', @Nik, @Pc, @tglnow, @AfaNo);

        COMMIT TRANSACTION;

        SET @Status  = 'SUCCESS';
        SET @Message = 'AFA ' + @AfaNo + ' dibatalkan.';
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        SET @Status  = 'FAILED';
        SET @Message = LEFT(ERROR_MESSAGE(), 255);
    END CATCH
END;
GO


/* ============================================================
   17. IFS BUDGET LOOKUP
   Called when the user picks a budget item, OUTSIDE the save
   transaction, so a slow SURILINK cannot hold a lock on the
   number counter table.
   ============================================================ */
CREATE PROC dbo.AFA_NonIFS_GetBudgetFromIFS_Proc
    @BudgetYear varchar(10),
    @BudgetRev  varchar(10),
    @Cc         varchar(50),
    @Contract   varchar(50),
    @Allocation varchar(50),
    @Status     varchar(10)  OUTPUT,
    @Message    varchar(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET @Status = 'FAILED'; SET @Message = '';

    DECLARE @inner nvarchar(max), @outer nvarchar(max);

    BEGIN TRY
        SET @inner = N'
            select sum(x.afa_used + x.amt_available) Budget_Tot,
                   sum(x.afa_used)                   Act_This_App
            from   ifsapp.SRI_PURCH_BUDGET_DETAIL x
            where  x.budget_year     = ''' + ISNULL(@BudgetYear,'') + '''
              and  x.budget_revision = ''' + ISNULL(@BudgetRev,'')  + '''
              and  x.cost_center     = ''' + ISNULL(@Cc,'')         + '''
              and  x.contract        = ''' + ISNULL(@Contract,'')   + '''
              and  x.allocation      = ''' + ISNULL(@Allocation,'') + '''';

        SET @outer = N'
            SELECT CAST(ISNULL(Budget_Tot,0)   AS numeric(18,3)) AS BUDGET_AMOUNT,
                   CAST(ISNULL(Act_This_App,0) AS numeric(18,3)) AS ACTUAL_UP
            FROM OPENQUERY(SURILINK, ''' + REPLACE(@inner, '''', '''''') + N''')';

        EXEC (@outer);

        SET @Status  = 'SUCCESS';
        SET @Message = 'Budget figures fetched from IFS.';
    END TRY
    BEGIN CATCH
        -- IFS unreachable: return zeros so the form can still be filled in
        SELECT CAST(0 AS numeric(18,3)) AS BUDGET_AMOUNT,
               CAST(0 AS numeric(18,3)) AS ACTUAL_UP;
        SET @Status  = 'FAILED';
        SET @Message = 'IFS connection failed: ' + LEFT(ERROR_MESSAGE(), 200);
    END CATCH
END;
GO


/* ============================================================
   18. READ PROCEDURES - no output parameters
   Called with the plain ExecuteStoredProcedureQuery helper.
   ============================================================ */

IF OBJECT_ID('dbo.AFA_NonIFS_GetDetail_Proc','P')  IS NOT NULL DROP PROC dbo.AFA_NonIFS_GetDetail_Proc;
IF OBJECT_ID('dbo.AFA_NonIFS_Monitoring_Proc','P') IS NOT NULL DROP PROC dbo.AFA_NonIFS_Monitoring_Proc;
GO

CREATE PROC dbo.AFA_NonIFS_GetDetail_Proc
    @AfaNo varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @type varchar(10);
    SELECT @type = AFA_TYPE FROM dbo.AFA_NON_IFS WHERE AFA_NO = @AfaNo;

    SELECT * FROM dbo.V_AFA_NON_IFS_MONITORING WHERE AFA_NO = @AfaNo;

    IF @type = 'INF'
        SELECT * FROM dbo.AFA_NON_IFS_INF WHERE AFA_NO = @AfaNo;
    ELSE IF @type = 'DAA'
        SELECT * FROM dbo.AFA_NON_IFS_DAA WHERE AFA_NO = @AfaNo ORDER BY SEQ;
    ELSE IF @type = 'BRE'
        SELECT * FROM dbo.AFA_NON_IFS_BRE WHERE AFA_NO = @AfaNo ORDER BY ITEM_ROLE DESC, SEQ;
    ELSE IF @type = 'ADD'
        SELECT * FROM dbo.AFA_NON_IFS_ADD WHERE AFA_NO = @AfaNo ORDER BY SEQ;

    SELECT s.TYPE, s.ID, RTRIM(s.NIK) AS NIK, RTRIM(s.NAMA) AS NAMA, s.JAB,
           s.STS, s.DATEAPP, s.Reason, j.urut
    FROM   dbo.AFA_SIGNATURE s
    LEFT   JOIN dbo.AFA_Jenis_Urut j ON j.Jenis = s.TYPE
    WHERE  s.AFA_NO = @AfaNo
    ORDER  BY j.urut, s.ID;

    SELECT * FROM dbo.AFA_NON_IFS_ATTACHMENT WHERE AFA_NO = @AfaNo ORDER BY TYPE DESC, SEQ;

    SELECT Type, NIK, PC, DateCreate FROM dbo.AFA_Log
    WHERE AFA = @AfaNo ORDER BY DateCreate;
END;
GO

/* ============================================================
   18. MONITORING LIST

   @Nik      : content filter - only this NIK's own drafts, '' = everyone
   @ScopeNik : access filter - viewer's NIK, '' = no department restriction
               (used for the elevated roles that see every department)

   The two are kept separate: conflating them would make it impossible
   for someone to browse their department's documents drafted by a
   colleague.
   ============================================================ */
CREATE PROC dbo.AFA_NonIFS_Monitoring_Proc
    @AfaType   varchar(10),
    @Sts       varchar(50),
    @BudgetSts varchar(20),
    @Priority  varchar(5),          -- varchar so '' can mean "all"
    @Nik       varchar(50),
    @ScopeNik  varchar(50),
    @DateFrom  date,
    @DateTo    date
AS
BEGIN
    SET NOCOUNT ON;

    SELECT v.*
    FROM   dbo.V_AFA_NON_IFS_MONITORING v
    WHERE  (ISNULL(@AfaType,'')   = '' OR v.AFA_TYPE = @AfaType)
      AND  (ISNULL(@Sts,'')       = '' OR v.STS = @Sts)
      AND  (ISNULL(@BudgetSts,'') = '' OR ISNULL(v.BUDGET_STS,'') = @BudgetSts)
      AND  (ISNULL(@Priority,'')  = '' OR v.PRIORITY = TRY_CAST(@Priority AS tinyint))
      AND  (ISNULL(@Nik,'')       = '' OR v.CREATED_NIK = @Nik)
      AND  (ISNULL(@ScopeNik,'')  = ''
            OR v.DEPT_ID IN (SELECT du.DEPT_ID FROM dbo.AFA_DEPARTMENT_USER du WHERE du.NIK = @ScopeNik))
      AND  (@DateFrom IS NULL OR v.CREATED_DATE >= @DateFrom)
      AND  (@DateTo   IS NULL OR v.CREATED_DATE < DATEADD(day,1,@DateTo))
    ORDER  BY v.PRIORITY DESC, v.CREATED_DATE DESC;
END;
GO


CREATE PROC dbo.AFA_NonIFS_GetSubType_Proc
    @AfaType varchar(10)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT CODE, NAME
    FROM   dbo.AFA_SUB_TYPE
    WHERE  AFA_TYPE = @AfaType AND IS_ACTIVE = 1
    ORDER  BY SEQ;
END;
GO

/* NIK in AFA_Employee_GTAS is stored with a trailing space, so every
   read trims it. */
CREATE PROC dbo.AFA_NonIFS_SearchEmployee_Proc
    @Keyword varchar(100)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @key varchar(100) = ISNULL(LTRIM(RTRIM(@Keyword)),'');

    SELECT RTRIM(e.NIK)    AS NIK,
           RTRIM(e.Nama)   AS Nama,
           RTRIM(e.Jab)    AS Jab,
           RTRIM(e.SectCd) AS SectCd
    FROM   dbo.AFA_Employee_GTAS e
    WHERE  @key = '' OR RTRIM(e.NIK) LIKE '%' + @key + '%'
                     OR e.Nama LIKE '%' + @key + '%'
    ORDER  BY e.Nama;
END;
GO


/* ============================================================================


/* ----------------------------------------------------------------------------
   Active application users, with position resolved through the view above.
   Used wherever a NIK must be picked from a list rather than typed - the
   User Department Mapping form is the first of these.

   Columns: NIK, NAMA, JABATAN, DISPLAY_NAME ("Name - NIK - Position").

   The collation fix: me.position is cast to the database's default
   collation before it is concatenated, not just before it is joined.
   ---------------------------------------------------------------------------- */

IF OBJECT_ID('dbo.AFA_NonIFS_GetActiveUsers_Proc','P') IS NOT NULL
    DROP PROC dbo.AFA_NonIFS_GetActiveUsers_Proc;
GO

CREATE PROC dbo.AFA_NonIFS_GetActiveUsers_Proc
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
         u.UserID                                       AS NIK
        ,u.Name                                         AS NAMA
        ,ISNULL(me.position COLLATE DATABASE_DEFAULT,'') AS JABATAN
        ,u.Name + ' - ' + u.UserID +
         CASE WHEN ISNULL(me.position,'') = '' THEN ''
              ELSE ' - ' + me.position COLLATE DATABASE_DEFAULT END
                                                          AS DISPLAY_NAME
    FROM   dbo.User_H u
    LEFT   JOIN dbo.V_MASTER_EMPLOYEE me
           ON me.nik COLLATE DATABASE_DEFAULT = u.UserID
    WHERE  ISNULL(u.Aktif,'') = 'Y'
    ORDER  BY u.Name;
END;
GO
