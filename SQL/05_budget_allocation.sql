/* ============================================================================
   FILE 05 - BUDGET ALLOCATION LOOKUP (BRE / ADD)
   Local mirror of IFS budget allocations, so the Reclass Budget and
   Additional Budget E-Forms can offer a searchable Budget Item dropdown
   without an OPENQUERY hop into IFS on every keystroke.

   dbo.IFS_budget_allocation does not exist anywhere in files 00-04 of this
   deployment script, so its table definition is added here rather than
   assumed. If it turns out to already exist under a different shape,
   drop this CREATE TABLE block and keep only the two procedures below.

     AFA_NonIFS_GetBudgetAllocation_Proc - plain read, no OUTPUT params,
       same convention as every other GetXxx_Proc in this module (see
       AFA_NonIFS_GetSubType_Proc, AFA_NonIFS_GetActiveUsers_Proc).

     AFA_NonIFS_SyncBudget_Proc - placeholder only. It does not touch IFS
       and does not write to IFS_budget_allocation yet: it just reports
       SUCCESS so the UI's Sync button has something real to call while
       the actual sync logic is written separately. Calling it today will
       not make a new allocation appear in the lookup.
   ============================================================================ */

USE AFASYS;
GO
SET NOCOUNT ON;
GO


IF OBJECT_ID('dbo.IFS_budget_allocation','U') IS NULL
CREATE TABLE dbo.IFS_budget_allocation (
    BUDGET_YEAR      varchar(10)   NOT NULL,
    BUDGET_REVISION  varchar(10)   NOT NULL,
    COST_CENTER      varchar(50)   NOT NULL,
    CONTRACT         varchar(50)   NOT NULL,
    ALLOCATION       varchar(50)   NOT NULL,
    AMT              numeric(18,2) NOT NULL CONSTRAINT DF_IFSBA_AMT     DEFAULT (0),
    AMT_USE          numeric(18,2) NOT NULL CONSTRAINT DF_IFSBA_AMTUSE  DEFAULT (0),
    DATESYNC         datetime      NOT NULL CONSTRAINT DF_IFSBA_DS      DEFAULT (GETDATE()),
    CONSTRAINT PK_IFS_BUDGET_ALLOCATION PRIMARY KEY
        (BUDGET_YEAR, BUDGET_REVISION, COST_CENTER, CONTRACT, ALLOCATION)
);
GO


IF OBJECT_ID('dbo.AFA_NonIFS_GetBudgetAllocation_Proc','P') IS NOT NULL
    DROP PROC dbo.AFA_NonIFS_GetBudgetAllocation_Proc;
GO

CREATE PROC dbo.AFA_NonIFS_GetBudgetAllocation_Proc
    @BudgetYear varchar(10),
    @BudgetRev  varchar(10)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
         ALLOCATION   AS BUDGET_ITEM_CODE,
         ALLOCATION   AS BUDGET_ITEM_NAME,
         COST_CENTER  AS CC,
         CONTRACT,
         AMT          AS BUDGET_AMOUNT,
         AMT_USE      AS ACTUAL_UP
    FROM dbo.IFS_budget_allocation
    WHERE BUDGET_YEAR = @BudgetYear AND BUDGET_REVISION = @BudgetRev
    ORDER BY ALLOCATION;
END;
GO


IF OBJECT_ID('dbo.AFA_NonIFS_SyncBudget_Proc','P') IS NOT NULL
    DROP PROC dbo.AFA_NonIFS_SyncBudget_Proc;
GO


CREATE PROC dbo.AFA_NonIFS_SyncBudget_Proc
    @BudgetYear varchar(10),
    @BudgetRev  varchar(10),
    @Allocation varchar(50),
    @Status     varchar(10)  OUTPUT,
    @Message    varchar(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    SET @Status  = 'SUCCESS';
    SET @Message = 'Sync placeholder';
END;
GO
