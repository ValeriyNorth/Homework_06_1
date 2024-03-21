using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_06
{
    class Program
    {
        static ConsoleKeyInfo rkey;
        static void Main(string[] args)
        {
            string inffile = "HomeWork6.inf";
            string path_data = "d:\\data.scv";
            string temp_path;
            //ConsoleKeyInfo rkey;
            string[] atag = new string[7] { "ID: ", "Дата и время добавления записи: ", "Ф. И. О. ", "Возраст: ", "Рост: ", "Дата рождения: ", "Место рождения: " }; // Массив заголовков
            string[] aval = new string[7]; // Массив значений


            if (!File.Exists(inffile))
            {
                //File.Create(inffile);
                File.WriteAllText(inffile, path_data); // Записываем путь к базе по умолчанию
            }
            //else {}

            Console.WriteLine("Введите путь к файлу данных \n Enter оставить без изменения - " + File.ReadAllText(inffile));
            
            temp_path = Console.ReadLine();
            if (temp_path.Length != 0) path_data = temp_path;
            Console.WriteLine($"Путь к базе данных - {path_data}");
            File.WriteAllText(inffile, path_data); // Записываем путь к базе по умолчанию
            /// Если файл не существует, то сразу переходим в режим записи, не спрашивая о печати содержимого
            if (!File.Exists(path_data))
            {
                WriteMyDate(path_data, atag, aval, false);
            }
            else
            {
                //rkey = Console.ReadKey();
                do
                {
                    Console.Clear();
                    Console.WriteLine("Выберите необходимое действие. \n");
                    Console.WriteLine("1. Просмотр списка. \n");
                    Console.WriteLine("2. Ввод нового элемента. \n");
                    Console.WriteLine("ESC. Выход. \n  \n");

                    rkey = Console.ReadKey();
                    switch (rkey.KeyChar)
                    {
                        case '1':
                            {
                                Console.WriteLine(" Режим просмотра списка сотрудников");
                                ReadMyDate(path_data, atag);
                                break;
                            }
                        case '2':
                            {
                                Console.WriteLine(" Режим ввода сотрудников");
                                WriteMyDate(path_data, atag, aval, true);
                                break;
                            }
                    }
                }
                while (rkey.Key != ConsoleKey.Escape);

            }


            //string text = File.ReadLines(@"e:\data.txt"); // Открывает текстовый файл, считывает все строки файла и затем закрывает файл.
            //string infile = "d:\\data.scv";
            //Console.WriteLine("Введите название файла ");
            //infile = Console.ReadLine();

         }

        static void WriteMyDate(string path_data, string[] atag, string[] aval, bool flag)
        {
            //Console.WriteLine(path_data);
            string InFile = "";
            int count = 0;
            if (flag)
            {
                count = File.ReadAllLines(path_data).Length;
            }
            
            DateTime dateTime = DateTime.Now;
            aval[0] = Convert.ToString(count+1); aval[1] = Convert.ToString(dateTime);
            for (int i = 2; i < atag.Length; i++)
            {
                Console.WriteLine("Введите " + atag[i]);
                aval[i] = Console.ReadLine();
            }
            Console.Clear() ;
            Console.WriteLine("Вы ввели данные: ");
            
            for (int i = 0; i < atag.Length; i++)
            {
                Console.WriteLine(atag[i] + aval[i]);
                //string v = (i != atag.Length) ? (InFile += atag[i] + aval[i] + '#') : (InFile += atag[i] + aval[i]);
                string v = (i != atag.Length) ? (InFile += aval[i] + '#') : (InFile += aval[i]);
            }
            Console.WriteLine("\nСохранить? - y(Да) / n(Нет)");
            rkey = Console.ReadKey();

            do
            {
                if (rkey.KeyChar == 'y' || rkey.KeyChar == 'д')
                {
                    //File.AppendAllText(path_data, InFile);
                    using (StreamWriter sw = new StreamWriter(path_data,true))
                        sw.WriteLine(InFile);
                    //using (FileStream fstream = new FileStream(path_data, FileMode.Append))
                    //{
                    //    using (StreamWriter sr = new StreamWriter(fstream))
                    //        sr.WriteLine(InFile);
                        
                    //}
                    break;

                }
                else if (rkey.KeyChar == 'n' || rkey.KeyChar == 'н')
                {
                    break;
                }
            }
            while ((rkey.KeyChar != 'y') && (rkey.KeyChar != 'n') && (rkey.KeyChar != 'д') && (rkey.KeyChar != 'н'));
            Console.ReadLine();
        }

        static void ReadMyDate(string path_data, string[] atag)
        { Console.WriteLine(path_data);
            using (StreamReader sr = new StreamReader(path_data))
            {
                //string text = sr.ReadToEnd();
                Console.WriteLine($" {"ID: ".PadLeft(10)} {"Дата и время добавления записи: ".PadLeft(25)} {"Ф. И. О. ".PadLeft(45)} {"Возраст: ".PadLeft(5)} {"Рост: ".PadLeft(5)} {"Дата рождения: ".PadLeft(10)} {"Место рождения: ".PadLeft(25)}  ");          
                
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split('#');
                    Console.WriteLine($" {words[0].PadLeft(10)} {words[1].PadLeft(25)} {words[2].PadLeft(45)} {words[3].PadLeft(5)} {words[4].PadLeft(5)} {words[5].PadLeft(10)} {words[6].PadLeft(25)}  ");

                    //    for (int i = 0; i < words.Length; i++)
                    //    {
                    //        Console.Write(line[i]);
                    //    }
                    //}
                   
                }
                Console.ReadLine();
            }
        }  

    }




}