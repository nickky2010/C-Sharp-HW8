using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8_3
{
    //источник события
    class Reception
    {
        public event EventHandler ChangeLocation;
        public void ChangeLocationDoctor(string surnameDoctor, int cabinetNumber)
        {
            ChangeLocation?.Invoke(this, new MyEventArgs { SurnameDoctor = surnameDoctor, CabinetNumber = cabinetNumber });
        }
    }
}
