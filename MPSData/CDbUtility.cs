using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;


namespace RSMPS
{
    public class CDbUtility
    {
        public void InitWeeksInDb(DateTime startDate)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            int indx;
            int weekNum;
            DateTime sDate;
            DateTime eDate;

            indx = 0;
            weekNum = GetWeekNumber(startDate);

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spUtility_WeekInput", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            while (indx < 800)
            {
                sDate = startDate.AddDays(indx * 7);

                indx++;
                cmd.Parameters.Clear();
                prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
                prm.Direction = ParameterDirection.Output;
                prm = cmd.Parameters.Add("@StartOfWeek", SqlDbType.SmallDateTime);
                prm.Value = sDate;
                prm = cmd.Parameters.Add("@EndOfWeek", SqlDbType.SmallDateTime);
                eDate = sDate.AddDays(6) ;
                prm.Value = eDate;
                prm = cmd.Parameters.Add("@Number", SqlDbType.Int);
                prm.Value = GetWeekNumber(sDate);
                prm = cmd.Parameters.Add("DisplayVal", SqlDbType.VarChar, 50);
                prm.Value = "Wk " + sDate.Month.ToString() + "/" + sDate.Day.ToString() + "/" + sDate.Year.ToString().Substring(2,2);

                cmd.ExecuteNonQuery();
            }

            cnn.CloseConnection();
        }

        private int GetWeekNumber(DateTime dt)
        {
            DateTime tmpDate;
            int yr;
            decimal wkVal;
            decimal weekNum;

            yr = dt.Year;
            tmpDate = new DateTime(yr, 1, 1);
            wkVal = (((TimeSpan)(dt - tmpDate)).Days / 7.0m) + 1.0m;
            weekNum = Math.Truncate(wkVal);

            return Convert.ToInt32(weekNum);
        }
        /*
        CREATE PROCEDURE spUtility_WeekInput
        @ID		int		output,
        @StartOfWeek	smalldatetime,
        @EndOfWeek		smalldatetime,
        @Number	int,
        @DisplayVal		varchar(50)

        function WeekOfYear(ADate : TDateTime) : word;
        var
          day : word;
          month : word;
          year : word;
          FirstOfYear : TDateTime;
        begin
          DecodeDate(ADate, year, month, day);
          FirstOfYear := EncodeDate(year, 1, 1);
          Result := Trunc(ADate - FirstOfYear) div 7 + 1;
        end;


        procedure TForm1.Button1Click(Sender: TObject);
        begin
          ShowMessage(IntToStr(WeekOfYear(Date)));
        end;

        */


        public DataSet GetTestJobStat()
        {
            SqlDataAdapter da;
            DataSet ds;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spTesting_List", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            ds = new DataSet();
            da.Fill(ds);

            cnn.CloseConnection();

            return ds;
        }
    }
}
