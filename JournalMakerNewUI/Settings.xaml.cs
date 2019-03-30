using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Xml;

namespace JournalMakerNewUI
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
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
                XmlDataProvider provider = App.Current.TryFindResource("xmlConfigProvider") as XmlDataProvider;
                if (provider != null)
                {
                    XmlDocument doc = provider.Document;
                    if (doc != null)
                    {
                        doc.Save(provider.Source.ToString());
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            XmlDataProvider provider = App.Current.TryFindResource("xmlConfigProvider") as XmlDataProvider;
            if (provider != null)
            {
                XmlDocument doc = provider.Document;
                if (doc != null)
                {
                    XmlElement newstage = doc.CreateElement("Stage");
                    newstage.InnerText = txtNewStage.Text;
                    doc.SelectSingleNode("/Configuration/Stages").AppendChild(newstage);
                }
            }
        }
    }
}
