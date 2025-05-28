using comandos.logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace comandos.presentation
{
    public partial class CommandsForm : Form
    {
        int per_id;
        int ua_id;
        public CommandsForm(int per_id, int ua_id)
        {
            InitializeComponent();
            this.ua_id = ua_id;
            this.per_id = per_id;
        }

        private void Logout()
        {
            LoginForm form2 = new LoginForm();
            form2.Region = this.Region;
            form2.Show();
            this.Close();
        }
        private void ToLogs()
        {
            LogsForm form2 = new LogsForm(this.per_id, this.ua_id);
            form2.Region = this.Region;
            form2.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ToLogs();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cm_id = CommandOperations.SendCommand(this.ua_id, textBox1.Text, textBox2.Text);

            if (cm_id == -2) MessageBox.Show("Errores de red, por favor intente más tarde");
            else if (cm_id == -1) MessageBox.Show("La unidad insertada es inválida");
            else if (cm_id == 0) MessageBox.Show("El usuario ingresado es inválido.");
            else MessageBox.Show("Commando insertado con código de transacción: " + cm_id);
        }
    }
}
