using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Channels;
using System.Xml.Linq;
using WorkWithFile;


namespace WorkWithFile
{
    class Program
    {
        static string? _Path { get; set; }


        static void Main(string[] args)
        {
            
            List<Person> _Check = MoveWithStudent.ReadAllStudents();

            bool _FinishMark = true;

            if (!File.Exists(_Path) && _Path != null)
            {
               FileStream file = File.Create(_Path);
                file.Close();
            }
            
            
            int comand;
            while (_FinishMark)
            {
                Console.Write("0 - Показать всех\n1 - Добавить\n2 - Удалить\n3 - Изменить\n4 - Фильтрация\n5 - Завершить\n\n");

                try
                {
                    
                    comand = TryConvert(Console.ReadLine()); 
                    Console.WriteLine();
                }
                catch
                {
                    Console.WriteLine("Неверное значение команды! Попробуйте снова :)\n");
                    continue;
                }

                switch (comand)
                {
                    case 0:
                         _Check = MoveWithStudent.ReadAllStudents();
                        if (_Check.Count > 0)
                        {
                            foreach (Person p in _Check)
                            {
                                Console.WriteLine(p);
                                
                            }
                            Console.WriteLine();
                            break;
                        }

                        Console.WriteLine("Студентов нет\n");
                        break;
                        

                    case 1:

                        Person student = PatternAddStudent.Writter();

                        MoveWithStudent.AppendToList(student);

                        break;

                    case 2:

                        string? IdStudentForDelete;
                        if (_Check.Count > 0)
                        {
                            Console.WriteLine("Введите 'ID' студента: ");
                            IdStudentForDelete = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Студентов нет\n");
                            break ;
                        }
                        int ConvertId = TryConvert(IdStudentForDelete);

                        if (IdStudentForDelete != null && _Check.Any(p => p.ID == ConvertId))
                        {
                            MoveWithStudent.DeleteStudentOfList(ConvertId);
                            Console.WriteLine("Успешно!\n");
                            break;
                        }

                        Console.WriteLine("Такого 'id' нет.\n");
                        break;


                    case 3:
                        
                        string? IdStudentForOverride;
                        if (_Check.Count > 0)
                        {
                            Console.WriteLine("Введите 'ID' студента, которого хотите перезаписать: ");
                            IdStudentForOverride = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Студентов нет\n");
                            break;
                        }
                        int ThisId = TryConvert(IdStudentForOverride);

                        if (IdStudentForOverride != null && _Check.Any(p => p.ID == ThisId))
                        {
                            Person NewStudent = PatternAddStudent.Writter();
                            MoveWithStudent.OverrideStudentOfList(ThisId, NewStudent);
                            break;
                        }

                        break;
                    case 4:
                        Console.WriteLine("Введите критерий, (факультет, специальность, курс или группа): ");
                        string? Standart = Console.ReadLine();
                        Console.WriteLine();
                        
                        switch (Standart)
                        {
                            case "факультет":
                                Console.WriteLine("Введите фильтр: ");
                                var FilterFac = Console.ReadLine();
                                List<Person> SortedListFac = FilteringStudent.FilterFaculty(FilterFac);
                                Console.WriteLine();
                                if (SortedListFac.Count > 0)
                                {
                                    foreach (Person p in SortedListFac)
                                    {
                                        Console.WriteLine($"{p}\n");
                                    }
                                    break;
                                }
                                Console.WriteLine("Список пуст...\n"); break; 

                            case "специальность":
                                Console.WriteLine("Введите фильтр: ");
                                var FilterSpec = Console.ReadLine();
                                List<Person> SortedListSpec = FilteringStudent.FilterSpeciality(FilterSpec);
                                Console.WriteLine();
                                if (SortedListSpec.Count > 0)
                                {
                                    foreach (Person p in SortedListSpec)
                                    {
                                        Console.WriteLine($"{p}\n");
                                    }
                                    break;
                                }
                                Console.WriteLine("Список пуст...\n"); break;

                            case "курс":
                                Console.WriteLine("Введите фильтр: ");
                                var FilterCour = Console.ReadLine();
                                List<Person> SortedListCour = FilteringStudent.FilterSpeciality(FilterCour);
                                Console.WriteLine();
                                if (SortedListCour.Count > 0)
                                {
                                    foreach (Person p in SortedListCour)
                                    {
                                        Console.WriteLine($"{p}\n");
                                    }
                                    break;
                                }
                                Console.WriteLine("Список пуст...\n"); break;

                            case "группа":
                                Console.WriteLine("Введите фильтр: ");
                                var FilterGro = Console.ReadLine();
                                List<Person> SortedListGro = FilteringStudent.FilterSpeciality(FilterGro);
                                Console.WriteLine();
                                if (SortedListGro.Count > 0)
                                {
                                    foreach (Person p in SortedListGro)
                                    {
                                        Console.WriteLine($"{p}\n");
                                    }
                                    break;
                                }
                                Console.WriteLine("Список пуст...\n"); break;

                            default:
                                Console.WriteLine("Нет такого критерия\n");
                                break;

                        }

                        break;

                    case 5:

                        _FinishMark = WhileMarker();
                        Console.WriteLine("Конец выполнения!\n");
                        break;

                    default:
                        Console.WriteLine("Нет такой команды!\n");
                        break;
                }
            }
            
            

        }
        
        static bool WhileMarker()
        {
            bool marker = false;
            return marker;
        }

        public static int TryConvert (string? str)
        {
            
            if(str != null && Int32.TryParse(str, out int ConvertNumber )) { return ConvertNumber; }
            Console.WriteLine();
            
            throw new Exception();
        }

        
    }

}
