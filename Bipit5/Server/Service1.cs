using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Service1 : IService1
    {
        string path = @"Data Source=Library00001.mssql.somee.com;Initial Catalog=Library00001;User Id=D98512416_SQLLogin_1;Password=5vem21popc";
        public void DoWork()
        {

        }

        public DataTable GetData()
        {
            string query = "SELECT  [ФИО читателя], [Название книги], [Дата выдачи], [Дата возврата],- DATEDIFF(day, [Дата возврата], [Дата выдачи]) as 'Число дней чтения' FROM Выдача";

            using (SqlConnection connection = new SqlConnection(path))
            {
                SqlCommand command = new SqlCommand(query);
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                command.Connection = connection;
                dataAdapter.SelectCommand = command;
                DataTable dataTable = new DataTable();
                dataTable.TableName = "Выдача";
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        public DataTable GetComboValue()
        {
            string query = "SELECT * FROM Книги";
            using (SqlConnection connection = new SqlConnection(path))
            {
                SqlCommand command = new SqlCommand(query);
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                command.Connection = connection;
                dataAdapter.SelectCommand = command;
                DataTable dataTable = new DataTable();
                dataTable.TableName = "Книги";
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        public void NewRec(string fio, string book, string date1, string date2)
        {
            string query = $"INSERT INTO Выдача ([Дата выдачи], [ФИО читателя], [Название книги], [Дата возврата], [Число дней чтения]) Values ('{date1.ToString()}', '{fio}', '{book}', '{date2.ToString()}', '')";

            var connect = new SqlConnection(path);
            connect.Open();
            SqlCommand command = connect.CreateCommand();
            command.CommandText = query;
            command.ExecuteNonQuery();
            connect.Close();
        }
    }
}
