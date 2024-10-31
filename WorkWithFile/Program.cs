using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static string _Path { get; set; }



        static void Main(string[] args)
        {
            // TEXT
            string FileTxt = "123.txt";
            string TempDirection = Path.GetTempPath();
            _Path = TempDirection + FileTxt;
            bool _FinishMark = true;

            if (!File.Exists(_Path))
            {
               var file = File.Create(_Path);
                file.Close();
            }
            
            var FirstCommand = Console.Write("0 - Считать\n1 - Выход\n");
            int comand = 0;
            while (_FinishMark)
            {
                try
                {
                    comand = Int32.Parse(Console.ReadLine());

                }
                catch
                {
                    throw new Exception("Неверное значение");
                }
                switch (comand)
                {
                    case 0:
                        List<Person> read = ReadAllText();
                        if (read.Count > 0)
                        {
                            foreach (Person p in read)
                            {
                                Console.WriteLine(p);
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Студентов нет");
                            break;
                        }
                    case 1:
                        bool FinishMark = false;
                        Console.WriteLine("Конец выполнения!");
                        break;



                }
            }
            
            

        }
        static List<Person> ReadAllText()
        {
            
            using (StreamReader reader = new StreamReader(_Path))
            {
                string json = reader.ReadToEnd();
                List<Person>? NamePerson = JsonConvert.DeserializeObject<List<Person>>(json);
                return NamePerson ?? new List<Person> { };
            }
                
        }
        static bool WhileMarker()
        {
            bool marker = false;
            return marker;
        }
    }
    class Person
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public Person(string name, string surName, string lastName) 
        {
            Name = name;
            SurName = surName;
            LastName = lastName;
        }
    }
}
