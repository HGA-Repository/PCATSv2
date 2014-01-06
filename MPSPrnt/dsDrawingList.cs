using System.Data;

namespace RSMPS {


    partial class dsDrawingList
    {
        partial class spRPRT_DrawingLogListDataTable
        {
            public void LoadFromDs(DataSet ds)
            {
                this.Rows.Clear();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    object[] arr = dr.ItemArray;

                    this.Rows.Add(arr);
                }
            }
        }
    }
}
