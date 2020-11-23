using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Бипит_5
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Service1 : IService1
    {
        string connectionString = @"Data Source=Library00001.mssql.somee.com;Initial Catalog=Library00001;User Id=D98512416_SQLLogin_1;Password=5vem21popc";

        public DataSet GetData()
        {
            string query = "SELECT  [ФИО читателя], [Название книги], [Дата выдачи], [Дата возврата],- DATEDIFF(day, [Дата возврата], [Дата выдачи]) as 'Число дней чтения' FROM Выдача";


            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(ds, "Выдача");
                return ds;
            }
        }

        public DataSet Fill()
        {
            string query = "SELECT * FROM Книги";
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(ds, "Книги");
                return ds;
            }
        }



        public void NewRec(string fio, string book, string date1, string date2)
        {
            string query = $"INSERT INTO Выдача ([Дата выдачи], [ФИО читателя], [Название книги], [Дата возврата], [Число дней чтения]) Values ('{date1.ToString()}', '{fio}', '{book}', '{date2.ToString()}', '')";
            var connect = new SqlConnection(connectionString);
            connect.Open();
            SqlCommand command = connect.CreateCommand();
            command.CommandText = query;
            command.ExecuteNonQuery();
            connect.Close();
        }
    }
}
