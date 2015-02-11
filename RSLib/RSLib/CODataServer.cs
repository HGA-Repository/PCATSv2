using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using System.Windows.Forms;
namespace RSLib
{
	[Serializable]
	public class CODataServer
	{
		private string PWRDKEY = "2434287644232400";
		private string VECTOR = "!REVSOL!";
		private string msDBServer;
		private string msDBName;
		private bool mbUseWinAuth;
		private string msUsername;
		private string msPassword;
		public string DBServer
        
		{
			get
			{
                //MessageBox.Show("How many data access requests does it take", "Please Count", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
				//sql user
                return this.msUsername;
                //return this.DecryptString(this.msUsername);
			}
			set
			{
				//sql user
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
		public CODataServer()
		{
			this.Clear();
		}
		public void Clear()
		{
			this.msDBServer = "server";
            this.msDBName = "RS";
            this.mbUseWinAuth = false;
			this.msUsername = "none";
			this.msPassword = "none";
		}
		public void InitAppSettings()
		{
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(CODataServer));
				TextReader textReader = new StreamReader(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\DataConfig.xml");
				CODataServer cODataServer = (CODataServer)xmlSerializer.Deserialize(textReader);
				this.msDBServer = cODataServer.DBServer;
				this.msDBName = cODataServer.DBName;
				this.mbUseWinAuth = cODataServer.UseWinAuth;
				this.msUsername = cODataServer.Username;
				this.msPassword = cODataServer.Password;
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
				CODataServer cODataServer = new CODataServer();
				cODataServer.DBServer = this.msDBServer;
				cODataServer.DBName = this.msDBName;
				cODataServer.UseWinAuth = this.mbUseWinAuth;
				cODataServer.Username = this.msUsername;
				cODataServer.Password = this.msPassword;
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(CODataServer));
				TextWriter textWriter = new StreamWriter(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\DataConfig.xml");
				xmlSerializer.Serialize(textWriter, cODataServer);
				textWriter.Close();
			}
			catch
			{
			}
		}
        private string EncryptString(string val)
        {
            string result;
            try
            {
                COEncrypt cOEncrypt = new COEncrypt(EncryptionAlgorithm.TripleDes);
                byte[] bytes = Encoding.ASCII.GetBytes(val);
                byte[] bytes2 = Encoding.ASCII.GetBytes(this.PWRDKEY);
                cOEncrypt.IV = Encoding.ASCII.GetBytes(this.VECTOR);
                byte[] inArray = cOEncrypt.Encrypt(bytes, bytes2);
                Encoding.ASCII.GetString(cOEncrypt.IV);
                result = Convert.ToBase64String(inArray);
            }
            catch
            {
                result = val;
            }
            return result;
        }
        private string DecryptString(string val)
        {
            string vECTOR = this.VECTOR;
            string result;
            try
            {
                CODecrypt cODecrypt = new CODecrypt(EncryptionAlgorithm.TripleDes);
                byte[] bytes = Encoding.ASCII.GetBytes(this.PWRDKEY);
                byte[] bytes2 = cODecrypt.Decrypt(Convert.FromBase64String(val), bytes);
                result = Encoding.ASCII.GetString(bytes2);
            }
            catch
            {
                result = val;
            }
            return result;
        }
    }
}
