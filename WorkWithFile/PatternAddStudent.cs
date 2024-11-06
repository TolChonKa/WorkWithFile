using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithFile
{
    internal class PatternAddStudent
    {
        
        public static Person Writter()
        {
            
            Console.WriteLine("Введите Фамилию: ");
            string? SurName = Console.ReadLine();
            if (SurName == "") { SurName = "нет"; }

            Console.WriteLine("Введите Имя: ");
            string? Name = Console.ReadLine();
            if (Name == "") { Name = "нет"; }

            Console.WriteLine("Введите Отчество: ");
            string? LastName = Console.ReadLine();
            if (LastName == "") { LastName = "нет"; }

            Console.WriteLine("Введите Факультет: ");
            string? Faculty = Console.ReadLine();
            if (Faculty == "") { Faculty = "нет"; }

            Console.WriteLine("Введите Специальность: ");
            string? Speciality = Console.ReadLine();
            if (Speciality == "") { Speciality = "нет"; }

            Console.WriteLine("Введите Курс: ");
            string? Course = Console.ReadLine();
            if (Course == "") { Course = "нет"; }

            Console.WriteLine("Введите Группу: ");
            string? Group = Console.ReadLine();
            if (Group == "") { Group = "нет"; }

            Console.WriteLine("Введите Город: ");
            string? City = Console.ReadLine();
            if (City == "") { City = "нет"; }

            
            Console.WriteLine("Введите Постиндекс: ");
            Int32.TryParse(Console.ReadLine(), out int Value);
            

            Console.WriteLine("Введите Улицу: ");
            string? Street = Console.ReadLine();
            if (Street == "") { Street = "нет"; }

            Console.WriteLine("Введите Телефон: ");
            string? Phone = Console.ReadLine();
            if (Phone == "") { Phone = "нет"; }

            Console.WriteLine("Введите Email: ");
            string? Email = Console.ReadLine();
            if (Email == "") { Email = "нет"; }

            Console.WriteLine();

            Person student = new(Name, SurName, LastName, Faculty, Speciality, Course, Group, City, Value, Street, Phone, Email);
            return student;
        }
    }
}
