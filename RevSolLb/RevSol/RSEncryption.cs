using System;
using System.Security.Cryptography;
using System.Text;
namespace RevSol
{
	public class RSEncryption
	{
		public string HashValueToString(string value)
		{
			UTF8Encoding uTF8Encoding = new UTF8Encoding();
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			string str = "RSEncrypt";
			string s = str + value;
			byte[] inArray = mD5CryptoServiceProvider.ComputeHash(uTF8Encoding.GetBytes(s));
			return Convert.ToBase64String(inArray);
		}
		public string Encrypt(string value, string keyVal, string vect, EncryptionAlgorithm alg)
		{
			string result = "";
			try
			{
				COEncryptor cOEncryptor = new COEncryptor(alg);
				byte[] bytes = Encoding.ASCII.GetBytes(value);
				byte[] bytes2 = Encoding.ASCII.GetBytes(this.GetValidKey(keyVal, alg));
				byte[] bytes3 = Encoding.ASCII.GetBytes(this.GetValidVect(vect, alg));
				cOEncryptor.IV = bytes3;
				byte[] inArray = cOEncryptor.Encrypt(bytes, bytes2, bytes3);
				result = Convert.ToBase64String(inArray);
			}
			catch (Exception)
			{
				result = "Error";
			}
			return result;
		}
		public string GetValidKey(string keyVal, EncryptionAlgorithm alg)
		{
			string result;
			if (alg == EncryptionAlgorithm.TripleDes)
			{
				if (keyVal.Length > 24)
				{
					result = keyVal.Substring(0, 24);
				}
				else
				{
					if (keyVal.Length < 16)
					{
						result = keyVal.PadRight(16, Convert.ToChar("0"));
					}
					else
					{
						if (keyVal.Length > 16 && keyVal.Length < 24)
						{
							result = keyVal.PadRight(24, Convert.ToChar("0"));
						}
						else
						{
							result = keyVal;
						}
					}
				}
			}
			else
			{
				if (alg == EncryptionAlgorithm.Rijndael)
				{
					if (keyVal.Length > 16)
					{
						result = keyVal.Substring(0, 16);
					}
					else
					{
						if (keyVal.Length < 16)
						{
							result = keyVal.PadRight(16, Convert.ToChar("0"));
						}
						else
						{
							result = keyVal;
						}
					}
				}
				else
				{
					if (alg == EncryptionAlgorithm.Des)
					{
						if (keyVal.Length > 8)
						{
							result = keyVal.Substring(0, 8);
						}
						else
						{
							if (keyVal.Length < 8)
							{
								result = keyVal.PadRight(8, Convert.ToChar("0"));
							}
							else
							{
								result = keyVal;
							}
						}
					}
					else
					{
						result = keyVal;
					}
				}
			}
			return result;
		}
		public string GetValidVect(string vectVal, EncryptionAlgorithm alg)
		{
			string result;
			if (alg == EncryptionAlgorithm.Rijndael)
			{
				if (vectVal.Length > 16)
				{
					result = vectVal.Substring(0, 16);
				}
				else
				{
					if (vectVal.Length < 16)
					{
						result = vectVal.PadRight(16, Convert.ToChar("0"));
					}
					else
					{
						result = vectVal;
					}
				}
			}
			else
			{
				if (vectVal.Length > 8)
				{
					result = vectVal.Substring(0, 8);
				}
				else
				{
					if (vectVal.Length < 8)
					{
						result = vectVal.PadRight(8, Convert.ToChar("0"));
					}
					else
					{
						result = vectVal;
					}
				}
			}
			return result;
		}
		public string Decrypt(string value, string keyVal, string vect, EncryptionAlgorithm alg)
		{
			string result;
			try
			{
				CODecryptor cODecryptor = new CODecryptor(alg);
				byte[] bytes = Encoding.ASCII.GetBytes(this.GetValidVect(vect, alg));
				byte[] bytes2 = Encoding.ASCII.GetBytes(this.GetValidKey(keyVal, alg));
				cODecryptor.IV = bytes;
				byte[] bytes3 = cODecryptor.Decrypt(Convert.FromBase64String(value), bytes2, bytes);
				result = Encoding.ASCII.GetString(bytes3);
			}
			catch (Exception)
			{
				result = "Error";
			}
			return result;
		}
	}
}
