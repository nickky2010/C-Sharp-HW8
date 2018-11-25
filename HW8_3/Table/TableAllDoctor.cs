using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8_3.Extend
{
    class TableAllDoctor : Table
    {
        public TableAllDoctor(string headTable = "", params Column[] column) : base(headTable, column)
        {
        }
        public void Print(Doctor[] doctor, Patient[] patients)
        {
            PrintHead(false);
            for (int i = 0, j = 0; i < patients.Length; i++)
            {
                for (int k = 0; k < doctor.Length; k++)
                {
                    if (patients[i].CabinetNumber == doctor[k].CabinetNumber)
                    {
                        PrintString((++j).ToString(), patients[i].Surname, doctor[k].CabinetNumber.ToString(), patients[i].DateReception,
                           patients[i].TimeReception, doctor[k].Surname, patients[i].Diagnoz.ToString());
                    }
                }
            }
            PrintBottom();
        }
    }
}
