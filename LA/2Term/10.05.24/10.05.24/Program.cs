using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._05._24
{
    internal class Program
    {
        class Database
        {
            public int numberOfProduct;
            public string productName;
            public string productCategory;
            public int productCountOnWarehouse;
            public double productPrice;
            public string warehouse;
            public Database(int numberOfProduct, string productName, string productCategory, int productCountOnWarehouse, double productPrice, string warehouse)
            {
                this.numberOfProduct = numberOfProduct;
                this.productName = productName;
                this.productCategory = productCategory;
                this.productCountOnWarehouse = productCountOnWarehouse;
                this.productPrice = productPrice;
                this.warehouse = warehouse;
            }
        }
        static void Main(string[] args)
        {
            Database[] products = new Database[10];
            products[0] = new Database(1, "Телевизор Samsung", "", 50, 30000, "Склад №1");
            products[1] = new Database(2, "Смартфон Apple iPhone", "Электроника", 100, 60000, "Склад №2");
            products[2] = new Database(3, "Холодильник LG", "Бытовая техника", 30, 45000, "Склад №1");
            products[3] = new Database(4, "Стиральная машина Bosch", "Бытовая техника", 20, 25000, "Склад №3");
            products[4] = new Database(5, "Ноутбук Lenovo", "Электроника", 75, 40000, "Склад №2");
            products[5] = new Database(6, "Кофемашина DeLonghi", "Бытовая техника", 15, 20000, "Склад №3");
            products[6] = new Database(7, "Пылесос Dyson", "Бытовая техника", 25, 15000, "Склад №1");
            products[7] = new Database(8, "Умные часы Xiaomi", "Электроника", 40, 10000, "Склад №2");
            products[8] = new Database(9, "Блендер Philips", "", 60, 5000, "Склад №3");
            products[9] = new Database(10, "Электросамокат Ninebot", "Транспорт", 20, 35000, "Склад №1");
            var countOfProducts = products.Sum(product => product.productCountOnWarehouse);
            Console.WriteLine($"Объём товаров: {countOfProducts}");
            Dictionary<string, List<double>> PricesOfProductsByCategory = new Dictionary<string, List<double>>();
            for (int i = 0; i < products.Length; i++)
            {
                if (!PricesOfProductsByCategory.ContainsKey(products[i].productCategory))
                {
                    PricesOfProductsByCategory[products[i].productCategory] = new List<double>();
                    PricesOfProductsByCategory[products[i].productCategory].Add(products[i].productPrice);
                }
                else
                {
                    PricesOfProductsByCategory[products[i].productCategory].Add(products[i].productPrice);
                }
            }
            Dictionary<string, List<double>> PricesOfProductsByWarehouse = new Dictionary<string, List<double>>();
            for (int i = 0; i < products.Length; i++)
            {
                if (!PricesOfProductsByWarehouse.ContainsKey(products[i].warehouse))
                {
                    PricesOfProductsByWarehouse[products[i].warehouse] = new List<double>();
                    PricesOfProductsByWarehouse[products[i].warehouse].Add(products[i].productPrice);
                }
                else
                {
                    PricesOfProductsByWarehouse[products[i].warehouse].Add(products[i].productPrice);
                }
            }
            foreach (var key in PricesOfProductsByCategory.Keys)
            {
                if (!key.Equals(""))
                {
                    var maxPrice = PricesOfProductsByCategory[key].Max();
                    Console.Write($"Наибольшая цена в категории {key}: {maxPrice}");
                    Console.WriteLine();
                }
            }
            foreach (var key in PricesOfProductsByCategory.Keys)
            {
                if (key.Equals(""))
                {
                    var averagePrice = PricesOfProductsByCategory[key].Sum() / PricesOfProductsByCategory[key].Count();
                    Console.WriteLine($"Средняя цена товаров, для которых не указана категория: {averagePrice}");
                }
            }
            foreach (var key in PricesOfProductsByWarehouse.Keys)
            {
                var minPrice = PricesOfProductsByWarehouse[key].Min();
                Console.Write($"Наименьшая цена товара на складе {key}: {minPrice}");
                Console.WriteLine();

            }
            double sum = 0;
            for(int i  = 0; i < products.Length; i++)
            {
                sum += products[i].productPrice * products[i].productCountOnWarehouse;
            }
            Console.WriteLine($"Общая стоимость товаров со всех складов: {sum}");
        }
    }
}