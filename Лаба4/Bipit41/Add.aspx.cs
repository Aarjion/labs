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
    public partial class Add1 : System.Web.UI.Page
    {
       // string path = @"Server = localhost\SQLEXPRESS; Database = Библиотека; Trusted_Connection = True";
        string path = @"Data Source=Library00001.mssql.somee.com;Initial Catalog=Library00001;User Id=D98512416_SQLLogin_1;Password=5vem21popc";

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void NewRec()
        {
            string query = $"INSERT INTO Выдача ([Дата выдачи], [ФИО читателя], [Название книги], [Дата возврата], [Число дней чтения]) Values ('{Calendar1.SelectedDate}', '{TextBox3.Text}', '{DropDownList1.SelectedValue}', '{Calendar2.SelectedDate}', '')";

            string query1 = @"update Выдача SET [Число дней чтения] = CONVERT(int, [Дата возврата]- [Дата выдачи])  FROM Выдача";
            using (SqlConnection con = new SqlConnection(path))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.ExecuteNonQuery();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            NewRec();
            Response.Redirect("~/List.aspx");
        }
    }
}