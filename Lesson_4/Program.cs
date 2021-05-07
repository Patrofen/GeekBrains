using System;

namespace DZ_Lesson_4
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    //FullName();
        //    //StringToNumbers();
        //    //TimeOfYearStart();
        //}


        #region Задание №1 GetFullName
        static void FullName()
        {
            string[] persons = {GetFullName("Иванов", "Иван", "Иванович"),
                                GetFullName("Петров", "Пётр", "Петрович"),
                                GetFullName("Сидоров", "Михаил", "Михайлович")};

            for (int i = 0; i < persons.Length; i++)
            {
                Console.WriteLine(persons[i]);
            }
        }
        static string GetFullName(string firstName, string lastName, string patronymic)
        {
            return firstName + " " + lastName + " " + patronymic;
        }
        #endregion

        #region Задание №2 Сумма чисел в строке
        static void StringToNumbers()
        {
            Console.Write("Введите числа через пробел: ");
            string data = Console.ReadLine();
            Console.WriteLine(Sum(data));
        }

        static int Sum(string line)
        {
            int sum = 0;

            string[] array = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in array)
            {
                sum += Convert.ToInt32(item);
            }

            //string number = "";

            //for (int i = 0; i <= line.Length; i++)
            //{
            //    if (i == line.Length || line[i] == ' ')
            //    {
            //        if (number != "")
            //        {
            //            sum += Convert.ToInt32(number);
            //            number = "";
            //        }
            //    }
            //    else
            //    {
            //        number += line[i];
            //    }
            //}
            return sum;
        }
        #endregion

        #region Задание №3 Времена года
        static void TimeOfYearStart()
        {
            Console.Write("Введите порядковый номер текущего месяца: ");

            string inputMonthNumber;
            do
            {
                inputMonthNumber = Console.ReadLine();
                if (!IsValidMonthNum(inputMonthNumber))
                {
                    Console.WriteLine("Ошибка! Введите число от 1 до 12: ");
                }
            } while (!IsValidMonthNum(inputMonthNumber));
            
            TimeOfYear2(Convert.ToInt32(inputMonthNumber));
        }

        static bool IsValidMonthNum(string text)
        {
            bool isValidMonths = int.TryParse(text, out int MonthNumber);
            return isValidMonths && MonthNumber >= 1 && MonthNumber <= 12;
        }

        static void TimeOfYear2(int MonthNum)
        {
            switch (MonthNum)
            {
                case 12:
                case 1:
                case 2:
                    Console.WriteLine($"{TimesOfYearEng.Winter}");
                    TimeOfYear3(TimesOfYearEng.Winter);
                    break;
                case 3:
                case 4:
                case 5:
                    Console.WriteLine($"{TimesOfYearEng.Spring}");
                    TimeOfYear3(TimesOfYearEng.Spring);
                    break;
                case 6:
                case 7:
                case 8:
                    Console.WriteLine($"{TimesOfYearEng.Summer}");
                    TimeOfYear3(TimesOfYearEng.Summer);
                    break;
                case 9:
                case 10:
                case 11:
                    Console.WriteLine($"{TimesOfYearEng.Autumn}");
                    TimeOfYear3(TimesOfYearEng.Autumn);
                    break;
            }
        }

        static void TimeOfYear3(TimesOfYearEng Arg)
        {
            switch (Arg)
            {
                case TimesOfYearEng.Winter:
                    Console.WriteLine(TimesOfYearRus.Зима);
                    break;
                case TimesOfYearEng.Spring:
                    Console.WriteLine(TimesOfYearRus.Весна);
                    break;
                case TimesOfYearEng.Summer:
                    Console.WriteLine(TimesOfYearRus.Лето);
                    break;
                case TimesOfYearEng.Autumn:
                    Console.WriteLine(TimesOfYearRus.Осень);
                    break;
            }
         }
        #endregion

        #region Задание №5 Преобразование строки
        string str1 = " Предложение один  Теперь предложение    два Предложение три ";
        #endregion


        [Flags]
        public enum TimesOfYearEng
        {
            Winter = 1,
            Spring = 2,
            Summer = 3,
            Autumn = 4
        }

        public enum TimesOfYearRus
        {
            Зима = 1,
            Весна = 2,
            Лето = 3,
            Осень = 4
        }
    }
}