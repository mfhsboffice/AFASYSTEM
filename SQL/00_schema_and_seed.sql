/* ============================================================================
   AFASYS - AFA NON-IFS MODULE
   Full deployment script
   PT Sumi Rubber Indonesia - Purchasing / MIS
   ----------------------------------------------------------------------------
   Scope   : INF (Information / Donation), DAA (Disposal),
             BRE (Reclass Budget), ADD (Additional Budget)

   Nothing that already exists is altered. The legacy Expense /
   Investment flow keeps running untouched.

     Written to  : AFA_SIGNATURE (approval nodes), AFA_Log (history)
     Read only   : AFA_Bulan_Alias, AFA_Jenis_Urut, AFA_JAB_SIGN,
                   AFA_Employee_GTAS, BUDGET_CURR_RATE, User_H,
                   User_Email, AFA_CONFIG, IFSAPP via SURILINK
     New objects : everything prefixed AFA_NON_IFS / AFA_NonIFS,
                   plus the AFA_TYPE, AFA_SUB_TYPE, AFA_LOCATION,
                   AFA_DEPARTMENT, AFA_DEPARTMENT_USER and
                   AFA_SRI_RULE masters

   Conventions
     - @Status ('SUCCESS' / 'FAILED') and @Message are always the
       last two parameters, because SQLOLEDB binds by position and
       ClassKoneksi appends them after the inputs
     - no parameter has a default value, for the same reason
     - every write procedure uses TRY/CATCH with rollback

   Run order is top to bottom. The script is re-runnable: masters
   are only seeded when empty and procedures are dropped first.
   ============================================================================ */

USE AFASYS;
GO
SET NOCOUNT ON;
GO


SECTION 1 - MASTER TABLES
   ============================================================================ */

IF OBJECT_ID('dbo.AFA_TYPE','U') IS NULL
CREATE TABLE dbo.AFA_TYPE (
    CODE        varchar(10)   NOT NULL,
    NAME        varchar(100)  NOT NULL,
    DESCR       varchar(1000) NULL,
    IS_ACTIVE   bit           NOT NULL CONSTRAINT DF_AFA_TYPE_ACTIVE DEFAULT (1),
    DATECREATE  datetime      NOT NULL CONSTRAINT DF_AFA_TYPE_DC     DEFAULT (GETDATE()),
    CONSTRAINT PK_AFA_TYPE PRIMARY KEY (CODE)
);
GO

IF OBJECT_ID('dbo.AFA_LOCATION','U') IS NULL
CREATE TABLE dbo.AFA_LOCATION (
    CODE        varchar(10)  NOT NULL,
    NAME        varchar(100) NOT NULL,
    DESCR       varchar(500) NULL,
    IS_ACTIVE   bit          NOT NULL CONSTRAINT DF_AFA_LOC_ACTIVE DEFAULT (1),
    DATECREATE  datetime     NOT NULL CONSTRAINT DF_AFA_LOC_DC     DEFAULT (GETDATE()),
    CONSTRAINT PK_AFA_LOCATION PRIMARY KEY (CODE)
);
GO

/* Sub-types of INF and DAA. One master for both, filtered by AFA_TYPE,
   so the form only needs a single lookup procedure. */
IF OBJECT_ID('dbo.AFA_SUB_TYPE','U') IS NULL
CREATE TABLE dbo.AFA_SUB_TYPE (
    AFA_TYPE    varchar(10)  NOT NULL,
    CODE        varchar(10)  NOT NULL,
    NAME        varchar(200) NOT NULL,
    SEQ         int          NOT NULL,
    IS_ACTIVE   bit          NOT NULL CONSTRAINT DF_AST_ACTIVE DEFAULT (1),
    DATECREATE  datetime     NOT NULL CONSTRAINT DF_AST_DC     DEFAULT (GETDATE()),
    CONSTRAINT PK_AFA_SUB_TYPE PRIMARY KEY (AFA_TYPE, CODE),
    CONSTRAINT FK_AST_TYPE FOREIGN KEY (AFA_TYPE) REFERENCES dbo.AFA_TYPE(CODE)
);
GO

/* PREFIX is NOT unique - six departments share 'HRD'. DEPT_ID is the key. */
IF OBJECT_ID('dbo.AFA_DEPARTMENT','U') IS NULL
BEGIN
    CREATE TABLE dbo.AFA_DEPARTMENT (
        DEPT_ID     int           NOT NULL,
        DEPT_NAME   nvarchar(150) NOT NULL,
        PREFIX      varchar(10)   NOT NULL,
        IS_ACTIVE   bit           NOT NULL CONSTRAINT DF_AFA_DEPT_ACTIVE DEFAULT (1),
        DATECREATE  datetime      NOT NULL CONSTRAINT DF_AFA_DEPT_DC     DEFAULT (GETDATE()),
        USERUPDATE  varchar(50)   NULL,
        DATEUPDATE  datetime      NULL,
        CONSTRAINT PK_AFA_DEPARTMENT PRIMARY KEY (DEPT_ID)
    );

    CREATE INDEX IX_AFA_DEPARTMENT_NAME   ON dbo.AFA_DEPARTMENT (DEPT_NAME);
    CREATE INDEX IX_AFA_DEPARTMENT_PREFIX ON dbo.AFA_DEPARTMENT (PREFIX);
    CREATE UNIQUE INDEX UX_AFA_DEPARTMENT_NAME_PREFIX
        ON dbo.AFA_DEPARTMENT (DEPT_NAME, PREFIX);
END
GO

/* Which departments a drafter may raise an AFA for. The department
   prefix becomes part of the AFA number, so this is an access control,
   not a convenience. */
IF OBJECT_ID('dbo.AFA_DEPARTMENT_USER','U') IS NULL
BEGIN
    CREATE TABLE dbo.AFA_DEPARTMENT_USER (
        DEPT_ID int         NOT NULL,
        NIK     varchar(10) NOT NULL,
        CONSTRAINT PK_AFA_DEPARTMENT_USER PRIMARY KEY (DEPT_ID, NIK),
        CONSTRAINT FK_ADU_DEPT FOREIGN KEY (DEPT_ID)
            REFERENCES dbo.AFA_DEPARTMENT(DEPT_ID)
    );

    CREATE INDEX IX_AFA_DEPARTMENT_USER_NIK ON dbo.AFA_DEPARTMENT_USER (NIK);
END
GO

/* One row per AFA type and sub-type. Holds the SRI threshold and the
   default authorised signer, which points at the existing AFA_JAB_SIGN
   position master. */
IF OBJECT_ID('dbo.AFA_SRI_RULE','U') IS NULL
CREATE TABLE dbo.AFA_SRI_RULE (
    AFA_TYPE       varchar(10)   NOT NULL,
    SUB_TYPE       varchar(10)   NOT NULL,   -- '*' when the type has none
    SRI_ALWAYS     bit           NOT NULL CONSTRAINT DF_SRI_ALW DEFAULT (0),
    SRI_THRESHOLD  numeric(18,3) NULL,       -- JPY; SRI Need when AMT_JPY exceeds it
    REF_REG        varchar(100)  NULL,
    AUTH1_JAB      varchar(50)   NULL,
    AUTH2_JAB      varchar(50)   NULL,
    IS_ACTIVE      bit           NOT NULL CONSTRAINT DF_SRI_ACT DEFAULT (1),
    DATECREATE     datetime      NOT NULL CONSTRAINT DF_SRI_DC  DEFAULT (GETDATE()),
    USERUPDATE     varchar(50)   NULL,
    DATEUPDATE     datetime      NULL,
    CONSTRAINT PK_AFA_SRI_RULE PRIMARY KEY (AFA_TYPE, SUB_TYPE),
    CONSTRAINT FK_SRI_TYPE  FOREIGN KEY (AFA_TYPE)  REFERENCES dbo.AFA_TYPE(CODE),
    /* AUTH1_JAB and AUTH2_JAB hold a position from AFA_JAB_SIGN, but no
       foreign key is declared: that legacy table has no primary key on
       Jabatan, and adding one would mean altering a table this module
       is not allowed to touch. Section 10 checks the values instead. */
    /* three valid shapes: always SRI, threshold based, or never SRI */
    CONSTRAINT CK_SRI_SHAPE CHECK (SRI_ALWAYS = 0 OR SRI_THRESHOLD IS NULL)
);
GO


/* ============================================================================
   SECTION 2 - MASTER SEED DATA
   Only inserted when the table is still empty, so re-running is safe.
   ============================================================================ */

IF NOT EXISTS (SELECT 1 FROM dbo.AFA_TYPE)
INSERT INTO dbo.AFA_TYPE (CODE, NAME, DESCR) VALUES
 ('INF', 'Information / Donation',     N'AFA untuk informasi tertentu maupun aktivitas donasi perusahaan. Jenis spesifiknya dipilih lewat sub-type pada E-Form.'),
 ('DAA', 'Disposal Asset / Non-Asset', N'Penghapusan, pelepasan, penjualan, pemusnahan, atau penghentian penggunaan aset maupun non-aset perusahaan.'),
 ('BRE', 'Reclass Budget',             N'Pengalihan alokasi anggaran antar budget item tanpa penambahan total budget.'),
 ('ADD', 'Additional Budget',          N'Penambahan alokasi budget pada item yang telah disetujui karena kebutuhan aktual melebihi anggaran.');
GO

IF NOT EXISTS (SELECT 1 FROM dbo.AFA_LOCATION)
INSERT INTO dbo.AFA_LOCATION (CODE, NAME, DESCR) VALUES
 ('CKP', 'Cikampek', N'AFA untuk Lokasi Cikampek'),
 ('JKT', 'Jakarta',  N'AFA untuk Lokasi Jakarta');
GO

/* 12 Information sub-types, then 2 Disposal sub-types.
   Donation and Membership live here rather than as separate AFA types. */
IF NOT EXISTS (SELECT 1 FROM dbo.AFA_SUB_TYPE)
INSERT INTO dbo.AFA_SUB_TYPE (AFA_TYPE, CODE, NAME, SEQ) VALUES
 ('INF','DOC', N'Dokumen, saham, rencana bisnis dan lampiran keuangan',  1),
 ('INF','SEC', N'Investasi, Akuisisi & Pelepasan sekuritas',             2),
 ('INF','LOA', N'Pinjaman',                                              3),
 ('INF','COL', N'Agunan',                                                4),
 ('INF','BAD', N'Piutang tak tertagih',                                  5),
 ('INF','PRL', N'Penanganan Pinjaman bermasalah',                        6),
 ('INF','ORG', N'Terkait organisasi',                                    7),
 ('INF','LEG', N'Perkara hukum',                                         8),
 ('INF','CLM', N'Klaim kerugian',                                        9),
 ('INF','DON', N'AFA Donation',                                         10),
 ('INF','MEM', N'AFA Membership / Keanggotaan',                         11),
 ('INF','OTH', N'Others',                                               12),
 ('DAA','FA',  N'Fixed Asset',                                           1),
 ('DAA','INV', N'Inventory',                                             2);
GO

/* SRI thresholds in JPY, from the Mapping Regulation sheet.

   SRI_ALWAYS = 1               always requires SRI
   SRI_THRESHOLD set            SRI when the amount exceeds it
   both NULL / 0                never requires SRI

   President Director signs every document as the authorised approver;
   AUTH2_JAB is left NULL because the mapping sheet's second default
   authority appears in the Direct Signature chain, not here. */
IF NOT EXISTS (SELECT 1 FROM dbo.AFA_SRI_RULE)
INSERT INTO dbo.AFA_SRI_RULE (AFA_TYPE, SUB_TYPE, SRI_ALWAYS, SRI_THRESHOLD, AUTH1_JAB) VALUES
 ('INF','DOC', 1, NULL,      'President Director'),
 ('INF','SEC', 0, 50000000,  'President Director'),
 ('INF','LOA', 0, 200000000, 'President Director'),
 ('INF','COL', 0, 50000000,  'President Director'),
 ('INF','BAD', 0, 5000000,   'President Director'),
 ('INF','PRL', 0, 100000000, 'President Director'),
 ('INF','ORG', 1, NULL,      'President Director'),
 ('INF','LEG', 0, 100000000, 'President Director'),
 ('INF','CLM', 0, 100000000, 'President Director'),
 ('INF','DON', 0, 5000000,   'President Director'),
 ('INF','MEM', 0, 5000000,   'President Director'),
 ('INF','OTH', 0, NULL,      'President Director'),
 ('DAA','FA',  0, 50000000,  'President Director'),
 ('DAA','INV', 0, 10000000,  'President Director'),
 ('BRE','*',   0, NULL,      'President Director'),
 ('ADD','*',   0, 10000000,  'President Director'),
 /* Wildcard rows for the two types that do have sub-types. They apply
    only while the detail row is still missing, so the strictest value
    of the type is used and no document slips through under-flagged. */
 ('INF','*',   1, NULL,      'President Director'),
 ('DAA','*',   0, 10000000,  'President Director');
GO

/* 85 departments. PREFIX repeats across departments by design. */
IF NOT EXISTS (SELECT 1 FROM dbo.AFA_DEPARTMENT)
INSERT INTO dbo.AFA_DEPARTMENT (DEPT_ID, DEPT_NAME, PREFIX) VALUES
 (1, N'LABOR (COMMON) SGA', 'HRD'),
 (2, N'HRD - TYRE', 'HRD'),
 (3, N'LABOR (DIRECT) GB #1', 'HRD'),
 (4, N'LABOR (INDIRECT) GB #1', 'HRD'),
 (5, N'LABOR (WELFARE) D/I GB #1', 'HRD'),
 (6, N'HRD -  GB #1', 'HRD'),
 (7, N'GA - SGA', 'GAJ'),
 (8, N'GA - TYRE', 'GAC'),
 (9, N'GA - GB #1', 'GAC'),
 (10, N'SAFETY & ENVIRONMENT - SGA', 'SFT'),
 (11, N'SAFETY & ENVIRONMENT - TYRE', 'SFT'),
 (12, N'GENERAL ACCOUNTING', 'ACT'),
 (13, N'COST & BUDGET - TYRE', 'CB'),
 (14, N'COST & BUDGET - GB #1', 'CB'),
 (15, N'FINANCE', 'FIN'),
 (16, N'PLANNING, & PROD.CONTROL', 'PPT'),
 (17, N'PPC - RAW MATERIAL TYRE', 'PMT'),
 (18, N'PPC - GOLF BALL #1', 'PG1'),
 (19, N'PPC - GOLF BALL #1', 'PG'),
 (20, N'PPC - GOLF BALL #2', 'PG2'),
 (21, N'WORK TECHNICAL', 'WTC'),
 (22, N'PRODUCTION', 'PRD'),
 (23, N'(P1) OFFICE', 'PR1'),
 (24, N'(P2) OFFICE', 'PR2'),
 (25, N'(P3) OFFICE', 'PR3'),
 (26, N'(P4) OFFICE', 'PR4'),
 (27, N'(P5) OFFICE', 'PR5'),
 (28, N'PROD. GB DIRECT #1', 'PDG'),
 (29, N'PROD. GB DIRECT #1', 'PDG1'),
 (30, N'PROD. GB DIRECT #2', 'PDG2'),
 (31, N'PROD. GB INDIRECT #1', 'PID'),
 (32, N'PROD. GB INDIRECT #1', 'PIG1'),
 (33, N'PROD. GB INDIRECT #2', 'PIG2'),
 (34, N'PURCHASING - TYRE', 'PUR'),
 (35, N'PURCHASING - GB #1', 'G1P'),
 (36, N'PURCHASING - GB #2', 'G2P'),
 (37, N'QUALITY ASSURANCE', 'QAS'),
 (38, N'QUALITY CONTROL', 'QCT'),
 (39, N'TECHNICAL', 'QTC'),
 (40, N'AUDIT OFFICE', 'ADO'),
 (41, N'MANAGEMENT(SGA)', 'MNG'),
 (42, N'MANAGEMENT(MFG- TYRE)', 'MNG'),
 (43, N'MANAGEMENT(MFG - GB) #1', 'MNG'),
 (44, N'MIS', 'MIS'),
 (45, N'WAREHOUSE COMMON', 'WHC'),
 (46, N'WAREHOUSE 1', 'WH1'),
 (47, N'WAREHOUSE 2', 'WH2'),
 (48, N'WAREHOUSE 3', 'WHR'),
 (49, N'Warehouse (Outside)', 'WHO'),
 (50, N'COMMON/FACTORY', 'ETE'),
 (51, N'ENG. DEVELOPMENT STAFF TYRE', 'ENGT'),
 (52, N'ENG. DEVELOPMENT STAFF GB#1', 'ENGB'),
 (53, N'ENG. DEVELOPMENT STAFF GB#2', 'EGS2'),
 (54, N'ENG. MAINT. COMMON TYRE', 'ETMS'),
 (55, N'ENG. MAINT. 1', 'ETM1'),
 (56, N'ENG. MAINT. 2', 'ETM2'),
 (57, N'ENG. MAINT. 3', 'ETM3'),
 (58, N'ENG. MAINT. ME', 'ETME'),
 (59, N'ENG. MAINT.UTILITY TYRE', 'ETU'),
 (60, N'ENG. M.UTILITY - GENERATOR', 'ETUG'),
 (61, N'ENG. M.UTILITY - BOILER', 'ETUB'),
 (62, N'ENG. M. UTILITY - COMPRESSOR', 'ETUM'),
 (63, N'ENG. M. UTILITY - CHILLER', 'ETUC'),
 (64, N'ENG. M. TOOLS MOULD & DIES', 'ETMM'),
 (65, N'ENG. MAINT.UTILITY G/B #1', 'EGU1'),
 (66, N'ENG. M. UTILITY - COMPRESSOR G/B #1', 'EGM1'),
 (67, N'ENG. M. UTILITY - CHILLER G/B #1', 'EGC1'),
 (68, N'ENG. MAINT.UTILITY G/B #2', 'EGU2'),
 (69, N'ENG. M. UTILITY - COMPRESSOR G/B #2', 'EGM2'),
 (70, N'ENG. M. UTILITY - CHILLER G/B #2', 'EGC2'),
 (71, N'ENG. MAINTENANCE - GB #1', 'ENG'),
 (72, N'ENG. MAINTENANCE - GB #1', 'EGM1'),
 (73, N'ENG. MAINTENANCE - GB #2', 'EGM2'),
 (74, N'ENG. MAINT.UTILITY G/B #1', 'ENG'),
 (75, N'ENG. FOR OTHER DIVISION - TYRE', 'ENT'),
 (76, N'ENG. FOR OTHER DIVISION - GB #1', 'ENG'),
 (77, N'Factory Automation Tyre', 'FAT'),
 (78, N'Factory Automation GB#1', 'FAG'),
 (79, N'MARKETING & SALES PLANNING', 'MKT'),
 (80, N'SALES REPLACEMENT', 'REP'),
 (81, N'SALES EXPORT', 'EXP'),
 (82, N'SALES ADMIN. & DISTRIBUTION', 'LOG'),
 (83, N'SALES OE', 'OEM'),
 (84, N'TECHNICAL SERVICE', 'TES');
/* DEPT_ID 85 in the source sheet repeated SALES REPLACEMENT / REP,
   which the unique index on (DEPT_NAME, PREFIX) rejects. It is left
   out here as a straight duplicate of DEPT_ID 80. */
GO


/* ============================================================================


SECTION 3 - TRANSACTION TABLES
   ============================================================================ */

IF OBJECT_ID('dbo.AFA_NON_IFS','U') IS NULL
BEGIN
    CREATE TABLE dbo.AFA_NON_IFS (
        AFA_NO              varchar(50)   NOT NULL,
        AFA_NO_APPROVAL     varchar(50)   NULL,
        AFA_TYPE            varchar(10)   NOT NULL,
        AFA_LOCATION        varchar(10)   NOT NULL,
        DEPT_ID             int           NOT NULL,

        BUDGET_YEAR         varchar(10)   NULL,
        BUDGET_REV          varchar(10)   NULL,

        SUBJECT             varchar(500)  NULL,
        PURPOSES            varchar(max)  NULL,
        BG_EXPLANATION      varchar(max)  NULL,
        NOTETEXT            varchar(max)  NULL,

        AFA_DATE            date          NULL,
        AFA_PER_FROM        date          NULL,
        AFA_PER_TO          date          NULL,
        AFA_APPROVAL_DATE   date          NULL,
        FINANCE_DATE        date          NULL,

        CURCODE             varchar(10)   NOT NULL CONSTRAINT DF_ANI_CUR  DEFAULT ('USD'),
        AMT                 numeric(18,3) NULL,
        AMT_JPY             numeric(18,3) NULL,
        CUR_RATE            numeric(18,9) NULL,
        RATE_DATE           date          NULL,

        PRIORITY            tinyint       NOT NULL CONSTRAINT DF_ANI_PRIO DEFAULT (0),
        PRIORITY_REASON     varchar(500)  NULL,
        STS                 varchar(50)   NOT NULL CONSTRAINT DF_ANI_STS  DEFAULT ('Draft'),
        SRI_STS             varchar(20)   NULL,
        REF_REG             varchar(100)  NULL,

        BUDGET_STS          varchar(20)   NULL,
        BUDGET_CHECK_BY     varchar(50)   NULL,
        BUDGET_CHECK_DATE   datetime      NULL,

        USERID              varchar(50)   NULL,
        PC                  varchar(50)   NULL,
        DATECREATE          datetime      NOT NULL CONSTRAINT DF_ANI_DC DEFAULT (GETDATE()),
        USERUPDATE          varchar(50)   NULL,
        DATEUPDATE          datetime      NULL,

        CONSTRAINT PK_AFA_NON_IFS PRIMARY KEY (AFA_NO),
        CONSTRAINT FK_ANI_TYPE FOREIGN KEY (AFA_TYPE)     REFERENCES dbo.AFA_TYPE(CODE),
        CONSTRAINT FK_ANI_LOC  FOREIGN KEY (AFA_LOCATION) REFERENCES dbo.AFA_LOCATION(CODE),
        CONSTRAINT FK_ANI_DEPT FOREIGN KEY (DEPT_ID)      REFERENCES dbo.AFA_DEPARTMENT(DEPT_ID),
        CONSTRAINT CK_ANI_PRIO   CHECK (PRIORITY BETWEEN 0 AND 3),
        CONSTRAINT CK_ANI_BUDSTS CHECK (BUDGET_STS IS NULL OR BUDGET_STS IN ('Checked','Unchecked')),
        CONSTRAINT CK_ANI_SRISTS CHECK (SRI_STS IS NULL OR SRI_STS IN ('Need','No Need')),
        CONSTRAINT CK_ANI_STS    CHECK (STS IN ('Draft','Planned','Approved','Cancelled')),
        CONSTRAINT CK_ANI_PERIOD CHECK (AFA_PER_TO IS NULL OR AFA_PER_FROM IS NULL
                                        OR AFA_PER_TO >= AFA_PER_FROM)
    );

    CREATE UNIQUE INDEX UX_ANI_APPROVAL ON dbo.AFA_NON_IFS (AFA_NO_APPROVAL)
        WHERE AFA_NO_APPROVAL IS NOT NULL;
    CREATE INDEX IX_ANI_MONITOR ON dbo.AFA_NON_IFS (STS, AFA_TYPE, PRIORITY, DATECREATE);
    CREATE INDEX IX_ANI_DRAFTER ON dbo.AFA_NON_IFS (USERID, STS);
END
GO

/* INF detail. AFA_TYPE is a constant computed column so the composite
   foreign key can stop a DAA sub-type ending up on an INF document. */
IF OBJECT_ID('dbo.AFA_NON_IFS_INF','U') IS NULL
CREATE TABLE dbo.AFA_NON_IFS_INF (
    AFA_NO         varchar(50)   NOT NULL,
    SUB_TYPE       varchar(10)   NOT NULL CONSTRAINT DF_INF_SUB DEFAULT ('OTH'),
    CODE_BUDGET    varchar(50)   NULL,     -- required for DON and MEM
    ESTIMATE_COST  numeric(18,3) NOT NULL CONSTRAINT DF_INF_EST DEFAULT (0),
    AFA_TYPE       AS (CAST('INF' AS varchar(10))) PERSISTED,
    CONSTRAINT PK_AFA_NON_IFS_INF PRIMARY KEY (AFA_NO),
    CONSTRAINT FK_INF_H FOREIGN KEY (AFA_NO)
        REFERENCES dbo.AFA_NON_IFS(AFA_NO) ON DELETE CASCADE,
    CONSTRAINT FK_INF_SUB FOREIGN KEY (AFA_TYPE, SUB_TYPE)
        REFERENCES dbo.AFA_SUB_TYPE (AFA_TYPE, CODE)
);
GO

IF OBJECT_ID('dbo.AFA_NON_IFS_DAA','U') IS NULL
/* No asset fields (ASSET_NO, ASSET_DESCR, QTY, UOM, REMARK): a Disposal
   AFA describes the asset in Background & Explanation and in the cover
   attachment, so those columns were dropped. SEQ stays as part of the
   key because the table was already built with it, but a document holds
   exactly one row - the save procedure always writes SEQ = 1. */
CREATE TABLE dbo.AFA_NON_IFS_DAA (
    AFA_NO              varchar(50)   NOT NULL,
    SEQ                 int           NOT NULL,
    SUB_TYPE            varchar(10)   NOT NULL CONSTRAINT DF_DAA_SUB DEFAULT ('FA'),
    ACQUISITION         numeric(18,3) NOT NULL CONSTRAINT DF_DAA_ACQ DEFAULT (0),
    ACCUM_DEPRECIATION  numeric(18,3) NOT NULL CONSTRAINT DF_DAA_DEP DEFAULT (0),
    BOOK_VALUE          AS (ACQUISITION - ACCUM_DEPRECIATION) PERSISTED,
    RESELL_VALUE        numeric(18,3) NOT NULL CONSTRAINT DF_DAA_RES DEFAULT (0),
    PROFIT_LOSS         AS ((ACQUISITION - ACCUM_DEPRECIATION) - RESELL_VALUE) PERSISTED,
    AFA_TYPE            AS (CAST('DAA' AS varchar(10))) PERSISTED,
    CONSTRAINT PK_AFA_NON_IFS_DAA PRIMARY KEY (AFA_NO, SEQ),
    CONSTRAINT FK_DAA_H FOREIGN KEY (AFA_NO)
        REFERENCES dbo.AFA_NON_IFS(AFA_NO) ON DELETE CASCADE,
    CONSTRAINT FK_DAA_SUB FOREIGN KEY (AFA_TYPE, SUB_TYPE)
        REFERENCES dbo.AFA_SUB_TYPE (AFA_TYPE, CODE)
);
GO

/* Reclass: one row per budget item, Source and Target linked through
   RECLASS_FROM_SEQ. IFS keys on year + revision + cost centre +
   contract + allocation, so all five are stored. */
IF OBJECT_ID('dbo.AFA_NON_IFS_BRE','U') IS NULL
BEGIN
    CREATE TABLE dbo.AFA_NON_IFS_BRE (
        AFA_NO            varchar(50)   NOT NULL,
        SEQ               int           NOT NULL,
        ITEM_ROLE         varchar(10)   NOT NULL,
        BUDGET_ITEM_CODE  varchar(50)   NOT NULL,
        BUDGET_ITEM_NAME  varchar(500)  NULL,
        CC                varchar(50)   NULL,
        CONTRACT          varchar(50)   NULL,
        BUDGET_AMOUNT     numeric(18,3) NOT NULL CONSTRAINT DF_BRE_BA DEFAULT (0),
        ACTUAL_UP         numeric(18,3) NOT NULL CONSTRAINT DF_BRE_AU DEFAULT (0),
        ESTIMATION        numeric(18,3) NULL,
        SHORTAGE          numeric(18,3) NULL,
        RECLASS_AMOUNT    numeric(18,3) NULL,
        BALANCE           numeric(18,3) NULL,
        RECLASS_FROM_SEQ  int           NULL,
        IFS_SYNC_DATE     datetime      NULL,
        CONSTRAINT PK_AFA_NON_IFS_BRE PRIMARY KEY (AFA_NO, SEQ),
        CONSTRAINT FK_BRE_H FOREIGN KEY (AFA_NO)
            REFERENCES dbo.AFA_NON_IFS(AFA_NO) ON DELETE CASCADE,
        CONSTRAINT FK_BRE_SRC FOREIGN KEY (AFA_NO, RECLASS_FROM_SEQ)
            REFERENCES dbo.AFA_NON_IFS_BRE(AFA_NO, SEQ),
        CONSTRAINT CK_BRE_ROLE CHECK (ITEM_ROLE IN ('Source','Target')),
        CONSTRAINT CK_BRE_SHAPE CHECK (
            (ITEM_ROLE = 'Source' AND RECLASS_FROM_SEQ IS NULL)
         OR (ITEM_ROLE = 'Target' AND RECLASS_FROM_SEQ IS NOT NULL))
    );

    CREATE INDEX IX_BRE_ITEM ON dbo.AFA_NON_IFS_BRE (BUDGET_ITEM_CODE);
END
GO

IF OBJECT_ID('dbo.AFA_NON_IFS_ADD','U') IS NULL
BEGIN
    CREATE TABLE dbo.AFA_NON_IFS_ADD (
        AFA_NO            varchar(50)   NOT NULL,
        SEQ               int           NOT NULL,
        BUDGET_ITEM_CODE  varchar(50)   NOT NULL,
        BUDGET_ITEM_NAME  varchar(500)  NULL,
        CC                varchar(50)   NULL,
        CONTRACT          varchar(50)   NULL,
        BUDGET_AMOUNT     numeric(18,3) NOT NULL CONSTRAINT DF_ADD_BA DEFAULT (0),
        ACTUAL_UP         numeric(18,3) NOT NULL CONSTRAINT DF_ADD_AU DEFAULT (0),
        ESTIMATION        numeric(18,3) NOT NULL CONSTRAINT DF_ADD_ES DEFAULT (0),
        SHORTAGE          AS (BUDGET_AMOUNT - ACTUAL_UP - ESTIMATION) PERSISTED,
        IFS_SYNC_DATE     datetime      NULL,
        CONSTRAINT PK_AFA_NON_IFS_ADD PRIMARY KEY (AFA_NO, SEQ),
        CONSTRAINT FK_ADD_H FOREIGN KEY (AFA_NO)
            REFERENCES dbo.AFA_NON_IFS(AFA_NO) ON DELETE CASCADE
    );

    CREATE INDEX IX_ADD_ITEM ON dbo.AFA_NON_IFS_ADD (BUDGET_ITEM_CODE);
END
GO

/* Cover plus supporting files, so no per-department table is needed. */
IF OBJECT_ID('dbo.AFA_NON_IFS_ATTACHMENT','U') IS NULL
BEGIN
    CREATE TABLE dbo.AFA_NON_IFS_ATTACHMENT (
        AFA_NO      varchar(50)  NOT NULL,
        SEQ         int          NOT NULL,
        TYPE        varchar(20)  NOT NULL CONSTRAINT DF_ATT_TYPE DEFAULT ('Lampiran'),
        FILE_PATH   varchar(500) NOT NULL,
        CAPTION     varchar(500) NULL,
        NIK         varchar(50)  NULL,
        DateCreate  datetime     NOT NULL CONSTRAINT DF_ATT_DC DEFAULT (GETDATE()),
        CONSTRAINT PK_AFA_NON_IFS_ATTACHMENT PRIMARY KEY (AFA_NO, SEQ),
        CONSTRAINT FK_ATT_H FOREIGN KEY (AFA_NO)
            REFERENCES dbo.AFA_NON_IFS(AFA_NO) ON DELETE CASCADE,
        CONSTRAINT CK_ATT_TYPE CHECK (TYPE IN ('Cover','Lampiran'))
    );

    CREATE UNIQUE INDEX UX_ATT_COVER ON dbo.AFA_NON_IFS_ATTACHMENT (AFA_NO)
        WHERE TYPE = 'Cover';
END
GO

/* Running number, reset per AFA type per year. */
IF OBJECT_ID('dbo.AFA_NON_IFS_SEQ','U') IS NULL
CREATE TABLE dbo.AFA_NON_IFS_SEQ (
    AFA_TYPE     varchar(10) NOT NULL,
    PERIOD_YEAR  int         NOT NULL,
    LAST_SEQ     int         NOT NULL CONSTRAINT DF_ANISEQ_LAST DEFAULT (0),
    DATEUPDATE   datetime    NULL,
    CONSTRAINT PK_AFA_NON_IFS_SEQ PRIMARY KEY (AFA_TYPE, PERIOD_YEAR)
);
GO


/* AFA_NO_APPROVAL counter - independent from AFA_NO_SEQ above.
   Keyed by the YEAR THE APPROVAL HAPPENED, not the document's creation
   year. See AFA_NonIFS_GenerateApprovalNumber_Proc: this is only touched
   at the moment a document becomes fully approved, never at creation,
   and a value is never reused once issued (a real sequence, gaps on
   rollback/un-approve are expected and correct). */
CREATE TABLE dbo.AFA_NON_IFS_APPROVAL_SEQ (
    AFA_TYPE     varchar(10) NOT NULL,
    PERIOD_YEAR  int         NOT NULL,
    LAST_SEQ     int         NOT NULL CONSTRAINT DF_ANIASEQ_LAST DEFAULT (0),
    DATEUPDATE   datetime    NULL,
    CONSTRAINT PK_AFA_NON_IFS_APPROVAL_SEQ PRIMARY KEY (AFA_TYPE, PERIOD_YEAR)
);
GO


/* ============================================================================
   SECTION 4 - MONITORING VIEW
   The latest approver is derived at read time from AFA_SIGNATURE rather
   than stored, so no trigger is placed on that shared table.
   ============================================================================ */

IF OBJECT_ID('dbo.V_AFA_NON_IFS_MONITORING','V') IS NOT NULL
    DROP VIEW dbo.V_AFA_NON_IFS_MONITORING;
GO

CREATE VIEW dbo.V_AFA_NON_IFS_MONITORING AS
SELECT
     h.AFA_NO
    ,h.AFA_NO_APPROVAL
    ,h.AFA_TYPE
    ,t.NAME                AS AFA_TYPE_NAME
    ,sub.SUB_TYPE
    ,sub.SUB_TYPE_NAME
    ,h.AFA_LOCATION
    ,l.NAME                AS LOCATION_NAME
    ,h.DEPT_ID
    ,d.DEPT_NAME
    ,d.PREFIX              AS DEPT_PREFIX
    ,h.SUBJECT
    ,h.BUDGET_YEAR
    ,h.CURCODE
    ,h.AMT
    ,h.AMT_JPY
    ,h.SRI_STS
    ,h.REF_REG
    ,h.PRIORITY
    ,CASE h.PRIORITY WHEN 1 THEN 'Important'
                     WHEN 2 THEN 'Urgent'
                     WHEN 3 THEN 'Top Priority'
                     ELSE '' END AS PRIORITY_LABEL
    ,h.PRIORITY_REASON
    ,h.STS
    ,h.BUDGET_STS
    ,h.BUDGET_CHECK_BY
    ,h.BUDGET_CHECK_DATE
    ,h.USERID              AS CREATED_NIK
    ,u.Name                AS CREATED_BY
    ,h.DATECREATE          AS CREATED_DATE
    ,sg.DATEAPP            AS LATEST_APPROVAL_DATE
    ,sg.NAMA               AS LATEST_APPROVED_BY
    ,sg.JAB                AS LATEST_APPROVED_JAB
    ,nx.NAMA               AS PENDING_AT
    ,nx.JAB                AS PENDING_AT_JAB
    ,pr.TOTAL_NODE
    ,pr.APPROVED_NODE
FROM dbo.AFA_NON_IFS h
LEFT JOIN dbo.AFA_TYPE       t ON t.CODE    = h.AFA_TYPE
LEFT JOIN dbo.AFA_LOCATION   l ON l.CODE    = h.AFA_LOCATION
LEFT JOIN dbo.AFA_DEPARTMENT d ON d.DEPT_ID = h.DEPT_ID
LEFT JOIN dbo.User_H         u ON u.UserID  = h.USERID
OUTER APPLY (
    SELECT TOP 1 x.SUB_TYPE, s.NAME AS SUB_TYPE_NAME
    FROM (
        SELECT AFA_NO, SUB_TYPE, AFA_TYPE FROM dbo.AFA_NON_IFS_INF
        UNION ALL
        SELECT AFA_NO, SUB_TYPE, AFA_TYPE FROM dbo.AFA_NON_IFS_DAA
    ) x
    LEFT JOIN dbo.AFA_SUB_TYPE s
           ON s.AFA_TYPE = x.AFA_TYPE AND s.CODE = x.SUB_TYPE
    WHERE x.AFA_NO = h.AFA_NO
) sub
OUTER APPLY (
    SELECT TOP 1 s.NAMA, s.JAB, s.DATEAPP
    FROM   dbo.AFA_SIGNATURE s
    WHERE  s.AFA_NO = h.AFA_NO AND s.STS = 'App' AND s.DATEAPP IS NOT NULL
    ORDER  BY s.DATEAPP DESC
) sg
OUTER APPLY (
    SELECT TOP 1 s.NAMA, s.JAB
    FROM   dbo.AFA_SIGNATURE s
    LEFT   JOIN dbo.AFA_Jenis_Urut j ON j.Jenis = s.TYPE
    WHERE  s.AFA_NO = h.AFA_NO AND s.STS = 'Send' AND ISNULL(s.NIK,'') <> ''
    ORDER  BY j.urut ASC, s.ID ASC
) nx
OUTER APPLY (
    SELECT COUNT(*) AS TOTAL_NODE,
           SUM(CASE WHEN s.STS IN ('App','Skip') THEN 1 ELSE 0 END) AS APPROVED_NODE
    FROM   dbo.AFA_SIGNATURE s
    WHERE  s.AFA_NO = h.AFA_NO AND ISNULL(s.NIK,'') <> ''
) pr;
GO


/* ============================================================================


IF OBJECT_ID('dbo.V_AFA_NON_IFS_UNCONFIGURED','V') IS NOT NULL
    DROP VIEW dbo.V_AFA_NON_IFS_UNCONFIGURED;
GO

CREATE VIEW dbo.V_AFA_NON_IFS_UNCONFIGURED AS
SELECT
     h.AFA_NO
    ,h.AFA_TYPE
    ,t.NAME                AS AFA_TYPE_NAME
    ,sub.SUB_TYPE_NAME
    ,h.DEPT_ID
    ,d.DEPT_NAME
    ,d.PREFIX              AS DEPT_PREFIX
    ,h.SUBJECT
    ,h.PRIORITY
    ,CASE h.PRIORITY WHEN 1 THEN 'Important'
                     WHEN 2 THEN 'Urgent'
                     WHEN 3 THEN 'Top Priority'
                     ELSE '' END AS PRIORITY_LABEL
    ,h.USERID              AS CREATED_NIK
    ,u.Name                AS CREATED_BY
    ,h.DATECREATE          AS CREATED_DATE
    ,DATEDIFF(day, h.DATECREATE, GETDATE()) AS DAYS_IN_DRAFT
    ,cnt.FILLED_NODES
    ,cnt.HAS_SUPP
    ,cnt.HAS_DIR
FROM   dbo.AFA_NON_IFS h
LEFT   JOIN dbo.AFA_TYPE       t ON t.CODE    = h.AFA_TYPE
LEFT   JOIN dbo.AFA_DEPARTMENT d ON d.DEPT_ID = h.DEPT_ID
LEFT   JOIN dbo.User_H         u ON u.UserID  = h.USERID
OUTER  APPLY (
    SELECT TOP 1 x.SUB_TYPE_NAME
    FROM (
        SELECT i.AFA_NO, s.NAME AS SUB_TYPE_NAME
        FROM   dbo.AFA_NON_IFS_INF i
        LEFT   JOIN dbo.AFA_SUB_TYPE s ON s.AFA_TYPE = 'INF' AND s.CODE = i.SUB_TYPE
        UNION ALL
        SELECT dd.AFA_NO, s.NAME
        FROM   dbo.AFA_NON_IFS_DAA dd
        LEFT   JOIN dbo.AFA_SUB_TYPE s ON s.AFA_TYPE = 'DAA' AND s.CODE = dd.SUB_TYPE
    ) x
    WHERE  x.AFA_NO = h.AFA_NO
) sub
OUTER  APPLY (
    SELECT
         COUNT(*)                                          AS FILLED_NODES
        ,MAX(CASE WHEN s.TYPE = 'Supp' THEN 1 ELSE 0 END)   AS HAS_SUPP
        ,MAX(CASE WHEN s.TYPE = 'Dir'  THEN 1 ELSE 0 END)   AS HAS_DIR
    FROM   dbo.AFA_SIGNATURE s
    WHERE  s.AFA_NO = h.AFA_NO AND ISNULL(s.NIK,'') <> ''
) cnt
WHERE  h.STS = 'Draft';
GO


IF OBJECT_ID('dbo.V_MASTER_EMPLOYEE','V') IS NOT NULL
    DROP VIEW dbo.V_MASTER_EMPLOYEE;
GO

CREATE VIEW dbo.V_MASTER_EMPLOYEE AS
SELECT * FROM dbo.master_employee;
GO
