using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;

namespace JournalMakerNewUI
{
    /// <summary>
    /// Interaction logic for Estimate.xaml
    /// </summary>
    public partial class Estimate : Window
    {
        private Dictionary<String, String> _codeestimation, _timeestimation;
        public Estimate()
        {
            InitializeComponent();
            this._codeestimation = new Dictionary<string, string>();
            this._timeestimation = new Dictionary<string, string>();
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void btnFinish_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.DialogResult == true)
            {
                XmlDataProvider provider = App.Current.TryFindResource("xmlDataProvider") as XmlDataProvider;
                if (provider != null)
                {
                    XmlDocument doc = provider.Document;
                    if (doc != null)
                    {
                        XmlElement rootnode = doc.CreateElement("Estimations");
                        foreach (XmlNode node in doc.SelectNodes("/Project/Estimations/Estimation"))
                        {
                            String stage = node["Stage"].InnerText;
                            XmlElement estnode = doc.CreateElement("Estimation");
                            XmlElement timeestnode = doc.CreateElement("TimeEst");
                            XmlElement locestnode = doc.CreateElement("LOCEst");
                            if (this._timeestimation.ContainsKey(stage))
                            {
                                timeestnode.InnerText = this._timeestimation[stage];
                            }
                            if (this._codeestimation.ContainsKey(stage))
                            {
                                locestnode.InnerText = this._codeestimation[stage];
                            }
                            estnode.AppendChild(timeestnode);
                            estnode.AppendChild(locestnode);
                            rootnode.AppendChild(estnode);
                        }
                        doc.RemoveChild(doc.SelectSingleNode("/Project/Estimations"));
                        doc.AppendChild(rootnode);

                        doc.Save(provider.Source.LocalPath);
                    }
                }
            }

        }

        private void txtEstDur_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox) sender;
            XmlText xmlt = (XmlText)tb.Tag;
            if (this._timeestimation.ContainsKey(xmlt.Value.ToString()))
            {
                this._timeestimation.Remove(xmlt.Value.ToString());
            }
            this._timeestimation.Add(xmlt.Value.ToString(), tb.Text);
        }

        private void txtEstLOC_TextChanged(object sender, TextChangedEventArgs e)
        {
           TextBox tb = (TextBox)sender;
            XmlText xmlt = (XmlText)tb.Tag;
            if (this._codeestimation.ContainsKey(xmlt.Value.ToString()))
            {
                this._codeestimation.Remove(xmlt.Value.ToString());
            }
            this._codeestimation.Add(xmlt.Value.ToString(), tb.Text);
        }
    }
}
