using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Xml;
using System.Timers;
using System.Windows.Threading;
using System.Drawing;
using System.Collections.Generic;

namespace JournalMakerNewUI
{
    /// <summary>
    /// Interaction logic for NewEntry.xaml
    /// </summary>
    public partial class NewEntry : Window
    {
        private int entry = -1;
        private DispatcherTimer _runtime, _inttime;
        private int _lastIntTime;
        private Brush _pausemask;
        private List<String> _sourcefiles;
        private int _oldsize;

        public Brush PauseMask
        {
            get
            {
                return this._pausemask;
            }
            set
            {
                this._pausemask = value;
            }
        }

        private Brush _stopmask;

        public Brush StopMask
        {
            get
            {
                return this._stopmask;
            }
            set
            {
                this._stopmask = value;
            }
        }

        private Brush _startmask;

        public Brush StartMask
        {
            get
            {
                return this._startmask;
            }
            set
            {
                this._startmask = value;
            }
        }

        public NewEntry(int entryIndex)
        {
            this.entry = entryIndex;
            System.Windows.Forms.Application.EnableVisualStyles();
            this._oldsize = 0;
            this._sourcefiles = new List<string>();
            if (entryIndex > 0)
            {
                XmlDataProvider provider = App.Current.TryFindResource("xmlDataProvider") as XmlDataProvider;
                if (provider != null)
                {
                    provider.XPath = "/Project/Logs/Log[" + entryIndex + "]";
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
            this._pausemask = Brushes.AliceBlue;
            this._startmask = Brushes.DarkBlue;
            this._stopmask = Brushes.Blue;
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
            this.udIntDuration.Value += (decimal) 1;
        }

        void _runtime_Elapsed(object sender, EventArgs e)
        {
            this.udDuration.Value += (decimal) 1;
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
            this._lastIntTime = (int) this.udIntDuration.Value;
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            this._runtime.Stop();
            this._inttime.Start();
            this._lastIntTime = (int) this.udIntDuration.Value;
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
                            int numChildren = doc.SelectNodes("/Project/Logs/Log").Count;
                            XmlElement topelement = doc.CreateElement("Log");
                            XmlElement dateelement = doc.CreateElement("Date");
                            dateelement.InnerText = this.dpDate.DateTimeSelected.ToString();
                            topelement.AppendChild(dateelement);
                            XmlElement durationelement = doc.CreateElement("Duration");
                            durationelement.InnerText = this.udDuration.Value.ToString();
                            topelement.AppendChild(durationelement);
                            XmlElement intdurationelement = doc.CreateElement("InterruptionDuration");
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
                            numericstage.InnerText = this.cboDevStage.SelectedIndex.ToString();
                            devstage.AppendChild(numericstage);
                            XmlElement readablestage = doc.CreateElement("ReadableString");
                            readablestage.InnerText = this.cboDevStage.SelectedValue.ToString();
                            devstage.AppendChild(readablestage);
                            topelement.AppendChild(devstage);
                            XmlElement descelement = doc.CreateElement("Comments");
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
    }
}