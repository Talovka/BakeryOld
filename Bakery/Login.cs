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

namespace Bakery
{
    public partial class Login : Form
    {
        public string Role { get; set; }
        public Login()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            string role = DAL.Login(userName.Text, password.Text);
            if( role == Constants.userStorekeeper || role == Constants.userClient || role == Constants.userCook || role == Constants.userOwner || role == Constants.userAdmin)
            {
                Role = role;
                Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Сообщение");
            }
        }
    }
}
