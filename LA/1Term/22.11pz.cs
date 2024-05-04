using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace students
{
    class Student
    {
        string fio, group, year;
        public Student(string fio, string group, string year)
        {
            this.fio = fio;
            this.group = group;
            this.year = year;
        }
        public static void FindByYear(Student st, string Year)
        {
            if (st.year == Year)
            {
                Console.WriteLine($"{st.fio} {st.group} {st.year}");
            }
        }
        public static void FindByGroup(Student st, string Group)
        {
            if (st.group == Group)
            {
                Console.WriteLine(st.fio + " " + st.group + " " + st.year);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Student[] students = new Student[5];
            students[0] = new Student("Иванов Иван Иванович", "ФИТ-231", "2002");
            students[1] = new Student("Петров Петр Петрович", "ФИТ-231", "2004");
            students[2] = new Student("Александров Александр Александрович", "ФИТ-231", "2010");
            students[3] = new Student("Сергеев Сергей Сергеевич", "ФИТ-231", "2008");
            students[4] = new Student("Васильев Василий Васильевич", "ФИТ-231", "2015");
            Console.Write("Введите фильтр поиска 1 - Год рождения, 2 - Группа: ");
            int fltr = Convert.ToInt32(Console.ReadLine());
            switch (fltr)
            {
                case 1:
                    Console.Write("Введите год рождения студента: ");
                    string Year = Console.ReadLine();
                    foreach (Student i in students)
                    {
                        Student.FindByYear(i, Year);
                    }
                    break;

                case 2:
                    Console.Write("Введите группу студента: ");
                    string Group = Console.ReadLine();

                    foreach (Student i in students)
                    {
                        Student.FindByGroup(i, Group);
                    }
                    break;
            }
        }
    }
}
