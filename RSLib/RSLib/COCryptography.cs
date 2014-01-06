using System;
using System.Text;
namespace RSLib
{
	public class COCryptography
	{
		public static string EncryptString(string val)
		{
			string s = "2434287644232400";
			string s2 = "!REVSOL!";
			string result;
			try
			{
				COEncrypt cOEncrypt = new COEncrypt(EncryptionAlgorithm.TripleDes);
				byte[] bytes = Encoding.ASCII.GetBytes(val);
				byte[] bytes2 = Encoding.ASCII.GetBytes(s);
				cOEncrypt.IV = Encoding.ASCII.GetBytes(s2);
				byte[] inArray = cOEncrypt.Encrypt(bytes, bytes2);
				Encoding.ASCII.GetString(cOEncrypt.IV);
				result = Convert.ToBase64String(inArray);
			}
			catch
			{
				result = val;
			}
			return result;
		}
		public static string EncryptString(string val, string eKey, string vector)
		{
			string result;
			try
			{
				COEncrypt cOEncrypt = new COEncrypt(EncryptionAlgorithm.TripleDes);
				byte[] bytes = Encoding.ASCII.GetBytes(val);
				byte[] bytes2 = Encoding.ASCII.GetBytes(eKey);
				cOEncrypt.IV = Encoding.ASCII.GetBytes(vector);
				byte[] inArray = cOEncrypt.Encrypt(bytes, bytes2);
				Encoding.ASCII.GetString(cOEncrypt.IV);
				result = Convert.ToBase64String(inArray);
			}
			catch
			{
				result = val;
			}
			return result;
		}
		public static string DecryptString(string val, string eKey, string vector)
		{
			string result;
			try
			{
				CODecrypt cODecrypt = new CODecrypt(EncryptionAlgorithm.TripleDes);
				cODecrypt.IV = Encoding.ASCII.GetBytes(vector);
				byte[] bytes = Encoding.ASCII.GetBytes(eKey);
				byte[] bytes2 = cODecrypt.Decrypt(Convert.FromBase64String(val), bytes);
				result = Encoding.ASCII.GetString(bytes2);
			}
			catch
			{
				result = val;
			}
			return result;
		}
	}
}
