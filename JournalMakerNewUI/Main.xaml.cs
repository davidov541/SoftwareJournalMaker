using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Windows.Forms;
using System.IO;
using System.Windows.Media;

namespace JournalMakerNewUI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Main : Window
    {

        public Main()
        {
            XmlDataProvider provider = App.Current.TryFindResource("xmlConfigProvider") as XmlDataProvider;
            if (provider != null)
            {
                XmlDocument doc = provider.Document;
                if (doc != null)
                {
                    XmlDataProvider data = App.Current.TryFindResource("xmlDataProvider") as XmlDataProvider;
                    data.Source = new Uri(doc["Configuration"]["LastProject"].InnerText);
                    InitializeComponent();
                }

            }
        }

        private void NewProject_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "pj";
            sfd.AddExtension = true;
            bool canContinue = false;
            DialogResult dr = sfd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                while (canContinue == false)
                {
                    NewProject window = new NewProject(false, sfd.FileName);
                    if (window.ShowDialog() == true)
                    {
                        Estimate est = new Estimate();
                        if (est.ShowDialog() == true)
                        {
                            canContinue = true;
                        }
                        else
                        {
                            canContinue = false;
                        }
                    }
                    else
                    {
                        canContinue = true;
                    }
                }
            }
        }

        private void NewEntry_Click(object sender, RoutedEventArgs e)
        {
            NewEntry window = new NewEntry(0);
            
            if (window.ShowDialog() == true)
            {
            }
            else
            {

            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            bool gothrough = false;
            DialogResult dr;
            while (!gothrough)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if ((dr = ofd.ShowDialog()) == System.Windows.Forms.DialogResult.OK && ofd.CheckPathExists && ofd.CheckFileExists)
                {
                    XmlDataProvider config = App.Current.TryFindResource("xmlConfigProvider") as XmlDataProvider;
                    if (config != null)
                    {
                        XmlDocument doc = config.Document;
                        if (doc != null)
                        {
                            doc.SelectSingleNode("/Configuration/LastProject").InnerText = ofd.FileName;
                            doc.Save(config.Source.ToString());
                            XmlDataProvider data = App.Current.TryFindResource("xmlDataProvider") as XmlDataProvider;
                            data.Source = new Uri(ofd.FileName);
                        }
                    }
                    gothrough = true;
                }
                else if (dr == System.Windows.Forms.DialogResult.OK && (!ofd.CheckPathExists || !ofd.CheckFileExists))
                {
                    System.Windows.MessageBox.Show("Please choose a correct file and try again.");
                }
                else
                {
                    gothrough = true;
                }
            }
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            XmlDataProvider provider = App.Current.TryFindResource("xmlDataProvider") as XmlDataProvider;
            if (provider != null)
            {
                XmlDocument doc = provider.Document;
                if (doc != null)
                {
                    PdfDocument pdf = new PdfDocument();
                    PdfPage page = pdf.AddPage();
                    XGraphics xg = XGraphics.FromPdfPage(page);
                    XFont boldFont = new XFont("Times New Roman", 12, XFontStyle.Bold);
                    XFont font = new XFont("Times New Roman", 12);
                    int ypos = 20;
                    int num = 1;
                    foreach (XmlElement element in doc.SelectNodes("/Project/Logs/Log"))
                    {
                        if ((num - 1) % 5 == 0 && num != 1)
                        {
                            page = pdf.AddPage();
                            xg = XGraphics.FromPdfPage(page);
                            ypos = 20;
                        }
                        WriteString(element.SelectSingleNode("Date").InnerText, boldFont, xg, 10, ypos, page.Width);
                        xg.DrawLine(XPens.Black, new System.Drawing.Point(0, ypos + 13), new System.Drawing.Point((int)page.Width.Value, ypos + 13));
                        ypos += 20;
                        WriteString("Development Stage: " + element.SelectSingleNode("DevelopmentStage/ReadableString").InnerText, font, xg, 10, ypos, page.Width);
                        ypos += 20;
                        WriteString(element.SelectSingleNode("Comments").InnerText, font, xg, 10, ypos, page.Width);
                        ypos += 60;
                        WriteString("Duration: " + element.SelectSingleNode("Duration").InnerText + " hours", font, xg, 10, ypos, page.Width);
                        ypos += 20;
                        num++;
                        ypos += 20;
                    }
                    String[] parts = provider.Source.ToString().Split('/', '\\', '.');
                    String ending = parts[parts.Length - 2];
                    String filename = ending + ".pdf";
                    pdf.Save(filename);
                    Process.Start(filename);
                }
            }
        }

        private void Properties_Click(object sender, RoutedEventArgs e)
        {
            bool canContinue = false;
            while (canContinue == false)
            {
                NewProject window = new NewProject(true, "");
                if (window.ShowDialog() == true)
                {
                    Estimate est = new Estimate();
                    if (est.ShowDialog() == true)
                    {
                        canContinue = true;
                    }
                    else
                    {
                        canContinue = false;
                    }
                }
                else
                {
                    canContinue = true;
                }
            }
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Settings window = new Settings();
            if (window.ShowDialog() == true)
            {

            }
            else
            {

            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void lvGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DependencyObject obj = (DependencyObject)e.OriginalSource;

            while (obj != null && obj != this.lvGrid)
            {
                if (obj.GetType() == typeof(System.Windows.Controls.ListViewItem))
                {
                    NewEntry window = new NewEntry(lvGrid.SelectedIndex + 1);
                    if (window.ShowDialog() == true)
                    {

                    }
                    else
                    {

                    }
                    break;
                }
                obj = VisualTreeHelper.GetParent(obj);
            }
        }

        private void lvBugGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DependencyObject obj = (DependencyObject)e.OriginalSource;

            while (obj != null && obj != this.lvBugGrid)
            {
                if (obj.GetType() == typeof(System.Windows.Controls.ListViewItem))
                {
                    NewBug window = new NewBug(lvBugGrid.SelectedIndex + 1);
                    if (window.ShowDialog() == true)
                    {

                    }
                    else
                    {

                    }
                    break;
                }
                obj = VisualTreeHelper.GetParent(obj);
            }
        }

        private void BugReport_Click(object sender, RoutedEventArgs e)
        {
            NewBug window = new NewBug(0);
            if (window.ShowDialog() == true)
            {

            }
            else
            {

            }
        }

        private void WriteString(String str, XFont font, XGraphics xg, int x, int y, XUnit width)
        {
            Document doc = new Document();
            MigraDoc.DocumentObjectModel.Section sec = doc.AddSection();
            MigraDoc.DocumentObjectModel.Paragraph para = sec.AddParagraph();
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

    }
}
