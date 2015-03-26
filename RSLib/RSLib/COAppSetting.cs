using System;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
namespace RSLib
{
	[Serializable]
	public class COAppSetting
	{
		private string msLastUser;
		private bool mbWindowMax;
		private int miWindowHt;
		private int miWindowWid;
		private bool mbUseSecurity;
        public static readonly string DefaultXMLFilePath = Environment.GetEnvironmentVariable("temp");
		public string LastUser
		{
			get
			{
				return this.msLastUser;
			}
			set
			{
				this.msLastUser = value;
			}
		}
		public bool WindowMax
		{
			get
			{
				return this.mbWindowMax;
			}
			set
			{
				this.mbWindowMax = value;
			}
		}
		public int WindowHt
		{
			get
			{
				return this.miWindowHt;
			}
			set
			{
				this.miWindowHt = value;
			}
		}
		public int WindowWid
		{
			get
			{
				return this.miWindowWid;
			}
			set
			{
				this.miWindowWid = value;
			}
		}
		public bool UseSecurity
		{
			get
			{
				return this.mbUseSecurity;
			}
			set
			{
				this.mbUseSecurity = value;
			}
		}
		public COAppSetting()
		{
			this.Clear();
		}
		public void Clear()
		{
			this.msLastUser = "User";
			this.mbWindowMax = false;
			this.miWindowHt = 725;
			this.miWindowWid = 1000;
			this.mbUseSecurity = false;
		}
		public void InitAppSettings()
		{
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(COAppSetting));
				//TextReader textReader = new StreamReader(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\AppConfig.xml");
                TextReader textReader = new StreamReader(DefaultXMLFilePath + "\\AppConfig.xml"); 
				COAppSetting cOAppSetting = (COAppSetting)xmlSerializer.Deserialize(textReader);
                
				this.msLastUser = cOAppSetting.LastUser;
				this.mbWindowMax = cOAppSetting.WindowMax;
				this.miWindowHt = cOAppSetting.WindowHt;
				this.miWindowWid = cOAppSetting.WindowWid;
				this.mbUseSecurity = cOAppSetting.UseSecurity;
				textReader.Close();
			}
			catch
			{
				this.Clear();
			}
		}
		public void SaveAppSettings()
		{
			try
			{
				COAppSetting cOAppSetting = new COAppSetting();
				cOAppSetting.LastUser = this.msLastUser;
				cOAppSetting.WindowMax = this.mbWindowMax;
				cOAppSetting.WindowHt = this.miWindowHt;
				cOAppSetting.WindowWid = this.miWindowWid;
				cOAppSetting.UseSecurity = this.mbUseSecurity;
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(COAppSetting));
				//TextWriter textWriter = new StreamWriter(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\AppConfig.xml");
                TextWriter textWriter = new StreamWriter(DefaultXMLFilePath + "\\AppConfig.xml"); 
               
				xmlSerializer.Serialize(textWriter, cOAppSetting);
				textWriter.Close();
                
			}
			catch
			{
			}
		}
	}
}
