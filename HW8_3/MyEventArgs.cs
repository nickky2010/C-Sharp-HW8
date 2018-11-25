using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8_3
{
    class MyEventArgs : EventArgs
    {
        public int CabinetNumber { get; set; }
        public int NewCabinetNumber { get; set; }
        public string SurnameDoctor { get; set; }
    }
}
