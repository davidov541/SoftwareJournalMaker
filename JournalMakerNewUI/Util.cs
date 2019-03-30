using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace JournalMakerNewUI
{
    static class Util
    {
        public static int GetLOC(string filename)
        {
            int i = 0;
            FileInfo fi = new FileInfo(filename);
            FileStream fs = fi.OpenRead();
            StreamReader sr = new StreamReader(fs);
            while (sr.ReadLine() != null)
            {
                i++;
            }
            return i;
        }
    }
}