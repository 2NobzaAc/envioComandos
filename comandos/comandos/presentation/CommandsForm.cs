using comandos.logic;
using System;
using System.Windows.Forms;
using System.Configuration;

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
            HideButtons();
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

            if (cm_id == -4) MessageBox.Show("Escriba un comando para insertar");
            else if (cm_id == -3) MessageBox.Show("Escriba la unidad para insertar comando");
            else if (cm_id == -2) MessageBox.Show("Errores de red, por favor intente más tarde");
            else if (cm_id == -1) MessageBox.Show("La unidad insertada es inválida");
            else if (cm_id == 0) MessageBox.Show("El usuario ingresado es inválido.");
            else MessageBox.Show("Commando insertado con código de transacción: " + cm_id);
        }

        private bool[] GetBitsArray(int number)
        {
            // Determine the minimum required length (at least 11)
            int length = Math.Max(11, (int)Math.Log(number, 2) + 1);

            // Create the bool array
            bool[] result = new bool[length];

            // Convert to binary (LSB first)
            for (int i = 0; i < length; i++)
            {
                result[i] = (number & (1 << i)) != 0;
            }

            return result;
        }

        //se maneja que botones se renderizan usando un sistema similar al de permisos de unix
        private void SwitchButtons(int code)
        {
            bool[] values = GetBitsArray(code);
            calibrationButton.Visible = values[0];
            warningButton.Visible = values[1];
            guayaButton1.Visible = values[2];
            guayaButton2.Visible = values[3];
            guayaButton3.Visible = values[4];
            cutButton1.Visible = values[5];
            cutButton2.Visible = values[6];
            cutButton3.Visible = values[7];
            removeButton1.Visible = values[8];
            removeButton2.Visible = values[9];
            removeButton3.Visible = values[10];
        }

        private void HideButtons()
        {
            calibrationButton.Visible = false;
            warningButton.Visible = false;
            guayaButton1.Visible = false;
            guayaButton2.Visible = false;
            guayaButton3.Visible = false;
            cutButton1.Visible = false;
            cutButton2.Visible = false;
            cutButton3.Visible = false;
            removeButton1.Visible = false;
            removeButton2.Visible = false;
            removeButton3.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text.Length > 0)
            {
                char firstCharacter = textBox1.Text.ToCharArray()[0];
                switch (firstCharacter) {
                    case '0':
                        SwitchButtons(226);
                        break;
                    case 'n':
                    case 'N':
                        SwitchButtons(1821);
                        break;
                    case 'f':
                    case 'F':
                        SwitchButtons(3);
                        break;
                    case 'k':
                    case 'K':
                        SwitchButtons(29);
                        break;
                    default:
                        HideButtons();
                        break;
                }
            }
            else
            {
                HideButtons();
            }
        }

        private void sensorButton_Click(object sender, EventArgs e)
        {
            textBox2.Text = ConfigurationManager.AppSettings["sensormov"];
        }

        private void calibrationButton_Click(object sender, EventArgs e)
        {
            textBox2.Text = ConfigurationManager.AppSettings["calibracion"];
        }

        private void warningButton_Click(object sender, EventArgs e)
        {
            textBox2.Text = ConfigurationManager.AppSettings["alerta"];
        }

        private void guayaButton1_Click(object sender, EventArgs e)
        {
            textBox2.Text = ConfigurationManager.AppSettings["guaya1"];
        }

        private void guayaButton2_Click(object sender, EventArgs e)
        {
            textBox2.Text = ConfigurationManager.AppSettings["guaya2"];
        }

        private void guayaButton3_Click(object sender, EventArgs e)
        {
            textBox2.Text = ConfigurationManager.AppSettings["guaya12"];
        }

        private void cutButton1_Click(object sender, EventArgs e)
        {
            textBox2.Text = ConfigurationManager.AppSettings["corte1"];
        }

        private void cutButton2_Click(object sender, EventArgs e)
        {
            textBox2.Text = ConfigurationManager.AppSettings["corte2"];
        }

        private void cutButton3_Click(object sender, EventArgs e)
        {
            textBox2.Text = ConfigurationManager.AppSettings["corte3"];
        }

        private void removeButton1_Click(object sender, EventArgs e)
        {
            textBox2.Text = ConfigurationManager.AppSettings["remocion1"];
        }

        private void removeButton2_Click(object sender, EventArgs e)
        {
            textBox2.Text = ConfigurationManager.AppSettings["remocion2"];
        }

        private void removeButton3_Click(object sender, EventArgs e)
        {
            textBox2.Text = ConfigurationManager.AppSettings["remocion12"];
        }
    }
}
