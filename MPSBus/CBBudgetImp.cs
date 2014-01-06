using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace RSMPS
{
    public class CBBudgetImp
    {

        public static void ClearBudgetImp()
        {
            CDbBudgetImp bi = new CDbBudgetImp();

            bi.ClearBudgetTmp();
        }

        public static void SaveNewBudget(int projID, string codes, string desc, string qty, string uom, string hours)
        {
            CDbBudgetImp bi = new CDbBudgetImp();

            bi.SaveNewBudget(projID, codes, desc, qty, uom, hours);
        }

        public static void UpdateActivityCodes()
        {
            CDbBudgetImp bi = new CDbBudgetImp();

            bi.UpdateActivityCodes();
        }

        public static DataSet GetBudgetImportData()
        {
            CDbBudgetImp bi = new CDbBudgetImp();

            return bi.GetBudgetImportData();
        }

        public static void ApplyBudgetImport()
        {
            CDbBudgetImp bi = new CDbBudgetImp();

            bi.ApplyBudgetImport();
        }
    }
}
