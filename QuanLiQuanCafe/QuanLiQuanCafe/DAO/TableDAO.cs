using QuanLiQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiQuanCafe.DAO
{
   public class TableDAO
    {
        private static TableDAO instance;
        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO();return instance; }
            private set { instance = value; }
        }

        public static int TableWidth = 90;
        public static int TableHeight =90;

        private TableDAO() { }
        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_TableList");
            // chuyển DataTable thành ListTable

            foreach(DataRow item in data.Rows)
            {
                Table table = new Table(item);
                
                tableList.Add(table);
            }
            return tableList;
        }



    }
}
