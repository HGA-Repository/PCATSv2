using System;
using System.IO;
namespace RevSol
{
	public class RSFileUtility
	{
		public event ItemValueChangedHandler OnFolderCopied;
		public void CopyFolder(string orgLoc, string newLoc)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(orgLoc);
			string text = newLoc + "\\" + directoryInfo.Name;
			DirectoryInfo directoryInfo2 = new DirectoryInfo(text);
			if (!directoryInfo2.Exists)
			{
				RSFileUtility.CreateFolder(text);
			}
			if (directoryInfo.GetDirectories().GetLength(0) > 0)
			{
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				for (int i = 0; i < directories.Length; i++)
				{
					DirectoryInfo directoryInfo3 = directories[i];
					this.CopyFolder(directoryInfo3.FullName, text);
				}
			}
			if (directoryInfo.GetFiles().GetLength(0) > 0)
			{
				FileInfo[] files = directoryInfo.GetFiles();
				for (int j = 0; j < files.Length; j++)
				{
					FileInfo fileInfo = files[j];
					string destFileName = text + "\\" + fileInfo.Name;
					fileInfo.CopyTo(destFileName, true);
				}
			}
			if (this.OnFolderCopied != null)
			{
				this.OnFolderCopied(1, text);
			}
		}
		public void CopyFolder(string orgLoc, string newLoc, string newFoldName)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(orgLoc);
			string text = newLoc + "\\" + newFoldName;
			DirectoryInfo directoryInfo2 = new DirectoryInfo(text);
			if (directoryInfo2.Exists)
			{
				RSFileUtility.DeleteFolder(text);
			}
			RSFileUtility.CreateFolder(text);
			if (directoryInfo.GetDirectories().GetLength(0) > 0)
			{
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				for (int i = 0; i < directories.Length; i++)
				{
					DirectoryInfo directoryInfo3 = directories[i];
					this.CopyFolder(directoryInfo3.FullName, text);
				}
			}
			if (directoryInfo.GetFiles().GetLength(0) > 0)
			{
				FileInfo[] files = directoryInfo.GetFiles();
				for (int j = 0; j < files.Length; j++)
				{
					FileInfo fileInfo = files[j];
					string destFileName = text + "\\" + fileInfo.Name;
					fileInfo.CopyTo(destFileName, true);
				}
			}
			if (this.OnFolderCopied != null)
			{
				this.OnFolderCopied(1, text);
			}
		}
		public void CopyFolder(string orgLoc, string newLoc, string mask, string substitute)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(orgLoc);
			string text = newLoc + "\\" + directoryInfo.Name;
			text = text.Replace(mask, substitute);
			DirectoryInfo directoryInfo2 = new DirectoryInfo(text);
			if (!directoryInfo2.Exists)
			{
				RSFileUtility.CreateFolder(text);
			}
			if (directoryInfo.GetDirectories().GetLength(0) > 0)
			{
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				for (int i = 0; i < directories.Length; i++)
				{
					DirectoryInfo directoryInfo3 = directories[i];
					this.CopyFolder(directoryInfo3.FullName, text, mask, substitute);
				}
			}
			if (directoryInfo.GetFiles().GetLength(0) > 0)
			{
				FileInfo[] files = directoryInfo.GetFiles();
				for (int j = 0; j < files.Length; j++)
				{
					FileInfo fileInfo = files[j];
					string str = fileInfo.Name.Replace(mask, substitute);
					string destFileName = text + "\\" + str;
					fileInfo.CopyTo(destFileName, true);
				}
			}
			if (this.OnFolderCopied != null)
			{
				this.OnFolderCopied(1, text);
			}
		}
		public void CopyFolder(string orgLoc, string newLoc, string majorMask, string majorSubstitute, string subMask, string subSubstitute)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(orgLoc);
			string text = newLoc + "\\" + directoryInfo.Name;
			text = text.Replace(majorMask, majorSubstitute);
			text = text.Replace(subMask, subSubstitute);
			DirectoryInfo directoryInfo2 = new DirectoryInfo(text);
			if (!directoryInfo2.Exists)
			{
				RSFileUtility.CreateFolder(text);
			}
			if (directoryInfo.GetDirectories().GetLength(0) > 0)
			{
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				for (int i = 0; i < directories.Length; i++)
				{
					DirectoryInfo directoryInfo3 = directories[i];
					this.CopyFolder(directoryInfo3.FullName, text, majorMask, majorSubstitute, subMask, subSubstitute);
				}
			}
			if (directoryInfo.GetFiles().GetLength(0) > 0)
			{
				FileInfo[] files = directoryInfo.GetFiles();
				for (int j = 0; j < files.Length; j++)
				{
					FileInfo fileInfo = files[j];
					string text2 = fileInfo.Name.Replace(majorMask, majorSubstitute);
					text2 = text2.Replace(subMask, subSubstitute);
					string destFileName = text + "\\" + text2;
					fileInfo.CopyTo(destFileName, true);
				}
			}
			if (this.OnFolderCopied != null)
			{
				this.OnFolderCopied(1, text);
			}
		}
		public static void CreateFolder(string folder)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(folder);
			if (!directoryInfo.Exists)
			{
				directoryInfo.Create();
			}
		}
		public static void DeleteFolder(string folder)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(folder);
			directoryInfo.Delete(true);
		}
		public int GetFolderCount(string orgLoc)
		{
			int num = 0;
			DirectoryInfo directoryInfo = new DirectoryInfo(orgLoc);
			if (directoryInfo.GetDirectories().GetLength(0) > 0)
			{
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				for (int i = 0; i < directories.Length; i++)
				{
					DirectoryInfo directoryInfo2 = directories[i];
					num += this.GetFolderCount(directoryInfo2.FullName);
				}
			}
			return num + 1;
		}
		public static void DeleteFile(string file)
		{
			FileInfo fileInfo = new FileInfo(file);
			if (fileInfo.Exists)
			{
				fileInfo.Delete();
			}
		}
		public static void DeleteFilesInFolder(string folder)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(folder);
			FileInfo[] files = directoryInfo.GetFiles();
			for (int i = 0; i < files.Length; i++)
			{
				FileInfo fileInfo = files[i];
				fileInfo.Delete();
			}
		}
	}
}
