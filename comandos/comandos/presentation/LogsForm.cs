using comandos.data.templates;
using comandos.logic;
using System;
using System.Collections.Generic;
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
            button3.Visible = this.per_id == 0;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "lo_infoascii",
                HeaderText = "ASCII",
                Width = 720
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "lo_ip",
                HeaderText = "Dirección IP",
                Width = 115
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "lo_fecha",
                HeaderText = "Fecha",
                Width = 125
            });
        }

        private void Logout()
        {
            LoginForm form2 = new LoginForm();
            form2.Region = this.Region;
            form2.Show();
            this.Close();
        }
        private void ToCommands()
        {
            CommandsForm form2 = new CommandsForm(this.per_id, this.ua_id);
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
            List<LogResult> results = LogsOperations.GetLogsByDate(textBox1.Text, dateTimePicker2.Value, dateTimePicker1.Value, checkBox1.Checked);
            dataGridView1.DataSource = results;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ToCommands();
        }
    }
}
