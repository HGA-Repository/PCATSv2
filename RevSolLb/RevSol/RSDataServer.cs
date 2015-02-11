using System;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
namespace RevSol
{
	[Serializable]
	public class RSDataServer
	{
		private string PWRDKEY = "RevolutionarySolutions";
		private string VECTOR = "RevSolPassVector";
		private string msDBServer;
		private string msDBName;
		private bool mbUseWinAuth;
		private string msUsername;
		private string msPassword;
		public string DBServer
		{
			get
			{
				return this.msDBServer;
			}
			set
			{
				this.msDBServer = value;
			}
		}
		public string DBName
		{
			get
			{
				return this.msDBName;
			}
			set
			{
				this.msDBName = value;
			}
		}
		public bool UseWinAuth
		{
			get
			{
				return this.mbUseWinAuth;
			}
			set
			{
				this.mbUseWinAuth = value;
			}
		}
		public string Username
		{
			get
			{
				return this.msUsername;
                //return this.DecryptString(this.msUsername);
			}
			set
			{
				this.msUsername = value;
                //this.msUsername = this.EncryptString(value);
			}
		}
		public string Password
		{
			get
			{
				return this.msPassword;
                //return this.DecryptString(this.msPassword);
			}
			set
			{
                this.msPassword = value;
				//this.msPassword = this.EncryptString(value);

			}
		}
		public RSDataServer()
		{
			this.Clear();
		}
		public void Clear()
		{
			this.msDBServer = "server";
			this.msDBName = "RS";
			this.mbUseWinAuth = false;
			this.msUsername = "None";
			this.msPassword = "None";
		}
		public void InitAppSettings()
		{
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(RSDataServer));
				string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\DataConfig.xml";
				TextReader textReader = new StreamReader(path);
				RSDataServer rSDataServer = (RSDataServer)xmlSerializer.Deserialize(textReader);
				this.msDBServer = rSDataServer.DBServer;
				this.msDBName = rSDataServer.DBName;
				this.mbUseWinAuth = rSDataServer.UseWinAuth;
				this.msUsername = rSDataServer.Username;
				this.msPassword = rSDataServer.Password;
				textReader.Close();
			}
			catch (Exception ex)
			{
				this.Clear();
				this.msPassword = ex.Message;
				this.CreateFileForUse();
			}
		}
		public void InitAppSettings(string altVersion)
		{
			string str = "\\DataConfig" + altVersion.ToString() + ".xml";
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(RSDataServer));
				string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + str;
				TextReader textReader = new StreamReader(path);
				RSDataServer rSDataServer = (RSDataServer)xmlSerializer.Deserialize(textReader);
				this.msDBServer = rSDataServer.DBServer;
				this.msDBName = rSDataServer.DBName;
				this.mbUseWinAuth = rSDataServer.UseWinAuth;
				this.msUsername = rSDataServer.Username;
				this.msPassword = rSDataServer.Password;
				textReader.Close();
			}
			catch (Exception ex)
			{
				this.Clear();
				this.msPassword = ex.Message;
				this.CreateFileForUse(altVersion);
			}
		}
		private void CreateFileForUse()
		{
			this.SaveAppSettings();
		}
		private void CreateFileForUse(string alt)
		{
			this.SaveAppSettings(alt);
		}
		public void SaveAppSettings()
		{
			try
			{
				RSDataServer rSDataServer = new RSDataServer();
				rSDataServer.DBServer = this.msDBServer;
				rSDataServer.DBName = this.msDBName;
				rSDataServer.UseWinAuth = this.mbUseWinAuth;
				rSDataServer.Username = this.msUsername;
				rSDataServer.Password = this.msPassword;
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(RSDataServer));
				TextWriter textWriter = new StreamWriter(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\DataConfig.xml");
				xmlSerializer.Serialize(textWriter, rSDataServer);
				textWriter.Close();
			}
			catch
			{
			}
		}
		public void SaveAppSettings(string alt)
		{
			//"\\DataConfig" + alt + ".xml";
			try
			{
				RSDataServer rSDataServer = new RSDataServer();
				rSDataServer.DBServer = this.msDBServer;
				rSDataServer.DBName = this.msDBName;
				rSDataServer.UseWinAuth = this.mbUseWinAuth;
				rSDataServer.Username = this.msUsername;
				rSDataServer.Password = this.msPassword;
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(RSDataServer));
				TextWriter textWriter = new StreamWriter(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\DataConfig.xml");
				xmlSerializer.Serialize(textWriter, rSDataServer);
				textWriter.Close();
			}
			catch
			{
			}
		}
		private string EncryptString(string val)
		{
			RSEncryption rSEncryption = new RSEncryption();
			string result;
			try
			{
				result = rSEncryption.Encrypt(val, this.PWRDKEY, this.VECTOR, EncryptionAlgorithm.TripleDes);
			}
			catch
			{
				result = val;
			}
			return result;
		}
		private string DecryptString(string val)
		{
			RSEncryption rSEncryption = new RSEncryption();
			string result;
			try
			{
				result = rSEncryption.Decrypt(val, this.PWRDKEY, this.VECTOR, EncryptionAlgorithm.TripleDes);
			}
			catch
			{
				result = val;
			}
			return result;
		}
		public string EncryptForFile(string val)
		{
			RSEncryption rSEncryption = new RSEncryption();
			string result;
			try
			{
				result = rSEncryption.Encrypt(val, this.PWRDKEY, this.VECTOR, EncryptionAlgorithm.TripleDes);
			}
			catch
			{
				result = val;
			}
			return result;
		}
	}
}
