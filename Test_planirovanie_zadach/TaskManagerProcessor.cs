using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Task_Manager;

namespace Task_Manager
{
    class TaskManagerProcessor
    {
        private static System.Timers.Timer aTimer;
        //private static List<Zadacha> listZadach = new List<Zadacha>();

        private static List<Zadacha> _ListZadach;
        public List<Zadacha> ListZadach
        {
            get { return _ListZadach; }
            set { if (ListZadach != value) _ListZadach = value; }
        }

        private static List<Action> _Actions;
        public List<Action> Actions
        {
            get { return _Actions; }
            set { if (Actions != value) _Actions = value; }
        }

        /// <summary>
        /// Таймер, раз в секунду запускает событие
        /// </summary>
        /// <param name="elapsedEventHandler"></param>
        private static void SetTimer(ElapsedEventHandler elapsedEventHandler, bool start)
        {
            // Таймер
            // Создаем таймер с интервалом в 1 секунду.
            aTimer = new System.Timers.Timer(1000);
            // Подключаем событие Elapsed к таймеру. 
            aTimer.Elapsed += elapsedEventHandler;
            aTimer.AutoReset = true;
            aTimer.Enabled = start;
        }

        /// <summary>
        /// Функция активации события по времени из объекта List<Zadacha>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            DateTime tt = DateTime.Now;

            for (int i = 0; i < _ListZadach.Count; i++)
            {
                switch (_ListZadach[i].TipZapuska)
                {
                    // Тип запуска: однократно в определенное время
                    case 1:
                        if (
                        tt.Date.Year == _ListZadach[i].DateTime.Year &&
                        tt.Date.Month == _ListZadach[i].DateTime.Month &&
                        tt.TimeOfDay.Hours == _ListZadach[i].DateTime.TimeOfDay.Hours &&
                        tt.TimeOfDay.Minutes == _ListZadach[i].DateTime.TimeOfDay.Minutes &&
                        tt.TimeOfDay.Seconds == 0
                            )
                        {
                            try
                            {
                                _ListZadach[i].Status = true;
                                foreach (Action a in _Actions)
                                    if (a.Method.Name == _ListZadach[i].TaskName) a();
                            }
                            catch
                            {
                                _ListZadach[i].Status = false;
                            }
                        }
                        break;

                    // Тип запуска: каждый день в указанное время
                    case 2:
                        if (
                        tt.TimeOfDay.Hours == _ListZadach[i].DateTime.TimeOfDay.Hours &&
                        tt.TimeOfDay.Minutes == _ListZadach[i].DateTime.TimeOfDay.Minutes &&
                        tt.TimeOfDay.Seconds == 0
                            )
                        {
                            try
                            {
                                _ListZadach[i].Status = true;
                                foreach (Action a in _Actions)
                                    if (a.Method.Name == _ListZadach[i].TaskName) a();
                            }
                            catch
                            {
                                _ListZadach[i].Status = false;
                            }
                        }
                        break;

                    // Тип запуска: по дням недели в указанное время
                    case 3:
                        if (
                        (int)tt.Date.DayOfWeek == _ListZadach[i].DayOfWeek &&
                        tt.TimeOfDay.Hours == _ListZadach[i].DateTime.TimeOfDay.Hours &&
                        tt.TimeOfDay.Minutes == _ListZadach[i].DateTime.TimeOfDay.Minutes &&
                        tt.TimeOfDay.Seconds == 0
                            )
                        {
                            try
                            {
                                _ListZadach[i].Status = true;
                                foreach (Action a in _Actions)
                                    if (a.Method.Name == _ListZadach[i].TaskName) a();
                            }
                            catch
                            {
                                _ListZadach[i].Status = false;
                            }
                        }
                        break;

                    // Тип запуска: каждый месяц в определенное число в указанное время
                    case 4:
                        if (
                        tt.Date.Day == _ListZadach[i].DateTime.Day &&
                        tt.TimeOfDay.Hours == _ListZadach[i].DateTime.TimeOfDay.Hours &&
                        tt.TimeOfDay.Minutes == _ListZadach[i].DateTime.TimeOfDay.Minutes &&
                        tt.TimeOfDay.Seconds == 0
                            )
                        {
                            try
                            {
                                _ListZadach[i].Status = true;
                                foreach (Action a in _Actions)
                                    if (a.Method.Name == _ListZadach[i].TaskName) a();
                            }
                            catch
                            {
                                _ListZadach[i].Status = false;
                            }
                        }
                        break;
                }
            }
        }

        private void systemclock(Object s)
        {
            DateTime tt = DateTime.Now;
            //if (tt.Date.DayOfWeek == DayOfWeek.Sunday && tt.TimeOfDay.Hours == 11 && tt.TimeOfDay.Minutes == 58 && tt.TimeOfDay.Seconds == 0)
            //    MessageBox.Show("Время 11:58");
        }

        public void Start()
        {
            SetTimer(OnTimedEvent, true);
        }

        public void Stop()
        {
            SetTimer(OnTimedEvent, false);
        }
    }
}
