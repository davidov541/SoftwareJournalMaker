using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Xml;
using System.Windows.Threading;
using System.Collections.Generic;

namespace JournalMakerNewUI
{
    /// <summary>
    /// Interaction logic for NewEntry.xaml
    /// </summary>
    public partial class NewBug : Window
    {
        private int entry = -1;
        private DispatcherTimer _runtime, _inttime;
        private int _lastIntTime;
        private List<String> _sourcefiles;
        private int _oldsize;

        public NewBug(int entryIndex)
        {
            entry = entryIndex;
            System.Windows.Forms.Application.EnableVisualStyles();
            this._oldsize = 0;
            this._sourcefiles = new List<string>();
            if (entryIndex > 0)
            {
                XmlDataProvider provider = App.Current.TryFindResource("xmlDataProvider") as XmlDataProvider;
                if (provider != null)
                {
                    provider.XPath = "/Project/BugReports/BugReport[" + entryIndex + "]";
                }
                XmlDocument doc = provider.Document;
                if (doc != null)
                {
                    foreach (XmlElement sourcefile in doc.SelectNodes("/Project/SourceFile"))
                    {
                        this._oldsize += Util.GetLOC(sourcefile.InnerText);
                        this._sourcefiles.Add(sourcefile.InnerText);
                    }
                }
            }
            InitializeComponent();
            if (entryIndex <= 0)
            {
                this.DataContext = null;
            }
            this._runtime = new DispatcherTimer();
            this._runtime.Interval = new TimeSpan(0, 1, 0);
            this._runtime.Tick += new EventHandler(_runtime_Elapsed);
            this._inttime = new DispatcherTimer();
            this._inttime.Interval = new TimeSpan(0, 1, 0);
            this._inttime.Tick += new EventHandler(_inttime_Elapsed);
            this._lastIntTime = 0;
        }

        void _inttime_Elapsed(object sender, EventArgs e)
        {
            this.udIntDuration.Value += (decimal)1;
        }

        void _runtime_Elapsed(object sender, EventArgs e)
        {
            this.udFixDuration.Value += (decimal)1;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            this._runtime.Start();
            this._inttime.Stop();
            this._lastIntTime = (int)this.udIntDuration.Value;
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            this._runtime.Stop();
            this._inttime.Start();
            this._lastIntTime = (int)this.udIntDuration.Value;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            this._runtime.Stop();
            this._inttime.Stop();
            this.udIntDuration.Value = (decimal)this._lastIntTime;
        }

        void OnClosing(object sender, CancelEventArgs e)
        {
            Console.WriteLine("OnClosing is running in NewEntry");
            if (this.DialogResult == true)
            {
                XmlDataProvider provider = App.Current.TryFindResource("xmlDataProvider") as XmlDataProvider;
                if (provider != null)
                {
                    XmlDocument doc = provider.Document;
                    if (doc != null)
                    {
                        if (this.entry == 0)
                        {
                            int numChildren = doc.SelectNodes("/Project/BugReports/BugReport").Count;
                            XmlElement topelement = doc.CreateElement("BugReport");
                            XmlElement dateelement = doc.CreateElement("Date");
                            dateelement.InnerText = this.dpDate.DateTimeSelected.ToString();
                            topelement.AppendChild(dateelement);
                            XmlElement typeelement = doc.CreateElement("Type");
                            typeelement.InnerText = this.txtTypeCode.Text;
                            topelement.AppendChild(typeelement);
                            XmlElement injstage = doc.CreateElement("InjectedPhase");
                            XmlElement numericinjstage = doc.CreateElement("Numeric");
                            numericinjstage.InnerText = this.cboInjStage.SelectedIndex.ToString();
                            injstage.AppendChild(numericinjstage);
                            XmlElement readableinjstage = doc.CreateElement("ReadableString");
                            readableinjstage.InnerText = this.cboInjStage.SelectedValue.ToString();
                            injstage.AppendChild(readableinjstage);
                            topelement.AppendChild(injstage);
                            XmlElement fixstage = doc.CreateElement("FixPhase");
                            XmlElement numericfixstage = doc.CreateElement("Numeric");
                            numericfixstage.InnerText = this.cboFixStage.SelectedIndex.ToString();
                            fixstage.AppendChild(numericfixstage);
                            XmlElement readablefixstage = doc.CreateElement("ReadableString");
                            readablefixstage.InnerText = this.cboFixStage.SelectedValue.ToString();
                            fixstage.AppendChild(readablefixstage);
                            topelement.AppendChild(fixstage);
                            XmlElement durationelement = doc.CreateElement("FixTime");
                            durationelement.InnerText = this.udFixDuration.Value.ToString();
                            topelement.AppendChild(durationelement);
                            XmlElement intdurationelement = doc.CreateElement("InterruptionDuration");
                            intdurationelement.InnerText = this.udIntDuration.Value.ToString();
                            topelement.AppendChild(intdurationelement);
                            XmlElement referenceelement = doc.CreateElement("ReferenceBug");
                            topelement.AppendChild(referenceelement);
                            XmlElement descelement = doc.CreateElement("Description");
                            descelement.InnerText = this.txtDesc.Text;
                            topelement.AppendChild(descelement);
                            doc.SelectSingleNode("/Project/BugReports").AppendChild(topelement);

                            numChildren = doc.SelectNodes("/Project/Logs/Log").Count;
                            topelement = doc.CreateElement("Log");
                            dateelement = doc.CreateElement("Date");
                            dateelement.InnerText = this.dpDate.DateTimeSelected.ToString();
                            topelement.AppendChild(dateelement);
                            durationelement = doc.CreateElement("Duration");
                            durationelement.InnerText = this.udFixDuration.Value.ToString();
                            topelement.AppendChild(durationelement);
                            intdurationelement = doc.CreateElement("InterruptionDuration");
                            intdurationelement.InnerText = this.udIntDuration.Value.ToString();
                            topelement.AppendChild(intdurationelement);
                            XmlElement sizediff = doc.CreateElement("CodeSizeDifference");
                            int newcodesize = 0;
                            foreach (String sourcefile in this._sourcefiles)
                            {
                                newcodesize += Util.GetLOC(sourcefile);
                            }
                            sizediff.InnerText = newcodesize.ToString();
                            topelement.AppendChild(sizediff);
                            XmlElement devstage = doc.CreateElement("DevelopmentStage");
                            XmlElement numericstage = doc.CreateElement("Numeric");
                            numericstage.InnerText = this.cboFixStage.SelectedIndex.ToString();
                            devstage.AppendChild(numericstage);
                            XmlElement readablestage = doc.CreateElement("ReadableString");
                            readablestage.InnerText = this.cboFixStage.SelectedValue.ToString();
                            devstage.AppendChild(readablestage);
                            topelement.AppendChild(devstage);
                            descelement = doc.CreateElement("Comments");
                            descelement.InnerText = this.txtDesc.Text;
                            topelement.AppendChild(descelement);
                            doc.SelectSingleNode("/Project/Logs").AppendChild(topelement);
                        }
                        doc.Save(provider.Source.OriginalString);
                    }
                }
                e.Cancel = false;
            }
        }

        private void btnGetTypeCode_Click(object sender, RoutedEventArgs e)
        {
            BugTypeTable btt = new BugTypeTable();
            btt.Show();
        }
    }
}