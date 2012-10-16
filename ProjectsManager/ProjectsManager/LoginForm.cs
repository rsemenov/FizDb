using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Red;

namespace ProjectsManager
{
    public partial class LoginForm : Form
    {
        private RedContext context;
        
        public User CurrentUser { get; set; }
        private string validateCustomerQuery = "Select TOP 1 Login, UserType form Users where Login={0} and Password={1}";

        public LoginForm(RedContext context)
        {
            InitializeComponent();
            this.context = context;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var query = string.Format(validateCustomerQuery, textBox1.Text, textBox2);
            var table = context.Provider.ExecuteSelectCommand(query);
            if(table.Rows.Count>0)
            {
                CurrentUser = new User() {Login = table.Rows[0][0].ToString()};
                var utype = (UserType) table.Rows[0][1];
                CurrentUser.UserType = utype;
            }
            else
            {
                MessageBox.Show("Помилка входу. Введіть правильні логін та пароль.");
            }
        }
    }
}
