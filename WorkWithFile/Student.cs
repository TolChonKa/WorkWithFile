using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithFile
{
    internal class Person
    {
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? LastName { get; set; }

        public int ID { get; set; }

        public string? Faculty { get; }
        public string? Speciality { get; }
        public string? Course { get; }
        public string? Group { get; }

        public string? City { get; }
        public int PostIndex { get; }
        public string? Street { get; }

        public string? Phone { get; }
        public string? Email { get; }


        public Person(string? name, string? surName, string? lastName, string? faculty, string? speciality, string? course, string? group, string? city, int postIndex, string? street, string? phone, string? email)
        {
            Name = name;
            SurName = surName;
            LastName = lastName;

            Faculty = faculty;
            Speciality = speciality;
            Course = course;
            Group = group;

            City = city;
            PostIndex = postIndex;
            Street = street;

            Phone = phone;
            Email = email;
        }

        public override string ToString()
        {
            return $"{ID} ФИО: {SurName} {Name} {LastName}; Учебный курс: {Faculty}, {Speciality}, {Course}, {Group}; Место проживания: {City}, {PostIndex}, {Street}; Контакты: {Phone}, {Email}";
        }
    }
}
