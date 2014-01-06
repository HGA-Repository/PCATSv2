using System;
using System.Security.Cryptography;
namespace RSLib
{
	public class CIDecrypt
	{
		private EncryptionAlgorithm algorithmID;
		private byte[] initVec;
		internal byte[] IV
		{
			set
			{
				this.initVec = value;
			}
		}
		internal CIDecrypt(EncryptionAlgorithm deCryptId)
		{
			this.algorithmID = deCryptId;
		}
		internal ICryptoTransform GetCryptoServiceProvider(byte[] bytesKey)
		{
			switch (this.algorithmID)
			{
			case EncryptionAlgorithm.Des:
				return new DESCryptoServiceProvider
				{
					Mode = CipherMode.CBC,
					Key = bytesKey,
					IV = this.initVec
				}.CreateDecryptor();
			case EncryptionAlgorithm.Rc2:
				return new RC2CryptoServiceProvider
				{
					Mode = CipherMode.CBC
				}.CreateDecryptor(bytesKey, this.initVec);
			case EncryptionAlgorithm.Rijndael:
				return new RijndaelManaged
				{
					Mode = CipherMode.CBC
				}.CreateDecryptor(bytesKey, this.initVec);
			case EncryptionAlgorithm.TripleDes:
				return new TripleDESCryptoServiceProvider
				{
					Mode = CipherMode.CBC
				}.CreateDecryptor(bytesKey, this.initVec);
			default:
				throw new CryptographicException("Algorithm ID '" + this.algorithmID + "' not supported.");
			}
		}
	}
}
