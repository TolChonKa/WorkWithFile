using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WorkWithFile
{
    
    class FilteringStudent
    {
        

        public static List<Person> FilterFaculty(string? PatternFilter)
        {
            List<Person> ListStudent = MoveWithStudent.ReadAllStudents();
            var NewSortedListFac = ListStudent.Where(x => x.Faculty == PatternFilter);
            return NewSortedListFac.ToList() ?? new List<Person>();
        }

        public static List<Person> FilterCourse(string? PatternFilter)
        {
            List<Person> ListStudent = MoveWithStudent.ReadAllStudents();
            var NewSortedListCour = ListStudent.Where(x => x.Course == PatternFilter);
            return NewSortedListCour.ToList() ?? new List<Person>();    
        }

        public static List<Person> FilterGroup(string? PatternFilter)
        {
            List<Person> ListStudent = MoveWithStudent.ReadAllStudents();
            var NewSortedListGro = ListStudent.Where(x => x.Group == PatternFilter);
            return NewSortedListGro.ToList() ?? new List<Person>(); 
        }

        public static List<Person> FilterSpeciality(string? PatternFilter)
        {
            List<Person> ListStudent = MoveWithStudent.ReadAllStudents();
            var NewSortedListSpe = ListStudent.Where(x => x.Speciality == PatternFilter);
            return NewSortedListSpe.ToList() ?? new List<Person>();
        }

    }
    
   
    
}
