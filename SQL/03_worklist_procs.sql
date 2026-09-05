/* ============================================================================
   FILE 03 - WORKLIST PROCEDURES
   AFA_NonIFS_GetUnconfigured_Proc - Draft-status documents, scoped by NIK
   through AFA_DEPARTMENT_USER internally.
   ============================================================================ */

/* ============================================================================
   AFASYS - AFA NON-IFS MODULE  |  UNCONFIGURED DOCUMENTS BY NIK (rev. 22)
   ----------------------------------------------------------------------------
   Replaces the @DeptIds version. The caller now passes a NIK; the
   procedure resolves that person's departments itself via
   AFA_DEPARTMENT_USER, the same mapping table that already governs which
   departments the E-Form offers.

   One person can be mapped to several departments, which is exactly why
   this is a WHERE ... IN (subquery) rather than a single equality - no
   comma list to build or split on the application side, and one person
   with the wrong department can be fixed in AFA_DEPARTMENT_USER without
   touching this procedure.

   A NIK with no mapping rows simply produces an empty IN-list, so the
   result is naturally empty - no separate branch is needed for that case
   the way the @DeptIds version needed one.
   ============================================================================ */

IF OBJECT_ID('dbo.AFA_NonIFS_GetUnconfigured_Proc','P') IS NOT NULL
    DROP PROC dbo.AFA_NonIFS_GetUnconfigured_Proc;
GO

CREATE PROC dbo.AFA_NonIFS_GetUnconfigured_Proc
    @Nik     varchar(50),
    @AfaType varchar(10)       -- pass '' for every type
AS
BEGIN
    SET NOCOUNT ON;

    SELECT v.*
    FROM   dbo.V_AFA_NON_IFS_UNCONFIGURED v
    WHERE  v.DEPT_ID IN (SELECT du.DEPT_ID FROM dbo.AFA_DEPARTMENT_USER du WHERE du.NIK = @Nik)
      AND  (ISNULL(@AfaType,'') = '' OR v.AFA_TYPE = @AfaType)
    ORDER  BY v.DAYS_IN_DRAFT DESC, v.CREATED_DATE ASC;
END;
GO
