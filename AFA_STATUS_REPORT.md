# AFA Non-IFS Module — Status Report

Laporan ini murni hasil pembacaan kode (read-only), tidak ada file yang diubah.
Cakupan: modul BARU (INF/DAA/BRE/ADD + form pendukung) dengan prefix
`XtraFormAFA*`, `Services/*`, dan SP `AFA_NonIFS_*`. Modul lama
Expense/Investment (AFA_H/AFA_ALOC/AFA_Purch_Budget) tidak disentuh — lihat
bagian terakhir.

---

## 1. Tabel Status: Modul x Fitur

| Modul | E-Form (input) | Signature (approver + attachment) | Service |
|---|---|---|---|
| **INF** — Information/Donation | ✅ Selesai — [XtraFormAFAInfEF.vb](AFASYSTEM/XtraFormAFAInfEF.vb) lengkap: load combo, validasi, save header/detail/attachment | ✅ Selesai — [XtraFormAFAInfSign.vb](AFASYSTEM/XtraFormAFAInfSign.vb) lengkap: grid approver, priority, 2 slot attachment, submit. Satu tombol placeholder ("View AFA" → lihat §4) | ✅ Selesai — [AFAInformationService.vb](AFASYSTEM/Services/AFAInformationService.vb) 5 method |
| **DAA** — Disposal Asset/Non-Asset | ✅ Selesai — [XtraFormAFADaaEForm.vb](AFASYSTEM/XtraFormAFADaaEForm.vb) lengkap, termasuk kalkulasi Book Value/Profit-Loss otomatis + ApplySRI setelah save | ✅ Selesai — [XtraFormAFADaaSign.vb](AFASYSTEM/XtraFormAFADaaSign.vb) lengkap, pola sama dengan INF Sign. Tombol "View AFA" juga placeholder | ✅ Selesai — [AFADisposalService.vb](AFASYSTEM/Services/AFADisposalService.vb) 4 method |
| **BRE** — Reclass Budget | ⚠️ Sebagian — Designer sudah punya 48 kontrol (TextEditBudgetYear, TextEditReclassAmount, TextEditBalanceTarget, TextEditShortageSource, BtnSave, dst) tapi [XtraFormAFABreEForm.vb](AFASYSTEM/XtraFormAFABreEForm.vb) kosong total, tidak ada satu pun event handler | ⚠️ Sebagian — Designer 47 kontrol, [XtraFormAFABreSign.vb](AFASYSTEM/XtraFormAFABreSign.vb) kosong total | ❌ Belum Ada — [AFAReclassBudgetService.vb](AFASYSTEM/Services/AFAReclassBudgetService.vb) hanya `Public Class ... End Class` |
| **ADD** — Additional Budget | ⚠️ Sebagian — Designer 41 kontrol, [XtraFormAFAAddEForm.vb](AFASYSTEM/XtraFormAFAAddEForm.vb) kosong total | ⚠️ Sebagian — Designer 33 kontrol, [XtraFormAFAAddSign.vb](AFASYSTEM/XtraFormAFAAddSign.vb) kosong total | ❌ Belum Ada — [AFAAdditionalBudgetService.vb](AFASYSTEM/Services/AFAAdditionalBudgetService.vb) hanya stub |

Catatan tambahan (lintas modul, bukan per-tipe AFA):

| Form/Service pendukung | Status | Catatan |
|---|---|---|
| [XtraFormAFAApproval.vb](AFASYSTEM/XtraFormAFAApproval.vb) | ✅ Selesai | Grid pending approval, bulk approve, unapprove, skip, checkbox multi-select. Tombol "View AFA" placeholder (§4). **Belum dipanggil dari FormFluMenu** (§4) |
| [XtraFormAFAMonitoring.vb](AFASYSTEM/XtraFormAFAMonitoring.vb) | ✅ Selesai | Filter status & type, scope elevated vs non-elevated berdasarkan level user. **Belum dipanggil dari FormFluMenu** (§4) |
| [XtraFormDepartment.vb](AFASYSTEM/XtraFormDepartment.vb) | ⚠️ Sebagian | Load & tampil grid department jalan; tombol Save/Update cuma `XtraMessageBox.Show("Fitur simpan belum tersedia.")` (§4) |
| [XtraFormUserDepartments.vb](AFASYSTEM/XtraFormUserDepartments.vb) | ✅ Selesai | CRUD mapping user-department lengkap (load, save/update, clear, refresh) |
| [XtraFormUnconfiguredDocuments.vb](AFASYSTEM/XtraFormUnconfiguredDocuments.vb) | ✅ Selesai | Grid dokumen yang belum ter-assign approver, double-click copy AFA No |
| [AFAMonitoringService.vb](AFASYSTEM/Services/AFAMonitoringService.vb) | ✅ Selesai | 1 method `GetList` + helper statis `IsElevated` |
| [AFASignatureService.vb](AFASYSTEM/Services/AFASignatureService.vb) | ✅ Selesai | 13 method, service paling lengkap di modul ini |
| [UserDepartmentService.vb](AFASYSTEM/Services/UserDepartmentService.vb) | ✅ Selesai | 4 method (GetList, GetByNik, Save, DeleteByNik) — `DeleteByNik` tidak dipanggil dari form manapun |
| [UnconfiguredDocumentsService.vb](AFASYSTEM/Services/UnconfiguredDocumentsService.vb) | ✅ Selesai | 1 method |
| [GeneralService.vb](AFASYSTEM/Services/GeneralService.vb) | ✅ Selesai | Lookup/master data + cache, 13 method publik |
| [BulkApproveResult.vb](AFASYSTEM/Services/BulkApproveResult.vb) | ✅ Selesai | Bukan service DB, cuma value object (result + summary builder) untuk `ApproveMany` |

---

## 2. Daftar Service & Method Publik

### [AFAInformationService.vb](AFASYSTEM/Services/AFAInformationService.vb) — INF
- `SaveHeader(...)` → String (AFA_NO)
- `SaveDetail(...)` → Boolean
- `SaveAttachment(...)` → Boolean
- `GetDetail(afaNo)` → DataTable
- `Submit(afaNo, nik, pc)` → Boolean

### [AFADisposalService.vb](AFASYSTEM/Services/AFADisposalService.vb) — DAA
- `SaveHeader(...)` → String (AFA_NO)
- `SaveDetail(...)` → Boolean
- `SaveAttachment(...)` → Boolean
- `ApplySRI(afaNo)` → String (SRI_STS)

### [AFAReclassBudgetService.vb](AFASYSTEM/Services/AFAReclassBudgetService.vb) — BRE
- *(kosong, tidak ada method)*

### [AFAAdditionalBudgetService.vb](AFASYSTEM/Services/AFAAdditionalBudgetService.vb) — ADD
- *(kosong, tidak ada method)*

### [AFASignatureService.vb](AFASYSTEM/Services/AFASignatureService.vb)
- `GetDocument(afaNo)` → DataTable
- `GetNodes(afaNo)` → DataTable
- `SaveNode(...)` → Boolean
- `UpdatePriority(...)` → Boolean
- `Submit(afaNo, nik, pc)` → Boolean
- `Approve(...)` → Boolean
- `Skip(...)` → Boolean
- `InitNodes(...)` → Boolean
- `SaveAttachment(...)` → Boolean
- `GetAttachments(afaNo)` → DataTable
- `GetApprovers(jenis)` → DataTable
- `GetNodesGrid(afaNo, maxRow)` → DataTable
- `GetDisposalFigures(afaNo)` → DataTable
- `GetPendingApproval(nik)` → DataTable
- `ApproveMany(rows, nik, pc)` → BulkApproveResult

### [AFAMonitoringService.vb](AFASYSTEM/Services/AFAMonitoringService.vb)
- `IsElevated(level)` → Boolean *(Shared)*
- `GetList(...)` → DataTable

### [UserDepartmentService.vb](AFASYSTEM/Services/UserDepartmentService.vb)
- `GetList(keyword)` → DataTable
- `GetByNik(nik)` → DataTable
- `Save(nik, deptIds, nikUpdate, pc)` → Boolean
- `DeleteByNik(nik)` → Boolean

### [UnconfiguredDocumentsService.vb](AFASYSTEM/Services/UnconfiguredDocumentsService.vb)
- `GetList(nik, afaType)` → DataTable

### [GeneralService.vb](AFASYSTEM/Services/GeneralService.vb)
- `ClearCache()` *(Shared)*
- `GetLocations(useCache)` → DataTable
- `GetDepartments(useCache)` → DataTable
- `GetDepartmentsByNik(nik)` → DataTable
- `GetDepartmentPrefix(deptId)` → String
- `GetAfaTypes(useCache)` → DataTable
- `GetSubTypes(afaType, useCache)` → DataTable
- `GetBudgetYears(useCache)` → DataTable
- `GetBudgetRevisions(budgetYear)` → DataTable
- `GetCurrencies(useCache)` → DataTable
- `GetJpyFactor(budgetYear, budgetRev, curCode)` → Decimal?
- `GetPriorities()` → DataTable
- `SearchEmployee(keyword)` → DataTable
- `GetEmployeeName(nik)` → String
- `GetActiveUsers()` → DataTable
- `GetSignatureTypes()` → DataTable

### [BulkApproveResult.vb](AFASYSTEM/Services/BulkApproveResult.vb)
- Class `BulkApproveResult`: properti `TotalAttempted/TotalSucceeded/Failures/TotalFailed`, method `BuildSummary()` → String
- Class `BulkApproveFailure`: properti `AfaNo/Reason`

---

## 3. Daftar Unik Stored Procedure yang Dipanggil dari Kode

Untuk dicocokkan manual dengan database (25 nama):

1. `AFA_NonIFS_SaveHeader_Proc`
2. `AFA_NonIFS_SaveDetail_INF_Proc`
3. `AFA_NonIFS_SaveDetail_DAA_Proc`
4. `AFA_NonIFS_SaveAttachment_Proc`
5. `AFA_NonIFS_GetDetail_Proc`
6. `AFA_NonIFS_Submit_Proc`
7. `AFA_NonIFS_ApplySRI_Proc`
8. `AFA_NonIFS_GetSubType_Proc`
9. `AFA_NonIFS_SearchEmployee_Proc`
10. `AFA_NonIFS_GetActiveUsers_Proc`
11. `AFA_NonIFS_GetUnconfigured_Proc`
12. `AFA_NonIFS_GetUserDepartmentList_Proc`
13. `AFA_NonIFS_GetUserDepartment_Proc`
14. `AFA_NonIFS_SaveUserDepartment_Proc`
15. `AFA_NonIFS_DeleteUserDepartment_Proc`
16. `AFA_NonIFS_GetForSignature_Proc`
17. `AFA_NonIFS_GetSignature_Proc`
18. `AFA_NonIFS_Signature_Proc`
19. `AFA_NonIFS_UpdatePriority_Proc`
20. `AFA_NonIFS_App_Proc`
21. `AFA_NonIFS_Skip_Proc`
22. `AFA_NonIFS_InitSignature_Proc`
23. `AFA_NonIFS_GetSignatureGrid_Proc`
24. `AFA_NonIFS_GetPendingApproval_Proc`
25. `AFA_NonIFS_Monitoring_Proc`

Catatan: BRE dan ADD tidak memanggil SP apa pun karena service-nya masih kosong
— jadi belum ada nama SP `AFA_NonIFS_*Bre*`/`*Add*`/`*Reclass*` yang bisa
dicocokkan untuk kedua tipe tersebut.

---

## 4. Lokasi TODO / Stub / Placeholder

Tidak ditemukan komentar literal `TODO`, `FIXME`, atau `NotImplementedException`
di modul baru. Penanda "belum selesai" yang ditemukan:

| Lokasi | Jenis | Isi |
|---|---|---|
| [Services/AFAReclassBudgetService.vb](AFASYSTEM/Services/AFAReclassBudgetService.vb) | Stub kosong | `Public Class AFAReclassBudgetService : End Class` — tidak ada method |
| [Services/AFAAdditionalBudgetService.vb](AFASYSTEM/Services/AFAAdditionalBudgetService.vb) | Stub kosong | `Public Class AFAAdditionalBudgetService : End Class` — tidak ada method |
| [XtraFormAFABreEForm.vb](AFASYSTEM/XtraFormAFABreEForm.vb) | Stub kosong | Code-behind kosong; Designer sudah punya 48 kontrol siap pakai |
| [XtraFormAFABreSign.vb](AFASYSTEM/XtraFormAFABreSign.vb) | Stub kosong | Code-behind kosong; Designer sudah punya 47 kontrol |
| [XtraFormAFAAddEForm.vb](AFASYSTEM/XtraFormAFAAddEForm.vb) | Stub kosong | Code-behind kosong; Designer sudah punya 41 kontrol |
| [XtraFormAFAAddSign.vb:1-3](AFASYSTEM/XtraFormAFAAddSign.vb) | Stub kosong | Code-behind kosong; Designer sudah punya 33 kontrol |
| [XtraFormAFAInfSign.vb:593](AFASYSTEM/XtraFormAFAInfSign.vb:593) | Placeholder pesan | `BtnViewAFA_Click` → `XtraMessageBox.Show("The document view is not available yet.")` |
| [XtraFormAFADaaSign.vb:512](AFASYSTEM/XtraFormAFADaaSign.vb:512) | Placeholder pesan | `BtnViewAFA_Click` → pesan sama persis |
| [XtraFormAFAApproval.vb:230](AFASYSTEM/XtraFormAFAApproval.vb:230) | Placeholder pesan | `BtnViewAFA_Click` → pesan sama, plus AFA No yang dipilih |
| [XtraFormDepartment.vb:112](AFASYSTEM/XtraFormDepartment.vb:112) | Placeholder pesan | `BtnSaveUpdate_Click` → `XtraMessageBox.Show("Fitur simpan belum tersedia.")` — grid Department read-only, tidak bisa create/edit dari UI |

Temuan tambahan di luar 4 kriteria pencarian di atas, tapi relevan untuk
"belum selesai" secara fungsional:

- **[FormFluMenu.vb](AFASYSTEM/FormFluMenu.vb)** tidak memiliki baris yang membuka
  `XtraFormAFAApproval` atau `XtraFormAFAMonitoring` (dicek dengan grep nama
  form tsb). Kedelapan form E-Form/Signature (INF/DAA/BRE/ADD) sudah dipasang
  ke `PanelControl1` dengan pola `TopLevel=False / Parent / Dock / Show /
  BringToFront`, tapi dua form baru ini belum — jadi meski logic-nya sudah
  selesai, form Approval & Monitoring kemungkinan belum bisa diakses user dari
  menu utama.
- **`UserDepartmentService.DeleteByNik`** ada di service tapi tidak dipanggil
  dari `XtraFormUserDepartments.vb` manapun (tidak ada tombol Delete di form).

---

## 5. Form dengan Potensi Mismatch Code-behind vs Designer

Semua kontrol (`TextEdit*`, `Select*`/`ComboBoxEdit*`, `Btn*`, `GridControl*`,
`GridView*`, `MemoEdit*`, `DateEdit*`, `PictureEdit*`, `ButtonEdit*`,
`CheckedComboDepartments`) yang dirujuk di code-behind untuk form-form berikut
sudah dicocokkan satu per satu terhadap deklarasi `Friend WithEvents` di
Designer.vb pasangannya:

- XtraFormAFAInfEF, XtraFormAFAInfSign
- XtraFormAFADaaEForm, XtraFormAFADaaSign
- XtraFormAFAApproval, XtraFormAFAMonitoring
- XtraFormDepartment, XtraFormUserDepartments, XtraFormUnconfiguredDocuments

**Tidak ditemukan mismatch** — setiap nama kontrol yang dipakai di code-behind
punya deklarasi yang cocok di Designer, jadi tidak ada indikasi form-form ini
akan gagal kompilasi karena kontrol hilang.

XtraFormAFABreEForm/BreSign/AddEForm/AddSign tidak bisa diperiksa untuk
mismatch karena code-behind-nya kosong (tidak ada referensi kontrol sama
sekali untuk dibandingkan).

---

## 6. Form/Service Legacy yang Ditemukan Tapi Diabaikan dari Analisis Ini

Ditemukan saat menjelajah folder, sengaja dilewati sesuai instruksi karena
memakai `AFA_H`/`AFA_SIGNATURE` (modul Expense/Investment lama):

- `XtraFormMonitoring.vb`
- `XtraFormApproval.vb`
- `XtraFormViewAfa.vb`
- `XtraFormSignatureNew.vb`
- `XtraFormLogin.vb`
- `FormFluMenu.vb` (hanya dibaca sebatas untuk mengecek wiring menu ke form
  baru di §4 — isinya sendiri tidak dianalisis/dinilai statusnya)
- `XtraFormAFAEntry.vb` / `XtraFormAFAEntry.Designer.vb` — nama memakai prefix
  `XtraFormAFA*` tapi isinya query langsung ke `dbo.AFA_H` join
  `AFA_HAK_AKSES`/`User_H`, jadi ini bagian dari modul lama, bukan modul
  Non-IFS baru
- `XtraFormAFAHistory.vb` / `XtraFormAFAHistory.Designer.vb` — sama, query
  langsung ke `dbo.AFA_SIGNATURE` join `AFA_Jenis_Urut`, bagian modul lama

Tidak ada satu pun dari file-file di atas yang diberi catatan "belum
selesai" dalam laporan ini, sesuai instruksi.
