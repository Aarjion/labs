using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bipit3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            //string path = @"Server = localhost\SQLEXPRESS; Database = Библиотека; Trusted_Connection = True";
            string path = @"Data Source=Library00001.mssql.somee.com;Initial Catalog=Library00001;User Id=D98512416_SQLLogin_1;Password=5vem21popc";
            if (Menu1.SelectedValue.Contains("Читатель"))
            {
                string query = "SELECT * FROM Читатель";
                DataSet dataSet = new DataSet();
                using (SqlConnection connection = new SqlConnection(path))
                {
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
                    sqlDataAdapter.Fill(dataSet, "Читатель");
                    GridView1.DataSource = dataSet.Tables["Читатель"];
                    GridView1.DataBind();
                }
            }
            if (Menu1.SelectedValue.Contains("Книги"))
            {
                string query = "SELECT * FROM Книги";
                DataSet dataSet = new DataSet();
                using (SqlConnection connection = new SqlConnection(path))
                {
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
                    sqlDataAdapter.Fill(dataSet, "Книги");
                    GridView1.DataSource = dataSet.Tables["Книги"];
                    GridView1.DataBind();
                }
            }
            if (Menu1.SelectedValue.Contains("Выдача"))
            {
                string query = "SELECT * FROM Выдача";
                DataSet dataSet = new DataSet();
                using (SqlConnection connection = new SqlConnection(path))
                {
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
                    sqlDataAdapter.Fill(dataSet, "Выдача");
                    GridView1.DataSource = dataSet.Tables["Выдача"];
                    GridView1.DataBind();
                }
            }
        }
    }
}