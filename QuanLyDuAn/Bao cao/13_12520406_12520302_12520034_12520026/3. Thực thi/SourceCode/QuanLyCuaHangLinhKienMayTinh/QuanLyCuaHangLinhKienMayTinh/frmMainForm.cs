using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangLinhKienMayTinh
{
    public partial class frmMainForm : Form
    {


        public frmMainForm()
        {
            InitializeComponent();
            Form s = new frmHome();
            s.TopLevel = false;
            s.Visible = true;
            s.Padding = new Padding(0);
            s.Location = new Point(0, 0);
            pnlHome.Controls.Add(s);
            pnlHome.Size = new Size(pnlHome.Parent.Width - 6, pnlHome.Parent.Height - 21);
            s.Size = pnlHome.Size;
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Console.WriteLine("dda dang xuat");
        }
        private void btnFuntion_click(object sender, EventArgs e)
        {

            //form
            //if (((DevComponents.DotNetBar.ButtonX)sender).Text == "Trang chủ")
            //{
            //    Form s = new frmHome();
            //    s.TopLevel = false;
            //    s.Visible = true;
            //    s.Location = new Point(0, 0);
            //    AddForm(s, ((DevComponents.DotNetBar.ButtonX)sender).Text);
            //}

            //if(((DevComponents.DotNetBar.ButtonX)sender).Text== "Giới thiệu công ty")
            //{
            //    Form s = new frmIntroCompany();
            //    s.TopLevel = false;
            //    s.Visible = true;
            //    s.Location = new Point(0, 0);
            //    AddForm(s, ((DevComponents.DotNetBar.ButtonX)sender).Text);
            //}
            switch(((DevComponents.DotNetBar.ButtonX)sender).Text)
            {
                case "Trang chủ":
                    {
                        Form s = new frmHome();
                        s.TopLevel = false;
                        s.Visible = true;
                        s.Location = new Point(0, 0);
                        AddForm(s, ((DevComponents.DotNetBar.ButtonX)sender).Text);
                        break;
                    }
                case "Giới thiệu công ty":
                    {
                        Form s = new frmIntroCompany();
                        s.TopLevel = false;
                        s.Visible = true;
                        s.Location = new Point(0, 0);
                        AddForm(s, ((DevComponents.DotNetBar.ButtonX)sender).Text);
                        break;
                    }
                case "Sơ đồ nhân viên":
                    {
                        Form s = new frmEmployee();
                        s.TopLevel = false;
                        s.Visible = true;
                        s.Location = new Point(0, 0);
                        AddForm(s, ((DevComponents.DotNetBar.ButtonX)sender).Text);
                        break;
                    }
                case "Quản lý sản phẩm":
                    {
                        Form s = new Warehouse.frmProduct();
                        s.TopLevel = false;
                        s.Visible = true;
                        s.Location = new Point(0, 0);
                        AddForm(s, ((DevComponents.DotNetBar.ButtonX)sender).Text);
                        break;
                    }
                case "Quản lý phiếu nhập kho":
                    {
                        Form s = new Warehouse.frmWarehouseBill();
                        s.TopLevel = false;
                        s.Visible = true;
                        s.Location = new Point(0, 0);
                        AddForm(s, ((DevComponents.DotNetBar.ButtonX)sender).Text);
                        break;
                    }
                case "Quản lý phiếu xuất kho":
                    {
                        Form s = new Warehouse.frmDeliveryBill();
                        s.TopLevel = false;
                        s.Visible = true;
                        s.Location = new Point(0, 0);
                        AddForm(s, ((DevComponents.DotNetBar.ButtonX)sender).Text);
                        break;
                    }
                default: break;
            }



        }



        #region add_form_to_tabpage
        public void AddForm(Form f, string name)
        {
            int kt = 0;
            //foreach (DevComponents.DotNetBar.TabItem conv in tapcol_content.Tabs)
            if(tapcol_content.Tabs.Count==0)
            {
                AddComponent(f, name);
            }
            else
            {
                for (int i = 0; i < tapcol_content.Tabs.Count; i++)
                {


                    //Control con = conv.AttachedControl;
                    Control con = tapcol_content.Tabs[i].AttachedControl;

                    Console.WriteLine("ten0:" + con.Name);
                    foreach (Control con1 in con.Controls)
                    {
                        Console.WriteLine("ten1:" + con1.Name);
                        foreach (Control con2 in con1.Controls)
                        {
                            Console.WriteLine("ten2:" + con2.Name);
                            foreach (Control con3 in con2.Controls)
                            {
                                Console.WriteLine("ten3:" + con3.Name);
                                if (con3.Name == f.Name)
                                {
                                    kt = 1;
                                    Console.WriteLine("da ton tai");
                                    tapcol_content.SelectedTab = tapcol_content.Tabs[i];
                                    break;

                                }

                            }
                        }
                    }

                    if (i == tapcol_content.Tabs.Count - 1 && kt == 0)
                    {

                        // add form
                        AddComponent(f, name);
                        break;


                    }

                }
            }
            


            
        }
        public void AddComponent(Form f, string name)
        {
            //add form to panel
            Panel pa = new Panel();
            pa.Dock = DockStyle.Fill;
            pa.AutoScroll = true;
            pa.Controls.Add(f);
            pa.Padding=  new Padding(0);
            pa.Name = "panel" + name;
            
            
            //add form to group
            DevComponents.DotNetBar.Controls.GroupPanel g = new DevComponents.DotNetBar.Controls.GroupPanel();
            g.Resize += new EventHandler(pnl_resize);
            g.Dock = DockStyle.Fill;
            pa.Size =  new Size(g.Width - 6, g.Height - 21);
            f.Size=g.Size; 
            ///// set group box
            g.Text = name;
            g.Name = "group_panel" + name;
            g.CanvasColor = System.Drawing.SystemColors.Control;
            g.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            //g.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            g.DrawTitleBox = false;
            g.Location = new System.Drawing.Point(1, 1);
            g.ShowFocusRectangle = true;
            g.Dock = DockStyle.Fill;
            g.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            g.Style.BackColorGradientAngle = 90;
            g.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            g.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            g.Style.BorderBottomWidth = 1;
            g.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            g.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            g.Style.BorderLeftWidth = 1;
            g.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            g.Style.BorderRightWidth = 1;
            g.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            g.Style.BorderTopWidth = 1;
            g.Style.CornerDiameter = 4;
            g.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            g.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            g.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            g.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            g.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            g.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            g.AutoSize = true;
            //////////////
            g.TabIndex = 0;
            g.Controls.Add(pa);
            //add group to tabpage
            DevComponents.DotNetBar.TabControlPanel p = new DevComponents.DotNetBar.TabControlPanel();
            p.Dock = DockStyle.Fill;
            p.Name = "tab_panel" + name;
            p.Controls.Add(g);
            DevComponents.DotNetBar.TabItem t = new DevComponents.DotNetBar.TabItem();
            t.Text = name;
            t.AttachedControl = p;
            t.Name = "tab_title" + name;
            t.Icon = ((System.Drawing.Icon)(tabItemHome.Icon));
            // add tab_item to tab
            tapcol_content.Tabs.Add(t);
            tapcol_content.SelectedTab = t;
            // refesh
           // tapcol_content.Refresh();
            //this.Refresh();

        }
        #endregion add_form_to_tab

        #region ui

        /// <summary>
        /// ktra du lieu truoc khi dong page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabMenu_TabItemClose(object sender, DevComponents.DotNetBar.TabStripActionEventArgs e)
        {

                Console.WriteLine(((DevComponents.DotNetBar.TabControl)sender).SelectedTab.Name);

        }

        /// <summary>
        /// mo rong khi click vao menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabMenu_TabStripMouseClick(object sender, MouseEventArgs e)
        {
            if (pnlTop.Height == 50)
            {
                pnlTop.Height = 150;
                pnlImage.Width = 200;
                btnExpand.BackgroundImage.RotateFlip(RotateFlipType.Rotate180FlipX);
            }
        }

        /// <summary>
        /// click mo rong
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExpand_Click(object sender, EventArgs e)
        {
            if(pnlTop.Height == 150)
            {
                pnlTop.Height = 50;
                pnlImage.Width = 0;
            }
            else
            {
                pnlTop.Height = 150;
                pnlImage.Width = 200;
            }
            

            btnExpand.BackgroundImage.RotateFlip(RotateFlipType.Rotate180FlipX);
        }

        /// <summary>
        /// resize sub_frm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnl_resize(object sender, EventArgs e)
        {
            Control m = (Control)sender;
            if (m.HasChildren )
            {
                Control n = m.Controls[0];
                if (n.HasChildren)
                {
                    Control c = n.Controls[0];
                    n.Location = new Point(0, 0);
                    n.Size = new Size(m.Width - 6, m.Height - 21);
                    c.Size = new Size(n.Width, n.Height);

                }
            }

           




        }



        #endregion
    }
}
