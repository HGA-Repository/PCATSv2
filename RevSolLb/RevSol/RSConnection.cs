using System;
using System.Data;
using System.Data.SqlClient;
namespace RevSol
{
	public class RSConnection
	{
		private string mConnStr;
		private bool mbCnnOpened;
		private SqlConnection mCnn;
		private RSDataServer mDbSet;
		public string ConnectionString
		{
			get
			{
				return this.mConnStr;
			}
		}
		public RSConnection()
		{
			this.mDbSet = new RSDataServer();
			this.mDbSet.InitAppSettings();
			if (this.mDbSet.UseWinAuth)
			{
				this.mConnStr = string.Concat(new string[]
				{
					"Data Source=",
					this.mDbSet.DBServer,
					";Initial Catalog=",
					this.mDbSet.DBName,
					";integrated security=SSPI;persist security info=False"
				});
				return;
			}
			this.mConnStr = string.Concat(new string[]
			{
				"uid=",
				this.mDbSet.Username,
				";pwd=",
				this.mDbSet.Password,
				";Data Source=",
				this.mDbSet.DBServer,
				";Initial Catalog=",
				this.mDbSet.DBName,
				";"
			});
		}
		public RSConnection(string altVersion)
		{
			this.mDbSet = new RSDataServer();
			this.mDbSet.InitAppSettings(altVersion);
			if (this.mDbSet.UseWinAuth)
			{
				this.mConnStr = string.Concat(new string[]
				{
					"Data Source=",
					this.mDbSet.DBServer,
					";Initial Catalog=",
					this.mDbSet.DBName,
					";integrated security=SSPI;persist security info=False"
				});
				return;
			}
			this.mConnStr = string.Concat(new string[]
			{
				"uid=",
				this.mDbSet.Username,
				";pwd=",
				this.mDbSet.Password,
				";Data Source=",
				this.mDbSet.DBServer,
				";Initial Catalog=",
				this.mDbSet.DBName,
				";"
			});
		}
		public RSConnection(bool useLocalFile)
		{
			this.mDbSet = new RSDataServer();
			this.mDbSet.InitAppSettings();
			string text = RSUtility.GetLocation() + "\\" + this.mDbSet.DBName + ".mdf";
			if (this.mDbSet.UseWinAuth)
			{
				this.mConnStr = string.Concat(new string[]
				{
					"Data Source=",
					this.mDbSet.DBServer,
					";Initial Catalog=;integrated security=true;AttachDBFileName='",
					text,
					"';Database='",
					this.mDbSet.DBName,
					"'"
				});
				return;
			}
			this.mConnStr = string.Concat(new string[]
			{
				"uid=",
				this.mDbSet.Username,
				";pwd=",
				this.mDbSet.Password,
				";Data Source=",
				this.mDbSet.DBServer,
				";Initial Catalog=",
				this.mDbSet.DBName,
				";"
			});
		}
		public RSConnection(bool useLocalFile, bool useCompactDb)
		{
			this.mDbSet = new RSDataServer();
			this.mDbSet.InitAppSettings();
			string text = RSUtility.GetLocation() + "\\" + this.mDbSet.DBName + ".sdf";
			if (this.mDbSet.UseWinAuth)
			{
				this.mConnStr = string.Concat(new string[]
				{
					"Data Source=",
					this.mDbSet.DBServer,
					";Initial Catalog=;integrated security=true;AttachDBFileName='",
					text,
					"';Database='",
					this.mDbSet.DBName,
					"'"
				});
				return;
			}
			this.mConnStr = string.Concat(new string[]
			{
				"uid=",
				this.mDbSet.Username,
				";pwd=",
				this.mDbSet.Password,
				";Data Source=",
				this.mDbSet.DBServer,
				";Initial Catalog=",
				this.mDbSet.DBName,
				";"
			});
		}
		public void OpenConnection()
		{
			this.CloseConnection();
            this.mCnn = new SqlConnection(this.mConnStr);
			this.mCnn.Open();
			this.mbCnnOpened = true;
		}
		public void OpenConnection(int altTimeout)
		{
			this.CloseConnection();
            this.mCnn = new SqlConnection(this.mConnStr);
			this.mCnn.Open();
			this.mbCnnOpened = true;
		}
		public SqlConnection GetConnection()
		{
			if (!this.mbCnnOpened)
			{
				this.OpenConnection();
			}
			return this.mCnn;
		}
		public SqlConnection GetConnection(int altTimeout)
		{
			if (!this.mbCnnOpened)
			{
				this.OpenConnection(altTimeout);
			}
			return this.mCnn;
		}
		public void CloseConnection()
		{
			if (this.mCnn != null)
			{
				if (this.mCnn.State == ConnectionState.Open)
				{
					this.mCnn.Close();
				}
				this.mCnn = null;
			}
		}
	}
}
