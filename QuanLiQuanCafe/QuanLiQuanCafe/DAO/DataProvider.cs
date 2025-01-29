using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiQuanCafe.DAO
{
   

    public class DataProvider
    {
        private static DataProvider instance;//Ctr+R+E
        // tạo chuỗi kết nối với DataBase
        private string connectionSTR = @"Data Source=DESKTOP-JFCSOM4;Initial Catalog=QUANLIQUANCAFE;Integrated Security=True";

        public static DataProvider Instance
        {
          get { if (instance == null) instance = new DataProvider(); return instance;}
          private set { instance = value; }
        }

        private DataProvider() { }
        public DataTable ExecuteQuery(string query,object[]parameter=null)
        {
            // Lấy dữ liệu ra giao diện
            DataTable data = new DataTable();
            // kết nối đến DataBase
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {

                connection.Open();
                // tạo câu truy vấn

                // thực thi câu truy vấn trên kết nối connection
                SqlCommand command = new SqlCommand(query, connection);
               if(parameter!=null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach(string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                // bên trung gian để lấy dữ liệu ra
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                // đổ dữ liệu lấy ra vào Datatable
                adapter.Fill(data);
                connection.Close();
            }

            return data;
        }
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            // Lấy dữ liệu ra giao diện
            int data = 0;
            // kết nối đến DataBase
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {

                connection.Open();
                // tạo câu truy vấn

                // thực thi câu truy vấn trên kết nối connection
                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in parameter)
                    {

                        command.Parameters.AddWithValue("userName", parameter[i]);
                        i++;
                    }
                }

                data = command.ExecuteNonQuery();
                connection.Close();
            }

            return data;
        }
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            // Lấy dữ liệu ra giao diện
            object data = 0;
            // kết nối đến DataBase
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {

                connection.Open();
                // tạo câu truy vấn

                // thực thi câu truy vấn trên kết nối connection
                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in parameter)
                    {

                        command.Parameters.AddWithValue("userName", parameter[i]);
                        i++;
                    }
                }

                // bên trung gian để lấy dữ liệu ra
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                // đổ dữ liệu lấy ra vào Datatable
                data =command.ExecuteScalar();
                connection.Close();
            }

            return data;
        }


    }
}
