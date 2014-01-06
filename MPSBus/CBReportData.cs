using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;


namespace RSMPS
{
    public class CBReportData
    {
        public static SqlDataReader GetListByRangeDeptEmpProj(DateTime sDate, DateTime eDate)
        {
            CDbReportData dbRp = new CDbReportData();

            return dbRp.GetListByRangeDeptEmpProj(sDate, eDate);
        }

        public static SqlDataReader GetListByRangeDeptEmpProj(DateTime sDate, DateTime eDate, bool selDept, bool selProj, string deptXml, string projXml)
        {
            CDbReportData dbRp = new CDbReportData();

            return dbRp.GetListByRangeDeptEmpProj(sDate, eDate, selDept, selProj, deptXml, projXml);
        }

        public static SqlDataReader GetListByRangeProjDeptEmp(DateTime sDate, DateTime eDate)
        {
            CDbReportData dbRp = new CDbReportData();

            return dbRp.GetListByRangeProjDeptEmp(sDate, eDate);
        }

        public static SqlDataReader GetListByRangeProjDeptEmp(DateTime sDate, DateTime eDate, bool selDept, bool selProj, string deptXml, string projXml)
        {
            CDbReportData dbRp = new CDbReportData();

            return dbRp.GetListByRangeProjDeptEmp(sDate, eDate, selDept, selProj, deptXml, projXml);
        }
    }
}
