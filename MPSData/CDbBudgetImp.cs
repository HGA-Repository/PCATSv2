using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;


namespace RSMPS
{
    public class CDbBudgetImp
    {
        public void ClearBudgetTmp()
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBUDIMP_Clear", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.ExecuteNonQuery();

            cnn.CloseConnection();
        }

        public void SaveNewBudget(int projID, string codes, string desc, string qty, string uom, string hours)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBUDIMP_Insert", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;
            prm = cmd.Parameters.Add("@Codes", SqlDbType.VarChar, 255);
            prm.Value = codes;
            prm = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 255);
            prm.Value = desc;
            prm = cmd.Parameters.Add("@Qty", SqlDbType.VarChar, 255);
            prm.Value = qty;
            prm = cmd.Parameters.Add("@UOM", SqlDbType.VarChar, 255);
            prm.Value = uom;
            prm = cmd.Parameters.Add("@Hours", SqlDbType.VarChar, 255);
            prm.Value = hours;

            cmd.ExecuteNonQuery();

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;
        }

        public void UpdateActivityCodes()
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBUDIMP_UpdateAcctCodes", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.ExecuteNonQuery();

            cnn.CloseConnection();
        }

        public DataSet GetBudgetImportData()
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlDataAdapter da;
            DataSet ds;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBUDIMP_ImportData", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            da = new SqlDataAdapter();
            ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);

            cnn.CloseConnection();

            return ds;
        }


        public void ApplyBudgetImport()
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBUDIMP_ApplyImport", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.ExecuteNonQuery();

            cnn.CloseConnection();
        }
    }
}
