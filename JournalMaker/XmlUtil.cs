using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace JournalMaker
{
    class XmlUtil {

        public static void UpdateProject(XmlDocument configdoc, string projdir)
        {
            XmlNode newNode = configdoc.CreateElement("LastProject");
            newNode.InnerText = projdir;
            configdoc["Configuration"].ReplaceChild(newNode, configdoc["Configuration"]["LastProject"]);
        }

        public static void InsertNewEntry(frmNewEntry form, XmlDocument currproj)
        {
            XmlElement logelement = currproj.CreateElement("Log");
            XmlElement dateElement = currproj.CreateElement("Date");
            XmlElement descriptionElement = currproj.CreateElement("Description");
            XmlElement durationElement = currproj.CreateElement("Duration");
            XmlElement stageElement = currproj.CreateElement("DevelopmentStage");
            dateElement.InnerText = form.date;
            descriptionElement.InnerText = form.description;
            durationElement.InnerText = form.duration;
            stageElement.InnerText = form.stage;
            logelement.AppendChild(dateElement);
            logelement.AppendChild(descriptionElement);
            logelement.AppendChild(durationElement);
            logelement.AppendChild(stageElement);
            currproj["Project"]["Logs"].AppendChild(logelement);
        }

        public static string CreateNewProject(string name, string description, string stage, string status)
        {
            XmlDocument newproj = new XmlDocument();
            XmlDeclaration decl = newproj.CreateXmlDeclaration("1.0", "us-ascii", "");
            newproj.AppendChild(decl);
            XmlElement projnode = newproj.CreateElement("Project", "http://tempuri.org/ProjectInfo.xsd");
            XmlElement titlenode = newproj.CreateElement("Title");
            XmlElement descnode = newproj.CreateElement("Description");
            XmlElement stagenode = newproj.CreateElement("CurrentStage");
            XmlElement statusnode = newproj.CreateElement("CurrentStatus");
            titlenode.InnerText = name;
            descnode.InnerText = description;
            stagenode.InnerText = stage;
            statusnode.InnerText = status;
            projnode.AppendChild(titlenode);
            projnode.AppendChild(descnode);
            projnode.AppendChild(stagenode);
            projnode.AppendChild(statusnode);
            XmlElement logsnode = newproj.CreateElement("Logs");
            projnode.AppendChild(logsnode);
            newproj.AppendChild(projnode);
            string file = Directory.GetCurrentDirectory() + "\\" + name.Trim() + ".pj";
            XmlTextWriter xmltw = new XmlTextWriter(file, Encoding.ASCII);
            newproj.Save(xmltw);
            xmltw.Close();
            return file;
        }

        public static void UpdateProjectProperties(XmlDocument doc, string name, string description, string stage, string status)
        {
            XmlElement titlenode = doc.CreateElement("Title");
            XmlElement descnode = doc.CreateElement("Description");
            XmlElement stagenode = doc.CreateElement("CurrentStage");
            XmlElement statusnode = doc.CreateElement("CurrentStatus");
            titlenode.InnerText = name;
            descnode.InnerText = description;
            stagenode.InnerText = stage;
            statusnode.InnerText = status;
            doc["Project"].ReplaceChild(titlenode, doc["Project"]["Title"]);
            doc["Project"].ReplaceChild(descnode, doc["Project"]["Description"]);
            doc["Project"].ReplaceChild(stagenode, doc["Project"]["CurrentStage"]);
            doc["Project"].ReplaceChild(statusnode, doc["Project"]["CurrentStatus"]);
        }
    }

}