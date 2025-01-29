using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLiQuanCafe.DAO;

namespace QuanLiQuanCafe
{
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();
            LoadAccountList();
        }
        #region No use
        private void tpBill_Click(object sender, EventArgs e)
        {

        }

        private void tpFood_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbAccount_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtgvFood_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        #endregion

        public void LoadFoodList()
        {
            string query = "Select*From Food";
            dtgvFood.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
        public void LoadAccountList()
        {
            string query = "EXEC USP_GetAccountByUserName @userName";
      
            
            dtgvAccount.DataSource= DataProvider.Instance.ExecuteQuery(query,new object[] { "Staff"});
        }
    }
}
