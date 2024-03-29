﻿using LGAConnectSOMS.Models;
using LGAConnectSOMS.Properties;
using LGAConnectSOMS.Services;
using LGAConnectSOMS.Views;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGAConnectSOMS
{
    public partial class HomeViewAdmin : Form
    {
       
        public HomeViewAdmin()
        {            
            InitializeComponent();          
        }

        //Load
        private void HomeView_Load(object sender, EventArgs e)
        {
            LoadData();
            var profile = Settings.Default.TeacherProfile;
            byte[] convertprofile = System.Convert.FromBase64String(profile);
            var imageMemoryStream = new MemoryStream(convertprofile);
            Image imgFromStream = Image.FromStream(imageMemoryStream);
            pictureBox1.Image = imgFromStream;          
            btnHome.ForeColor = Color.FromArgb(255, 246, 143);
            //CustomFont();
            lblAccountName.Text = Settings.Default.Fullname;
            lblTitle.Text = "Good Day, " + Settings.Default.Firstname;
            this.RestoreWindowPosition();
            panel1.Hide();           
            MaximizeIcon();
            
        }


        public async void LoadData()
        {
            await DynamicHomeViewAdminPanel();
        }


        //public void CustomFont()
        //{
        //    //Create your private font collection object.
        //    PrivateFontCollection pfc = new PrivateFontCollection();

        //    //Select your font from the resources.
        //    //My font here is "Digireu.ttf"
        //    int fontLength = Properties.Resources.Montserrat_Medium.Length;
            

        //    // create a buffer to read in to
        //    byte[] fontdata = Properties.Resources.Montserrat_Medium;
            
        //    // create an unsafe memory block for the font data
        //    System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
          

        //    // copy the bytes to the unsafe memory block
        //    Marshal.Copy(fontdata, 0, data, fontLength);       

        //    // pass the font to the font collection
        //    pfc.AddMemoryFont(data, fontLength);            

        //    lblTitle.Font = new Font(pfc.Families[0], 20);          
        //    lblAccountName.Font = new Font(pfc.Families[0], 10);
        //    lblUserRole.Font = new Font(pfc.Families[0], 10);
        //    btnHome.Font = new Font(pfc.Families[0], 12);
        //    btnClassRecords.Font = new Font(pfc.Families[0], 12);
        //    btnClassSchedule.Font = new Font(pfc.Families[0], 12);
        //    btnManageNews.Font = new Font(pfc.Families[0], 12);
        //    btnPaymentRecords.Font = new Font(pfc.Families[0], 12);
        //    lblTitleNewsPanel.Font = new Font(pfc.Families[0], 10);
        //    lblvViewMoreNews.Font = new Font(pfc.Families[0], 8);
        //    lblArticleTitle.Font = new Font(pfc.Families[0], 12);
        //    lblArticelDescription.Font = new Font(pfc.Families[0], 10);
        //}


        //NavigationToOtherForm

        private void btnClassRecords_Click(object sender, EventArgs e)
        {
            this.SaveWindowPosition();
            var CRAV = new ClassRecordAdminView();
            CRAV.Show();
            Task.Delay(5000);
            this.Hide();
        }

        private void btnManageNews_Click(object sender, EventArgs e)
        {
            this.SaveWindowPosition();
            var MNV = new ManageNewsView();
            MNV.Show();
            Task.Delay(5000);
            this.Hide();

        }

        private void btnPaymentRecords_Click(object sender, EventArgs e)
        {
            this.SaveWindowPosition();
            var PRV = new PaymentRecordsView();
            PRV.Show();
            this.Hide();
        }

        private void btnClassSchedule_Click(object sender, EventArgs e)
        {
            this.SaveWindowPosition();
            var CSV = new ClassScheduleView();
            CSV.Show();
            this.Hide();
        }

        private void btnFacultyAdmin_Click(object sender, EventArgs e)
        {
            this.SaveWindowPosition();
            FacultyAdminRecords facultyAdminRecords = new FacultyAdminRecords();
            facultyAdminRecords.Show();
            this.Hide();
        }


        //Commands

        public async Task DynamicHomeViewAdminPanel()
        {
            //StudentService studentService = new StudentService();
            //var students = await studentService.GetStudentAccount();
            //var studentsList = students.Select(x => x.ID).ToList();
            
            Panel EnrolledStudentsPanel = new Panel();
            Panel FileRequestPanel = new Panel();
            EnrolledStudentsPanel.Size = new System.Drawing.Size(219, 188);
            EnrolledStudentsPanel.Location = new System.Drawing.Point(1069, 121);
            EnrolledStudentsPanel.BackColor = Color.FromArgb(233, 77, 144);
            EnrolledStudentsPanel.TabIndex = 0;
            FileRequestPanel.Size = new System.Drawing.Size(219, 188);
            FileRequestPanel.Location = new System.Drawing.Point(1069, 326);
            FileRequestPanel.BackColor = Color.FromArgb(33, 209, 255);
            FileRequestPanel.TabIndex = 0;
            Controls.Add(EnrolledStudentsPanel);
            Controls.Add(FileRequestPanel);
            Label lblEnrolledStudents = new Label();
            Label lblEnrolledStudentsCount = new Label();
            Label lblFileRequestCount = new Label();
            lblEnrolledStudents.Text = "Enrolled\nStudents";
            lblEnrolledStudents.ForeColor = Color.White;
            lblEnrolledStudents.Font = new Font("Tw Cen MT", 14);
            lblEnrolledStudents.AutoSize = true;            
            lblEnrolledStudentsCount.ForeColor = Color.White;
            lblEnrolledStudentsCount.Font = new Font("Tw Cen MT", 36);
            lblEnrolledStudentsCount.AutoSize = true;
            lblEnrolledStudentsCount.Location = new System.Drawing.Point(0,130);
            Label lblFileRequest = new Label();
            lblFileRequest.Text = "File\nRequest";
            lblFileRequest.ForeColor = Color.White;
            lblFileRequest.Font = new Font("Tw Cen MT", 14);
            lblFileRequest.AutoSize = true;
            lblFileRequestCount.Text = "10";
            lblFileRequestCount.ForeColor = Color.White;
            lblFileRequestCount.Font = new Font("Tw Cen MT", 36);
            lblFileRequestCount.AutoSize = true;
            lblFileRequestCount.Location = new System.Drawing.Point(0, 130);
            EnrolledStudentsPanel.Controls.Add(lblEnrolledStudents);
            EnrolledStudentsPanel.Controls.Add(lblEnrolledStudentsCount);
            FileRequestPanel.Controls.Add(lblFileRequest);
            FileRequestPanel.Controls.Add(lblFileRequestCount);
            EnrolledStudentsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            FileRequestPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            EnrolledStudentsPanel.Cursor = Cursors.Hand;
            //lblEnrolledStudentsCount.Text = studentsList.Count.ToString();
        }

        //Buttons Forecolor and background Styles
        private void btnHome_MouseEnter(object sender, EventArgs e)
        {
            //btnHome.ForeColor = Color.FromArgb(255, 246, 143);           
        }

        private void btnHome_MouseLeave(object sender, EventArgs e)
        {
            //btnHome.ForeColor = Color.White;
        }

        private void btnClassRecords_MouseEnter(object sender, EventArgs e)
        {
            btnClassRecords.ForeColor = Color.FromArgb(255, 246, 143);
        }

        private void btnClassRecords_MouseLeave(object sender, EventArgs e)
        {
            btnClassRecords.ForeColor = Color.White;
        }

        private void btnClassSchedule_MouseEnter(object sender, EventArgs e)
        {
            btnClassSchedule.ForeColor = Color.FromArgb(255, 246, 143);
        }

        private void btnClassSchedule_MouseLeave(object sender, EventArgs e)
        {
            btnClassSchedule.ForeColor = Color.White;
        }

        private void btnManageNews_MouseEnter(object sender, EventArgs e)
        {
            btnManageNews.ForeColor = Color.FromArgb(255, 246, 143);
        }

        private void btnManageNews_MouseLeave(object sender, EventArgs e)
        {
            btnManageNews.ForeColor = Color.White;
        }

        private void btnPaymentRecords_MouseEnter(object sender, EventArgs e)
        {
            btnPaymentRecords.ForeColor = Color.FromArgb(255, 246, 143);
        }

        private void btnPaymentRecords_MouseLeave(object sender, EventArgs e)
        {
            btnPaymentRecords.ForeColor = Color.White;
        }



        //TitleBarFunction

        private void RestoreWindowPosition()
        {
            
            try
            {
                if (Settings.Default.HasSetDefault)
                {
                    this.WindowState = Settings.Default.WindowState;
                    this.Location = Settings.Default.Location;
                    this.Size = Settings.Default.Size;
                   

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void HomeViewAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.SaveWindowPosition();
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SaveWindowPosition()
        {
            try
            {
                Settings.Default.WindowState = this.WindowState;

                if (this.WindowState == FormWindowState.Normal)
                {
                    Settings.Default.Location = this.Location;
                    Settings.Default.Size = this.Size;
                   

                }
                else
                {
                    Settings.Default.Location = this.RestoreBounds.Location;
                    Settings.Default.Size = this.RestoreBounds.Size;
                }

                Settings.Default.HasSetDefault = true;

                Settings.Default.Save();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Minimized;
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    this.WindowState = FormWindowState.Maximized;
                    btnMaximize.Image = LGAConnectSOMS.Properties.Resources.NormalBlack;
                    
                }

                else
                {
                    this.WindowState = FormWindowState.Normal;
                    btnMaximize.Image = LGAConnectSOMS.Properties.Resources.FullScreenBlack;
                   
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //DragWIindows

        private Point _mouseLoc;        
        private void DragWindowsPanel_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;
                    btnMaximize.Image = LGAConnectSOMS.Properties.Resources.FullScreenBlack;
                   
                }

                _mouseLoc = e.Location;

            }
            catch (Exception)
            {

                throw;
            }

        }

        private void DragWindowsPanel_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    int dx = e.Location.X - _mouseLoc.X;
                    int dy = e.Location.Y - _mouseLoc.Y;
                    this.Location = new Point(this.Location.X + dx, this.Location.Y + dy);
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void DragWindowsPanel_MouseUp(object sender, MouseEventArgs e)
        {
           
        }

        public void MaximizeIcon()
        {

            try
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    btnMaximize.Image = LGAConnectSOMS.Properties.Resources.NormalBlack;
                }

                else if (this.WindowState == FormWindowState.Normal)
                {
                    btnMaximize.Image = LGAConnectSOMS.Properties.Resources.FullScreenBlack;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {                      
            IsMenuVisible();
        }

        public void IsMenuVisible()
        {
            if (panel1.Visible == false)
            {
                panel1.Show();
            }

            else if(panel1.Visible == true)
            {
                panel1.Hide();
            }
        }

        public const int Form_DropShadow = 0x00020000;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= Form_DropShadow;
                return cp;
            }
        }

        private void HomeViewAdmin_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SaveWindowPosition();
            Settings.Default.ID = 0;
            Settings.Default.Firstname = null;
            Settings.Default.Lastname = null;
            Settings.Default.Fullname = null;
            LoginPageView loginPageView = new LoginPageView();
            loginPageView.Show();
            this.Hide();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutPageView aboutPageView = new AboutPageView();
            aboutPageView.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            IsMenuVisible();
        }
    }    
}
