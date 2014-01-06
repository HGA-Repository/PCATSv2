using System;
using System.Data;
using System.Data.SqlClient;
namespace RSLib
{
	public class CDbConnection
	{
		private string m_ConnStr;
		private bool m_bCnnOpened;
		private SqlConnection m_Cnn;
		private CODataServer mDBSet;
		public string ConnectionString
		{
			get
			{
				return this.m_ConnStr;
			}
		}
		public CDbConnection()
		{
			this.mDBSet = new CODataServer();
			this.mDBSet.InitAppSettings();
			if (this.mDBSet.UseWinAuth)
			{
				this.m_ConnStr = string.Concat(new string[]
				{
					"Data Source=",
					this.mDBSet.DBServer,
					";Initial Catalog=",
					this.mDBSet.DBName,
					";"
				});
				return;
			}
			this.m_ConnStr = string.Concat(new string[]
			{
				"uid=",
				this.mDBSet.Username,
				";pwd=",
				this.mDBSet.Password,
				";Data Source=",
				this.mDBSet.DBServer,
				";Initial Catalog=",
				this.mDBSet.DBName,
				";"
			});
		}
		public void OpenConnection()
		{
			this.CloseConnection();
			this.m_Cnn = new SqlConnection(this.m_ConnStr);
			this.m_Cnn.Open();
			this.m_bCnnOpened = true;
		}
		public void OpenConnection(int altTimeout)
		{
			this.CloseConnection();
			this.m_Cnn = new SqlConnection(this.m_ConnStr);
			this.m_Cnn.Open();
			this.m_bCnnOpened = true;
		}
		public SqlConnection GetConnection()
		{
			if (!this.m_bCnnOpened)
			{
				this.OpenConnection();
			}
			return this.m_Cnn;
		}
		public SqlConnection GetConnection(int altTimeout)
		{
			if (!this.m_bCnnOpened)
			{
				this.OpenConnection(altTimeout);
			}
			return this.m_Cnn;
		}
		public void CloseConnection()
		{
			if (this.m_Cnn != null)
			{
				if (this.m_Cnn.State == ConnectionState.Open)
				{
					this.m_Cnn.Close();
				}
				this.m_Cnn = null;
			}
		}
	}
}
