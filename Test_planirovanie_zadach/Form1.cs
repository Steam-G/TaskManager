using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Timers;

namespace Task_Manager
{
    public partial class Form1 : Form
    {
        private static System.Timers.Timer aTimer;
        private static List<Zadacha> listZadach = new List<Zadacha>();
        private static List<Action> myAction = new List<Action> { test_task_1, test_task_2, test_task_3, test_task_4 };



        public Form1()
        {
            InitializeComponent();

            SetTimer(OnTimedEvent);

            TimerCallback tcb = systemclock;
            System.Threading.Timer tm_cl = new System.Threading.Timer(tcb, null, 0, 1000);

            Zadacha zadacha = new Zadacha();

            dataGridView1.DataSource = listZadach;
            taskManagerControl1.ListTasks = myAction;
            
        }

        private static void SetTimer(ElapsedEventHandler elapsedEventHandler)
        {
            
            for (int i = 0; i < 4; i++)
            {
                DateTime tt_now = DateTime.Now;
                tt_now = tt_now.AddMinutes(i+1);
                listZadach.Add(new Zadacha() {
                    NameZadacha = (string)("Событие по списку №" + i),
                    TaskName = (string)("test_task_" + (4-i)),
                    DateTime = tt_now,
                    TipZapuska = 2
                });


            }
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += elapsedEventHandler;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;

           
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        { 
            DateTime tt = DateTime.Now;
            
            for (int i = 0; i < listZadach.Count; i++)
            {
                switch (listZadach[i].TipZapuska)
                {
                    case 1:
                        if (
                        tt.Date.Year == listZadach[i].DateTime.Year &&
                        tt.Date.Month == listZadach[i].DateTime.Month &&
                        tt.TimeOfDay.Hours == listZadach[i].DateTime.TimeOfDay.Hours &&
                        tt.TimeOfDay.Minutes == listZadach[i].DateTime.TimeOfDay.Minutes &&
                        tt.TimeOfDay.Seconds == 0
                            )
                        { //ShowMessages(e, listZadach[i].NameZadacha); 
                            listZadach[i].Status = true;
                            //myAction[i]();
                            foreach (Action c in myAction)
                                if (c.Method.Name == listZadach[i].TaskName)
                                    c();
                            
                        }
                        break;

                    case 2:
                        if (
                        tt.TimeOfDay.Hours == listZadach[i].DateTime.TimeOfDay.Hours &&
                        tt.TimeOfDay.Minutes == listZadach[i].DateTime.TimeOfDay.Minutes &&
                        tt.TimeOfDay.Seconds == 0
                            )
                        { //ShowMessages(e, listZadach[i].NameZadacha); 
                            listZadach[i].Status = true;
                            foreach (Action c in myAction)
                                if (c.Method.Name == listZadach[i].TaskName)
                                    c();
                        }
                        break;

                    case 3:
                        if (
                        (int)tt.Date.DayOfWeek == listZadach[i].DayOfWeek &&
                        tt.TimeOfDay.Hours == listZadach[i].DateTime.TimeOfDay.Hours &&
                        tt.TimeOfDay.Minutes == listZadach[i].DateTime.TimeOfDay.Minutes &&
                        tt.TimeOfDay.Seconds == 0
                            )
                        { //ShowMessages(e, listZadach[i].NameZadacha); 
                            listZadach[i].Status = true;
                            foreach (Action c in myAction)
                                if (c.Method.Name == listZadach[i].TaskName)
                                    c();
                        }
                        break;

                    case 4:
                        if (
                        tt.Date.Day == listZadach[i].DateTime.Day &&
                        tt.TimeOfDay.Hours == listZadach[i].DateTime.TimeOfDay.Hours &&
                        tt.TimeOfDay.Minutes == listZadach[i].DateTime.TimeOfDay.Minutes &&
                        tt.TimeOfDay.Seconds == 0
                            )
                        { //ShowMessages(e, listZadach[i].NameZadacha); 
                            listZadach[i].Status = true;
                            foreach (Action c in myAction)
                                if (c.Method.Name == listZadach[i].TaskName)
                                    c();
                        }
                        break;
                }

                //if (
                //        tt.Date.DayOfWeek == listZadach[i].DateTime.Date.DayOfWeek &&
                //        tt.TimeOfDay.Hours == listZadach[i].DateTime.TimeOfDay.Hours &&
                //        tt.TimeOfDay.Minutes == listZadach[i].DateTime.TimeOfDay.Minutes &&
                //        tt.TimeOfDay.Seconds == 0//listZadach[i].DateTime.TimeOfDay.Seconds 
                //        //tt.Date.DayOfWeek == DayOfWeek.Monday && 
                //        //tt.TimeOfDay.Hours == 13 && 
                //        //tt.TimeOfDay.Minutes == 36 && 
                //        //tt.TimeOfDay.Seconds == 0
                //        )
                //{
                //    ShowMessages(e, listZadach[i].NameZadacha);
                //}
            }
        }

        //Создать функцию процесса!!!
        private static void ShowMessages (ElapsedEventArgs e, string nameZadacha)
        {
            string result = string.Format("{0:HH:mm:ss.fff}", e.SignalTime); // форматирование строки
            MessageBox.Show("The Elapsed event was raised at " + result, nameZadacha);
        }

        private static void test_task_1 ()
        {
            MessageBox.Show("Это первый процесс", "Первый процесс", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private static void test_task_2()
        {
            MessageBox.Show("Это второй процесс", "Второй процесс", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        private static void test_task_3()
        {
            MessageBox.Show("Это третий процесс", "Третий процесс", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void test_task_4()
        {
            MessageBox.Show("Это четвертый процесс", "Четвертый процесс", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }




        private void button3_Click(object sender, EventArgs e)
        {
            listZadach.Add(new Zadacha() {
                NameZadacha = (string)("Событие из компонента"),
                DateTime = taskManagerControl1.GetZadacha.DateTime,
                DayOfWeek = taskManagerControl1.GetZadacha.DayOfWeek,
                TipZapuska = taskManagerControl1.GetZadacha.TipZapuska,
                TaskName = taskManagerControl1.GetZadacha.TaskName
            });
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listZadach;
        }

        

        private void systemclock(Object s)
        {
            DateTime tt = DateTime.Now;
            //if (tt.Date.DayOfWeek == DayOfWeek.Sunday && tt.TimeOfDay.Hours == 11 && tt.TimeOfDay.Minutes == 58 && tt.TimeOfDay.Seconds == 0)
            //    MessageBox.Show("Время 11:58");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listZadach;
        }

        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    Zadacha ccclick = new Zadacha();
        //    int index = dataGridView1.CurrentCell.RowIndex;
        //    List<Zadacha> list = (List<Zadacha>)dataGridView1.DataSource;
        //    ccclick = list[index];
        //    taskManagerControl1.GetZadacha = ((List<Zadacha>)dataGridView1.DataSource)[index];
        //}

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            taskManagerControl1.GetZadacha = ((List<Zadacha>)dataGridView1.DataSource)[dataGridView1.CurrentCell.RowIndex];
        }
    }
}
