using System;
using System.IO;
using System.Xml.Serialization;
namespace RevSol
{
	[Serializable]
	public class COUpdater
	{
		private bool mbUseUpdater;
		private string msSourceExe;
		private string msUpdateLocation;
		public bool UseUpdater
		{
			get
			{
				return this.mbUseUpdater;
			}
			set
			{
				this.mbUseUpdater = value;
			}
		}
		public string SourceExe
		{
			get
			{
				return this.msSourceExe;
			}
			set
			{
				this.msSourceExe = value;
			}
		}
		public string UpdateLocation
		{
			get
			{
				return this.msUpdateLocation;
			}
			set
			{
				this.msUpdateLocation = value;
			}
		}
		public virtual void Clear()
		{
			this.mbUseUpdater = false;
			this.msSourceExe = "";
			this.msUpdateLocation = "";
		}
		public void Copy(COUpdater oNew)
		{
			oNew.UseUpdater = this.mbUseUpdater;
			oNew.SourceExe = this.msSourceExe;
			oNew.UpdateLocation = this.msUpdateLocation;
		}
		public void LoadFromObj(COUpdater oOrg)
		{
			this.mbUseUpdater = oOrg.UseUpdater;
			this.msSourceExe = oOrg.SourceExe;
			this.msUpdateLocation = oOrg.UpdateLocation;
		}
		public void InitAppSettings()
		{
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(COUpdater));
				string path = RSUtility.GetLocation() + "\\Updater.xml";
				TextReader textReader = new StreamReader(path);
				COUpdater cOUpdater = (COUpdater)xmlSerializer.Deserialize(textReader);
				this.mbUseUpdater = cOUpdater.UseUpdater;
				this.msSourceExe = cOUpdater.SourceExe;
				this.msUpdateLocation = cOUpdater.UpdateLocation;
				textReader.Close();
			}
			catch
			{
				this.Clear();
				this.CreateFileForUse();
			}
		}
		private void CreateFileForUse()
		{
			this.SaveAppSettings();
		}
		public void SaveAppSettings()
		{
			try
			{
				COUpdater cOUpdater = new COUpdater();
				cOUpdater.UseUpdater = this.mbUseUpdater;
				cOUpdater.SourceExe = this.msSourceExe;
				cOUpdater.UpdateLocation = this.msUpdateLocation;
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(COUpdater));
				TextWriter textWriter = new StreamWriter(RSUtility.GetLocation() + "\\Updater.xml");
				xmlSerializer.Serialize(textWriter, cOUpdater);
				textWriter.Close();
			}
			catch
			{
			}
		}
	}
}
