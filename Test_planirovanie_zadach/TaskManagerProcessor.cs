using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Task_Manager;

namespace Test_planirovanie_zadach
{
    class TaskManagerProcessor
    {
        private static System.Timers.Timer aTimer;
        private static List<Zadacha> listZadach = new List<Zadacha>();

        private static void SetTimer(ElapsedEventHandler elapsedEventHandler)
        {

            for (int i = 0; i < 5; i++)
            {
                DateTime tt_now = DateTime.Now;
                tt_now = tt_now.AddMinutes(i);
                listZadach.Add(new Zadacha()
                {
                    NameZadacha = (string)("Событие по списку №" + i),
                    DateTime = tt_now,
                    TipZapuska = 2
                });


            }

            // Таймер
            // Создаем таймер с интервалом в 1 секунду.
            aTimer = new System.Timers.Timer(1000);
            // Подключаем событие Elapsed к таймеру. 
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
                        { //ShowMessages(e, listZadach[i].NameZadacha); listZadach[i].Status = true; 
                        }
                        break;

                    case 2:
                        if (
                        tt.TimeOfDay.Hours == listZadach[i].DateTime.TimeOfDay.Hours &&
                        tt.TimeOfDay.Minutes == listZadach[i].DateTime.TimeOfDay.Minutes &&
                        tt.TimeOfDay.Seconds == 0
                            )
                        { //ShowMessages(e, listZadach[i].NameZadacha); listZadach[i].Status = true; 
                        }
                        break;

                    case 3:
                        if (
                        (int)tt.Date.DayOfWeek == listZadach[i].DayOfWeek &&
                        tt.TimeOfDay.Hours == listZadach[i].DateTime.TimeOfDay.Hours &&
                        tt.TimeOfDay.Minutes == listZadach[i].DateTime.TimeOfDay.Minutes &&
                        tt.TimeOfDay.Seconds == 0
                            )
                        { //ShowMessages(e, listZadach[i].NameZadacha); listZadach[i].Status = true; 
                        }
                        break;

                    case 4:
                        if (
                        tt.Date.Day == listZadach[i].DateTime.Day &&
                        tt.TimeOfDay.Hours == listZadach[i].DateTime.TimeOfDay.Hours &&
                        tt.TimeOfDay.Minutes == listZadach[i].DateTime.TimeOfDay.Minutes &&
                        tt.TimeOfDay.Seconds == 0
                            )
                        { //ShowMessages(e, listZadach[i].NameZadacha); listZadach[i].Status = true; 
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

        private void systemclock(Object s)
        {
            DateTime tt = DateTime.Now;
            //if (tt.Date.DayOfWeek == DayOfWeek.Sunday && tt.TimeOfDay.Hours == 11 && tt.TimeOfDay.Minutes == 58 && tt.TimeOfDay.Seconds == 0)
            //    MessageBox.Show("Время 11:58");
        }
    }
}
