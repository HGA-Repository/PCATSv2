using System;
using System.IO;
using System.Security.Cryptography;
namespace RSLib
{
	public class COEncrypt
	{
		private CIEncrypt transformer;
		private byte[] initVec;
		private byte[] encKey;
		public byte[] IV
		{
			get
			{
				return this.initVec;
			}
			set
			{
				this.initVec = value;
			}
		}
		public byte[] Key
		{
			get
			{
				return this.encKey;
			}
		}
		public COEncrypt(EncryptionAlgorithm algId)
		{
			this.transformer = new CIEncrypt(algId);
		}
		public byte[] Encrypt(byte[] bytesData, byte[] bytesKey)
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
			this.encKey = this.transformer.Key;
			this.initVec = this.transformer.IV;
			cryptoStream.FlushFinalBlock();
			cryptoStream.Close();
			return memoryStream.ToArray();
		}
	}
}
