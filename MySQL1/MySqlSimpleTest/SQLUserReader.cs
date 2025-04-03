using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySqlSimpleTest
{
    public class SQLUserReader
    {
        MySqlConnection conn;
        string MyConnectionString = "server=127.0.0.1; uid=root;pwd=vertrigo; database=users;";
        public List<UserInfo> ReadUsers()
        {
            List<UserInfo> result = new List<UserInfo>();
           
            try
            {
                conn = new MySqlConnection(MyConnectionString);
                conn.Open();
                const string quary = "SELECT name, surname, login, password, email, birthdate from users;";
                MySqlCommand command = new MySqlCommand(quary, conn);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string Login = reader.GetString("login");

                        UserInfo us = new UserInfo(Login);
                        us.Name = reader.GetString("name");
                        us.Surname = reader.GetString("surname");
                        us.Password = reader.GetString("password");
                        us.Email = reader.GetString("email");
                        us.BirthDate = reader.GetDateTime("birthdate");
                        result.Add(us);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return result;
            }
            return result;
        }
        public void DeleteUser(string login)
        {
            try
            {
                conn = new MySqlConnection(MyConnectionString);
                conn.Open();

                string query = "DELETE FROM users WHERE login = @login;";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@login", login);
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}