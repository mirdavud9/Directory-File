

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace Directory
{
    public class Program
    {
        private const string FilePath = @"C:\Users\Mirdavud\source\repos\Directory, FIle\Directory, FIle\Names.json";

        public static void Main(string[] args)
        {
            List<string> names = new List<string>();


            GetJson(FilePath, names);


            Console.WriteLine("Movcud adlar");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }


            Add("Azad", names);
            Add("Ayxan", names);
            Add("Qabil", names);


            Console.WriteLine("\nYenilenmis adlar");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        static void GetJson(string filePath, List<string> names)
        {
            if (File.Exists(filePath))
            {
                string newResult;
                using (StreamReader sr = new StreamReader(filePath))
                {
                    newResult = sr.ReadToEnd();
                }

            }
        }

        static void SetJson(string filePath, List<string> names)
        {
            string result = JsonConvert.SerializeObject(names, Formatting.Indented);
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine(result);
            }
        }

        static void Add(string name, List<string> names)
        {

            names.Add(name);


            SetJson(FilePath, names);
        }
        static bool Search(string filePath, List<string> names)
        {
            Predicate<string> predicate = x => x.Contains(filePath);
            return predicate(filePath);


        }
        static void Delete(int index, List<string> names)
        {
            if (index >= 0 && index < names.Count)
            {
                names.RemoveAt(index);
                SetJson(FilePath, names);
                Console.WriteLine("Ad silindi");
            }
            else
            {
                Console.WriteLine("Bele bir index yoxdur");
            }
        }
    }
}