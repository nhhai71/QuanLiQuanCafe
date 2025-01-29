using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiQuanCafe.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;
        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO();return instance; }
            private set { instance = value; }
        }
        private AccountDAO() { }

        public bool Login(string userName,string password)
        {
            string query = "EXEC USP_Login @userName , @password";
            DataTable result = DataProvider.Instance.ExecuteQuery(query,new object[] {userName,password});

            return result.Rows.Count > 0;
        }
    }
}
