using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace JournalMakerNewUI
{
    /// <summary>
    /// Interaction logic for NewProject.xaml
    /// </summary>
    public partial class NewProject : Window
    {
        public String[] stages;
        private bool newProj;

        public NewProject(bool useCurrentProj, String newFile)
        {
            InitializeComponent();
            this.lstFiles.DataContext = new ObservableCollection<String>();
            this.newProj = useCurrentProj;
            XmlDataProvider provider = App.Current.TryFindResource("xmlDataProvider") as XmlDataProvider;
            if (provider != null)
            {
                if (!useCurrentProj)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.AppendChild(doc.CreateXmlDeclaration("1.0", "us-ascii", ""));
                    doc.AppendChild(doc.CreateElement("Project"));
                    doc["Project"].SetAttribute("xmlns", "");
                    doc["Project"].AppendChild(doc.CreateElement("Title"));
                    doc["Project"]["Title"].InnerText = "";
                    doc["Project"].AppendChild(doc.CreateElement("Description"));
                    doc["Project"]["Description"].InnerText = "";
                    doc["Project"].AppendChild(doc.CreateElement("Developer"));
                    doc["Project"]["Developer"].InnerText = "";
                    doc["Project"].AppendChild(doc.CreateElement("Language"));
                    doc["Project"]["Language"].InnerText = "";
                    doc["Project"].AppendChild(doc.CreateElement("CurrentStage"));
                    doc["Project"]["CurrentStage"].AppendChild(doc.CreateElement("ReadableString"));
                    doc["Project"]["CurrentStage"]["ReadableString"].InnerText = "";
                    doc["Project"]["CurrentStage"].AppendChild(doc.CreateElement("Numeric"));
                    doc["Project"]["CurrentStage"]["Numeric"].InnerText = "";
                    doc["Project"].AppendChild(doc.CreateElement("Estimations"));
                    XmlDocument configdoc = (App.Current.TryFindResource("xmlConfigProvider") as XmlDataProvider).Document;
                    foreach (XmlElement stage in configdoc.SelectNodes("Configuration/Stages/Stage"))
                    {
                        XmlElement est = doc.CreateElement("Estimation");
                        XmlElement stageel = doc.CreateElement("Stage");
                        stageel.InnerText = stage.InnerText;
                        est.AppendChild(stageel);
                        XmlElement timeest = doc.CreateElement("TimeEst");
                        est.AppendChild(timeest);
                        XmlElement locest = doc.CreateElement("LOCEst");
                        est.AppendChild(locest);
                        doc["Project"]["Estimations"].AppendChild(est);
                    }
                    doc["Project"].AppendChild(doc.CreateElement("Logs"));
                    doc["Project"].AppendChild(doc.CreateElement("BugReports"));
                    FileInfo fi = new FileInfo(newFile);
                    fi.Create().Close();
                    doc.Save(newFile);
                    provider.Source = new Uri(newFile);
                }
            }
            else
            {
                Console.WriteLine("Error -- XmlDataProvider was null");
            }
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        void OnClosing(object sender, CancelEventArgs e)
        {
            if (this.DialogResult == true)
            {
                XmlDataProvider provider = App.Current.TryFindResource("xmlDataProvider") as XmlDataProvider;
                if (provider != null)
                {
                    XmlDocument doc = provider.Document;
                    if (doc != null)
                    {
                        doc.SelectSingleNode("/Project/CurrentStage/ReadableString").InnerText = this.cboStage.SelectedValue.ToString();
                        doc.SelectSingleNode("/Project/CurrentStage/Numeric").InnerText = this.cboStage.SelectedIndex.ToString();
                        doc.SelectSingleNode("/Project/Title").InnerText = this.txtName.Text;
                        doc.SelectSingleNode("/Project/Description").InnerText = this.txtDesc.Text;
                        doc.SelectSingleNode("/Project/Language").InnerText = this.txtLanguage.Text;
                        doc.SelectSingleNode("/Project/Developer").InnerText = this.txtDeveloper.Text;
                        doc.Save(provider.Source.OriginalString);
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DialogResult dr;
            OpenFileDialog ofd = new OpenFileDialog();
            if ((dr = ofd.ShowDialog()) == System.Windows.Forms.DialogResult.OK && ofd.CheckPathExists && ofd.CheckFileExists)
            {
                XmlDataProvider provider = App.Current.TryFindResource("xmlDataProvider") as XmlDataProvider;
                XmlDocument doc = provider.Document;
                XmlElement topelement = doc.CreateElement("SourceFile");
                topelement.InnerText = ofd.FileName;
                doc.SelectSingleNode("/Project").AppendChild(topelement);
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            XmlDataProvider provider = App.Current.TryFindResource("xmlDataProvider") as XmlDataProvider;
            XmlDocument doc = provider.Document;
            foreach(XmlElement element in doc.SelectNodes("/Project/SourceFile"))
            {
                if (element.InnerText.Equals(this.lstFiles.SelectedValue.ToString()))
                {
                    doc.RemoveChild(element);
                    return;
                }
            }
        }
    }
}
