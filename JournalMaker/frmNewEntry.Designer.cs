namespace JournalMaker
{
    partial class frmNewEntry
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.nudDuration = new System.Windows.Forms.NumericUpDown();
            this.llblStage = new System.Windows.Forms.Label();
            this.cboStage = new System.Windows.Forms.ComboBox();
            this.lblHours = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(13, 13);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(33, 13);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Date:";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(150, 6);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 1;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(13, 35);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(150, 32);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(414, 72);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(13, 112);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(50, 13);
            this.lblDuration.TabIndex = 4;
            this.lblDuration.Text = "Duration:";
            // 
            // nudDuration
            // 
            this.nudDuration.DecimalPlaces = 2;
            this.nudDuration.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.nudDuration.Location = new System.Drawing.Point(150, 110);
            this.nudDuration.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudDuration.Name = "nudDuration";
            this.nudDuration.Size = new System.Drawing.Size(56, 20);
            this.nudDuration.TabIndex = 5;
            // 
            // llblStage
            // 
            this.llblStage.AutoSize = true;
            this.llblStage.Location = new System.Drawing.Point(13, 149);
            this.llblStage.Name = "llblStage";
            this.llblStage.Size = new System.Drawing.Size(107, 13);
            this.llblStage.TabIndex = 6;
            this.llblStage.Text = "Development Stage: ";
            // 
            // cboStage
            // 
            this.cboStage.FormattingEnabled = true;
            this.cboStage.Items.AddRange(new object[] {
            "Planning",
            "Development",
            "Testing"});
            this.cboStage.Location = new System.Drawing.Point(150, 141);
            this.cboStage.Name = "cboStage";
            this.cboStage.Size = new System.Drawing.Size(133, 21);
            this.cboStage.TabIndex = 7;
            this.cboStage.Text = "Planning";
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Location = new System.Drawing.Point(212, 112);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(33, 13);
            this.lblHours.TabIndex = 8;
            this.lblHours.Text = "hours";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(407, 164);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 9;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(488, 163);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmNewEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 199);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblHours);
            this.Controls.Add(this.cboStage);
            this.Controls.Add(this.llblStage);
            this.Controls.Add(this.nudDuration);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDate);
            this.Name = "frmNewEntry";
            this.Text = "NewEntry";
            this.Load += new System.EventHandler(this.frmNewEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.NumericUpDown nudDuration;
        private System.Windows.Forms.Label llblStage;
        private System.Windows.Forms.ComboBox cboStage;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button button1;
    }
}