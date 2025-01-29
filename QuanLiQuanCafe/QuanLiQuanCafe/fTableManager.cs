using QuanLiQuanCafe.DAO;
using QuanLiQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiQuanCafe
{
    public partial class fTableManager : Form
    {
        public fTableManager()
        {
            InitializeComponent();
            LoadTable();
        }

        #region Method
        public void LoadTable()
        {
            List<Table> tableList = TableDAO.Instance.LoadTableList();

            foreach(Table item in tableList)
            {
                Button button = new Button() { Width = TableDAO.TableWidth,Height = TableDAO.TableHeight };
                button.Text = item.Name + Environment.NewLine + item.Status;
                button.Tag = item;

                button.Click += button_Click;
                switch(item.Status)
                {
                    case "Trống":
                        button.BackColor = Color.Aqua;
                            break;
                    default:
                        button.BackColor = Color.LightPink;
                        break;
                }
                flbTable.Controls.Add(button);
            }
        }

        void ShowBill(int id)
        {

        }
        
        #endregion

        private void lsvBill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {

        }

        private void cbFood_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       
        #region Events
        private void button_Click(object sender,EventArgs e)
        {
            int tableID=(sender as Table).ID;
            ShowBill(tableID);
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new QuanLiQuanCafe.fAccountProfile();
            f.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new QuanLiQuanCafe.fAdmin();
            f.ShowDialog();
        }
        #endregion
    }
}
