using comandos.data;
using comandos.logic;
using comandos.presentation;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace comandos
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void OpenLogs(int per_id, int ua_id)
        {
            LogsForm form2 = new LogsForm(per_id, ua_id);
            form2.Region = this.Region;
            form2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usr = textBox1.Text;
            string con = textBox2.Text;

            int[] fetchedProfile = UserOperations.Login(usr, con);

            if (fetchedProfile[0] <= -2) MessageBox.Show("Error de Red");
            else if (fetchedProfile[0] == -1) MessageBox.Show("Usuario o contraseña incorrectos");
            else OpenLogs(fetchedProfile[0], fetchedProfile[1]);
        }
    }
}
