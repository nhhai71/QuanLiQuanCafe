using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiQuanCafe.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;
        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO();return instance; }
            private set { instance = value; }
        }

        private BillDAO() { }
        public int GetUncheckBillIDByTableID()
        {
            return DataProvider.Instance.ExecuteQuery("");
        }

    }
}
