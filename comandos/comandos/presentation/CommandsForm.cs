using comandos.logic;
using System;
using System.Windows.Forms;
using System.Configuration;
using comandos.data.templates;
using System.Collections.Generic;

namespace comandos.presentation
{
    public partial class CommandsForm : Form
    {
        private int per_id;
        private int ua_id;
        private List<int> loadedIDs = new List<int>();
        private List<CommandEntry> loadedCommands = new List<CommandEntry>();
        private TextBox[] unitRefs;
        private TextBox[] commandRefs;
        private int cursor;
        public CommandsForm(int per_id, int ua_id)
        {
            InitializeComponent();
            this.ua_id = ua_id;
            this.per_id = per_id;
            this.unitRefs = new TextBox[] { textBox1, textBox4, textBox6, textBox8, textBox10, textBox12 };
            this.commandRefs = new TextBox[] { textBox2, textBox3, textBox5, textBox7, textBox9, textBox11 };
            this.cursor = 0;
            HideButtons();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "cm_unidad",
                HeaderText = "Unidad",
                Width = 200
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "cm_comando",
                HeaderText = "Comando",
                Width = 240
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "cm_enviado",
                HeaderText = "Estado",
                Width = 120
            });
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

        private void refreshLoadedCommands()
        {
            loadedCommands = CommandOperations.GetSentCommands(loadedIDs);
            dataGridView1.DataSource = loadedCommands;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string finalResponse = "";
            for(int i = 0; i < this.unitRefs.Length; i++)
            {
                string unitText = this.unitRefs[i].Text.Trim();
                string commandText = this.commandRefs[i].Text.Trim();
                if (unitText != null && commandText != null && unitText != "" && commandText != "") {
                    int cm_id = CommandOperations.SendCommand(this.ua_id, unitText, commandText);

                    if (cm_id == -2) finalResponse += String.Format("Comando {0} fallido: Errores de red, por favor intente más tarde.{1}", i + 1, Environment.NewLine);
                    else if (cm_id == -1) finalResponse += String.Format("Comando {0} fallido: La unidad insertada es inválida.{1}", i + 1, Environment.NewLine);
                    else if (cm_id == 0)
                    {
                        MessageBox.Show("El usuario ingresado es inválido.");
                        return;
                    }
                    else
                    {
                        loadedIDs.Add(cm_id);
                        finalResponse += String.Format("Comando {0} insertado con código de transacción: {1}.{2}", i + 1, cm_id, Environment.NewLine);
                    }
                }
                
            }
            refreshLoadedCommands();
            MessageBox.Show(finalResponse);
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

        private void HandleUnitTextChange(string un_unidadid)
        {
            if (un_unidadid.Length > 0)
            {
                char firstCharacter = un_unidadid.ToCharArray()[0];
                switch (firstCharacter)
                {
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

        private void WriteButtonCommand(string command)
        {
            this.commandRefs[this.cursor].Text = ConfigurationManager.AppSettings[command];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ToLogs();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            HandleUnitTextChange(textBox1.Text);
            this.cursor = 0;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            HandleUnitTextChange(textBox4.Text);
            this.cursor = 1;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            HandleUnitTextChange(textBox6.Text);
            this.cursor = 2;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            HandleUnitTextChange(textBox8.Text);
            this.cursor = 3;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            HandleUnitTextChange(textBox10.Text);
            this.cursor = 4;
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            HandleUnitTextChange(textBox12.Text);
            this.cursor = 5;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.cursor = 0;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            this.cursor = 1;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            this.cursor = 2;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            this.cursor = 3;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            this.cursor = 4;
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            this.cursor = 5;
        }

        private void sensorButton_Click(object sender, EventArgs e)
        {
            WriteButtonCommand("sensormov");
        }

        private void calibrationButton_Click(object sender, EventArgs e)
        {
            WriteButtonCommand("calibracion");
        }

        private void warningButton_Click(object sender, EventArgs e)
        {
            WriteButtonCommand("alerta");
        }

        private void guayaButton1_Click(object sender, EventArgs e)
        {
            WriteButtonCommand("guaya1");
        }

        private void guayaButton2_Click(object sender, EventArgs e)
        {
            WriteButtonCommand("guaya2");
        }

        private void guayaButton3_Click(object sender, EventArgs e)
        {
            WriteButtonCommand("guaya12");
        }

        private void cutButton1_Click(object sender, EventArgs e)
        {
            WriteButtonCommand("corte1");
        }

        private void cutButton2_Click(object sender, EventArgs e)
        {
            WriteButtonCommand("corte2");
        }

        private void cutButton3_Click(object sender, EventArgs e)
        {
            WriteButtonCommand("corte3");
        }

        private void removeButton1_Click(object sender, EventArgs e)
        {
            WriteButtonCommand("remocion1");
        }

        private void removeButton2_Click(object sender, EventArgs e)
        {
            WriteButtonCommand("remocion2");
        }

        private void removeButton3_Click(object sender, EventArgs e)
        {
            WriteButtonCommand("remocion12");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            refreshLoadedCommands();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
