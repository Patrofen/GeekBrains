using System;
//using System.Collections.Generic;
using System.IO;
//using System.IO.Compression;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.Text;
using System.Text.Json;
//using System.Xml.Serialization;

namespace DZ_Lesson_5
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    //ReadDataAndSaveFile();
        //    //AppendTime();
        //    //EmpoyeeClass();
        //}

        #region Запись текста в файл
        static void ReadDataAndSaveFile()
        {
            Console.WriteLine("Input file path to save data");

            var path = Console.ReadLine();
            if (string.IsNullOrEmpty(path) || string.IsNullOrWhiteSpace(path))
            {
                Console.WriteLine("Incorrect Path");
                return;
            }

            if (!path.EndsWith(".txt")) path += ".txt";
            using var fs = new FileStream(path, File.Exists(path) ? FileMode.Append : FileMode.OpenOrCreate);
            using var sw = new StreamWriter(fs);


            Console.WriteLine("Input data to save in text file, press Esc to stop");
            sw.AutoFlush = true;
            while (true)
            {
                var inputKey = Console.ReadKey();

                if (inputKey.Key == ConsoleKey.Escape)
                    break;
                if (inputKey.Key == ConsoleKey.Enter)
                {
                    sw.Write("\n");
                    Console.WriteLine();
                }
                else sw.Write(inputKey.KeyChar);
            }


            // Program Stop
            Console.WriteLine("\nWork Done, cya");
        }
        #endregion

        #region Дописывание текущего времени в файл
        static void AppendTime()
        {
            using var sw = File.AppendText("startup.txt");
            var time = DateTime.Now.ToString("HH:mm:ss tt");
            sw.WriteLine(time);
            Console.WriteLine($"I add to startup.txt new time, it's {time}, go check");
        }
        #endregion

        #region Запись чисел в бинарный файл
        static void BinFile()
        {
            const string file = "test.bin";

            Console.WriteLine("Input a case of number's in range [0..255] separating with whitespace");
            var input = Console.ReadLine()?.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (input is null)
            {
                Console.WriteLine("incorrect input");
                return;
            }

            var array = new byte[input.Length];
            for (var i = 0; i < array.Length; i++)
            {
                if (!byte.TryParse(input[i], out var number))
                {
                    Console.WriteLine($"Incorrect number {input[i]}");
                    return;
                }

                array[i] = number;
            }

            using (var bw = new BinaryWriter(File.OpenWrite(file)))
            {
                bw.Write(array);
                bw.Flush();
            }

            Console.WriteLine($"see what now in file {file}");

            Console.WriteLine("i read it for you");
            byte[] newData;
            using (var br = new BinaryReader(File.OpenRead(file)))
            {
                newData = br.ReadBytes(array.Length);
            }

            for (var i = 0; i < newData.Length; i++)
            {
                Console.Write(newData[i] + " ");
            }
        }
        #endregion

        #region Сотрудник
        static void EmpoyeeClass()
        {
            // 1.	Создать класс "Сотрудник" с полями: ФИО, должность, телефон,
            // зарплата, возраст;
            //Employee e = new Employee("Rahid", "Semov",
            //        "Petrovich", "8(495)000-11-22", "art@mail.ru",
            //        "developer", 80000, 1985);

            // 5.	Создать массив из 5 сотрудников. С помощью цикла вывести
            // информацию только о сотрудниках старше 40 лет;

            Employee[] employees = {
                new Employee("Rahid", "Semov",
                    "Petrovich", "8(495)000-11-22", "art@mail.ru",
                    "developer", 80000, 1985),
                new Employee("Andrey", "Viktorovich",
                        "Bezrukov", "8(495)111-22-33", "art@mail.ru",
                        "fitter", 52000, 1973),
                new Employee("Evgeniy", "Viktorovich",
                        "Del'finov", "8(495)222-33-44", "art@mail.ru",
                        "project manager", 40000, 1963),
                new Employee("Natalia", "Pavlovna",
                        "Keks", "8(495)333-44-55", "art@mail.ru",
                        "senior developer", 90000, 1990),
                new Employee("Tatiana", "Sergeevna",
                        "Krasotkina", "8(495)444-55-66", "art@mail.ru",
                        "accountant", 50000, 1983)
            };

            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i].getAge() > 40)
                    Console.WriteLine(employees[i].GetFullInfo());
            }

            Console.WriteLine("--------------------------------------------------------");

            for (int i = 0; i < employees.Length; i++)
            {
                Console.WriteLine(employees[i].GetFullInfo());
            }

            Console.WriteLine("--------------------------------------------------------");
        }
        #endregion
    }
}
