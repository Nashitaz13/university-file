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

namespace QuanLyNhaThuoc
{
    public partial class FrmPhieuBanThuoc : Form
    {
        #region Object Initialization

        private BllPhieuXuatThuoc bllPhieuXuatThuoc;
        private BllNhanVien bllNhanVien;
        private BllThuoc bllThuoc;
        private TypedDSPhieuXuatThuoc dsPhieuXuatThuoc;
        private BindingSource bsChiTietPhieuXuat;
        private DtoPhieuXuatThuoc dtoPhieuXuatThuoc;

        int mMaPhieuXuatThuoc = 0;// Mac dinh = 0 de store hieu la insert thay vi update
        public int MaPhieuXuatThuoc
        {
            get { return mMaPhieuXuatThuoc; }
            set { mMaPhieuXuatThuoc = value; }
        }

        #endregion Object Initialization

        public FrmPhieuBanThuoc()
        {
            InitializeComponent();
            bllNhanVien = new BllNhanVien();
            bllThuoc = new BllThuoc();
            bllPhieuXuatThuoc = new BllPhieuXuatThuoc();
            bsChiTietPhieuXuat = new BindingSource();
            dtoPhieuXuatThuoc = new DtoPhieuXuatThuoc();
            dsPhieuXuatThuoc = new TypedDSPhieuXuatThuoc();
        }

        private void DocDuLieu()
        {
            //Doc du lieu cho combobox
            bllNhanVien.DocDanhSachNhanVien(dsPhieuXuatThuoc.tbNguoiGhiPhieu);
            bllNhanVien.DocDanhSachNhanVien(dsPhieuXuatThuoc.tbNguoiPhatThuoc);
            bllThuoc.DocDanhMucThuoc(dsPhieuXuatThuoc.tbThuoc);

            //Doc du lieu cho hoa don            
            dtoPhieuXuatThuoc = bllPhieuXuatThuoc.DocPhieuXuatThuocTheoMaHD(this.MaPhieuXuatThuoc);

            //Doc du lieu cho chi tiet hoa don
            bllPhieuXuatThuoc.DocChiTietPhieuXuatThuocTheoMaHD(dsPhieuXuatThuoc.tbChiTietHoaDonXuat, this.MaPhieuXuatThuoc);
            
        }

        private void GanDoiTuongDuLieuVaoCacDieuKhien()
        {
            //Hien thi du lieu cua phieu hoa don hien tai tren cac controls
            txtSoPhieu.DataBindings.Add(new Binding("Text", dtoPhieuXuatThuoc, "SeriHoaDonXuat", true));
            dtpNgayXuat.DataBindings.Add(new Binding("Value", dtoPhieuXuatThuoc, "NgayXuat", true));
            cboNguoiGhiPhieu.DataBindings.Add(new Binding("SelectedValue", dtoPhieuXuatThuoc, "MaNguoiGhiPhieu", true));
            cboNguoiPhatThuoc.DataBindings.Add(new Binding("SelectedValue", dtoPhieuXuatThuoc, "MaNguoiPhatThuoc", true));
            txtThongTinBenhNhan.DataBindings.Add(new Binding("Text", dtoPhieuXuatThuoc, "ThongTinBenhNhan", true));

            // Gan du lieu Tien VAT vao textbox txtTienVAT va co cap nhat lai gia tri khi co su thay doi
            txtTienVAT.DataBindings.Add(new Binding("Text", dtoPhieuXuatThuoc, "TongTienVAT", true, DataSourceUpdateMode.OnPropertyChanged));
            txtTienVAT.DataBindings[0].FormattingEnabled = true;
            //txtTienVAT.DataBindings[0].FormatString = "#,#.##";

            txtTongTienThuoc.DataBindings.Add(new Binding("Text", dtoPhieuXuatThuoc, "TongTienThuoc", true, DataSourceUpdateMode.OnPropertyChanged));
            txtTongTienThuoc.DataBindings[0].FormattingEnabled = true;
            //txtTongTienThuoc.DataBindings[0].FormatString = "#,#.##";

            txtTongThanhTien.DataBindings.Add(new Binding("Text", dtoPhieuXuatThuoc, "TongTienThanhToan", true, DataSourceUpdateMode.OnPropertyChanged));
            txtTongThanhTien.DataBindings[0].FormattingEnabled = true;

            //Hien thi du lieu cua chi tiet phieu Xuat thuoc tren tung cot cua luoi.
            dgvcMaHoaDonXuat.DataPropertyName = "MaHoaDonXuat";
            dgvcMaThuoc.DataPropertyName = "MaThuoc";
            dgvcDonGiaXuat.DataPropertyName = "DonGiaXuat";
            dgvcSoLuong.DataPropertyName = "SoLuong";
            dgvcThanhTien.DataPropertyName = "ThanhTien";
            dgvcSoLuongBanDau.DataPropertyName = "SoLuongBanDau";
        }

        private void HienThiDuLieu()
        {
            //Danh sach nguoi ghi phieu            
            cboNguoiGhiPhieu.DataSource = dsPhieuXuatThuoc.tbNguoiGhiPhieu;
            cboNguoiGhiPhieu.DisplayMember = "TenNhanVien";
            cboNguoiGhiPhieu.ValueMember = "MaNhanVien";

            cboNguoiPhatThuoc.DataSource = dsPhieuXuatThuoc.tbNguoiPhatThuoc;
            cboNguoiPhatThuoc.DisplayMember = "TenNhanVien";
            cboNguoiPhatThuoc.ValueMember = "MaNhanVien";


            //Danh muc cac loai thuoc            
            dgvcMaThuoc.DataSource = dsPhieuXuatThuoc.tbThuoc;
            dgvcMaThuoc.DisplayMember = "TenThuoc";
            dgvcMaThuoc.ValueMember = "MaThuoc";

            //Chi tiet phieu xuat thuoc  
            bsChiTietPhieuXuat.DataSource = dsPhieuXuatThuoc.tbChiTietHoaDonXuat;
            dgvChiTietPhieuXuat.DataSource = bsChiTietPhieuXuat;  
        }

        private void DinhDangHienThiNut(bool duocPhepSua)
        {
            btThem.Enabled = !duocPhepSua;
            btSua.Enabled = !duocPhepSua;
            btLuu.Enabled = duocPhepSua;
            btKhongLuu.Enabled = duocPhepSua;
            btThoat.Enabled = true;
        }

        private void FrmPhieuBanThuoc_Load(object sender, EventArgs e)
        {
            DinhDangHienThiNut(true);
            CommonFunction.DinhDangThaoTacLuoi(dgvChiTietPhieuXuat, true);
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
            CommonFunction.DinhDangThaoTacLuoi(dgvChiTietPhieuXuat, true);
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            DinhDangHienThiNut(true);
            CommonFunction.DinhDangThaoTacLuoi(dgvChiTietPhieuXuat, true);
            //Mot so ham can reset lai gia tri nen khi nguoi dung vua bam luu , sau do bam sua lien thi goi lai 2 ham sau.
            //De dam bao ham mot so ham tinh toan chay dung.
            DocDuLieu();
            HienThiDuLieu();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (dsPhieuXuatThuoc == null) return;

            DinhDangHienThiNut(false);
            CommonFunction.DinhDangThaoTacLuoi(dgvChiTietPhieuXuat, false);

            DtoPhieuXuatThuoc dtoPhieuXuatThuoc = new DtoPhieuXuatThuoc()
            {
                MaHoaDonXuat = this.MaPhieuXuatThuoc,               
                MaNguoiGhiPhieu = (cboNguoiGhiPhieu.SelectedValue.ToString() != "") ? Convert.ToInt32(cboNguoiGhiPhieu.SelectedValue) : -1,
                MaNguoiPhatThuoc = (cboNguoiPhatThuoc.SelectedValue.ToString() != "") ? Convert.ToInt32(cboNguoiPhatThuoc.SelectedValue) : -1,
                NgayXuat = dtpNgayXuat.Value,
                SeriHoaDonXuat = txtSoPhieu.Text,
                ThongTinBenhNhan = txtThongTinBenhNhan.Text,
                TongTienThuoc = (txtTongTienThuoc.Text != "") ? Convert.ToUInt32(txtTongTienThuoc.Text) : 0,
                TongTienThanhToan = (txtTongThanhTien.Text != "") ? Convert.ToUInt32(txtTongThanhTien.Text) : 0,
                TongTienVAT = (txtTienVAT.Text != "") ? Convert.ToUInt32(txtTienVAT.Text) : 0
            };

            this.MaPhieuXuatThuoc = bllPhieuXuatThuoc.LuuPhieuXuatThuoc(dtoPhieuXuatThuoc);
            if (this.MaPhieuXuatThuoc > 0) // Neu co Ma phieu Xuat tra ve thi tiep tuc luu du lieu cua chi tiet phieu Xuat tren luoi.
            {
                //Gan MaPhieuXuatThuoc vao tu row cua bang tbChiTietHoaDonXuat
                foreach (DataRow dr in dsPhieuXuatThuoc.tbChiTietHoaDonXuat)
                {
                    dr["MaHoaDonXuat"] = this.MaPhieuXuatThuoc;
                }
                bllPhieuXuatThuoc.LuuChiTietPhieuXuatThuoc(dsPhieuXuatThuoc.tbChiTietHoaDonXuat);
            }

        }

        private void btKhongLuu_Click(object sender, EventArgs e)
        {
            if (dsPhieuXuatThuoc == null) return;            
            dsPhieuXuatThuoc.tbChiTietHoaDonXuat.RejectChanges();
            DinhDangHienThiNut(false);
            CommonFunction.DinhDangThaoTacLuoi(dgvChiTietPhieuXuat, false);  
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvChiTietPhieuXuat_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //MessageBox.Show("Error happened " + e.Context.ToString());    
            if (e.Context == DataGridViewDataErrorContexts.Commit)
            {
                //MessageBox.Show("Commit error");
                if (String.IsNullOrEmpty(dgvChiTietPhieuXuat.Rows[e.RowIndex].Cells[1].Value.ToString()))//MaThuoc
                {
                    dgvChiTietPhieuXuat.Rows[e.RowIndex].ErrorText = String.Format(Constants.GridExceptionLoiNull, "Tên thuốc");
                    dgvChiTietPhieuXuat.Rows[e.RowIndex].Cells[1].Selected = true;//Ten thuoc
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

        private void dgvChiTietPhieuXuat_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Xoa row error trong truong hop bam esc
            DataGridViewRow rowGrid = dgvChiTietPhieuXuat.Rows[e.RowIndex];
            rowGrid.ErrorText = String.Empty;
        }

        private void dgvChiTietPhieuXuat_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return; //Chi xet doan code ben khi nguoi dung thao tac tren mot row nao do

                DataGridViewRow rowGrid = dgvChiTietPhieuXuat.Rows[e.RowIndex];
                string tenCot = dgvChiTietPhieuXuat.Columns[e.ColumnIndex].Name;


                if (tenCot.Equals("dgvcMaThuoc")) //Neu la cot thuoc, khi nguoi dung chon thuoc
                {
                    if (rowGrid.Cells["dgvcMaThuoc"].Value != DBNull.Value)
                    {
                        string donGiaBan = dsPhieuXuatThuoc.tbThuoc.FindByMaThuoc((int)rowGrid.Cells["dgvcMaThuoc"].Value).DonGiaBan.ToString();
                        rowGrid.Cells["dgvcDonGiaXuat"].Value = donGiaBan;
                    }
                }

                //Tinh tiep neu sau khi chon thuoc
                if (tenCot.Equals("dgvcSoLuong") || tenCot.Equals("dgvcDonGiaXuat")) //Neu la cot So Luong hoac Don Gia
                {
                    if (rowGrid.Cells["dgvcMaThuoc"].Value != DBNull.Value)
                    {
                        bsChiTietPhieuXuat.EndEdit();
                        //Kiem tra so luong row trong datatable luon > thu tu row dang xet
                        if ((e.RowIndex > -1) && (dsPhieuXuatThuoc.tbChiTietHoaDonXuat.Rows.Count > e.RowIndex))
                        {
                            DataRow rowTable = dsPhieuXuatThuoc.tbChiTietHoaDonXuat.Rows[e.RowIndex];
                            rowGrid.Cells["dgvcThanhTien"].Value = bllPhieuXuatThuoc.TinhTienThuoc(rowTable);
                        }

                        bllPhieuXuatThuoc.TinhTongTienThuoc(dsPhieuXuatThuoc.tbChiTietHoaDonXuat);
                        bllPhieuXuatThuoc.TinhTienVAT();
                        bllPhieuXuatThuoc.TinhTongThanhTien();
                    }

                }
            }
            catch (Exception)
            {
                throw new ArgumentException(Constants.GridExceptionLoiChung);
            }
        }


    }
}
