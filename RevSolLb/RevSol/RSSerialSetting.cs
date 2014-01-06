using System;
using System.IO;
using System.Xml.Serialization;
namespace RevSol
{
	public class RSSerialSetting
	{
		private string msComPort;
		private int miBaudRate;
		private int miDataBits;
		private int miStopBits;
		private bool mbUseCom;
		public string ComPort
		{
			get
			{
				return this.msComPort;
			}
			set
			{
				this.msComPort = value;
			}
		}
		public int BaudRate
		{
			get
			{
				return this.miBaudRate;
			}
			set
			{
				this.miBaudRate = value;
			}
		}
		public int DataBits
		{
			get
			{
				return this.miDataBits;
			}
			set
			{
				this.miDataBits = value;
			}
		}
		public int StopBits
		{
			get
			{
				return this.miStopBits;
			}
			set
			{
				this.miStopBits = value;
			}
		}
		public bool UseCom
		{
			get
			{
				return this.mbUseCom;
			}
			set
			{
				this.mbUseCom = value;
			}
		}
		public virtual void Clear()
		{
			this.msComPort = "COM2";
			this.miBaudRate = 9600;
			this.miDataBits = 8;
			this.miStopBits = 1;
			this.mbUseCom = false;
		}
		public void Copy(RSSerialSetting oNew)
		{
			oNew.ComPort = this.msComPort;
			oNew.BaudRate = this.miBaudRate;
			oNew.DataBits = this.miDataBits;
			oNew.StopBits = this.miStopBits;
			oNew.UseCom = this.mbUseCom;
		}
		public void LoadFromObj(RSSerialSetting oOrg)
		{
			this.msComPort = oOrg.ComPort;
			this.miBaudRate = oOrg.BaudRate;
			this.miDataBits = oOrg.DataBits;
			this.miStopBits = oOrg.StopBits;
			this.mbUseCom = oOrg.UseCom;
		}
		public void InitAppSettings()
		{
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(RSSerialSetting));
				string path = RSUtility.GetLocation() + "\\Serial.xml";
				TextReader textReader = new StreamReader(path);
				RSSerialSetting rSSerialSetting = (RSSerialSetting)xmlSerializer.Deserialize(textReader);
				this.msComPort = rSSerialSetting.ComPort;
				this.miBaudRate = rSSerialSetting.BaudRate;
				this.miDataBits = rSSerialSetting.DataBits;
				this.miStopBits = rSSerialSetting.StopBits;
				this.mbUseCom = rSSerialSetting.UseCom;
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
				RSSerialSetting rSSerialSetting = new RSSerialSetting();
				rSSerialSetting.ComPort = this.msComPort;
				rSSerialSetting.BaudRate = this.miBaudRate;
				rSSerialSetting.DataBits = this.miDataBits;
				rSSerialSetting.StopBits = this.miStopBits;
				rSSerialSetting.UseCom = this.mbUseCom;
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(RSSerialSetting));
				TextWriter textWriter = new StreamWriter(RSUtility.GetLocation() + "\\Serial.xml");
				xmlSerializer.Serialize(textWriter, rSSerialSetting);
				textWriter.Close();
			}
			catch
			{
			}
		}
	}
}
