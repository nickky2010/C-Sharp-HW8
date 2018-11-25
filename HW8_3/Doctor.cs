using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8_3
{
    //  Описать класс Врач, содержащий следующие поля: фамилия, время приема, номер кабинета.
    class Doctor
    {
        // фамилия
        public string Surname { get; set; }
        // время приема
        string timeReception;
        public string TimeReception
        {
            get => timeReception;
            set
            {
                try
                {
                    DateTime t;
                    t = DateTime.Parse(value);
                    timeReception = t.Hour.ToString() + ":" + t.Minute;
                }
                catch
                {
                    throw new Exception("Ошибка! Неверно задано время приема доктора " + Surname);
                }
            }
        }
        // номер кабинета
        int cabinetNumber;
        public int CabinetNumber
        {
            get => cabinetNumber;
            set
            {
                if (value > 0)
                    cabinetNumber = value;
                else
                    throw new Exception("Ошибка! Неверно задан номер кабинета доктора " + Surname+". Номер кабинета должен быть больше 0");
            }
        }
        public Doctor(string surname, string timeReception, int cabinetNumber)
        {
            Surname = surname;
            TimeReception = timeReception;
            CabinetNumber = cabinetNumber;
        }
        //метод, который будет запускаться при изменении номера кабинета у доктора
        public event EventHandler ChangeLocation;
        public void ChangeLocationDoctor(int cabinetNumber, int newCabinetNumber)
        {
            ChangeLocation?.Invoke(this, new MyEventArgs { CabinetNumber = cabinetNumber, NewCabinetNumber = newCabinetNumber });
        }
        public void ChangeCabinetReception(object o, EventArgs args)
        {
            if(((MyEventArgs)args).SurnameDoctor == Surname)
            {
                ChangeLocationDoctor(cabinetNumber, ((MyEventArgs)args).CabinetNumber);      // изменяем номер кабинета у пациентов
                CabinetNumber = ((MyEventArgs)args).CabinetNumber;
            }
        }
    }
}
