using System;
using System.IO;
using System.Security.Cryptography;
namespace RevSol
{
	public class COEncryptor
	{
		private COEncryptTransformer transformer;
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
		public COEncryptor(EncryptionAlgorithm algId)
		{
			this.transformer = new COEncryptTransformer(algId);
		}
		public byte[] Encrypt(byte[] bytesData, byte[] bytesKey, byte[] initVec)
		{
			MemoryStream memoryStream = new MemoryStream();
			this.transformer.IV = initVec;
			ICryptoTransform cryptoServiceProvider = this.transformer.GetCryptoServiceProvider(bytesKey, initVec);
			CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoServiceProvider, CryptoStreamMode.Write);
			try
			{
				cryptoStream.Write(bytesData, 0, bytesData.Length);
			}
			catch (Exception ex)
			{
				throw new Exception("Error while writing enctypted data to the stream: \n" + ex.Message);
			}
			this.encKey = this.transformer.Key;
			cryptoStream.FlushFinalBlock();
			cryptoStream.Close();
			return memoryStream.ToArray();
		}
	}
}
