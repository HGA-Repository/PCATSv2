using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;


namespace MPSUpdate
{
    [Serializable]
    public class CAppUpdate
    {
        private bool mbPerformUpdate;
        private string msUpdateLocation;
        private string msUpdateFile;

        #region Properties

        public bool PerformUpdate
        {
            get { return mbPerformUpdate; }
            set { mbPerformUpdate = value; }
        }

        public string UpdateLocation
        {
            get { return msUpdateLocation; }
            set { msUpdateLocation = value; }
        }

        public string UpdateFile
        {
            get { return msUpdateFile; }
            set { msUpdateFile = value; }
        }

        #endregion

        public void Clear()
        {
            mbPerformUpdate = false;
            msUpdateLocation = @"\\server\eng\itmanagement";
            msUpdateFile = "MPS.exe";
        }

        public void InitAppSettings()
        {
            CAppUpdate oTmp;
            XmlSerializer s;
            TextReader tr;

            try
            {
                s = new XmlSerializer(typeof(CAppUpdate));

#if DEBUG
                tr = new StreamReader(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\UpdateConfig.xml");
#else
					tr = new StreamReader(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\UpdateConfig.xml");
#endif


                oTmp = (CAppUpdate)s.Deserialize(tr);

                mbPerformUpdate = oTmp.PerformUpdate;
                msUpdateLocation = oTmp.UpdateLocation;
                msUpdateFile = oTmp.UpdateFile;

                tr.Close();
            }
            catch
            {
                Clear();
            }

            tr = null;
            s = null;
            oTmp = null;
        }

        public void SaveAppSettings()
        {
            CAppUpdate oTmp;
            XmlSerializer s;
            TextWriter tw;

            try
            {
                oTmp = new CAppUpdate();

                oTmp.PerformUpdate = mbPerformUpdate;
                oTmp.UpdateLocation = msUpdateLocation;
                oTmp.UpdateFile = msUpdateFile;

                s = new XmlSerializer(typeof(CAppUpdate));

#if DEBUG
                tw = new StreamWriter(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\UpdateConfig.xml");
#else
				tw = new StreamWriter(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\UpdateConfig.xml");
#endif

                s.Serialize(tw, oTmp);

                tw.Close();
            }
            catch
            {
            }

            tw = null;
            s = null;
            oTmp = null;
        }

    }
}
