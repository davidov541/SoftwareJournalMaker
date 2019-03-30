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
    public partial class frmNewEntry : Form
    {
        public String date;
        public String description;
        public String duration;
        public String stage;

        public frmNewEntry()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.date = dtpDate.Value.ToShortDateString();
            this.description = txtDescription.Text;
            this.duration = nudDuration.Value.ToString();
            this.stage = cboStage.Text;
            this.Tag = "Submitted";
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNewEntry_Load(object sender, EventArgs e)
        {

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
