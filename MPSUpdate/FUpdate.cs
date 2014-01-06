using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Xml;
using System.Diagnostics;

namespace MPSUpdate
{
    public partial class FUpdate : Form
    {

        private string m_locPath;
        private string m_locFile;
        private string m_netPath;
        private bool m_updateApp;
        
        
        public FUpdate()
        {
            InitializeComponent();
        }

        private void FUpdate_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }


        private void GetAppLocations()
        {
            CAppUpdate au = new CAppUpdate();

            au.InitAppSettings();
            m_updateApp = au.PerformUpdate;
            m_netPath = au.UpdateLocation;
            m_locFile = au.UpdateFile;

            m_locPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        }

        private void CheckForUpdates()
        {
            //check for new file
            string netVersion;
            string locVersion;
            bool errFlag;

            FileVersionInfo fviNet;
            FileVersionInfo fviLoc;

            fviNet = FileVersionInfo.GetVersionInfo(m_netPath + "\\" + m_locFile);
            try
            {
                fviLoc = FileVersionInfo.GetVersionInfo(m_locPath + "\\" + m_locFile);
                errFlag = false;
            }
            catch
            {
                // if it does not exist copy whatever is out there
                fviLoc = FileVersionInfo.GetVersionInfo(m_netPath + "\\" + m_locFile);
                errFlag = true;
            }

            netVersion = fviNet.FileVersion;
            locVersion = fviLoc.FileVersion;

            lblUpdating.Text = "Checking...";
            System.Windows.Forms.Application.DoEvents();

            if (netVersion != locVersion || errFlag == true)
                UpdateFile();

        }

        private void UpdateFile()
        {
            string locName;
            string netName;

            lblUpdating.Text = "Copying Update to Local Machine";
            System.Windows.Forms.Application.DoEvents();

            DirectoryInfo di = new DirectoryInfo(m_netPath);

            foreach (FileInfo fi in di.GetFiles())
            {
                locName = m_locPath + "\\" + fi.Name;
                netName = m_netPath + "\\" + fi.Name;

                lblUpdating.Text = "Copying " + fi.Name;
                System.Windows.Forms.Application.DoEvents();

                File.Copy(netName, locName, true);
            }

            File.Copy(m_netPath, m_locPath, true);

            lblUpdating.Text = "Finished Updating File";
            System.Windows.Forms.Application.DoEvents();
        }

        private void StartApp()
        {
            Process.Start(m_locPath + "\\" + m_locFile);
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            timer1.Enabled = false;

            try
            {
                GetAppLocations();
            }
            catch
            {
                m_updateApp = false;
            }

            if (m_updateApp == true)
            {
                try
                {
                    CheckForUpdates();
                }
                catch
                {
                    m_updateApp = false;
                }
            }


            try
            {
                lblUpdating.Text = "Starting Application";
                System.Windows.Forms.Application.DoEvents();

                StartApp();
            }
            catch
            {
                MessageBox.Show("Unable to update and start application", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            this.Close();
        }

    }
}