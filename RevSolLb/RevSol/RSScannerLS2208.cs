using System;
using System.IO.Ports;
namespace RevSol
{
	public class RSScannerLS2208
	{
		private SerialPort moSerialPort;
		private bool mbIsSerialOpen;
		private string msSerialData;
		public event HandleScannerDataInput OnScannedData;
		public RSScannerLS2208()
		{
			this.mbIsSerialOpen = false;
			this.msSerialData = "";
			this.moSerialPort = new SerialPort();
		}
		public void Open()
		{
			if (!this.mbIsSerialOpen)
			{
				RSSerialSetting rSSerialSetting = new RSSerialSetting();
				rSSerialSetting.InitAppSettings();
				this.moSerialPort.PortName = rSSerialSetting.ComPort;
				this.moSerialPort.BaudRate = rSSerialSetting.BaudRate;
				this.moSerialPort.DataBits = rSSerialSetting.DataBits;
				this.moSerialPort.StopBits = StopBits.One;
				this.moSerialPort.Parity = Parity.None;
				this.moSerialPort.DataReceived += new SerialDataReceivedEventHandler(this.moSerialPort_DataReceived);
				this.moSerialPort.Open();
				this.mbIsSerialOpen = true;
			}
		}
		private void moSerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			string text = this.moSerialPort.ReadLine();
			this.msSerialData += text;
			if (text.IndexOf(Convert.ToChar(13)) >= 0)
			{
				if (this.OnScannedData != null)
				{
					this.OnScannedData(this.msSerialData);
				}
				this.msSerialData = "";
			}
		}
		public void Close()
		{
			try
			{
				this.moSerialPort.Close();
				this.moSerialPort.DataReceived -= new SerialDataReceivedEventHandler(this.moSerialPort_DataReceived);
			}
			catch
			{
			}
			this.mbIsSerialOpen = false;
		}
	}
}
