using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace JournalMaker
{
    class DataEntry
    {

        private String _projectname, _description, _devstage;
        private DateTime _date;
        private TimeSpan _duration;

        public DataEntry(String projectName, String date, double duration, String description, String devstage)
        {
            this._projectname = projectName;
            this._date = DateTime.Parse(date);
            this._duration = TimeSpan.FromHours(duration);
            this._description = description;
            this._devstage = devstage;
        }

        public XmlDocument UpdateXml(XmlDocument doc, int num) 
        {
            XmlNode newNode = doc.CreateElement("Log");
            XmlNode dateNode = doc.CreateElement("Date");
            XmlNode descriptionNode = doc.CreateElement("Description");
            XmlNode durationNode = doc.CreateElement("Duration");
            XmlNode stageNode = doc.CreateElement("DevelopmentStage");
            dateNode.InnerText = this.Date;
            descriptionNode.InnerText = this.Description;
            durationNode.InnerText = this.Duration.ToString();
            stageNode.InnerText = this.DevStage;
            newNode.AppendChild(dateNode);
            newNode.AppendChild(descriptionNode);
            newNode.AppendChild(durationNode);
            newNode.AppendChild(stageNode);
            foreach (XmlNode child in doc["Project"]["Logs"].GetElementsByTagName("Log"))
            {
                if (num == 0)
                {
                    doc["Project"]["Logs"].ReplaceChild(newNode, child);
                    return doc;
                }
                num--;
            }
            return doc;
        }

        public String ProjectName
        {
            get
            {
                return this._projectname;
            }
            set
            {
                this._projectname = value;
            }
        }

        public String Date
        {
            get
            {
                return this._date.ToShortDateString();
            }
            set
            {
                this._date = DateTime.Parse(value);
            }
        }

        public DateTime DateTimeDate
        {
            get
            {
                return this._date;
            }
        }

        public double Duration
        {
            get
            {
                return this._duration.TotalHours;
            }
            set
            {
                this._duration = TimeSpan.FromHours(value);
            }
        }

        public String Description
        {
            get
            {
                return this._description;
            }
            set
            {
                this._description = value;
            }
        }

        public String DevStage
        {
            get
            {
                return this._devstage;
            }
            set
            {
                this._devstage = value;
            }
        }
    }
}
