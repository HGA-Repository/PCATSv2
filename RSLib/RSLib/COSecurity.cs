using System;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
namespace RSLib
{
	[Serializable]
	public class COSecurity
	{
		private string msSessionID;
		private int miUserID;
		private string msSessionSecurity;
		private DateTime mdLoginTime;
		public string SessionID
		{
			get
			{
				return this.msSessionID;
			}
			set
			{
				this.msSessionID = value;
			}
		}
		public int UserID
		{
			get
			{
				return this.miUserID;
			}
			set
			{
				this.miUserID = value;
			}
		}
		public DateTime LoginTime
		{
			get
			{
				return this.mdLoginTime;
			}
			set
			{
				this.mdLoginTime = value;
			}
		}
		public string SessionSecurity
		{
			get
			{
				return this.msSessionSecurity;
			}
			set
			{
				this.msSessionSecurity = value;
			}
		}
		public void Clear()
		{
			this.msSessionID = "";
			this.miUserID = 0;
			this.mdLoginTime = DateTime.Now;
			this.msSessionSecurity = "";
		}
		public void InitAppSettings()
		{
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(COSecurity));
				TextReader textReader = new StreamReader(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Secure.xml");
				COSecurity cOSecurity = (COSecurity)xmlSerializer.Deserialize(textReader);
				this.msSessionID = cOSecurity.SessionID;
				this.miUserID = cOSecurity.UserID;
				this.mdLoginTime = cOSecurity.LoginTime;
				this.msSessionSecurity = cOSecurity.SessionSecurity;
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
				COSecurity cOSecurity = new COSecurity();
				cOSecurity.SessionID = this.msSessionID;
				cOSecurity.UserID = this.miUserID;
				cOSecurity.LoginTime = this.mdLoginTime;
				cOSecurity.SessionSecurity = this.msSessionSecurity;
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(COSecurity));
				TextWriter textWriter = new StreamWriter(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Secure.xml");
				xmlSerializer.Serialize(textWriter, cOSecurity);
				textWriter.Close();
			}
			catch
			{
			}
		}
		public static void Delete()
		{
			string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Secure.xml";
			File.Delete(path);
		}
	}
}
