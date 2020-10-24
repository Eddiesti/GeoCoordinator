using GeoСoordination.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GeoСoordination
{
    class Program
    {
        //Ростовская область; Московская область город Раменское; Москва ЮВАО
        //C:\
        static void Main(string[] args)
        {
            Console.Write("Введите тип поиска: ");
            string type = Console.ReadLine();
            if (!Enum.TryParse(type, true, out СoordinationType coordinationType))
            {
                Console.Write("Такого типа поиска нету");
                return;
            }
            GeoCoordinator coordinator = null;
            if (coordinationType == СoordinationType.OSM)
                coordinator = new GeoCoordinator(new OSMCoordinator(), coordinationType);


            Console.Write("Введите адресса через ; :");
            string places = Console.ReadLine();

            Console.Write("Введите частоту точек: ");
            if (!Int32.TryParse(Console.ReadLine(), out int count))
            {
                Console.Write("Ввели не целое число");
                return;
            }

            var results = coordinator.GetPoints(places, count).ToList();

            Console.Write("Укажите папку: ");
            string path = Console.ReadLine();

            FileAttributes attr = File.GetAttributes(path);

            if ((attr & FileAttributes.Directory) != FileAttributes.Directory)
            {
                Console.Write("Вы указали не папку");
                return;
            }

            SaveResult(results, path);

        }

        private static void SaveResult(List<Result> results, string path)
        {
            foreach (var r in results)
            {
                path = path + "\\" + r.Place + ".txt";
                using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    string text = null;
                    foreach (var e in r.points)
                    {
                        text += e.ToString() + "\n";
                    }
                    byte[] array = System.Text.Encoding.Default.GetBytes(text);
                    fstream.Write(array, 0, array.Length);
                    Console.WriteLine("Текст записан в файл");
                }
                path = null;
            }
        }
    }
}
