namespace JournalMaker
{
    partial class frmMain
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
            this.tblEntries = new System.Windows.Forms.TableLayoutPanel();
            this.lblDate = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStage = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEdit = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiToPDF = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tblEntries.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblEntries
            // 
            this.tblEntries.AutoSize = true;
            this.tblEntries.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblEntries.ColumnCount = 5;
            this.tblEntries.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.430052F));
            this.tblEntries.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.46114F));
            this.tblEntries.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.98882F));
            this.tblEntries.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.51613F));
            this.tblEntries.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.360215F));
            this.tblEntries.Controls.Add(this.lblDate, 0, 0);
            this.tblEntries.Controls.Add(this.lbl, 1, 0);
            this.tblEntries.Controls.Add(this.label1, 2, 0);
            this.tblEntries.Controls.Add(this.lblStage, 3, 0);
            this.tblEntries.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblEntries.Location = new System.Drawing.Point(0, 0);
            this.tblEntries.Name = "tblEntries";
            this.tblEntries.RowCount = 1;
            this.tblEntries.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tblEntries.Size = new System.Drawing.Size(965, 16);
            this.tblEntries.TabIndex = 0;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDate.Location = new System.Drawing.Point(3, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(85, 16);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Date";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl.Location = new System.Drawing.Point(94, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(66, 16);
            this.lbl.TabIndex = 1;
            this.lbl.Text = "Duration (hrs)";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(166, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(622, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Description";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStage
            // 
            this.lblStage.AutoSize = true;
            this.lblStage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStage.Location = new System.Drawing.Point(794, 0);
            this.lblStage.Name = "lblStage";
            this.lblStage.Size = new System.Drawing.Size(134, 16);
            this.lblStage.TabIndex = 3;
            this.lblStage.Text = "Development Stage";
            this.lblStage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.tblEntries);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(965, 264);
            this.panel1.TabIndex = 1;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(831, 309);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(989, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.tsmiNewItem,
            this.tsmiOpenItem,
            this.exportToolStripMenuItem,
            this.propertiesToolStripMenuItem,
            this.toolStripSeparator1,
            this.tsmiExitItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newProjectToolStripMenuItem.Text = "New Project";
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
            // 
            // tsmiNewItem
            // 
            this.tsmiNewItem.Name = "tsmiNewItem";
            this.tsmiNewItem.Size = new System.Drawing.Size(152, 22);
            this.tsmiNewItem.Text = "New Entry";
            this.tsmiNewItem.Click += new System.EventHandler(this.newEntryToolStripMenuItem_Click);
            // 
            // tsmiOpenItem
            // 
            this.tsmiOpenItem.Name = "tsmiOpenItem";
            this.tsmiOpenItem.Size = new System.Drawing.Size(152, 22);
            this.tsmiOpenItem.Text = "Open";
            this.tsmiOpenItem.Click += new System.EventHandler(this.tsmiOpenItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiToPDF});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportToolStripMenuItem.Text = "Export...";
            // 
            // tsmiToPDF
            // 
            this.tsmiToPDF.Name = "tsmiToPDF";
            this.tsmiToPDF.Size = new System.Drawing.Size(112, 22);
            this.tsmiToPDF.Text = "To PDF";
            this.tsmiToPDF.Click += new System.EventHandler(this.tsmiToPDF_Click);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // tsmiExitItem
            // 
            this.tsmiExitItem.Name = "tsmiExitItem";
            this.tsmiExitItem.Size = new System.Drawing.Size(152, 22);
            this.tsmiExitItem.Text = "Exit";
            this.tsmiExitItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 344);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Engineering Journal Maker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tblEntries.ResumeLayout(false);
            this.tblEntries.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblEntries;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiExitItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiToPDF;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;



    }
}

