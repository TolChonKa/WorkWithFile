using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithFile
{
    internal class MoveWithStudent
    {
        
        static string FileTxt = "123.txt";
        static string TempDirection = Path.GetTempPath();
        static string _Path { get; set; } = TempDirection + FileTxt;

        public static List<Person> ReadAllStudents()
        {

            using (StreamReader reader = new StreamReader(_Path))
            {
                string json = reader.ReadToEnd();
                List<Person>? NamePerson = JsonConvert.DeserializeObject<List<Person>>(json);
                return NamePerson ?? new List<Person> { };
            }

        }
        public static void AppendToList(Person student)
        {

            var ListStudent = ReadAllStudents();
            int LastId = 0;
            if (ListStudent.Count > 0) { LastId = ListStudent.Last().ID; }
            ListStudent.Add(student);

            if (ListStudent.Count > 0) { student.ID = LastId += 1; }

            string json = JsonConvert.SerializeObject(ListStudent);

            File.WriteAllText(_Path, json);

        }
        
        public static void DeleteStudentOfList(int id)
        {

            var ListStudent = ReadAllStudents();
            ListStudent.RemoveAll(ListStudent => ListStudent.ID == id);

            string json = JsonConvert.SerializeObject(ListStudent);
            File.WriteAllText(_Path, json);

        }

        public static void OverrideStudentOfList(int id, Person NewStudent)
        {

            List<Person> ListStudent = ReadAllStudents();
            ListStudent.RemoveAll(ListStudent => ListStudent.ID == id);
            NewStudent.ID = id;
            ListStudent.Add(NewStudent);


            string json = JsonConvert.SerializeObject(ListStudent);
            File.WriteAllText(_Path, json);

        }
    }
}
