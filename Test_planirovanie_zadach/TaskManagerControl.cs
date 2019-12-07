using System;
using System.Windows.Forms;
using System.Globalization;
using System.Collections.Generic;

namespace Task_Manager
{
    public partial class TaskManagerControl : UserControl
    {
        Zadacha _GetZadacha = new Zadacha();
        List<Action> _ListTasks = new List<Action>();

        public TaskManagerControl()
        {
            InitializeComponent();
        }

        private void TaskManagerControl_Load(object sender, EventArgs e)
        {

            comboBox1.DataSource = DateTimeFormatInfo.CurrentInfo.DayNames;//Enum.GetValues(typeof(System.DayOfWeek));
            comboBox1.SelectedIndex = (int)dateTimePicker1.Value.DayOfWeek;

            CheckStartupType();

            _GetZadacha.DateTime = dateTimePicker1.Value;
        }

        private void Inputs_CheckedChanged(object sender, EventArgs e)
        {
            CheckStartupType();
        }

        private void CheckStartupType()
        {
            if (radioButton1.Checked) { dateTimePicker1.Enabled = true; dateTimePicker2.Enabled = true; comboBox1.Enabled = false; _GetZadacha.TipZapuska = radioButton1.TabIndex; }
            if (radioButton2.Checked) { dateTimePicker1.Enabled = false; dateTimePicker2.Enabled = true; comboBox1.Enabled = false; _GetZadacha.TipZapuska = radioButton2.TabIndex; }
            if (radioButton3.Checked) { dateTimePicker1.Enabled = false; dateTimePicker2.Enabled = true; comboBox1.Enabled = true; _GetZadacha.TipZapuska = radioButton3.TabIndex; }
            if (radioButton4.Checked) { dateTimePicker1.Enabled = true; dateTimePicker2.Enabled = true; comboBox1.Enabled = false; _GetZadacha.TipZapuska = radioButton4.TabIndex; }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            _GetZadacha.DateTime = dateTimePicker2.Value;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _GetZadacha.DayOfWeek = comboBox1.SelectedIndex;


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _GetZadacha.TaskName = comboBox2.SelectedItem.ToString();
        }


        public Zadacha GetZadacha
        {
            get { return _GetZadacha; }
            set { if (_GetZadacha != value)
                {
                    _GetZadacha = value;
                    dateTimePicker1.Value = value.DateTime;
                    dateTimePicker2.Value = value.DateTime;
                    comboBox1.DataSource = DateTimeFormatInfo.CurrentInfo.DayNames;
                    comboBox1.SelectedIndex = value.DayOfWeek;
                    foreach (Control c in this.groupBox1.Controls)
                        if (c.TabIndex == value.TipZapuska)
                            ((RadioButton)c).Checked = true;

                    comboBox2.SelectedIndex = comboBox2.FindString(value.TaskName);  
                }
            }
        }

        public List<Action> ListTasks
        {
            get { return _ListTasks; }
            set
            {
                if (_ListTasks != value)
                {
                    foreach (Action c in value)
                        comboBox2.Items.Add(c.Method.Name);
                    comboBox2.SelectedIndex = 0;
                    ///comboBox2.???????????
                }
            }
        }

        
    }
}
