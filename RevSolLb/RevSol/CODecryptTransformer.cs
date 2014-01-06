using System;
using System.Security.Cryptography;
namespace RevSol
{
	internal class CODecryptTransformer
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
		internal CODecryptTransformer(EncryptionAlgorithm deCryptId)
		{
			this.algorithmID = deCryptId;
		}
		internal ICryptoTransform GetCryptoServiceProvider(byte[] bytesKey, byte[] initVec)
		{
			switch (this.algorithmID)
			{
			case EncryptionAlgorithm.Des:
				return new DESCryptoServiceProvider
				{
					Mode = CipherMode.CBC,
					Key = bytesKey,
					IV = initVec
				}.CreateDecryptor();
			case EncryptionAlgorithm.Rc2:
				return new RC2CryptoServiceProvider
				{
					Mode = CipherMode.CBC
				}.CreateDecryptor(bytesKey, initVec);
			case EncryptionAlgorithm.Rijndael:
				return new RijndaelManaged
				{
					Mode = CipherMode.CBC
				}.CreateDecryptor(bytesKey, initVec);
			case EncryptionAlgorithm.TripleDes:
				return new TripleDESCryptoServiceProvider
				{
					Mode = CipherMode.CBC
				}.CreateDecryptor(bytesKey, initVec);
			default:
				throw new CryptographicException("Algorithm ID '" + this.algorithmID + "' not supported.");
			}
		}
	}
}
