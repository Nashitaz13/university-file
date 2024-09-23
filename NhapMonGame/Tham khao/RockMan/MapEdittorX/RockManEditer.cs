using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEdittorX
{
    public partial class RockManEditer : Form
    {
        private Keys _keyDown;
        private bool _isShowIDNumber;
        private bool _isMouseDown;
        private Point _endPoint;
        private int objectID;
        private int _row;                       // Tổng số dòng của ảnh map
        private int _column;                    // Tổng số cột của map
        private int axisX;                      // Vị trí giới hạn chiều rộng của map        
        private int axisY;                      // Vị trí giới hạn chiều cao của map     
        private string _mapPath;                // Đường dẫn lưu map sau khi người dùng thực hiện Save mode
        private Bitmap _bkg;                    // Bitmap nắm giữ file background được chọn
        private BackgroundWorker _bkgWorker;    // Tác vụ cắt map
        private PictureBox _pbMap;              // Chứa hình của Map
        private int[,] _tileMatrix;             // Matrix được dùng để lưu index của tile
        private List<Bitmap> _lstTile;          // Lưu danh sách các tile bitmap được cắt ra.
        private List<PictureBox> _lstObj;       // Lưu danh sách các hình anh đối tượng game
        private int _lstObjIndex = -1;
        private List<PictureBox> _lstObjInMap;  // Lưu danh sách các hình anh đối tượng game trong map
        private PictureBox _selectObj;          // Hinh  đang được chọn        
        private GObject _currentObj;            // Objet game hien tai dang chon
        private List<int> _lstIndex;            // Lưu danh sách các index trong matrix
        private Point _lastScroll;              // Vị trí cuộn trang trước đó
        private Point _startPoint;              // Vị trí chuột lúc nhấn chuột xuốngShi
        private List<Point> _lstPosDraw;             // Lưu danh sách 2 vị trí đầu cuối khi khi vẽ theo ngang dọc
        private Size _sizeRock; // Luu lai do lon cu hinh rock;
     
        private List<GObject> _lstGObject;      // Chứa danh sách các Object game được vẽ lên map.

        private QuadNode _nodeCollison;              // Node gốc
        int p = 0;

        private Bitmap curs;                    //Curs để vẽ hình.

        public RockManEditer()
        {
            InitializeComponent();
            this._lstPosDraw = new List<Point>();
            this.objectID = 0;
            this._lstGObject = new List<GObject>();
            this._currentObj = null;
            this._lastScroll = new Point(0, 0);
            this._lstTile = new List<Bitmap>();
            this._lstIndex = new List<int>();
            this._lstObj = new List<PictureBox>();
            this._lstObjInMap = new List<PictureBox>();
            this._selectObj = new PictureBox();
            this._sizeRock = new Size();

            this._lstObj.Add(this.pbBall);
            this._lstObj.Add(this.pbInkRed);
            this._lstObj.Add(this.pbNinija);
            this._lstObj.Add(this.pbEyeRedUp);
            this._lstObj.Add(this.pbEyeRedRight);
            this._lstObj.Add(this.pbFish);
            this._lstObj.Add(this.pbMachineAutoBlue);
            this._lstObj.Add(this.pbBoomBlue);
            this._lstObj.Add(this.pbBubbleBlue);
            this._lstObj.Add(this.pbCut);
            this._lstObj.Add(this.pbInkBlue);
            this._lstObj.Add(this.pbMachineAutoOrange);
            this._lstObj.Add(this.pbRobotRed);
            this._lstObj.Add(this.pbBubbleGreen);
            this._lstObj.Add(this.pbMachineOrange);
            this._lstObj.Add(this.pbRobotBlue);
            this._lstObj.Add(this.pbWorker);
            this._lstObj.Add(this.pbHat);
            this._lstObj.Add(this.pbblock);
            this._lstObj.Add(this.pbclamper);
            this._lstObj.Add(this.pbdieaarrow);
            this._lstObj.Add(this.pbrock);
            this._lstObj.Add(this.pbTroubleElevator);
            this._lstObj.Add(this.pbElevatorNormal);
            this._lstObj.Add(this.pbLife);
            this._lstObj.Add(this.pbBloodBig);
            this._lstObj.Add(this.pbBloodSmall);
            this._lstObj.Add(this.pbManaBig);
            this._lstObj.Add(this.pbManaSmall);
            this._lstObj.Add(this.pbBossBoom);
            this._lstObj.Add(this.pbWallShooterLeft);
            this._lstObj.Add(this.pbWallShooterRight);
            this._lstObj.Add(this.pbBossCut);
            this._lstObj.Add(this.pbBossRut);
            this._lstObj.Add(this.pbCameraPathPoint);
            this._lstObj.Add(this.pbFallingPoint);
            this._lstObj.Add(this.pbMachineAutoOrangeTop);
            this._lstObj.Add(this.pbMachineAutoBlueTop);
            this._lstObj.Add(this.picBoxDoor1BoomMan);
            this._lstObj.Add(this.picBoxDoor2BoomMan);
            this._lstObj.Add(this.picBoxDoor1GutsMan);
            this._lstObj.Add(this.picBoxDoor2GutsMan);
            this._lstObj.Add(this.picBoxDoor1CutMan);
            this._lstObj.Add(this.picBoxDoor2CutMan);
            this._lstObj.Add(this.picBoxDoor1GutsMan);
            this._lstObj.Add(this.picBoxDoor2GutsMan);
            this._lstObj.Add(this.pbxboxcut);
            this._lstObj.Add(this.RockFireMan);

            foreach (var p in this._lstObj)
            {
                p.Click += p_Click;
            }

            //Khởi tạo giá trị được chọn mặt định.
            this._lstObjIndex = 1;
            this._selectObj = this._lstObj[1];
            this.change_Obj(this._lstObj[0].Name);
        }

        void p_Click(object sender, EventArgs e)
        {
            this.change_Obj((sender as PictureBox).Name);
        }

        private void change_Obj(string name)
        {
            PictureBox new_Obj = (from pt in this._lstObj
                                  where pt.Name == name
                                  select pt).First();
            this._selectObj = this._lstObj[this._lstObjIndex];
            //Thay đổi màu nền của đối tượng được chọn trong danh sách menu
            if (new_Obj != null && this._selectObj != new_Obj)
            {
                this._selectObj.BackColor = Color.Transparent;
                this._selectObj.BorderStyle = BorderStyle.None;
                this._selectObj = new_Obj;
                this._lstObjIndex = this._lstObj.IndexOf(new_Obj);
                this._selectObj.BorderStyle = BorderStyle.Fixed3D;

                this.curs = new Bitmap(this._selectObj.Image);
            }
        }
        /// <summary>
        /// Thực hiện load một background mới
        /// </summary>
        private void modeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDlg = new OpenFileDialog();
            fileDlg.Filter = "Image Files (*.bmp; *.png; *.jpg; *.gif)|*.bmp; *.png; *.jpg; *.gif";
            fileDlg.Multiselect = false;
            if (fileDlg.ShowDialog() == DialogResult.OK)
            {
                // Lưu lại đường dẫn của ảnh
                _mapPath = fileDlg.FileName;

                // Đẩy ảnh vào _bkg dưới dạng Bitmap
                _bkg = (Bitmap)Image.FromFile(_mapPath, true);

                // Tiến hành cắt ảnh background thành các tiles
                _bkgWorker = new BackgroundWorker();
                _bkgWorker.DoWork += _bkgWorker_DoWork;
                _bkgWorker.ProgressChanged += _bkgWorker_ProgressChanged;
                _bkgWorker.RunWorkerCompleted += _bkgWorker_RunWorkerCompleted;
                _bkgWorker.WorkerReportsProgress = true;    // Cho phép báo cáo tiến trình doWork
                _bkgWorker.RunWorkerAsync();
                this.pnlMap.Controls.Clear();
            }
        }
        /// <summary>
        /// Hàm xữ lý khi hàm ReportProgress được gọi
        /// </summary>
        void _bkgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.pgbStatus.Value = e.ProgressPercentage;
            //if (e.UserState != null)
            //{
            //    this.
            //}
        }

        /// <summary>
        /// Công việc thực hiện sau khi hoàn tất cắc map thành các tiles
        /// </summary>
        private void _bkgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.pgbStatus.Value = 1000;
            this.DrawWorld();
        }

        /// <summary>
        /// Tiến trình cắt map thành các tiles
        /// </summary>
        private void _bkgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //  bmWhite.Save(
                //Số hàng và số cột tiles
                int colNum = _bkg.Width / Global.TILE_SIZE;
                int rowNum = _bkg.Height / Global.TILE_SIZE;
                // Danh sách các tiles đã được cắt và lưu nó lại đê so sánh lại sau.
                List<Bitmap> lstTiles = new List<Bitmap>();

                this._tileMatrix = new int[rowNum, colNum];

                for (int row = 0; row <rowNum; row++)
                {
                    this._bkgWorker.ReportProgress(row * 1000 / rowNum, "\n->");
                    string s = "";

                    //Duyệt từng title để so sánh.
                    for (int col = 0; col < colNum; col++)
                    {
                        Rectangle r = new Rectangle(col * Global.TILE_SIZE, row * Global.TILE_SIZE , Global.TILE_SIZE, Global.TILE_SIZE);
                        Bitmap BMTile = this._bkg.Clone(r, this._bkg.PixelFormat);
                        bool flag = false; // Kiểm tra các trường hợp các tiles giống và khác nhau.
                        if (this.CheckImageWhite(BMTile))
                        {
                            this._tileMatrix[row, col] = -1;
                            flag = true;
                        }
                        else
                        {
                            foreach (Bitmap b in lstTiles)
                            {
                                if (this.CompareBitmaps(BMTile, b))
                                {
                                    flag = true;
                                    this._tileMatrix[row, col] = lstTiles.IndexOf(b);
                                    break;
                                }
                            }
                        }

                        //Kiểm tra nếu chưa có tile nào trong lstTiles thì thêm vào lstTile
                        if (!flag)
                        {
                            lstTiles.Add(BMTile);
                            this._tileMatrix[row, col] = lstTiles.IndexOf(BMTile);
                        }
                        p = ((row * colNum + col) * 1000) / (rowNum * colNum);
                        this._bkgWorker.ReportProgress(p);
                    }
                    this._bkgWorker.ReportProgress(p, s);
                }

                this._row = rowNum;
                this._column = colNum;
                this._lstTile = lstTiles;

                this._bkgWorker.ReportProgress(1000, "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        /// <summary>
        /// Thực hiện vẽ Map lên form
        /// </summary>
        private void DrawWorld()
        {
            //Không cắt được tile nào thì không vẽ ra Map
            if (this._lstTile.Count == 0)
                return;

            this._pbMap = new PictureBox();
            this._pbMap.Location = new Point(0, 0);

            //Lưu các vị trí bắt đầu và kết thúc của Map
            int stX = 0;
            int stY = 0;
            int endX = stX + _column * Global.TILE_SIZE;
            int endY = stY + _row * Global.TILE_SIZE;

            int w = Math.Abs(endX - stX);
            int h = Math.Abs(endY - stY);

            this.axisX = endX;
            this.axisY = endY;

            this._pbMap.Size = new Size(w, h);
            this.pnlMap.Controls.Add(this._pbMap);
            this._pbMap.Click += _pbMap_Click;
            this._pbMap.Paint += _pbMap_Paint;
            this._pbMap.MouseDown += _pbMap_MouseDown;
            this._pbMap.MouseMove += _pbMap_MouseMove;

            pnlMap.AutoScrollPosition = this._lastScroll;
        }

        /// <summary>
        /// Hàm xử lý sự kiện di chuyển chuột
        /// </summary>
        void _pbMap_MouseMove(object sender, MouseEventArgs e)
        {
            //In ra tọa độ của chuột 
            int y = this.axisY - e.Location.Y;
            lblY.Text = "Y: " + y;
            lblX.Text = "X: " + e.Location.X;
            _endPoint = new Point(e.Location.X, e.Location.Y);
            if(_pbMap!=null)
                this._pbMap.Invalidate();
        }

        /// <summary>
        /// Hàm xác định vị trí khi chuột khi nhấn
        /// </summary>
        void _pbMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && Control.ModifierKeys == Keys.None)
            {
                _isMouseDown = _isMouseDown == true ? false : true;
                if (_isMouseDown)
                {
                    this._startPoint = e.Location;
                }
                else
                {
                    _endPoint = e.Location;
                }
            }
        }

        /// <summary>
        /// Hàm xử lý sự kiện vẽ
        /// </summary>
        void _pbMap_Paint(object sender, PaintEventArgs e)
        {

            //Tạo một Image trắng.
            Bitmap bmWhite = new Bitmap(Global.TILE_SIZE, Global.TILE_SIZE);
            for (int y = 0; y < bmWhite.Height; y++)
                for (int x = 0; x < bmWhite.Width; x++)
                {
                    bmWhite.SetPixel(y, x, Color.White);
                }

            //Vẽ Map
            Graphics g = e.Graphics;
            for (int i = 0; i < _row; i++)
            {
                for (int j = 0; j < this._column; j++)
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

                    int index = this._tileMatrix[i, j];
                    Bitmap bm;
                    if (index == -1)
                        bm = bmWhite;
                    else
                        bm = this._lstTile[index];

                    g.DrawImage(bm,
                        j * Global.TILE_SIZE,
                        i * Global.TILE_SIZE, Global.TILE_SIZE, Global.TILE_SIZE);
                }
            }

            foreach (GObject o in this._lstGObject)
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                switch (o.TypeID)
                {
                    case Global.ID_BLOCK:
                        Rectangle r = new Rectangle(new Point(o.Point.X - o.Size.Width / 2 - 1, this.axisY - o.Point.Y - o.Size.Height / 2), o.Size - new Size(0, 1));
                        Pen pen = new Pen(Color.Red, 1.0f);
                        g.DrawRectangle(pen, r);
                        break;
                    case Global.ID_CLAMPER:
                        Rectangle r1 = new Rectangle(new Point(o.Point.X - o.Size.Width / 2 - 1, this.axisY - o.Point.Y - o.Size.Height / 2), o.Size - new Size(0, 1));
                        Pen pen1 = new Pen(Color.White, 1.0f);
                        g.DrawRectangle(pen1, r1);
                        break;
                    default:
                        Rectangle r2 = new Rectangle(new Point(o.Point.X - o.Size.Width / 2 - 1, this.axisY - o.Point.Y - o.Size.Height / 2), o.Size);
                        g.DrawImage(o.Image, r2);
                        break;
                }
            }
            // Vẽ các đường giới hạn
            if (this.cbShowTiles.Checked)
            {
                //Vẽ các đường răng phân định tiles
                Pen p = new Pen(Color.Red, 1.0f);
                addObjectQuadTree(_pbMap.Size);
                if (_nodeCollison != null)
                    _nodeCollison.Paint(this.axisY, g, p, _isShowIDNumber);
                if (_isMouseDown)
                {
                    SolidBrush drawBrush = new SolidBrush(Color.FromArgb(128, 255, 0, 0));
                    Rectangle rect = new Rectangle();
                    rect.X = Math.Min(_startPoint.X, _endPoint.X);
                    rect.Y = Math.Min(_startPoint.Y, _endPoint.Y);
                    rect.Width = Math.Abs(_startPoint.X - _endPoint.X);
                    rect.Height = Math.Abs(_startPoint.Y - _endPoint.Y);
                    g.FillRectangle(drawBrush, rect);
                }
            }
        }

        /// <summary>
        /// Hàm xử lý sự kiện click
        /// </summary>
        void _pbMap_Click(object sender, EventArgs e)
        {
            try
            {
                MouseEventArgs Me = e as MouseEventArgs;
                if (Me.Button == MouseButtons.Left)
                {
                    Point p = new Point(Me.Location.X, Me.Location.Y);
                    // Xử lý phím S
                    if (Control.ModifierKeys == Keys.Control&& _keyDown==Keys.S)
                    {
                        Point selectedPoint = new Point(p.X, this.axisY - p.Y);
                        List<GObject> selectedObjects = _nodeCollison.GetObjectsWith(selectedPoint);
                        selectedObjects = selectedObjects.GroupBy(o => o.ID).Select(o => o.First()).ToList();
                            foreach (var obj in selectedObjects)
                                for (int i = 0; i < _lstGObject.Count; i++)
                                    if (_lstGObject[i].ID == obj.ID)
                                        _lstGObject[i].Select();
                            _pbMap.Invalidate();
                    }
                    else if (!_isMouseDown)
                    {
                        SolidBrush drawBrush = new SolidBrush(Color.FromArgb(128, 255, 0, 0));
                        Rectangle rect = new Rectangle();
                        rect.X = Math.Min(_startPoint.X, _endPoint.X);
                        rect.Y = this.axisY - Math.Min(_startPoint.Y, _endPoint.Y);
                        rect.Width = Math.Abs(_startPoint.X - _endPoint.X);
                        rect.Height = Math.Abs(_startPoint.Y - _endPoint.Y);

                      
                        foreach (var obj in _lstGObject)
                        {
                            if(obj.IsSelected &&!(rect.Left >= obj.Point.X + obj.Size.Width/2
                                || rect.Left + rect.Width <= obj.Point.X+obj.Size.Width/2
                                || rect.Top - rect.Height >= obj.Point.Y+obj.Size.Height/2
                                || rect.Top <= obj.Point.Y - obj.Size.Height/2))
                                obj.CollideRect = rect;
                            else
                            obj.IsSelected = false;
                        }
                        _pbMap.Invalidate();
                    }
                    #region Xử lý phím Ctrl
                    if (Control.ModifierKeys == Keys.Control && _keyDown != Keys.S)
                    {
                        this._selectObj = this._lstObj[this._lstObjIndex];
                        if (this._selectObj != null)
                        {
                            String typeID = this._selectObj.Name;
                            Image tempTemp = this._selectObj.Image;
                            Size size = new Size(this._selectObj.Image.Size.Width , this._selectObj.Image.Size.Height);
                            this._selectObj = new PictureBox();
                            this._selectObj.Image = tempTemp;
                            this._selectObj.Size = size;
                            this._selectObj.Name = typeID;
                            this.add(p);
                        }
                    }
                    #endregion
                    #region Xử lý phím Shift
                    if (Control.ModifierKeys == Keys.Shift && _keyDown != Keys.S)
                    {
                        GObject tmpObj = GetObjectsAtPos(Me.X, Me.Y);
                        if (tmpObj == null)
                            return;

                        this._lstGObject.Remove(tmpObj);
                    }
                    #endregion
                    #region Xử lý phím Alt -> ve lien tiep cac hinh theo chieu ngang tu vi tri nay toi vi tri khac
                    if (Control.ModifierKeys == Keys.Alt && _keyDown != Keys.S)
                    {
                        this._selectObj = this._lstObj[this._lstObjIndex];

                        if (!(this._selectObj.Name == "pbblock") && !(this._selectObj.Name == "pbrock") && !(this._selectObj.Name == "pbclamper"))
                            return;
                        //list chỉ chứa được 2 điểm 
                        if (this._lstPosDraw.Count >= 2)
                        {
                            this._lstPosDraw.Clear();
                        }

                        
                        if (this._selectObj != null && this._lstPosDraw.Count == 0)
                        {

                            String typeID = this._selectObj.Name;
                            Image tempTemp = this._selectObj.Image;
                            Size size = new Size(this._selectObj.Image.Size.Width, this._selectObj.Image.Size.Height);
                            this._selectObj = new PictureBox();
                            this._selectObj.Image = tempTemp;
                            this._selectObj.Size = size;
                            this._selectObj.Name = typeID;

                            //lưu lại size hình rock
                            this._sizeRock = size;
                            this.add(p);
                            this._lstPosDraw.Add(new Point(p.X, this.axisY - p.Y));
                        }
                        else
                        {                     
                            this._lstPosDraw.Add(new Point(p.X, this.axisY - p.Y));
                        }

                        if (cbHorizontal.Checked)
                        {
                            if (this._lstPosDraw.Count == 2 && (Math.Abs(_lstPosDraw[0].Y - _lstPosDraw[1].Y)) < 5)
                            {
                                foreach (var obj in _lstGObject)
                                {
                                    if (obj.Point == _lstPosDraw[0])
                                    {
                                        obj.Size.Width = Math.Abs(_lstPosDraw[1].X - obj.Point.X) + _sizeRock.Width;
                                        obj.Size.Height = obj.Image.Height;

                                        obj.Point.X = _lstPosDraw[0].X + Math.Abs(_lstPosDraw[1].X - obj.Point.X) / 2;
                                        obj.Point.Y = _lstPosDraw[0].Y;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (this._lstPosDraw.Count == 2 && (Math.Abs(_lstPosDraw[0].X - _lstPosDraw[1].X)) < 5)
                            {
                                foreach (var obj in _lstGObject)
                                {
                                    if (obj.Point == _lstPosDraw[0])
                                    {
                                        obj.Size.Height = Math.Abs(_lstPosDraw[1].Y - obj.Point.Y) + _sizeRock.Height;
                                        obj.Size.Width = obj.Image.Width;

                                        obj.Point.Y = _lstPosDraw[0].Y - ((_lstPosDraw[0].Y - _lstPosDraw[1].Y) / Math.Abs(_lstPosDraw[0].Y - _lstPosDraw[1].Y)) * Math.Abs(_lstPosDraw[1].Y - obj.Point.Y) / 2;
                                        obj.Point.X = _lstPosDraw[0].X;
                                    }
                                }
                            }
                        }

                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// //Hàm so sánh 2 bitmap
        /// </summary>     
        private bool CompareBitmaps(Image left, Image right)
        {
            if (object.Equals(left, right))
                return true;
            if (left == null || right == null)
                return false;
            if (!left.Size.Equals(right.Size) || !left.PixelFormat.Equals(right.PixelFormat))
                return false;

            Bitmap leftBitmap = left as Bitmap;
            Bitmap rightBitmap = right as Bitmap;
            if (leftBitmap == null || rightBitmap == null)
                return true;

            #region Optimized code for performance

            int bytes = left.Width * left.Height * (Image.GetPixelFormatSize(left.PixelFormat) / 8);

            bool result = true;
            byte[] b1bytes = new byte[bytes];
            byte[] b2bytes = new byte[bytes];

            BitmapData bmd1 = leftBitmap.LockBits(new Rectangle(0, 0, leftBitmap.Width - 1, leftBitmap.Height - 1), ImageLockMode.ReadOnly, leftBitmap.PixelFormat);
            BitmapData bmd2 = rightBitmap.LockBits(new Rectangle(0, 0, rightBitmap.Width - 1, rightBitmap.Height - 1), ImageLockMode.ReadOnly, rightBitmap.PixelFormat);

            Marshal.Copy(bmd1.Scan0, b1bytes, 0, bytes);
            Marshal.Copy(bmd2.Scan0, b2bytes, 0, bytes);

            for (int n = 0; n <= bytes - 1; n++)
            {
                if (b1bytes[n] != b2bytes[n])
                {
                    result = false;
                    break;
                }
            }

            leftBitmap.UnlockBits(bmd1);
            rightBitmap.UnlockBits(bmd2);

            #endregion

            return result;
        }

        private bool CheckImageWhite(Bitmap bmWhite)
        {
            for (int y = 0; y < bmWhite.Height; y++)
                for (int x = 0; x < bmWhite.Width; x++)
                {
                    if (!bmWhite.GetPixel(x, y).ToArgb().Equals(Color.White.ToArgb()))
                        return false;
                }
            return true;
        }

        private void RockManEditer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.Menu || e.KeyCode == Keys.Alt)
            {
                this._selectObj = this._lstObj[this._lstObjIndex];
                if (pnlMap.Cursor != Cursors.Arrow)
                {
                    pnlMap.Cursor = Cursors.Arrow;
                }

                if (this._currentObj != null)
                    this._currentObj = null;

                if (this._pbMap != null)
                    this._pbMap.Invalidate();

                this._lstPosDraw.Clear();
            }
            if (e.KeyCode == Keys.S&&this._pbMap!=null)
            {
                _keyDown = 0;
                this._pbMap.Cursor = Cursors.Default;
            }
        }
        private void RockManEditer_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.S ) && Control.ModifierKeys == Keys.Control)
            {
                _keyDown = e.KeyCode;
                if (_keyDown == Keys.S && this._pbMap != null)
                    this._pbMap.Cursor = Cursors.Hand;

                this._selectObj = this._lstObj[this._lstObjIndex];
                if (pnlMap.Cursor != Cursors.Arrow)
                {
                    pnlMap.Cursor = Cursors.Arrow;
                }

                if (this._currentObj != null)
                    this._currentObj = null;

                if (this._pbMap != null)
                    this._pbMap.Invalidate();

                this._lstPosDraw.Clear();
            }
            else
            {
                if (e.KeyCode == Keys.ControlKey || Control.ModifierKeys == Keys.Alt)
                {
                    this.pnlMap.Cursor = CustomCursor.CreateCursor(this.curs, this._selectObj.Image.Width, this._selectObj.Image.Height);
                    if (this._pbMap != null)
                        this._pbMap.Invalidate();
                }

                if (e.KeyCode == Keys.ShiftKey)
                {
                    Bitmap bm = (Bitmap)global::MapEdittorX.Properties.Resources.eraser;

                    pnlMap.Cursor = CustomCursor.CreateCursor(bm, bm.Width, bm.Height);
                    if (this._pbMap != null)
                        this._pbMap.Invalidate();
                }
            }
        }

        /// <summary>
        /// Thêm một Game Object được được vẽ lên map
        /// </summary>
        private void add(Point p)
        {
            int typeID = 0;
            switch (this._selectObj.Name)
            {
                case "pbNinija":
                    typeID = Global.ID_ENEMY_NINJA_GREEN;
                    break;
                case "pbInkRed":
                    typeID = Global.ID_ENEMY_INK_RED;
                    break;
                case "pbBall":
                    typeID = Global.ID_ENEMY_BALL;
                    break;
                case "pbEyeRedUp":
                    typeID = Global.ID_ENEMY_EYE_RED_UP;
                    break;
                case "pbEyeRedRight":
                    typeID = Global.ID_ENEMY_EYE_RED_RIGHT;
                    break;
                case "pbFish":
                    typeID = Global.ID_ENEMY_FISH_ORANGE;
                    break;
                case "pbMachineAutoBlue":
                    typeID = Global.ID_ENEMY_MACHINE_AUTO_BLUE_BOTTOM;
                    break;
                case "pbMachineAutoBlueTop":
                    typeID = Global.ID_ENEMY_MACHINE_AUTO_BLUE_TOP;
                    break;
                case "pbWallShooterLeft":
                    typeID = Global.ID_ENEMY_WALL_SHOOTER_LEFT;
                    break;
                case "pbWallShooterRight":
                    typeID = Global.ID_ENEMY_WALL_SHOOTER_RIGHT;
                    break;
                case "pbBoomBlue":
                    typeID = Global.ID_ENEMY_BOOM_BLUE;
                    break;
                case "pbBubbleBlue":
                    typeID = Global.ID_ENEMY_BUBBLE_BLUE;
                    break;
                case "pbCut":
                    typeID = Global.ID_ENEMY_CUT;
                    break;
                case "pbInkBlue":
                    typeID = Global.ID_ENEMY_INK_BLUE;
                    break;
                case "pbMachineAutoOrange":
                    typeID = Global.ID_ENEMY_MACHINE_AUTO_ORGANGE_BOTTOM;
                    break;
                case "pbMachineAutoOrangeTop":
                    typeID = Global.ID_ENEMY_MACHINE_AUTO_ORGANGE_TOP;
                    break;
                case "pbRobotRed":
                    typeID = Global.ID_ENEMY_ROBOT_RED;
                    break;
                case "pbBubbleGreen":
                    typeID = Global.ID_ENEMY_BUBBLE_GREEN;
                    break;
                case "pbHat":
                    typeID = Global.ID_ENEMY_HAT;
                    break;
                case "pbMachineOrange":
                    typeID = Global.ID_ENEMY_MACHINE_ORANGE;
                    break;
                case "pbRobotBlue":
                    typeID = Global.ID_ENEMY_ROBOT_BLUE;
                    break;
                case "pbWorker":
                    typeID = Global.ID_ENEMY_WORKER;
                    break;
                case "pbblock":
                    typeID = Global.ID_BLOCK;
                    break;
                case "pbclamper":
                    typeID = Global.ID_CLAMPER;
                    break;
                case "pbdieaarrow":
                    typeID = Global.ID_DIEAARROW;
                    break;
                case "pbrock":
                    typeID = Global.ID_ROCK;
                    break;
                case "pbTroubleElevator":
                    typeID = Global.ID_BLOCK_TROUBLE_OF_ELEVATOR;
                    break;
                case "pbElevatorNormal":
                    typeID = Global.ID_ELEVATOR;
                    break;
                case "pbLife":
                    typeID = Global.ID_ITEM_LIFE;
                    break;
                case "pbBloodBig":
                    typeID = Global.ID_ITEM_BLOOD_BIG;
                    break;
                case "pbBloodSmall":
                    typeID = Global.ID_ITEM_BLOOD_SMALL;
                    break;
                case "pbManaBig":
                    typeID = Global.ID_ITEM_MANA;
                    break;
                case "pbManaSmall":
                    typeID = Global.ID_ITEM_MANA_SMALL;
                    break;
                case "pbBossCut":
                    typeID = Global.ID_BOSSCUT;
                    break;
                case "pbBossBoom":
                    typeID = Global.ID_BOSSBOOM;
                    break;
                case "pbBossRut":
                    typeID = Global.ID_BOSSRUT;
                    break;
                case "pbFallingPoint":
                    typeID = Global.ID_FALLING_POINT;
                    break;
                case "pbCameraPathPoint":
                    typeID = Global.ID_CAMERA_PATH_POINT;
                    break;
                case "pdRankRed":
                    typeID = Global.ID_ENEMY_TANK_RED;
                    break;
                case "picBoxDoor1CutMan":
                    typeID = Global.ID_DOOR1_CUTMAN;
                    break;
                case "picBoxDoor1GutsMan":
                    typeID = Global.ID_DOOR1_GUTSMAN;
                    break;
                case "picBoxDoor2CutMan":
                    typeID = Global.ID_DOOR2_CUTMAN;
                    break;
                case "picBoxDoor2GutsMan":
                    typeID = Global.ID_DOOR2_GUTSMAN;
                    break;
                case "picBoxDoor1BoomMan":
                    typeID = Global.ID_DOOR1_BOOMMAN;
                    break;
                case "picBoxDoor2BoomMan":
                    typeID = Global.ID_DOOR2_BOOMMAN;
                    break;
                case "pbxboxcut" :
                    typeID = Global.ID_ENEMY_SNAPPER;
                    break;
                case "RockFireMan":
                    typeID = Global.ID_ROCKGUSTMAN;
                    break;
                default:
                    typeID = 99;
                    break;

            }

            GObject o = new GObject(objectID);
            o.TypeID = typeID;
            o.Image = this._selectObj.Image;
            o.Size = this._selectObj.Size;
            o.Point = new Point(p.X, this.axisY - p.Y);

            this._lstGObject.Add(o);

            objectID += 1;
        }

        /// <summary>
        /// Hàm lấy đối tượng game tại vị trí click
        /// </summary>
        private GObject GetObjectsAtPos(int x, int y)
        {
            if (this._lstGObject.Count == 0)
                return null;
            foreach (GObject o in this._lstGObject)
            {
                Point PX = new Point(o.Point.X - o.Size.Width / 2,this.axisY- o.Point.Y - o.Size.Height / 2);
                Rectangle r = new Rectangle(PX, o.Size);
                if (r.Contains(new Point(x, y)))
                {
                    return o;
                }
            }
            return null;
        }

        /// <summary>
        // Hàm xử lý button Save
        /// </summary>
        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this._pbMap != null)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "map file (*.txt)|*.txt";
                dlg.Title = "Save map";
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    addObjectQuadTree(_pbMap.Size);
                    using (FileStream fs = new FileStream(dlg.FileName, FileMode.Create, FileAccess.ReadWrite))
                    {
                        StreamWriter wr = new StreamWriter(fs);

                        // Lưu ma trận Tile xuống File
                        wr.WriteLine("#Tile_Matrix");
                        wr.WriteLine("Total_Row\tTotal_Column\tTotal_Tile");
                        wr.WriteLine(_row + "\t" + _column + "\t" + _lstTile.Count);
                        wr.WriteLine("#Tile_Matrix_Value");
                        for (int i = 0; i < _row; i++)
                        {
                            for (int j = 0; j < _column; j++)
                                wr.Write(_tileMatrix[i, j] + "\t");
                            wr.WriteLine();
                        }
                        wr.WriteLine("#Tile_Matrix_End");

                        wr.WriteLine("#Objects");
                        wr.WriteLine("ObjCount");
                        wr.WriteLine(_lstGObject.Count);
                        wr.WriteLine("ObjID\tTypeID\tPosX\tPosY\tWidth\tHeight\tPosXCollide\tPosYCollide\tWidthCollide\tHeightCollide");
                        for (int i = 0; i < _lstGObject.Count; i++)
                            wr.WriteLine(_lstGObject[i].ID + "\t" + _lstGObject[i].TypeID + "\t" + _lstGObject[i].Point.X + "\t" + _lstGObject[i].Point.Y + "\t" + _lstGObject[i].Size.Width + "\t" + _lstGObject[i].Size.Height + "\t" + _lstGObject[i].GetCollideRegion().X + "\t" + _lstGObject[i].GetCollideRegion().Y + "\t" + _lstGObject[i].GetCollideRegion().Width + "\t" + _lstGObject[i].GetCollideRegion().Height);
                        wr.WriteLine("#Objects_End");

                        wr.WriteLine("#Quadtree_Collision");
                        wr.WriteLine("NodeCount");
                        wr.WriteLine(_nodeCollison.CountChildNode());
                        wr.WriteLine("NodeID\tPosX\tPosY\tWidth\tHeight\tObjectsCount\tObjectIDs");
                        _nodeCollison.Save(wr);
                        wr.WriteLine("#Quadtree_Collision_End");
                        wr.WriteLine("#Camera_Path_Point");
                        var _cameraPoints = _lstGObject.Where(o => o.TypeID == Global.ID_CAMERA_PATH_POINT).ToList();
                        wr.WriteLine(_cameraPoints.Count);
                        foreach (GObject obj in _cameraPoints)
                            wr.WriteLine(obj.Point.X + "\t" + obj.Point.Y);
                        wr.WriteLine("#Camera_Path_Point_End");
                        wr.Close();
                    }
                }
                int bitmapColumn =(int) Math.Sqrt((double)_lstTile.Count)+1;
                Bitmap set = new Bitmap(bitmapColumn * Global.TILE_SIZE, bitmapColumn * Global.TILE_SIZE);
                set.SetResolution(72.0F, 72.0F);

                foreach (Bitmap bm in _lstTile)
                {
                    int i = this._lstTile.IndexOf(bm) % bitmapColumn;
                    int j = this._lstTile.IndexOf(bm) / bitmapColumn;

                    using (Graphics g = Graphics.FromImage(set))
                    {
                        g.InterpolationMode = InterpolationMode.NearestNeighbor;
                        g.DrawImage(bm, i * Global.TILE_SIZE, j * Global.TILE_SIZE, Global.TILE_SIZE, Global.TILE_SIZE);
                    }
                }
                //Lưu hình tile
                string name = dlg.FileName.Split('.')[0];
                string path = name + ".bmp";
                using (MemoryStream memory = new MemoryStream())
                {
                    using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                    {
                        set.Save(memory, ImageFormat.Bmp);
                        byte[] bytes = memory.ToArray();
                        fs.Write(bytes, 0, bytes.Length);
                        fs.Close();
                    }
                }

                MessageBox.Show("Save completed!");
            }
        }
        private void loadToolStripLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dg = new OpenFileDialog();
            dg.Filter = "Map Files (txt)|*.txt";
            dg.Multiselect = false;

            if (dg.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(dg.FileName, FileMode.Open, FileAccess.Read))
                {
                    StreamReader rd = new StreamReader(fs);
                    rd.ReadLine();  //#Tile_Matrix
                    rd.ReadLine();  // Total_Row	Total_Column    Total_Tile

                    string[] s = rd.ReadLine().Split('\t');
                    this._row = int.Parse(s[0]);
                    this._column = int.Parse(s[1]);
                    int totalTile = int.Parse(s[2]);
                    rd.ReadLine();  // #Tile_Matrix_Value

                    // dọc ma trân background.
                    this._tileMatrix = new int[this._row, this._column];

                    for (int i = 0; i < this._row; i++)
                    {
                        string[] item = rd.ReadLine().Split('\t');
                        for (int j = 0; j < this._column; j++)
                        {
                            this._tileMatrix[i, j] = int.Parse(item[j]);
                        }
                    }

                    rd.ReadLine();  //#Tile_Matrix_End
                    rd.ReadLine();  //#Objects
                    rd.ReadLine();  //ObjCount
                    int countObject = int.Parse(rd.ReadLine());
                    rd.ReadLine();  // ObjID	TypeID	PosX	PosY	Width	Height

                    this._lstGObject.Clear();
                    this.objectID = 0;
                    for (int i = 0; i < countObject; i++)
                    {
                        string[] o = rd.ReadLine().Split('\t');
                        GObject gO = new GObject(int.Parse(o[0]));
                        this.objectID = int.Parse(o[0]);
                        gO.TypeID = int.Parse(o[1]);
                        gO.Point.X = int.Parse(o[2]);
                        gO.Point.Y = int.Parse(o[3]) ;
                        gO.Size.Width = int.Parse(o[4]);
                        gO.Size.Height = int.Parse(o[5]);
                        if (o.Length > 6)
                        {
                            gO.CollideRect.X = int.Parse(o[6]);
                            gO.CollideRect.Y = int.Parse(o[7]);
                            gO.CollideRect.Width = int.Parse(o[8]);
                            gO.CollideRect.Height = int.Parse(o[9]);
                        }
                        switch (  gO.TypeID )
                        {
                            case  Global.ID_ENEMY_NINJA_GREEN:
                                gO.Image = Image.FromFile("..//..//Resources//BossBomMan//enemy_ninja_green_jump.png");
                                break;
                            case Global.ID_ENEMY_INK_RED:
                                gO.Image=Image.FromFile("..//..//Resources//BossBomMan//enemy_ink_red.png");
                                break;
                            case Global.ID_ENEMY_BALL:
                                gO.Image = Image.FromFile("..//..//Resources//BossBomMan//enemy_ball.png");
                                break;
                            case Global.ID_ENEMY_EYE_RED_UP:
                                gO.Image = Image.FromFile("..//..//Resources//BossCutMan//enemy_eye_red_up.png");
                                break;
                            case Global.ID_ENEMY_EYE_RED_RIGHT:
                                gO.Image = Image.FromFile("..//..//Resources//BossCutMan//enemy_eye_red_right.png");
                                break;
                            case  Global.ID_ENEMY_FISH_ORANGE:
                                gO.Image = Image.FromFile("..//..//Resources//BossBomMan//enemy_fish_orange.png");
                                break;
                            case Global.ID_ENEMY_MACHINE_AUTO_BLUE_BOTTOM:
                                gO.Image = Image.FromFile("..//..//Resources//BossBomMan//enemy_machine_auto_blue.png");
                                break;
                            case Global.ID_ENEMY_MACHINE_AUTO_BLUE_TOP:
                                gO.Image = Image.FromFile("..//..//Resources//BossBomMan//enemy_machine_auto_blue - top.png");
                                break;
                            case Global.ID_ENEMY_WALL_SHOOTER_LEFT:
                                gO.Image = Image.FromFile("..//..//Resources//BossCutMan//enemy_wall_shooter_left.png");
                                break;
                            case Global.ID_ENEMY_WALL_SHOOTER_RIGHT:
                                gO.Image = Image.FromFile("..//..//Resources//BossCutMan//enemy_wall_shooter_right.png");
                                break;
                            case  Global.ID_ENEMY_BOOM_BLUE:
                                gO.Image = Image.FromFile("..//..//Resources//BossBomMan//enemy_boom_blue.png");
                                break;
                            case Global.ID_ENEMY_BUBBLE_GREEN:
                                gO.Image = Image.FromFile("..//..//Resources//BossRutMan//enemy_bubble_green.png");
                                break;
                            case  Global.ID_ENEMY_CUT:
                                gO.Image = Image.FromFile("..//..//Resources//BossCutMan//enemy_cut.png");
                                break;
                            case Global.ID_ENEMY_INK_BLUE:
                                gO.Image = Image.FromFile("..//..//Resources//BossCutMan//enemy_ink_blue.png");
                                break;
                            case Global.ID_ENEMY_MACHINE_AUTO_ORGANGE_BOTTOM:
                                gO.Image = Image.FromFile("..//..//Resources//BossCutMan//enemy_machine_auto_orange.png");
                                break;
                            case Global.ID_ENEMY_MACHINE_AUTO_ORGANGE_TOP:
                                gO.Image = Image.FromFile("..//..//Resources//BossCutMan//enemy_machine_auto_orange - Top.png");
                                break;
                            case Global.ID_ENEMY_ROBOT_RED:
                                gO.Image = Image.FromFile("..//..//Resources//BossCutMan//enemy_robot_red.png");
                                break;
                            case Global.ID_ENEMY_BUBBLE_BLUE:
                                gO.Image = Image.FromFile("..//..//Resources//BossCutMan//enemy_bubble_blue.png");
                                break;
                            case Global.ID_BLOCK_TROUBLE_OF_ELEVATOR:
                                gO.Image = Image.FromFile("..//..//Resources//BossRutMan//trouble_of_elevator.png");
                                break;
                            case Global.ID_ELEVATOR:
                                gO.Image = Image.FromFile("..//..//Resources//BossRutMan//enemy_elevator_line_normal_green.png");
                                break;
                            case  Global.ID_ENEMY_HAT:
                                gO.Image = Image.FromFile("..//..//Resources//BossRutMan//enemy_hat.png");
                                break;
                            case Global.ID_ENEMY_MACHINE_ORANGE:
                                gO.Image = Image.FromFile("..//..//Resources//BossRutMan//enemy_machine_orange.png");
                                break;                          
                            case  Global.ID_ENEMY_WORKER:
                                gO.Image = Image.FromFile("..//..//Resources//BossRutMan//enemy_worker.png");
                                break;     
                            case Global.ID_ITEM_LIFE:
                                gO.Image = Image.FromFile("..//..//Resources//BossBomMan//enemy_ink_red.png");
                                break;
                            case Global.ID_ITEM_BLOOD_BIG:
                                gO.Image = Image.FromFile("..//..//Resources//oder//item_blood.png");
                                break;
                            case Global.ID_ITEM_BLOOD_SMALL:
                                gO.Image = Image.FromFile("..//..//Resources//oder//item_blood_small.png");
                                break;
                            case Global.ID_ITEM_MANA:
                                gO.Image = Image.FromFile("..//..//Resources//oder//item_mana.png");
                                break;
                            case Global.ID_ITEM_MANA_SMALL:
                                gO.Image = Image.FromFile("..//..//Resources//oder//item_mana_small.png");
                                break;
                            case Global.ID_BOSSCUT:
                                gO.Image = Image.FromFile("..//..//Resources//BossCutMan//icon_master_cut_man.png");
                                break;
                            case Global.ID_BOSSBOOM:
                                gO.Image = Image.FromFile("..//..//Resources//BossBomMan//icon_master_boom_man.png");
                                break;
                            case Global.ID_BOSSRUT:
                                gO.Image = Image.FromFile("..//..//Resources//BossRutMan//icon_master_guts_man.png");
                                break;
                            case Global.ID_ROCKGUSTMAN:
                                gO.Image = Image.FromFile("..//..//Resources//BossRutMan//rockFire_gutsman.png");
                                break;
                            case Global.ID_ENEMY_ROBOT_BLUE:
                                gO.Image = Image.FromFile("..//..//Resources//BossRutMan//enemy_robot_blue.png");
                                break;
                            case Global.ID_CAMERA_PATH_POINT:
                                gO.Image = Image.FromFile("..//..//Resources//oder//item_bonus_red.png");
                                break;
                            case Global.ID_BLOCK:
                                gO.Image = Image.FromFile("..//..//Resources//oder//block.png");
                                break;
                            case Global.ID_FALLING_POINT:
                                gO.Image = Image.FromFile("..//..//Resources//oder//falling_point.png");
                                break;
                            case Global.ID_ROCK:
                                gO.Image = Image.FromFile("..//..//Resources//oder//rock.png");
                                break;
                            case Global.ID_DIEAARROW:
                                gO.Image = Image.FromFile("..//..//Resources//oder//dieaarrow.png");
                                break;
                            case Global.ID_CLAMPER:
                                gO.Image = Image.FromFile("..//..//Resources//oder//clamper.png");
                                break;
                            case Global.ID_DOOR1_CUTMAN:
                                gO.Image = Image.FromFile("..//..//Resources//oder//door1_cutman.png");
                                break;
                            case Global.ID_DOOR2_CUTMAN:
                                gO.Image = Image.FromFile("..//..//Resources//oder//door2_cutman.png");
                                break;
                            case Global.ID_DOOR1_GUTSMAN:
                                gO.Image = Image.FromFile("..//..//Resources//oder//door1_gutsman.png");
                                break;
                            case Global.ID_DOOR2_GUTSMAN:
                                gO.Image = Image.FromFile("..//..//Resources//oder//door2_gutsman.png");
                                break;
                            case Global.ID_DOOR1_BOOMMAN:
                                gO.Image = Image.FromFile("..//..//Resources//oder//door1_boomman.png");
                                break;
                            case Global.ID_DOOR2_BOOMMAN:
                                gO.Image = Image.FromFile("..//..//Resources//oder//door2_boomman.png");
                                break;
                            case Global.ID_ENEMY_SNAPPER:
                                gO.Image = Image.FromFile("..//..//Resources//oder//boxcut.png");
                                break;
                        }
                        this._lstGObject.Add(gO);
                    }
                    this.objectID += 1;
                    this.pnlMap.Controls.Clear();

                    // Vẽ background
                    Bitmap background = new Bitmap(dg.FileName.Split('.')[0] + ".bmp");
                    int bitmapColumn = (int)Math.Sqrt((double)totalTile) + 1;
                    for (int k = 0; k < totalTile; k++)
                    {

                        int i = k % bitmapColumn;
                        int j = k / bitmapColumn;
                        Rectangle r2 = new Rectangle(i * Global.TILE_SIZE, j * Global.TILE_SIZE, Global.TILE_SIZE, Global.TILE_SIZE);
                        Bitmap b = background.Clone(r2, background.PixelFormat);
                        _lstTile.Add(b);
                        pgbStatus.Value = k * 1000 / totalTile;
                    }
                    pgbStatus.Value = 1000;
                    DrawWorld();
                    // Vẽ các đối tượng lên màn hình


                }
            }

        }

        private void cleanToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.pnlMap.Controls.Clear();
            _lstTile.Clear();
            _lstPosDraw.Clear();
            _lstGObject.Clear();
            pgbStatus.Value = 0;
        }

        public void addObjectQuadTree(Size size)
        {
            int maxDimension = size.Width > size.Height ? size.Width : size.Height;
            Point p = new Point(0, maxDimension);
            Size s = new Size(maxDimension, maxDimension);
            Rectangle r = new Rectangle(p, s);

            _nodeCollison = new QuadNode(0, p, s);
            foreach (GObject obj in _lstGObject)
            {
                GObject newObj = new GObject(obj.ID);
                newObj.TypeID = obj.TypeID;
                newObj.Size = obj.Size;
                newObj.Point = new Point(obj.Point.X, obj.Point.Y);
                newObj.IsSelected = obj.IsSelected;
                newObj.CollideRect = obj.CollideRect;

                if (obj.TypeID != Global.ID_CAMERA_PATH_POINT)
                    _nodeCollison.Insert(newObj);
            }
        }

        private void ckbShowIDNumber_CheckedChanged(object sender, EventArgs e)
        {
            _isShowIDNumber = ckbShowIDNumber.Checked;
            _pbMap.Invalidate();
        }

    }

    public struct IconInfo
    {
        public bool fIcon;
        public int xHotspot;
        public int yHotspot;
        public IntPtr hbmMask;
        public IntPtr hbmColor;
    }

    public class CustomCursor
    {
        public CustomCursor()
        {
        }

        [DllImport("user32.dll")]
        public static extern IntPtr CreateIconIndirect(ref IconInfo icon);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);

        public static Cursor CreateCursor(Bitmap bmp, int xHotSpot, int yHotSpot)
        {                     
                return new Cursor(bmp.GetHicon());        
        }
    }
}
