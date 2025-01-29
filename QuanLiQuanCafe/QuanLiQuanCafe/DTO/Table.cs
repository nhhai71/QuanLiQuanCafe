using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiQuanCafe.DTO
{
    public class Table
    {
        public Table(int id,string name,string status)
        {
            this.ID = id;
            this.Name = name;
            this.Status = status;
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Table(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.Status = row["status"].ToString();
        }

        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        private int iD;
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

    }
}
