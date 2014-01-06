using System;
using System.Security.Cryptography;
namespace RevSol
{
	internal class COEncryptTransformer
	{
		private EncryptionAlgorithm algorithmID;
		private byte[] initVec;
		private byte[] encKey;
		internal byte[] IV
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
		internal byte[] Key
		{
			get
			{
				return this.encKey;
			}
		}
		internal COEncryptTransformer(EncryptionAlgorithm algId)
		{
			this.algorithmID = algId;
		}
		internal ICryptoTransform GetCryptoServiceProvider(byte[] bytesKey, byte[] initVec)
		{
			switch (this.algorithmID)
			{
			case EncryptionAlgorithm.Des:
			{
				DES dES = new DESCryptoServiceProvider();
				dES.Mode = CipherMode.CBC;
				if (bytesKey == null)
				{
					this.encKey = dES.Key;
				}
				else
				{
					dES.Key = bytesKey;
					this.encKey = dES.Key;
				}
				if (initVec == null)
				{
					initVec = dES.IV;
				}
				else
				{
					dES.IV = initVec;
				}
				return dES.CreateEncryptor();
			}
			case EncryptionAlgorithm.Rc2:
			{
				RC2 rC = new RC2CryptoServiceProvider();
				rC.Mode = CipherMode.CBC;
				if (bytesKey == null)
				{
					this.encKey = rC.Key;
				}
				else
				{
					rC.Key = bytesKey;
					this.encKey = rC.Key;
				}
				if (initVec == null)
				{
					initVec = rC.IV;
				}
				else
				{
					rC.IV = initVec;
				}
				return rC.CreateEncryptor();
			}
			case EncryptionAlgorithm.Rijndael:
			{
				Rijndael rijndael = new RijndaelManaged();
				rijndael.Mode = CipherMode.CBC;
				if (bytesKey == null)
				{
					this.encKey = rijndael.Key;
				}
				else
				{
					rijndael.Key = bytesKey;
					this.encKey = rijndael.Key;
				}
				if (initVec == null)
				{
					initVec = rijndael.IV;
				}
				else
				{
					rijndael.IV = initVec;
				}
				return rijndael.CreateEncryptor();
			}
			case EncryptionAlgorithm.TripleDes:
			{
				TripleDES tripleDES = new TripleDESCryptoServiceProvider();
				tripleDES.Mode = CipherMode.CBC;
				if (bytesKey == null)
				{
					this.encKey = tripleDES.Key;
				}
				else
				{
					tripleDES.Key = bytesKey;
					this.encKey = tripleDES.Key;
				}
				if (initVec == null)
				{
					initVec = tripleDES.IV;
				}
				else
				{
					tripleDES.IV = initVec;
				}
				return tripleDES.CreateEncryptor();
			}
			default:
				throw new CryptographicException("Algorithm ID '" + this.algorithmID + "' not supported.");
			}
		}
	}
}
