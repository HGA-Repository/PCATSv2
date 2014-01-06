using System;
using System.IO;
namespace RevSol
{
	public class RSUpdater
	{
		public event PassDataString OnStatusUpdate;
		public void CheckForUpdate()
		{
			this.SendStatusUpdate("Checking for application updates");
			if (this.CheckIfNeedUpdate())
			{
				this.SendStatusUpdate("Updating application");
				COUpdater cOUpdater = new COUpdater();
				cOUpdater.InitAppSettings();
				this.CopyFolder(RSUtility.GetLocation(), cOUpdater.UpdateLocation);
				this.SendStatusUpdate("Completed application update");
			}
		}
		private bool CheckIfNeedUpdate()
		{
			COUpdater cOUpdater = new COUpdater();
			cOUpdater.InitAppSettings();
			string path = RSUtility.GetLocation() + "\\" + cOUpdater.SourceExe;
			string path2 = cOUpdater.UpdateLocation + "\\" + cOUpdater.SourceExe;
			DateTime lastWriteTime = File.GetLastWriteTime(path);
			DateTime lastWriteTime2 = File.GetLastWriteTime(path2);
			return cOUpdater.UseUpdater && (lastWriteTime - lastWriteTime2).Duration() > TimeSpan.FromSeconds(10.0);
		}
		private void SendStatusUpdate(string status)
		{
			if (this.OnStatusUpdate != null)
			{
				this.OnStatusUpdate(status);
			}
		}
		private void CopyFiles(string localFolder, string updateFolder)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(updateFolder);
			DirectoryInfo directoryInfo2 = new DirectoryInfo(localFolder);
			this.SendStatusUpdate("Copying Folder: " + localFolder);
			if (!directoryInfo2.Exists)
			{
				directoryInfo2.Create();
			}
			FileInfo[] files = directoryInfo.GetFiles();
			for (int i = 0; i < files.Length; i++)
			{
				FileInfo fileInfo = files[i];
				string text = directoryInfo2.FullName + "\\" + fileInfo.Name;
				this.SendStatusUpdate("Copying file: " + text);
				fileInfo.CopyTo(text, true);
			}
		}
		private void CopyFolder(string localFolder, string updateFolder)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(updateFolder);
			DirectoryInfo[] directories = directoryInfo.GetDirectories();
			if (directories.GetLength(0) > 1)
			{
				for (int i = 0; i < directories.GetLength(0); i++)
				{
					string localFolder2 = localFolder + "\\" + directories[i].Name;
					string updateFolder2 = updateFolder + "\\" + directories[i].Name;
					this.CopyFolder(localFolder2, updateFolder2);
				}
			}
			this.CopyFiles(localFolder, updateFolder);
		}
	}
}
