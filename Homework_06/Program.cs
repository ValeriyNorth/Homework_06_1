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
        static void Main(string[] args)
        {
            string inffile = "HomeWork6.inf";
            string path_data = "d:\\data.scv";
            string temp_path;

            if (!File.Exists(inffile))
            {
                //File.Create(inffile);
                File.WriteAllText(inffile, path_data); // Записываем путь к базе по умолчанию
            }
            //else {}
             
                Console.WriteLine("Введите путь к файлу данных \n Enter оставить без изменения - " + File.ReadAllText(inffile));
                temp_path = Console.ReadLine();
                if (temp_path.Length != 0) path_data = temp_path;
                File.WriteAllText(inffile, path_data); // Записываем путь к базе по умолчанию
                if(!File.Exists(path_data)) 
                    { 
                        WriteMyDate(path_data);
                    }
                else 
                    {    }


            //string text = File.ReadLines(@"e:\data.txt"); // Открывает текстовый файл, считывает все строки файла и затем закрывает файл.
            //string infile = "d:\\data.scv";
            //Console.WriteLine("Введите название файла ");
            //infile = Console.ReadLine();

        }

        static void WriteMyDate(string path_data)
            { Console.WriteLine(path_data)}

        static void ReadMyDate(string path_data)
            { Console.WriteLine(path_data)}  

    }




}