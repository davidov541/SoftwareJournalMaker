using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics;
using MigraDoc;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel;
using System.Windows;

namespace JournalMaker
{
    public partial class frmMain : Form
    {

        private XmlDocument _configdoc, _currproj;
        private List<DataEntry> _logs = new List<DataEntry>();
        private String _projdir;

        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _configdoc = new XmlDocument();
            _configdoc.Load("Configuration.config");
            _currproj = new XmlDocument();
            _projdir = _configdoc["Configuration"]["LastProject"].InnerText;
            if (!string.IsNullOrEmpty(_projdir))
            {
                _currproj.Load(_projdir);
                LoadTable();
                LoadLogs();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProject();
            this.Close();
        }

        private void newEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewEntry newEntryForm = new frmNewEntry();
            newEntryForm.ShowDialog();
            if (!String.IsNullOrEmpty(newEntryForm.Tag.ToString()))
            {
                XmlUtil.InsertNewEntry(newEntryForm, _currproj);
                LoadTable();
                LoadLogs();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmEditEntry editForm = new frmEditEntry();
            int row = 0;
            foreach (Control c in tblEntries.Controls)
            {
                if (c.GetType() == typeof(RadioButton) && ((RadioButton)c).Checked)
                {
                    row = tblEntries.GetRow(c);
                    Label lblDate = (Label)tblEntries.GetControlFromPosition(0, row);
                    Label lblDuration = (Label)tblEntries.GetControlFromPosition(1, row);
                    Label lblDescription = (Label)tblEntries.GetControlFromPosition(2, row);
                    Label lblStage = (Label)tblEntries.GetControlFromPosition(3, row);
                    editForm.date = lblDate.Text;
                    editForm.duration = lblDuration.Text;
                    editForm.description = lblDescription.Text;
                    editForm.stage = lblStage.Text;
                    continue;
                }
            }
            editForm.ShowDialog();
            _logs[row - 1] = new DataEntry(_currproj["Project"]["Title"].InnerText, editForm.date, Double.Parse(editForm.duration), editForm.description, editForm.stage);
            _currproj = _logs[row - 1].UpdateXml(_currproj, row - 1);
            LoadTable();
            LoadLogs();
        }

        private void tsmiOpenItem_Click(object sender, EventArgs e)
        {
            OpenNewProject();
        }

        private void OpenNewProject() {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult res = ofd.ShowDialog();
            if (res == DialogResult.OK)
            {
                SaveProject();
                _projdir = ofd.FileName;
                _currproj.Load(_projdir);
                LoadTable();
                LoadLogs();
                XmlUtil.UpdateProject(_configdoc, _projdir);
            }
        }

        private void tsmiToPDF_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_projdir))
            {
                PdfDocument pdf = new PdfDocument();
                PdfPage page = pdf.AddPage();
                XGraphics xg = XGraphics.FromPdfPage(page);
                XFont boldFont = new XFont("Times New Roman", 12, XFontStyle.Bold);
                XFont font = new XFont("Times New Roman", 12);
                int ypos = 20;
                int num = 1;
                foreach (DataEntry de in _logs)
                {
                    if ((num - 1) % 5 == 0 && num != 1)
                    {
                        page = pdf.AddPage();
                        xg = XGraphics.FromPdfPage(page);
                        ypos = 20;
                    }
                    WriteString(de.Date, boldFont, xg, 10, ypos, page.Width);
                    xg.DrawLine(XPens.Black, new Point(0, ypos + 13), new Point((int)page.Width.Value, ypos + 13));
                    ypos += 20;
                    WriteString("Development Stage: " + de.DevStage, font, xg, 10, ypos, page.Width);
                    ypos += 20;
                    WriteString(de.Description, font, xg, 10, ypos, page.Width);
                    ypos += 60;
                    WriteString("Duration: " + de.Duration + " hours", font, xg, 10, ypos, page.Width);
                    ypos += 20;
                    num++;
                    ypos += 20;
                }
                String filename = "Test.pdf";
                pdf.Save(filename);
                Process.Start(filename);
            }
        }

        

        private void LoadTable()
        {
            tblEntries.RowCount = 1;
            tblEntries.Controls.Clear();
            Label lblDate = new Label();
            lblDate.Text = "Date";
            lblDate.Dock = DockStyle.Fill;
            lblDate.TextAlign = ContentAlignment.MiddleCenter;
            Label lblDuration = new Label();
            lblDuration.Text = "Duration (hrs)";
            lblDuration.Dock = DockStyle.Fill;
            lblDuration.TextAlign = ContentAlignment.MiddleCenter;
            Label lblDescription = new Label();
            lblDescription.Text = "Description";
            lblDescription.Dock = DockStyle.Fill;
            lblDescription.TextAlign = ContentAlignment.MiddleCenter;
            Label lblStage = new Label();
            lblStage.Text = "Development Stage";
            lblStage.Dock = DockStyle.Fill;
            lblStage.TextAlign = ContentAlignment.MiddleCenter;
            tblEntries.Controls.Add(lblDate, 0, 0);
            tblEntries.Controls.Add(lblDuration, 1, 0);
            tblEntries.Controls.Add(lblDescription, 2, 0);
            tblEntries.Controls.Add(lblStage, 3, 0);
        }

        private void LoadLogs()
        {
            _logs.Clear();
            foreach (XmlNode child in _currproj["Project"]["Logs"].GetElementsByTagName("Log"))
            {
                DataEntry currDE = new DataEntry(_currproj["Project"]["Title"].InnerText, child["Date"].InnerText, Double.Parse(child["Duration"].InnerText), child["Description"].InnerText, child["DevelopmentStage"].InnerText);
                _logs.Add(currDE);
            }
            _logs.Sort(delegate(DataEntry de1, DataEntry de2) { return -1*de1.DateTimeDate.CompareTo(de2.DateTimeDate); });
            ShowLogs();
        }

        private void ShowLogs()
        {
            int row = 1;
            foreach (DataEntry de in _logs)
            {
                tblEntries.RowCount = row + 1;
                tblEntries.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
                Label lblDate = new Label();
                lblDate.Text = de.Date;
                lblDate.Dock = DockStyle.Fill;
                lblDate.Visible = true;
                Label lblDuration = new Label();
                lblDuration.Text = de.Duration.ToString();
                lblDuration.Dock = DockStyle.Fill;
                lblDuration.Visible = true;
                Label lblDescription = new Label();
                lblDescription.Text = de.Description;
                lblDescription.Dock = DockStyle.Fill;
                lblDescription.Visible = true;
                Label lblStage = new Label();
                lblStage.Text = de.DevStage;
                lblStage.Dock = DockStyle.Fill;
                lblStage.Visible = true;
                RadioButton rbSelected = new RadioButton();
                rbSelected.Dock = DockStyle.Fill;
                rbSelected.Visible = true;
                tblEntries.Controls.Add(lblDate, 0, row);
                tblEntries.Controls.Add(lblDuration, 1, row);
                tblEntries.Controls.Add(lblDescription, 2, row);
                tblEntries.Controls.Add(lblStage, 3, row);
                tblEntries.Controls.Add(rbSelected, 4, row);
                row++;
            }
        }

        private void SaveProject()
        {
            if (!string.IsNullOrEmpty(_projdir))
            {
                XmlTextWriter xmltw = new XmlTextWriter(_projdir, Encoding.ASCII);
                _currproj.Save(xmltw);
                xmltw.Close();
            }
        }

        private void WriteString(String str, XFont font, XGraphics xg, int x, int y, XUnit width)
        {
            Document doc = new Document();
            Section sec = doc.AddSection();
            Paragraph para = sec.AddParagraph();
            para.Format.Alignment = ParagraphAlignment.Justify;
            para.Format.Font.Name = font.Name;
            para.Format.Font.Size = font.Size;
            para.Format.Font.Bold = font.Bold;
            para.AddText(str);
            para.Format.Borders.Visible = false;
            para.Format.RightIndent = Unit.FromCentimeter(1.25d);
            para.Format.LeftIndent = Unit.FromCentimeter(1.25d);
            DocumentRenderer docrend = new DocumentRenderer(doc);
            docrend.PrepareDocument();
            docrend.RenderObject(xg, x, y, width, para);
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewProject newProjectForm = new frmNewProject();
            newProjectForm.ShowDialog();
            if (!String.IsNullOrEmpty((String) newProjectForm.Tag))
            {
                _projdir = XmlUtil.CreateNewProject(newProjectForm.name, newProjectForm.description, newProjectForm.stage, newProjectForm.status);
                _currproj.Load(_projdir);
                LoadTable();
                LoadLogs();
                XmlUtil.UpdateProject(_configdoc, _projdir);
            }
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewProject propertiesForm = new frmNewProject();
            propertiesForm.name = _currproj["Project"]["Title"].InnerText;
            propertiesForm.description = _currproj["Project"]["Description"].InnerText;
            propertiesForm.stage = _currproj["Project"]["CurrentStage"].InnerText;
            propertiesForm.status = _currproj["Project"]["CurrentStatus"].InnerText;
            propertiesForm.ShowDialog();
            XmlUtil.UpdateProjectProperties(_currproj, propertiesForm.name, propertiesForm.description, propertiesForm.stage, propertiesForm.status);
        }

    }
}
