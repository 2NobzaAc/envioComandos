using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace comandos.presentation
{
    public partial class LogsForm : Form
    {
        protected int per_id;
        protected int ua_id;
        public LogsForm(int per_id, int ua_id)
        {
            InitializeComponent();
            this.per_id = per_id;
            this.ua_id = ua_id;
            MessageBox.Show("Logged with profile: " + this.per_id + ", and user: " + this.ua_id);
        }

        private void Logout()
        {
            LoginForm form2 = new LoginForm();
            form2.Region = this.Region;
            form2.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Logout();
        }
    }
}
