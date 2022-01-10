﻿using LGAConnectSOMS.Models;
using LGAConnectSOMS.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGAConnectSOMS.Views
{
    public partial class EditClassScheduleView : Form
    {

        private ClassSchedule _classSchedule;

        public EditClassScheduleView(ClassSchedule classSchedule)
        {
            InitializeComponent();

            _classSchedule = classSchedule;

            if (_classSchedule != null)
                PreparePageBinding();

            LoadData();
        }

        private void PreparePageBinding() 
        {
            txtFullname.Text = _classSchedule.FullName;
            txtGradeLevel.Text = _classSchedule.GradeLevel;
            txtSection.Text = _classSchedule.SectionName;
            txtSubject.Text = _classSchedule.Subject;
            cmbStartTime.Text = _classSchedule.StartTime;
            cmbEndTime.Text = _classSchedule.EndTime;
            cmbDays.Text = _classSchedule.WeekDay;
        }

        public async void LoadData()
        {
            cmbCustomDays.Hide();
            lblRepeatEvery.Hide();
            await LoadGradeLevelSection();
            await LoadSubjects();
            await LoadFaculty();
        }

        IEnumerable<GradeLevelSection> gradeLevelSections = new List<GradeLevelSection>();
        public async Task LoadGradeLevelSection()
        {
            GradeLevelSectionService gradeLevelSectionService = new GradeLevelSectionService();
            gradeLevelSections = await gradeLevelSectionService.GetGradeLevel();
            var gradelevelslist = gradeLevelSections.ToList();
        }

        IEnumerable<Subjects> subjects = new List<Subjects>();
        public async Task LoadSubjects()
        {
            SubjectsService subjectsService = new SubjectsService();
            subjects = await subjectsService.GetSubjects();
        }

        IEnumerable<SchoolAccount> schoolAccounts = new List<SchoolAccount>();
        public async Task LoadFaculty()
        {
            SchoolAccountService schoolAccountService = new SchoolAccountService();
            schoolAccounts = await schoolAccountService.GetSchoolAccountOnly();
            var facultylist = schoolAccounts.Where(x => x.isAdmin == 0).Select(x => x.Fullname);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAddClassSchedule_Click(object sender, EventArgs e)
        {
            var selectedGradeLevel = (string)txtGradeLevel.Text;
            //var selectedSection = cmbSections.SelectedItem;
            var selectedteacher = (string)txtFullname.Text;
            var selectedSubject = txtSubject.Text;
            //var gradeLevelId = gradeLevelSections.First(x => x.GradeLevels.Equals(selectedGradeLevel) && x.SectionName.Equals(selectedSection)).GradeLevel;
            //var subjectid = subjects.First(x => x.SubjectName.Equals(selectedSubject) && x.GradeLevel == gradeLevelId).GradeLevel;
            var teacherid = schoolAccounts.First(x => x.Fullname == selectedteacher).id;
            var starttime = Convert.ToDateTime(cmbStartTime.Text);
            var endtime = Convert.ToDateTime(cmbEndTime.Text);
            var startday = starttime.ToString("HH:mm:ss");
            var endday = endtime.ToString("HH:mm:ss");
        }

        private void cmbDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDays.SelectedIndex == 1)
            {
                cmbCustomDays.Show();
                lblRepeatEvery.Show();
                cmbDays.Enabled = false;
                cmbCustomDays.SelectedIndex = -1;
            }
        }

        private void cmbCustomDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomDays.Text == "Cancel")
            {
                cmbDays.Enabled = true;
                cmbCustomDays.Hide();
                lblRepeatEvery.Hide();
                cmbDays.SelectedIndex = -1;
            }
        }

        private void cmbDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbCustomDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void EditClassScheduleView_Load(object sender, EventArgs e)
        {

        }
    }
}
