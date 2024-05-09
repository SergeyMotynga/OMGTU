using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _06._065._24
{
    internal class Program
    {
        class Database
        {
            public int accountNumber;
            public string FIO;
            public string phoneNumber;
            public double income;
            public double expenditure;
            public double tax;
            public double balance;
            public Database(int accountNumber, string fIO, string phoneNumber, double income, double expenditure)
            {
                this.accountNumber = accountNumber;
                this.FIO = FIO;
                this.phoneNumber = phoneNumber;
                this.income = income;
                this.expenditure = expenditure;
                this.tax = income * 5 / 100;
                this.balance = income - expenditure;
            }
        }
        static void Main(string[] args)
        {
            Database[] accounts = new Database[10];
            accounts[0] = new Database(1, "Иванов Иван Иванович", "+79991234567", 150000, 50000);
            accounts[1] = new Database(2, " Петров Петр Петрович", "+79997654321", 200000, 75000);
            accounts[2] = new Database(2, "Сидоров Сергей Сергеевич", " +79999876543", 50000, 30000);
            accounts[3] = new Database(3, "Иванова Мария Ивановна", "+79998765432", 120000, 40000);
            accounts[4] = new Database(4, "Петрова Анна Петровна", "+79996543210", 30000, 150000);
            accounts[5] = new Database(5, "Смирнова Ольга Петровна", "+79991231234", 8000, 20000);
            accounts[6] = new Database(6, "Кузнецова Светлана Ивановна", " +79997654321", 60000, 10000);
            accounts[7] = new Database(7, "Попова Ксения Сергеевна", "+79999876543", 7000, 30000);
            accounts[8] = new Database(8, "Васильева Екатерина Петровна", "+79998765432", 210000, 50000);
            accounts[9] = new Database(9, "Михайлова Дарья Ивановна", " +79996543210", 250000, 50000);
            var negativeBalanceCount = (from item in accounts where item.balance < 0 select item).Count();
            var maxBalance = accounts.Max(x => x.balance);
            var maxBalanceCount = (from x in accounts where x.balance == maxBalance select x);
            int n = maxBalanceCount.Count();
            Console.Write("Счета клиентов, которые имет наибольший баланс: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{Convert.ToString(maxBalanceCount.ToList()[i].accountNumber)} ");
            }
            Console.WriteLine();
            var averageIncome = accounts.Sum(x => x.income) / accounts.Length;
            Console.WriteLine($"Средний доход по счетам: {averageIncome}");
            var sumOfTax = accounts.Sum(x => x.tax);
            Console.WriteLine($"Общая сумма налогов: {Convert.ToString(sumOfTax)}");
        }
    }
}
