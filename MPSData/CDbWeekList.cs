using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Serialization;


namespace RSMPS
{
    public class CDbWeekList
    {
        private COWeekList oVar;

        public string GetByID(int lID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spWeekList_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                oVar = new COWeekList();

                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.StartOfWeek = Convert.ToDateTime(dr["StartOfWeek"]);
                oVar.EndOfWeek = Convert.ToDateTime(dr["EndOfWeek"]);
                oVar.Number = Convert.ToInt32(dr["Number"]);
                oVar.DisplayVal = dr["DisplayVal"].ToString();
                tmpStr = GetDataString();
            }

            dr.Close();
            dr = null;
            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return tmpStr;
        }


        public int SaveNew(string strXml)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            int retVal = 0;

            LoadVals(strXml);

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spWeekList_Insert", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@StartOfWeek", SqlDbType.SmallDateTime);
            prm.Value = oVar.StartOfWeek;
            prm = cmd.Parameters.Add("@EndOfWeek", SqlDbType.SmallDateTime);
            prm.Value = oVar.EndOfWeek;
            prm = cmd.Parameters.Add("@Number", SqlDbType.Int);
            prm.Value = oVar.Number;
            prm = cmd.Parameters.Add("@DisplayVal", SqlDbType.VarChar, 50);
            prm.Value = oVar.DisplayVal;
            cmd.ExecuteNonQuery();

            retVal = Convert.ToInt32(cmd.Parameters["@ID"].Value);

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return retVal;
        }


        public int SavePrev(string strXml)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            LoadVals(strXml);

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spWeekList_Update", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = oVar.ID;
            prm = cmd.Parameters.Add("@StartOfWeek", SqlDbType.SmallDateTime);
            prm.Value = oVar.StartOfWeek;
            prm = cmd.Parameters.Add("@EndOfWeek", SqlDbType.SmallDateTime);
            prm.Value = oVar.EndOfWeek;
            prm = cmd.Parameters.Add("@Number", SqlDbType.Int);
            prm.Value = oVar.Number;
            prm = cmd.Parameters.Add("@DisplayVal", SqlDbType.VarChar, 50);
            prm.Value = oVar.DisplayVal;
            cmd.ExecuteNonQuery();

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return oVar.ID;
        }


        private string GetDataString()
        {
            string tmpStr;
            XmlSerializer s;
            StringWriter sw;

            s = new XmlSerializer(typeof(COWeekList));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }


        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(COWeekList));
            sr = new System.IO.StringReader(strXml);

            oVar = new COWeekList();
            oVar = (COWeekList)s.Deserialize(sr);

            sr.Close();
            sr = null;
            s = null;
        }


        public bool Delete(int lID)
        {
            bool retVal = false;

            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spWeekList_Delete", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;

            try
            {
                cmd.ExecuteNonQuery();

                retVal = true;
            }
            catch
            {
                retVal = false;
            }

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return retVal;
        }


        public SqlDataReader GetList()
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spWeekList_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public DataSet GetList(DateTime startDate, DateTime endDate)
        {
            SqlDataAdapter da;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            DataSet ds;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spWeekList_ListByRange", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@StartDate", SqlDbType.SmallDateTime);
            prm.Value = startDate.ToShortDateString();
            prm = cmd.Parameters.Add("@EndDate", SqlDbType.SmallDateTime);
            prm.Value = endDate.ToShortDateString();

            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            ds = new DataSet();
            da.Fill(ds);

            cnn.CloseConnection();

            return ds;
        }
    }
}
