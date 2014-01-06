using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Data.SqlClient;

namespace RSMPS
{
    public class CBActivityCodeDisc : COActivityCodeDisc
    {


        public string GetDataString()
        {
            string tmpStr;
            COActivityCodeDisc o;
            XmlSerializer s;
            StringWriter sw;

            o = new COActivityCodeDisc();
            s = new XmlSerializer(typeof(COActivityCodeDisc));
            sw = new StringWriter();

            base.Copy(o);
            s.Serialize(sw, o);

            tmpStr = sw.ToString();

            o = null;
            s = null;
            sw = null;

            return tmpStr;
        }


        public static SqlDataReader GetListForProject(int id)
        {
            CDbActivityCodeDisc dbDt = new CDbActivityCodeDisc();
            return dbDt.GetListForProject(id);
        }

        public static SqlDataReader GetList()
        {
            CDbActivityCodeDisc dbDt = new CDbActivityCodeDisc();
            return dbDt.GetList();
        }

        public static void UpdateForProject(int group, int projet_id, bool enabled)
        {
            CDbActivityCodeDisc dbDt = new CDbActivityCodeDisc();
            dbDt.UpdateForProject(group, projet_id, enabled);
        }




        public static IEnumerable<CBActivityCodeDisc> GetAll()
        {
            var list = new List<CBActivityCodeDisc>();
            var raw = GetList();
            while (raw.Read())
            {
                list.Add(new CBActivityCodeDisc()
                {
                    Code = raw["Code"].ToString()
                    , Name = raw["Description"].ToString()
                });

            }
            return list;
        }



        public static IEnumerable<CBActivityCodeDisc> GetAllForProject(int id)
        {
            var list = new List<CBActivityCodeDisc>();
            var raw = GetListForProject( id );
            while (raw.Read())
            {
                list.Add( new CBActivityCodeDisc(){
                    Code = raw["Code"].ToString()
                    , Name = raw["Description"].ToString()
                });
 
            }
            return list;
        }


    }
}
