using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLNT.DataTransferObject;
using QLNT.BusinessLogicLayer;
using System.Data.SqlClient;
using QLNT.CommonLayer;
using QLNT.DataTransferObject.TraThuoc;

namespace QuanLyNhaThuoc
{
    public partial class FrmPhieuTraThuoc : Form
    {
        #region Object Initialization

        private BllPhieuTraThuoc bllPhieuTraThuoc;
        private BllNhanVien bllNhanVien;
        private BllThuoc bllThuoc;
        private TypedDSPhieuTraThuoc dsPhieuTraThuoc;
        private BindingSource bsChiTietPhieuTra;
        private DtoPhieuTraThuoc dtoPhieuTraThuoc;
        private BllSoPhieuXuatThuoc bllSoPhieuXuatThuoc;
        private DataTable dtHoaDonXuat;

        int mMaPhieuTraThuoc = 0;// Mac dinh = 0 de store hieu la insert thay vi update
        public int MaPhieuTraThuoc
        {
            get { return mMaPhieuTraThuoc; }
            set { mMaPhieuTraThuoc = value; }
        }

        #endregion Object Initialization

        public FrmPhieuTraThuoc()
        {
            InitializeComponent();
            bllNhanVien = new BllNhanVien();
            bllThuoc = new BllThuoc();
            bllPhieuTraThuoc = new BllPhieuTraThuoc();
            bllSoPhieuXuatThuoc = new BllSoPhieuXuatThuoc();
            bsChiTietPhieuTra = new BindingSource();
            dtoPhieuTraThuoc = new DtoPhieuTraThuoc();
            dsPhieuTraThuoc = new TypedDSPhieuTraThuoc();
            dtHoaDonXuat = new DataTable();
        }

        private void DocDuLieu()
        {
            //Doc du lieu cho combobox
            bllNhanVien.DocDanhSachNhanVien(dsPhieuTraThuoc.tbNguoiGhiPhieu);
            bllNhanVien.DocDanhSachNhanVien(dsPhieuTraThuoc.tbNguoiNhanThuoc);
            bllThuoc.DocDanhMucThuoc(dsPhieuTraThuoc.tbThuoc);
            dtHoaDonXuat= bllSoPhieuXuatThuoc.DocDanhSachPhieuXuatThuoc();

            //Doc du lieu cho hoa don            
            dtoPhieuTraThuoc = bllPhieuTraThuoc.DocPhieuTraThuocTheoMaHD(this.MaPhieuTraThuoc);

            //Doc du lieu cho chi tiet hoa don
            bllPhieuTraThuoc.DocChiTietPhieuTraThuocTheoMaHD(dsPhieuTraThuoc.tbChiTietPhieuTraThuoc, this.MaPhieuTraThuoc);

        }

        private void GanDoiTuongDuLieuVaoCacDieuKhien()
        {
            //Hien thi du lieu cua phieu hoa don hien tai tren cac controls
            txtSoPhieu.DataBindings.Add(new Binding("Text", dtoPhieuTraThuoc, "SeriHoaDonTra", true));
            dtpNgayTra.DataBindings.Add(new Binding("Value", dtoPhieuTraThuoc, "NgayTraThuoc", true));
            cboNguoiGhiPhieu.DataBindings.Add(new Binding("SelectedValue", dtoPhieuTraThuoc, "MaNguoiGhiPhieu", true));
            cboNguoiNhanThuoc.DataBindings.Add(new Binding("SelectedValue", dtoPhieuTraThuoc, "MaNguoiNhanThuoc", true));
            cboPhieuHoaDonXuat.DataBindings.Add(new Binding("SelectedValue", dtoPhieuTraThuoc, "MaHoaDonXuat", true));
            txtLyDo.DataBindings.Add(new Binding("Text", dtoPhieuTraThuoc, "LyDo", true));

            // Gan du lieu Tien VAT vao textbox txtTienVAT va co cap nhat lai gia tri khi co su thay doi
            txtTongTienPhaiTra.DataBindings.Add(new Binding("Text", dtoPhieuTraThuoc, "TongTienPhaiTra", true, DataSourceUpdateMode.OnPropertyChanged));
            txtTongTienPhaiTra.DataBindings[0].FormattingEnabled = true;
            //txtTienVAT.DataBindings[0].FormatString = "#,#.##";

            //Hien thi du lieu cua chi tiet phieu tra thuoc tren tung cot cua luoi.
            dgvcMaPhieuTraThuoc.DataPropertyName = "MaPhieuTraThuoc";
            dgvcMaThuoc.DataPropertyName = "MaThuoc";
            dgvcSoLuongXuatBanDau.DataPropertyName = "SoLuongXuatBanDau";
            dgvcSoLuongBanDau.DataPropertyName = "SoLuongBanDau";
            dgvcSoLuongTra.DataPropertyName = "SoLuongTra";
            dgvcThanhTien.DataPropertyName = "ThanhTien";
            dgvcDonGiaXuat.DataPropertyName = "DonGiaXuat";
        }

        private void HienThiDuLieu()
        {
            //Danh sach nguoi ghi phieu            
            cboNguoiGhiPhieu.DataSource = dsPhieuTraThuoc.tbNguoiGhiPhieu;
            cboNguoiGhiPhieu.DisplayMember = "TenNhanVien";
            cboNguoiGhiPhieu.ValueMember = "MaNhanVien";

            cboNguoiNhanThuoc.DataSource = dsPhieuTraThuoc.tbNguoiNhanThuoc;
            cboNguoiNhanThuoc.DisplayMember = "TenNhanVien";
            cboNguoiNhanThuoc.ValueMember = "MaNhanVien";
            
            //Danh muc cac loai thuoc            
            dgvcMaThuoc.DataSource = dsPhieuTraThuoc.tbThuoc;
            dgvcMaThuoc.DisplayMember = "TenThuoc";
            dgvcMaThuoc.ValueMember = "MaThuoc";

            //Cac hoa don xuat
            cboPhieuHoaDonXuat.DataSource = dtHoaDonXuat;
            cboPhieuHoaDonXuat.DisplayMember = "SeriHoaDonXuat";
            cboPhieuHoaDonXuat.ValueMember = "MaHoaDonXuat";

            //Chi tiet phieu Tra thuoc  
            bsChiTietPhieuTra.DataSource = dsPhieuTraThuoc.tbChiTietPhieuTraThuoc;
            dgvChiTietPhieuTra.DataSource = bsChiTietPhieuTra;  
        }

        private void DinhDangHienThiNut(bool duocPhepSua)
        {
            btThem.Enabled = !duocPhepSua;
            btSua.Enabled = !duocPhepSua;
            btLuu.Enabled = duocPhepSua;
            btKhongLuu.Enabled = duocPhepSua;
            btThoat.Enabled = true;
        }

        private void FrmPhieuTraThuoc_Load(object sender, EventArgs e)
        {
            DinhDangHienThiNut(true);
            CommonFunction.DinhDangThaoTacLuoi(dgvChiTietPhieuTra, true);
            DocDuLieu();
            //Gan doi tuong du lieu trong Hoa Don vao tung controls tuong ung va co cap nhat lai gia tri khi co su thay doi.
            //Ham nay chi duoc goi mot lan. Trong su kien sua sau khi nguoi dung luu phieu. 
            //Neu khai bao ham nay trong ham HienThiDuLieu, chuong trinh se bao loi. Do khong duoc phep binding 2 lan.
            GanDoiTuongDuLieuVaoCacDieuKhien();
            HienThiDuLieu();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            DinhDangHienThiNut(true);
            CommonFunction.DinhDangThaoTacLuoi(dgvChiTietPhieuTra, true);
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            DinhDangHienThiNut(true);
            CommonFunction.DinhDangThaoTacLuoi(dgvChiTietPhieuTra, true);
            //Mot so ham can reset lai gia tri nen khi nguoi dung vua bam luu , sau do bam sua lien thi goi lai 2 ham sau.
            //De dam bao ham mot so ham tinh toan chay dung.
            DocDuLieu();
            HienThiDuLieu();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (dsPhieuTraThuoc == null) return;

            DinhDangHienThiNut(false);
            CommonFunction.DinhDangThaoTacLuoi(dgvChiTietPhieuTra, false);

            DtoPhieuTraThuoc dtoPhieuTraThuoc = new DtoPhieuTraThuoc()
            {
                MaPhieuTraThuoc = this.MaPhieuTraThuoc,
                MaNguoiGhiPhieu = (cboNguoiGhiPhieu.SelectedValue.ToString() != "") ? Convert.ToInt32(cboNguoiGhiPhieu.SelectedValue) : -1,
                MaNguoiNhanThuoc = (cboNguoiNhanThuoc.SelectedValue.ToString() != "") ? Convert.ToInt32(cboNguoiNhanThuoc.SelectedValue) : -1,
                MaHoaDonXuat = (cboPhieuHoaDonXuat.SelectedValue.ToString() != "") ? Convert.ToInt32(cboPhieuHoaDonXuat.SelectedValue) : -1,
                NgayTraThuoc = dtpNgayTra.Value,
                SeriHoaDonTra = txtSoPhieu.Text,
                LyDo = txtLyDo.Text,
                
                TongTienPhaiTra = (txtTongTienPhaiTra.Text != "") ? Convert.ToUInt32(txtTongTienPhaiTra.Text) : 0              
            };

            this.MaPhieuTraThuoc = bllPhieuTraThuoc.LuuPhieuTraThuoc(dtoPhieuTraThuoc);
            if (this.MaPhieuTraThuoc > 0) // Neu co Ma phieu Tra tra ve thi tiep tuc luu du lieu cua chi tiet phieu Tra tren luoi.
            {
                //Gan MaPhieuTraThuoc vao tu row cua bang tbChiTietPhieuTraThuoc
                foreach (DataRow dr in dsPhieuTraThuoc.tbChiTietPhieuTraThuoc)
                {
                    dr["MaPhieuTraThuoc"] = this.MaPhieuTraThuoc;
                }
                bllPhieuTraThuoc.LuuChiTietPhieuTraThuoc(dsPhieuTraThuoc.tbChiTietPhieuTraThuoc);
            }

        }

        private void btKhongLuu_Click(object sender, EventArgs e)
        {
            if (dsPhieuTraThuoc == null) return;           
            dsPhieuTraThuoc.tbChiTietPhieuTraThuoc.RejectChanges();
            DinhDangHienThiNut(false);
            CommonFunction.DinhDangThaoTacLuoi(dgvChiTietPhieuTra, false);  
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvChiTietPhieuTra_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //MessageBox.Show("Error happened " + e.Context.ToString());    
            if (e.Context == DataGridViewDataErrorContexts.Commit)
            {
                //MessageBox.Show("Commit error");
                if (String.IsNullOrEmpty(dgvChiTietPhieuTra.Rows[e.RowIndex].Cells[1].Value.ToString()))//MaThuoc
                {
                    dgvChiTietPhieuTra.Rows[e.RowIndex].ErrorText = String.Format(Constants.GridExceptionLoiNull, "Tên thuốc");
                    dgvChiTietPhieuTra.Rows[e.RowIndex].Cells[1].Selected = true;//Ten thuoc
                    e.Cancel = true;
                }
            }
            if (e.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                MessageBox.Show(Constants.GridExceptionLoiChung);// "Cell change"
            }
            if (e.Context == DataGridViewDataErrorContexts.Parsing)
            {
                MessageBox.Show("parsing error");
            }
            if (e.Context == DataGridViewDataErrorContexts.LeaveControl)
            {
                MessageBox.Show("leave control error");
            }

            if ((e.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[e.RowIndex].ErrorText = "an error";
                view.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "an error";

                e.ThrowException = false;
            }
        }

        private void dgvChiTietPhieuTra_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Xoa row error trong truong hop bam esc
            DataGridViewRow rowGrid = dgvChiTietPhieuTra.Rows[e.RowIndex];
            rowGrid.ErrorText = String.Empty;
        }

        private void dgvChiTietPhieuTra_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return; //Chi xet doan code ben khi nguoi dung thao tac tren mot row nao do

                DataGridViewRow rowGrid = dgvChiTietPhieuTra.Rows[e.RowIndex];
                string tenCot = dgvChiTietPhieuTra.Columns[e.ColumnIndex].Name;


                if (tenCot.Equals("dgvcMaThuoc")) //Neu la cot thuoc, khi nguoi dung chon thuoc
                {
                    if (rowGrid.Cells["dgvcMaThuoc"].Value != DBNull.Value)
                    {
                        string donGiaBan = dsPhieuTraThuoc.tbThuoc.FindByMaThuoc((int)rowGrid.Cells["dgvcMaThuoc"].Value).DonGiaBan.ToString();
                        rowGrid.Cells["dgvcDonGiaXuat"].Value = donGiaBan;
                    }
                }

                //Tinh tiep neu sau khi chon thuoc
                if (tenCot.Equals("dgvcSoLuongTra") || tenCot.Equals("dgvcDonGiaXuat")) //Neu la cot So Luong hoac Don Gia
                {
                    if (rowGrid.Cells["dgvcMaThuoc"].Value != DBNull.Value)
                    {
                        bsChiTietPhieuTra.EndEdit();
                        //Kiem tra so luong row trong datatable luon > thu tu row dang xet
                        if ((e.RowIndex > -1) && (dsPhieuTraThuoc.tbChiTietPhieuTraThuoc.Rows.Count > e.RowIndex))
                        {
                            DataRow rowTable = dsPhieuTraThuoc.tbChiTietPhieuTraThuoc.Rows[e.RowIndex];
                            rowGrid.Cells["dgvcThanhTien"].Value = bllPhieuTraThuoc.TinhTienThuoc(rowTable);
                        }

                        bllPhieuTraThuoc.TinhTongTienThuoc(dsPhieuTraThuoc.tbChiTietPhieuTraThuoc);                       
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
                //throw new ArgumentException(Constants.GridExceptionLoiChung);
            }
        }

        private void cboPhieuHoaDonXuat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
