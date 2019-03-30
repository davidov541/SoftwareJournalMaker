using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JournalMaker
{
    public partial class frmNewProject : Form
    {
        public String name;
        public String description;
        public String status;
        public String stage;


        public frmNewProject()
        {
            InitializeComponent();
        }   

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.name = txtProjectName.Text;
            this.description = txtDescription.Text;
            this.stage = cboStage.Text;
            this.status = txtCurrentStatus.Text;
            this.Tag = "Submitted";
            this.Close();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNewProject_Load(object sender, EventArgs e)
        {
            txtProjectName.Text = this.name;
            txtDescription.Text = this.description;
            cboStage.SelectedText = this.stage;
            txtCurrentStatus.Text = this.status;
        }
    }
}
