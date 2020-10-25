using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bipit4
{
    public partial class List1 : System.Web.UI.Page
    {
       // string path = @"Server = localhost\SQLEXPRESS; Database = Библиотека; Trusted_Connection = True";
        string path = @"Data Source=Library00001.mssql.somee.com;Initial Catalog=Library00001;User Id=D98512416_SQLLogin_1;Password=5vem21popc";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Table();
            }
        }
        public void Table()
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

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (Menu1.SelectedValue.Contains("Список"))
            {
                Response.Redirect("~/List.aspx");
            }
            if (Menu1.SelectedValue.Contains("Новый"))
            {
                Response.Redirect("~/Add.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DeleteRec();
            Table();
        }
        public void DeleteRec()
        {
            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                var checkbox = gvrow.FindControl("CheckBox1") as CheckBox;
                if (checkbox.Checked)
                {
                    string query = $"DELETE FROM Выдача WHERE [Код выдачи] = '{gvrow.Cells[1].Text}'";
                    using (SqlConnection con = new SqlConnection(path))
                    {
                        SqlCommand cmd = new SqlCommand(query, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}