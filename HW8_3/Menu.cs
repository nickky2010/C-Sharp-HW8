using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW8_3.Extend;

namespace HW8_3
{
    class Menu
    {
        //Вертикальное меню
        private string[] menu;
        private Patient[] patients;
        private Doctor[] doctors;
        private Table[] table;
        private Reception reception;
        private bool isRun = true;
        private int current;
        private int last;

        public Menu(string[] menu, Reception reception, Doctor[] doctors, Patient[] patients, Table[] table)
        {
            this.menu = new string[menu.Length + 1];
            for (int i = 0; i < menu.Length; i++)
            {
                this.menu[i] = menu[i];
            }
            this.menu[menu.Length] = "Выход";
            this.doctors = doctors;
            this.patients = patients;
            this.reception = reception;
            this.table = table;
            isRun = true;
            current = 0;
            last = 0;
        }
        public void Show()
        {
            while (isRun)
            {
                //вывод меню
                BaseColor();
                Console.Clear();
                Console.CursorVisible = false;
                for (int i = 0; i < menu.Length; i++)
                {
                    ShowMenuItem(i, menu[i]);
                }
                // выбор пункта меню
                bool isNoEnter = true;
                while (isNoEnter)
                {
                    BaseColor();
                    ShowMenuItem(last, menu[last]);
                    LightColor();
                    ShowMenuItem(current, menu[current]);
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Enter)
                        isNoEnter = false;
                    else
                        if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        last = current;
                        current = (current == menu.Length - 1) ? 0 : current + 1;
                    }
                    else
                        if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        last = current;
                        current = (current == 0) ? menu.Length - 1 : current - 1;
                    }
                }// конец тела цикла while (isNoEnter)

                // действие в соответствии с выбором пользователя
                switch (current)
                {
                    case 0:
                        {
                            BaseColor();
                            Console.Clear();
                            Console.SetCursorPosition(0, 0);
                            for (int i = 0; i < doctors.Length; i++)
                            {
                                ((TableDoctor)table[0]).Print(doctors[i], patients);
                            }
                            Console.WriteLine("Для продолжения нажмите любую клавишу");
                            Console.ReadKey();
                            break;
                        }
                    case 1:
                        {
                            BaseColor();
                            Console.Clear();
                            Console.SetCursorPosition(0, 0);
                            Console.Write("Введите фамилию доктора: ");
                            string surname = Console.ReadLine();
                            int newCabinet = 0;
                            if (!CheckAndInput.InputData(ref newCabinet, "Введите номер нового кабинета: ", 1))
                                throw new Exception("Ошибка! Неправильный ввод номера нового кабинета доктора" + surname+"!");
                            reception.ChangeLocationDoctor(surname, newCabinet);
                            bool isNameTrue = false;
                            foreach (Doctor d in doctors)
                            {
                                if (d.Surname == surname)
                                {
                                    isNameTrue = true;
                                    break;
                                }
                            }
                            if (!isNameTrue)
                            {
                                Console.WriteLine("Доктора по фамилии "+surname+" не найдено!\nДля продолжения нажмите любую клавишу");
                                Console.ReadKey();
                            }
                            break;
                        }
                    case 2:
                        {
                            BaseColor();
                            Console.Clear();
                            Console.SetCursorPosition(0, 0);
                            ((TableAllDoctor)table[1]).Print(doctors, patients);
                            Console.WriteLine("Для продолжения нажмите любую клавишу");
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            isRun = false;
                            break;
                        }
                }
            }// конец цикла while (isRun)
        }
        private static void BaseColor()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static void LightColor()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        private static void ShowMenuItem(int itemIndex, string item)
        {
            Console.SetCursorPosition(25, 8 + itemIndex);
            Console.WriteLine(item);
        }
    }
}
