using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._4.practice
{
    internal class Program
    {
        class Student
        {
            public string SName { get; set; }
            public string Initials { get; set; }
            public int GroupNumber { get; set; }
            public int[] AcademicPerformance = new int[5];
            public Student(string SName, string Initials, int GroupNumber, int[] AcademicPerformance)
            {
                this.SName = SName;
                this.Initials = Initials;
                this.GroupNumber = GroupNumber;
                this.AcademicPerformance = AcademicPerformance;
            }
            /// <summary>
            /// Добавить возможность вывода фамилий и номеров групп студентов, имеющих оценки, равные только 4 или 5.
            /// </summary>
            /// <param name="students"></param>
            public void PrintBestStudents(Student[] students)
            {

                for (int i = 0; i < students.Length; i++)
                {
                    double sum = 0;
                    for (int j = 0; j < 5; j++)
                    {
                        sum += students[i].AcademicPerformance[j];
                    }
                    if (sum / 5 >= 4)
                    {
                        Console.Write("Surname: ");
                        Console.WriteLine(students[i].SName);
                        Console.Write("Group Number: ");
                        Console.WriteLine(students[i].GroupNumber);
                        Console.WriteLine($"student's GPA: {sum / 5}");
                        Console.WriteLine("");
                    }
                }
            }
            /// <summary>
            /// упорядочить записи по возрастанию среднего балла.
            /// </summary>
            /// <param name="students"></param>
            /// <returns></returns>
            public Student[] SortEntries(Student[] students)
            {
                int num = students.Length;
                for (int i = 0; i < students.Length; i++)
                {
                    int max = 0;
                    int counter = 0;
                    for (int j = 0; j < num; j++)
                    {
                        int sum = 0;
                        int[] average = new int[students[i].AcademicPerformance.Length];
                        average = students[i].AcademicPerformance;
                        for (int k = 0; k < average.Length; k++)
                        {
                            sum += average[k];
                        }
                        if (sum > max)
                        {
                            counter = j;
                            max = sum;
                        }
                    }
                    Student temp = students[num - 1];
                    students[num - 1] = students[counter];
                    students[counter] = temp;
                    num--;
                }
                return students;
            }



        }
        static void Main(string[] args)
        {
            Student[] students = new Student[2];

            for (int i = 0; i < students.Length; i++)
            {
                Console.Write("SName: ");
                string SName = Convert.ToString(Console.ReadLine());
                Console.Write("Initials: ");
                string Initials = Convert.ToString(Console.ReadLine());
                Console.Write("GroupNumber: ");
                int GroupNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("AcademicPerformance");
                int[] AcademicPerformance = new int[5];
                for (int j = 0; j < 5; j++)
                {
                    Console.Write($"{j + 1}: ");
                    AcademicPerformance[j] = Convert.ToInt32(Console.ReadLine());
                }
                Student student = new Student(SName, Initials, GroupNumber, AcademicPerformance);
                students[i] = student;
            }


            students = students[0].SortEntries(students);
            students[0].PrintBestStudents(students);


        }
    }
}
