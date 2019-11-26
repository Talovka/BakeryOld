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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void CreateAccount_Click(object sender, EventArgs e)
        {
            if(userNameReg.Text == "" || passwordReg.Text == "")
            {
                MessageBox.Show("Заполните все поля для регистрации","Сообщение");
            }
            else if(userNameReg.Text.Length < 4 || passwordReg.Text.Length < 4)
            {
                MessageBox.Show("Длина логина и пароля дожна превышать 4 символа");
            }
            else
            {
                int reg = DAL.UserNameСheck(userNameReg.Text);
                if(reg == 1)
                {
                    MessageBox.Show("Пользователь " + userNameReg.Text + " уже существует", "Сообщение");
                }
                else if(reg == 0)
                {
                    DAL.Registration(userNameReg.Text, passwordReg.Text);
                    Close();
                }
                else if(reg == -1)
                {
                    MessageBox.Show("Что-то пошло не так", "Сообщение");
                }
            }
        }
    }
}
