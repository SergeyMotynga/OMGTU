using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14._05._24
{
    internal class Program
    {
        class Database
        {
            public int numberOfWorker;
            public string FIO;
            public string education;
            public string specialization;
            public double salary;
            public int countOfProductProduced;
            public double pricePerUnit;
            public Database(int numberOfWorker, string FIO, string education, string specialization, double salary, int countOfProductProduced, double pricePerUnit)
            {
                this.numberOfWorker = numberOfWorker;
                this.FIO = FIO;
                this.education = education;
                this.specialization = specialization;
                this.salary = salary;
                this.countOfProductProduced = countOfProductProduced;
                this.pricePerUnit = pricePerUnit;
            }
        }
        static void Main(string[] args)
        {
            Database[] database = new Database[25];
            database[0] = new Database(1, "Иванов Иван Иванович", "высшее", "инженер", 60000, 120, 1500);
            database[1] = new Database(2, "Петров Петр Петрович", "среднее специальное", "техник", 45000, 110, 1300);
            database[2] = new Database(3, "Сидорова Мария Ивановна", "высшее", "экономист", 65000, 140, 2000);
            database[3] = new Database(4, "Алексеева Ольга Петровна", "высшее", "бухгалтер", 50000, 90, 1700);
            database[4] = new Database(5, "Кузнецов Сергей Юрьевич", "высшее", "менеджер", 55000, 100, 1800);
            database[5] = new Database(6, "Морозова Екатерина Васильевна", "высшее", "юрист", 70000, 150, 2100);
            database[6] = new Database(7, "Николаев Дмитрий Игоревич", "среднее", "оператор станка", 40000, 95, 1100);
            database[7] = new Database(8, "Семенова Анна Михайловна", "высшее", "архитектор", 62000, 105, 10);
            database[8] = new Database(9, "Лебедев Константин Николаевич", "высшее", "программист", 80000, 130, 2200);
            database[9] = new Database(10, "Горбунова Людмила Сергеевна", "среднее специальное", "секретарь", 35000, 80, 1000);
            database[10] = new Database(11, "Ефимов Игорь Владимирович", "высшее", "маркетолог", 48000, 125, 1600);
            database[11] = new Database(12, "Дмитриева Елена Александровна", "высшее", "продавец-консультант", 42000, 115, 1400);
            database[12] = new Database(13, "Белов Антон Сергеевич", "высшее", "аналитик", 53000, 108, 1650);
            database[13] = new Database(14, "Федорова Светлана Геннадьевна", "высшее", "HR-менеджер", 47000, 99, 1500);
            database[14] = new Database(15, "Тарасов Алексей Юрьевич", "высшее", "дизайнер", 51000, 86, 1750);
            database[15] = new Database(16, "Осипова Наталья Ивановна", "высшее", "редактор", 44000, 123, 1550);
            database[16] = new Database(17, "Киселев Владимир Алексеевич", "высшее", "врач", 750000, 137, 2300);
            database[17] = new Database(18, "Макарова Дарья Сергеевна", "высшее", "психолог", 46000, 102, 1450);
            database[18] = new Database(19, "Андреев Олег Петрович", "высшее", "инженер-конструктор", 64000, 112, 2000);
            database[19] = new Database(20, "Захарова Евгения Александровна", "высшее", "логист", 49000, 107, 1600);
            database[20] = new Database(21, "Соловьев Максим Дмитриевич", "высшее", "электрик", 41000, 89, 1200);
            database[21] = new Database(22, "Козлова Марина Владимировна", "высшее", "администратор", 43000, 96, 1350);
            database[22] = new Database(23, "Савельева Вера Константиновна", "высшее", "медсестра", 39000, 77, 1150);
            database[23] = new Database(24, "Лазарев Андрей Викторович", "высшее", "водитель", 38000, 83, 12);
            database[24] = new Database(25, "Медведева Ирина Анатольевна", "высшее", "главный бухгалтер", 660000, 96, 2100);
            var worker = from w in database where w.salary < (w.countOfProductProduced * w.pricePerUnit) select w;
            int n = worker.Count();
            Console.WriteLine("Работники, чья зарплата меньше суммы вырабатываемой ими продукции: ");
            for(int i  = 0; i < n; i++)
            {
                Console.WriteLine($"{i+1}){Convert.ToString(worker.ToList()[i].numberOfWorker)}, {Convert.ToString(worker.ToList()[i].FIO)}, {Convert.ToString(worker.ToList()[i].education)}, {Convert.ToString(worker.ToList()[i].specialization)}");
            }
            Console.WriteLine();
            var sumUnit = (from s in database select s.countOfProductProduced).Sum();
            Console.WriteLine($"Количество единиц всей продукции: {sumUnit}");
            Console.WriteLine();
            var sum = (from s in database select (s.countOfProductProduced * s.pricePerUnit)).Sum();
            Console.WriteLine($"Суммарная стоимость всех товаров: {sum}");
            Console.WriteLine();
            var countOfSalary = from s in database where s.salary >= (s.countOfProductProduced * s.pricePerUnit) select s;
            n = countOfSalary.Count();
            Console.WriteLine("Работники, чья зарплата не меньше 50% суммы вырабатываемой ими продукции: ");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{i + 1}){Convert.ToString(countOfSalary.ToList()[i].numberOfWorker)}, {Convert.ToString(countOfSalary.ToList()[i].FIO)}, {Convert.ToString(countOfSalary.ToList()[i].education)}, {Convert.ToString(countOfSalary.ToList()[i].specialization)}");
            }
        }
    }
}
