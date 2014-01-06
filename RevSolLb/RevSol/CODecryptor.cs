using System;
using System.IO;
using System.Security.Cryptography;
namespace RevSol
{
	public class CODecryptor
	{
		private CODecryptTransformer transformer;
		private byte[] initVec;
		public byte[] IV
		{
			set
			{
				this.initVec = value;
			}
		}
		public CODecryptor(EncryptionAlgorithm algId)
		{
			this.transformer = new CODecryptTransformer(algId);
		}
		public byte[] Decrypt(byte[] bytesData, byte[] bytesKey, byte[] initVec)
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
				throw new Exception("Error while writing data to the stream: \n" + ex.Message);
			}
			cryptoStream.FlushFinalBlock();
			cryptoStream.Close();
			return memoryStream.ToArray();
		}
	}
}
