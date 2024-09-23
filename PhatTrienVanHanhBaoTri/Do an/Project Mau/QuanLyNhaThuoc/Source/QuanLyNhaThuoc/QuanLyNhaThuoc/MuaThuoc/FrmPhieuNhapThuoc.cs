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
using QLNT.DataTransferObject.MuaThuoc;

namespace QuanLyNhaThuoc
{
    public partial class FrmPhieuNhapThuoc : Form
    {
        #region Object Initialization

        private BllPhieuNhapThuoc bllPhieuNhapThuoc;
        private BllNhanVien bllNhanVien;
        private BllNhaCungCap bllNhaCungCap;       
        private BllThuoc bllThuoc;
        private TypedDSPhieuNhapThuoc dsPhieuNhapThuoc;              
        private BindingSource bsChiTietPhieuNhap;
        private DtoPhieuNhapThuoc dtoPhieuNhapThuoc;

        int mMaPhieuNhapThuoc = 0;// Mac dinh = 0 de store hieu la insert thay vi update
        public int MaPhieuNhapThuoc
        {
            get { return mMaPhieuNhapThuoc; }
            set { mMaPhieuNhapThuoc = value; }
        }
           
        #endregion Object Initialization

        public FrmPhieuNhapThuoc()
        {
            InitializeComponent();

            bllNhanVien = new BllNhanVien();
            bllPhieuNhapThuoc = new BllPhieuNhapThuoc();
            bllNhaCungCap = new BllNhaCungCap();           
            bllThuoc = new BllThuoc();
            dsPhieuNhapThuoc = new TypedDSPhieuNhapThuoc();
            bsChiTietPhieuNhap = new BindingSource();
            dtoPhieuNhapThuoc = new DtoPhieuNhapThuoc();
            
        }
        
        private void DocDuLieu()
        {
            //Doc du lieu cho combobox           
            bllNhanVien.DocDanhSachNhanVien(dsPhieuNhapThuoc.tbNhanVien);
            bllNhaCungCap.DocDanhSachNhaCungCap(dsPhieuNhapThuoc.tbNhaCungCap);          
            bllThuoc.DocDanhMucThuoc(dsPhieuNhapThuoc.tbThuoc);

            //Doc du lieu cho hoa don            
            dtoPhieuNhapThuoc = bllPhieuNhapThuoc.DocPhieuNhapThuocTheoMaHD(this.MaPhieuNhapThuoc);

            //Doc du lieu cho chi tiet hoa don
            bllPhieuNhapThuoc.DocChiTietPhieuNhapThuocTheoMaHD(dsPhieuNhapThuoc.tbChiTietHoaDonNhap, this.MaPhieuNhapThuoc);           
        }

        private void GanDoiTuongDuLieuVaoCacDieuKhien()
        {
            //Hien thi du lieu cua phieu hoa don nhap hien tai tren cac controls
            cboNguoiGhiPhieu.DataBindings.Add(new Binding("SelectedValue", dtoPhieuNhapThuoc, "MaNhanVien", true));
            cboNhaCungCap.DataBindings.Add(new Binding("SelectedValue", dtoPhieuNhapThuoc, "MaNhaCungCap", true));
            cboHinhThucThanhToan.DataBindings.Add(new Binding("SelectedValue", dtoPhieuNhapThuoc, "MaHinhThucThanhToan", true));
            txtSoPhieu.DataBindings.Add(new Binding("Text", dtoPhieuNhapThuoc, "SeriHoaDonNhap", true));
            dtpNgayNhap.DataBindings.Add(new Binding("Value", dtoPhieuNhapThuoc, "NgayNhap", true));
            txtGhiChu.DataBindings.Add(new Binding("Text", dtoPhieuNhapThuoc, "GhiChu", true));

            // Gan du lieu Tien VAT vao textbox txtTienVAT va co cap nhat lai gia tri khi co su thay doi
            txtTienVAT.DataBindings.Add(new Binding("Text", dtoPhieuNhapThuoc, "TienVAT", true, DataSourceUpdateMode.OnPropertyChanged));
            txtTienVAT.DataBindings[0].FormattingEnabled = true;
            //txtTienVAT.DataBindings[0].FormatString = "#,#.##";

            txtTongTienThuoc.DataBindings.Add(new Binding("Text", dtoPhieuNhapThuoc, "TongTienThuoc", true, DataSourceUpdateMode.OnPropertyChanged));
            txtTongTienThuoc.DataBindings[0].FormattingEnabled = true;
            //txtTongTienThuoc.DataBindings[0].FormatString = "#,#.##";

            txtTongThanhTien.DataBindings.Add(new Binding("Text", dtoPhieuNhapThuoc, "TongTienThanhToan", true, DataSourceUpdateMode.OnPropertyChanged));
            txtTongThanhTien.DataBindings[0].FormattingEnabled = true;
            //txtTongThanhTien.DataBindings[0].FormatString = "#,#.##";

            //Hien thi du lieu cua chi tiet phieu nhap thuoc tren tung cot cua luoi.
            dgvcMaHoaDonNhap.DataPropertyName = "MaHoaDonNhap";
            dgvcThuoc.DataPropertyName = "MaThuoc";
            dgvcSoLo.DataPropertyName = "SoLo";
            dgvcNgaySanXuat.DataPropertyName = "NgaySanXuat";
            dgvcNgayHetHan.DataPropertyName = "NgayHetHan";
            dgvcDonGia.DataPropertyName = "DonGia";
            dgvcSoLuong.DataPropertyName = "SoLuong";
            dgvcTienThuoc.DataPropertyName = "ThanhTien";
           
            dgvcSoLuongBanDau.DataPropertyName = "SoLuongBanDau";
        }

        private void HienThiDuLieu()
        {      
            //Danh sach nguoi ghi phieu            
            cboNguoiGhiPhieu.DataSource = dsPhieuNhapThuoc.tbNhanVien;
            cboNguoiGhiPhieu.DisplayMember = "TenNhanVien";
            cboNguoiGhiPhieu.ValueMember = "MaNhanVien";
           
            //Danh sach nha cung cap            
            cboNhaCungCap.DataSource = dsPhieuNhapThuoc.tbNhaCungCap;
            cboNhaCungCap.DisplayMember = "TenNhaCungCap";           
            cboNhaCungCap.ValueMember = "MaNhaCungCap";

            //Danh muc cac hinh thuc thanh toan           
            cboHinhThucThanhToan.DataSource = Constants.DanhMucHinhThucThanhToan(); 
            cboHinhThucThanhToan.DisplayMember = "TenHinhThucThanhToan";
            cboHinhThucThanhToan.ValueMember = "MaHinhThucThanhToan";

            //Danh muc cac loai thuoc            
            dgvcThuoc.DataSource = dsPhieuNhapThuoc.tbThuoc;
            dgvcThuoc.DisplayMember = "TenThuoc";
            dgvcThuoc.ValueMember = "MaThuoc";

            //Chi tiet phieu nhap thuoc. Gan vao binding source de dong hoa du lieu giua grid va datatable
            bsChiTietPhieuNhap.DataSource = dsPhieuNhapThuoc.tbChiTietHoaDonNhap;
            dgvChiTietPhieuNhap.DataSource = bsChiTietPhieuNhap;             
            
        }

        private void DinhDangHienThiNut(bool duocPhepSua)
        {
            btThem.Enabled = !duocPhepSua;
            btSua.Enabled = !duocPhepSua;
            btLuu.Enabled = duocPhepSua;
            btKhongLuu.Enabled = duocPhepSua;
            btThoat.Enabled = true;
        }

        private void FrmPhieuNhapThuoc_Load(object sender, EventArgs e)
        {           
            DinhDangHienThiNut(true);
            CommonFunction.DinhDangThaoTacLuoi(dgvChiTietPhieuNhap, true);            
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
            CommonFunction.DinhDangThaoTacLuoi(dgvChiTietPhieuNhap, true);
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            DinhDangHienThiNut(true);
            CommonFunction.DinhDangThaoTacLuoi(dgvChiTietPhieuNhap, true);
            //Mot so ham can reset lai gia tri nen khi nguoi dung vua bam luu , sau do bam sua lien thi goi lai 2 ham sau.           
            DocDuLieu();
            HienThiDuLieu(); 
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            DinhDangHienThiNut(false);
            CommonFunction.DinhDangThaoTacLuoi(dgvChiTietPhieuNhap, false);

            if (dsPhieuNhapThuoc == null) return;            
            
            DtoPhieuNhapThuoc dtoPhieuNhapThuoc = new DtoPhieuNhapThuoc() {
                MaHoaDonNhap = this.MaPhieuNhapThuoc,
                MaHinhThucThanhToan = (cboHinhThucThanhToan.SelectedValue.ToString() != "") ? Convert.ToInt32(cboHinhThucThanhToan.SelectedValue) : -1,
                MaNhaCungCap = (cboNhaCungCap.SelectedValue.ToString() != "") ? Convert.ToInt32(cboNhaCungCap.SelectedValue) : -1,
                MaNhanVien = (cboNguoiGhiPhieu.SelectedValue.ToString() != "") ? Convert.ToInt32(cboNguoiGhiPhieu.SelectedValue) : -1,
                SeriHoaDonNhap = txtSoPhieu.Text,    
                VAT = 5,
                GhiChu = txtGhiChu.Text,
                NgayNhap = dtpNgayNhap.Value,
                TongTienThuoc = (txtTongTienThuoc.Text!="")?Convert.ToDecimal(txtTongTienThuoc.Text):0,              
                TienVAT = (txtTienVAT.Text != "") ? Convert.ToDecimal(txtTienVAT.Text) : 0,
                TongTienThanhToan = (txtTongThanhTien.Text != "") ? Convert.ToDecimal(txtTongThanhTien.Text) : 0               
            };

            this.MaPhieuNhapThuoc = bllPhieuNhapThuoc.LuuPhieuNhapThuoc(dtoPhieuNhapThuoc);
            if (this.MaPhieuNhapThuoc > 0) // Neu co Ma phieu nhap tra ve thi tiep tuc luu du lieu cua chi tiet phieu nhap tren luoi.
            {
                //Gan MaPhieuNhapThuoc vao tu row cua bang tbChiTietHoaDonNhap
                foreach (DataRow dr in dsPhieuNhapThuoc.tbChiTietHoaDonNhap)
                {
                    dr["MaHoaDonNhap"] = this.MaPhieuNhapThuoc;
                }
                bllPhieuNhapThuoc.LuuChiTietPhieuNhapThuoc(dsPhieuNhapThuoc.tbChiTietHoaDonNhap);
                MessageBox.Show(Constants.MsgFormLuuXong);
            }
        }

        private void btKhongLuu_Click(object sender, EventArgs e)
        {
            DinhDangHienThiNut(false);
            CommonFunction.DinhDangThaoTacLuoi(dgvChiTietPhieuNhap, false);  

            if (dsPhieuNhapThuoc == null) return;            
            dsPhieuNhapThuoc.tbChiTietHoaDonNhap.RejectChanges();                      
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvChiTietPhieuNhap_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {          
            //MessageBox.Show("Error happened " + e.Context.ToString());    
            if (e.Context == DataGridViewDataErrorContexts.Commit)
            {
                //MessageBox.Show("Commit error");
                if (String.IsNullOrEmpty(dgvChiTietPhieuNhap.Rows[e.RowIndex].Cells[1].Value.ToString()))//MaThuoc
                {
                    dgvChiTietPhieuNhap.Rows[e.RowIndex].ErrorText = String.Format(Constants.GridExceptionLoiNull, "Tên thuốc");
                    dgvChiTietPhieuNhap.Rows[e.RowIndex].Cells[1].Selected = true;//Ten thuoc
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

        private void dgvChiTietPhieuNhap_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Xoa row error trong truong hop bam esc
            DataGridViewRow rowGrid = dgvChiTietPhieuNhap.Rows[e.RowIndex];
            rowGrid.ErrorText = String.Empty;
        }
        
        private void dgvChiTietPhieuNhap_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return; //Chi xet doan code ben khi nguoi dung thao tac tren mot row nao do

                DataGridViewRow rowGrid = dgvChiTietPhieuNhap.Rows[e.RowIndex];
                string tenCot = dgvChiTietPhieuNhap.Columns[e.ColumnIndex].Name;

                if (tenCot.Equals("dgvcSoLuong") || tenCot.Equals("dgvcDonGia")) //Neu la cot So Luong hoac Don Gia
                {
                    if (rowGrid.Cells["dgvcThuoc"].Value != DBNull.Value)
                    {
                        bsChiTietPhieuNhap.EndEdit();
                        //Kiem tra so luong row trong datatable luon > thu tu row dang xet
                        if ((e.RowIndex > -1) && (dsPhieuNhapThuoc.tbChiTietHoaDonNhap.Rows.Count > e.RowIndex))
                        {
                            DataRow rowTable = dsPhieuNhapThuoc.tbChiTietHoaDonNhap.Rows[e.RowIndex];
                            rowGrid.Cells["dgvcTienThuoc"].Value = bllPhieuNhapThuoc.TinhTienThuoc(rowTable);
                        }

                        bllPhieuNhapThuoc.TinhTongTienThuoc(dsPhieuNhapThuoc.tbChiTietHoaDonNhap);
                        bllPhieuNhapThuoc.TinhTienVAT();
                        bllPhieuNhapThuoc.TinhTongThanhTien();
                    }

                }
            }
            catch (Exception)
            {
                throw new ArgumentException(Constants.GridExceptionLoiChung);
            }
        }

        private void btSoPhieuNhap_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.ParentForm.MdiChildren)
            {
               if(item.Name.Equals("FrmSoPhieuNhapThuoc"))
               {
                   item.Close();
                   break;
               }
            }
            FrmSoPhieuNhapThuoc frmSoPhieuNhapThuoc = new FrmSoPhieuNhapThuoc();
            frmSoPhieuNhapThuoc.MdiParent = this.MdiParent;
            frmSoPhieuNhapThuoc.Show();
        }

    }
}
