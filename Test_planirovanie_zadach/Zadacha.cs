using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager
{
    public class Zadacha
    {
        private string _NameZadacha;
        private DateTime _DateTime;
        private int _DayOfWeek = 0;
        private int _TipZapuska = 1;
        private string _TaskName;
        private string _TaskOptions;
        private bool _Status = false;

        public string NameZadacha
        {
            get { return _NameZadacha; }
            set { _NameZadacha = value; }
        }

        public DateTime DateTime
        {
            get { return _DateTime; }
            set { _DateTime = value; }
        }

        public int DayOfWeek
        {
            get { return _DayOfWeek; }
            set { _DayOfWeek = value; }
        }

        public int TipZapuska
        {
            get { return _TipZapuska; }
            set { _TipZapuska = value; }
        }

        public string TaskName
        {
            get { return _TaskName; }
            set { _TaskName = value; }
        }

        public string TaskOptions
        {
            get { return _TaskOptions; }
            set { _TaskOptions = value; }
        }

        public bool Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
    }

   
}
