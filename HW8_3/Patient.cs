using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8_3
{
    //	Описать класс Пациент, содержащий поля для хранения фамилии, диагноза, даты и времени приема, номера кабинета.
    class Patient
    {
        // фамилия
        public string Surname { get; set; }
        // диагноз
        public Diagnoz Diagnoz { get; set; }
        // дата приема
        string dateReception;
        public string DateReception
        {
            get => dateReception;
            set
            {
                try
                {
                    DateTime t;
                    t = DateTime.Parse(value);
                    dateReception = t.Day.ToString() + "." + t.Month + "." + t.Year;
                }
                catch
                {
                    throw new Exception("Ошибка! Неверно задана дата приема пациента " + Surname);
                }
            }
        }
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
                    throw new Exception("Ошибка! Неверно задано время приема пациента " + Surname);
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
                    throw new Exception("Ошибка! Неверно задан номер кабинета у пациента " + Surname +
                        "Номер кабинета должен быть больше 0");
            }
        }
        public Patient(string surname, Diagnoz diagnoz, string dateReception, string timeReception, int cabinetNumber)
        {
            Surname = surname;
            Diagnoz = diagnoz;
            DateReception = dateReception;
            TimeReception = timeReception;
            CabinetNumber = cabinetNumber;
        }
        //метод, который будет запускаться при изменении номера кабинета доктора
        public void ChangeCabinet(object o, EventArgs args)
        {
            if (((MyEventArgs)args).CabinetNumber == CabinetNumber)
            {
                CabinetNumber = ((MyEventArgs)args).NewCabinetNumber;
            }
        }
    }
}
