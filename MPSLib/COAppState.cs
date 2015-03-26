using System;
using System.Collections.Generic;
using System.Text;

using System.Xml;
using System.Xml.Serialization;
using System.IO;


namespace RSMPS
{
    [Serializable]
    public class COAppState
    {
        private int miSch_LastDeptID;
        private int miSch_EmplyID;
        private DateTime mdSch_LastStartDate;
        private DateTime mdSch_LastEndDate;
        private int miSch_SortType;
        private bool mbSch_ViewPlan;
        private bool mbSch_ViewFore;
        private bool mbSch_ViewActl;
        private string msSch_HrDisplay;
        public static readonly string DefaultXMLFilePath = Environment.GetEnvironmentVariable("temp");

        #region Properties

        public int Sch_LastDeptID
        {
            get { return miSch_LastDeptID; }
            set { miSch_LastDeptID = value; }
        }

        public int Sch_EmplyID
        {
            get { return miSch_EmplyID; }
            set { miSch_EmplyID = value; }
        }

        public DateTime Sch_LastStartDate
        {
            get { return mdSch_LastStartDate; }
            set { mdSch_LastStartDate = value; }
        }

        public DateTime Sch_LastEndDate
        {
            get { return mdSch_LastEndDate; }
            set { mdSch_LastEndDate = value; }
        }

        public int Sch_SortType
        {
            get { return miSch_SortType; }
            set { miSch_SortType = value; }
        }

        public bool Sch_ViewPlan
        {
            get { return mbSch_ViewPlan; }
            set { mbSch_ViewPlan = value; }
        }

        public bool Sch_ViewFore
        {
            get { return mbSch_ViewFore; }
            set { mbSch_ViewFore = value; }
        }

        public bool Sch_ViewActl
        {
            get { return mbSch_ViewActl; }
            set { mbSch_ViewActl = value; }
        }

        public string Sch_HrDisplay
        {
            get { return msSch_HrDisplay; }
            set { msSch_HrDisplay = value; }
        }

        #endregion

        public void Clear()
        {
            miSch_LastDeptID = 0;
            miSch_EmplyID = 1;
            mdSch_LastStartDate = DateTime.Now;
            mdSch_LastEndDate = DateTime.Now;
            miSch_SortType = 0;
            mbSch_ViewPlan = false;
            mbSch_ViewFore = false;
            mbSch_ViewActl = false;
            msSch_HrDisplay = "#,##0";
        }

        public void InitAppSettings()
        {
            COAppState oTmp;
            XmlSerializer s;
            TextReader tr;

            try
            {
                s = new XmlSerializer(typeof(COAppState));


				//tr = new StreamReader(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\AppState.xml");
                tr = new StreamReader(DefaultXMLFilePath + "\\AppState.xml");

                oTmp = (COAppState)s.Deserialize(tr);

                miSch_LastDeptID = oTmp.Sch_LastDeptID;
                miSch_EmplyID = oTmp.Sch_EmplyID;
                mdSch_LastStartDate = oTmp.Sch_LastStartDate;
                mdSch_LastEndDate = oTmp.Sch_LastEndDate;
                miSch_SortType = oTmp.Sch_SortType;
                mbSch_ViewPlan = oTmp.Sch_ViewPlan;
                mbSch_ViewFore = oTmp.Sch_ViewFore;
                mbSch_ViewActl = oTmp.Sch_ViewActl;
                msSch_HrDisplay = oTmp.Sch_HrDisplay;

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
            COAppState oTmp;
            XmlSerializer s;
            TextWriter tw;

            try
            {
                oTmp = new COAppState();
                
                oTmp.Sch_LastDeptID = miSch_LastDeptID;
                oTmp.Sch_EmplyID = miSch_EmplyID;
                oTmp.Sch_LastStartDate = mdSch_LastStartDate;
                oTmp.Sch_LastEndDate = mdSch_LastEndDate;
                oTmp.Sch_SortType = miSch_SortType;
                oTmp.Sch_ViewPlan = mbSch_ViewPlan;
                oTmp.Sch_ViewFore = mbSch_ViewFore;
                oTmp.Sch_ViewActl = mbSch_ViewActl;
                oTmp.Sch_HrDisplay = msSch_HrDisplay;

                s = new XmlSerializer(typeof(COAppState));

				//tw = new StreamWriter(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\AppState.xml");
                tw = new StreamWriter(DefaultXMLFilePath + "\\AppState.xml");
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
