using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySqlSimpleTest
{
    public partial class MainForm: Form
    {
        SQLUserReader sqlreader = new SQLUserReader();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UserTable.DataSource = sqlreader.ReadUsers();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (UserTable.SelectedRows.Count > 0)
            {
                // Получаем логин выбранного пользователя
                string selectedLogin = UserTable.SelectedRows[0].Cells["login"].Value.ToString();
                // Вызываем метод удаления пользователя
                sqlreader.DeleteUser(selectedLogin);
                // Обновляем таблицу пользователей
                UserTable.DataSource = sqlreader.ReadUsers();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите пользователя для удаления.");
            }
        }
    }
}