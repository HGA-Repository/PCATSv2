using System;
using System.IO;
using System.Security.Cryptography;
namespace RSLib
{
	public class CODecrypt
	{
		private CIDecrypt transformer;
		private byte[] initVec;
		public byte[] IV
		{
			set
			{
				this.initVec = value;
			}
		}
		public CODecrypt(EncryptionAlgorithm algId)
		{
			this.transformer = new CIDecrypt(algId);
		}
		public byte[] Decrypt(byte[] bytesData, byte[] bytesKey)
		{
			MemoryStream memoryStream = new MemoryStream();
			this.transformer.IV = this.initVec;
			ICryptoTransform cryptoServiceProvider = this.transformer.GetCryptoServiceProvider(bytesKey);
			CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoServiceProvider, CryptoStreamMode.Write);
			try
			{
				cryptoStream.Write(bytesData, 0, bytesData.Length);
			}
			catch (Exception ex)
			{
				throw new Exception("Error while writing encrypted data to the stream: \n" + ex.Message);
			}
			cryptoStream.FlushFinalBlock();
			cryptoStream.Close();
			return memoryStream.ToArray();
		}
	}
}
