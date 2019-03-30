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
    public partial class frmEditEntry : Form
    {
        public String date;
        public String description;
        public String duration;
        public String stage;

        public frmEditEntry()
        {
            InitializeComponent();
        }

        private void frmEditEntry_Load(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Parse(this.date);
            txtDescription.Text = this.description;
            nudDuration.Value = (decimal) Double.Parse(this.duration);
            cboStage.Text = this.stage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.date = dtpDate.Value.ToShortDateString();
            this.description = txtDescription.Text;
            this.duration = nudDuration.Value.ToString();
            this.stage = cboStage.Text;
            this.Close();
        }
    }
}
