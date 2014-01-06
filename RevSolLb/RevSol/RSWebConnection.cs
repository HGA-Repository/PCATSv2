using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace RevSol
{
	public class RSWebConnection
	{
		private string m_ConnStr;
		private bool m_bCnnOpened;
		private SqlConnection m_Cnn;
		public string ConnectionString
		{
			get
			{
				return this.m_ConnStr;
			}
		}
		public RSWebConnection()
		{
		}
		public RSWebConnection(string connName)
		{
			this.m_ConnStr = ConfigurationManager.ConnectionStrings[connName].ConnectionString;
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
