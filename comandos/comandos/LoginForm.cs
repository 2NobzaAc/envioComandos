using comandos.data;
using comandos.logic;
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

        private void button1_Click(object sender, EventArgs e)
        {
            string usr = textBox1.Text;
            string con = textBox2.Text;

            short fetchedProfile = UserOperations.Login(usr, con);

            if (fetchedProfile <= -2) MessageBox.Show("Error de Red");
            else if (fetchedProfile == -1) MessageBox.Show("Usuario o contraseña incorrectos");
            else MessageBox.Show("Usuario autenticado con perfil: " + fetchedProfile);
        }
    }
}
