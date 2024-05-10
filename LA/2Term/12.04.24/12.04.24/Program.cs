using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _12._04._24
{
    internal class Program
    {
        static void Main()
        {
            string databaseFile = "database.txt";
            string citySelectionFile = "city_selection.txt";
            string surnameSelectionFile = "surname_selection.txt";
            string fullNameAndCitySelectionFile = "full_name_and_city_selection.txt";
            string selectedCity = "Москва"; 
            string selectedSurname = "Иванов"; 
            string selectedFullName = "Петров Петр Петрович"; 
            List<string> databaseLines = File.ReadAllLines(databaseFile).ToList();
            var citySelection = databaseLines.Where(line => line.Contains(selectedCity));
            File.WriteAllLines(citySelectionFile, citySelection);
            var surnameSelection = databaseLines.Where(line => line.Split(',')[0].Trim().StartsWith(selectedSurname));
            File.WriteAllLines(surnameSelectionFile, surnameSelection);
            var fullNameAndCitySelection = databaseLines.Where(line =>
                line.Split(',')[0].Trim().Equals(selectedFullName, StringComparison.OrdinalIgnoreCase) &&
                line.Split(',')[2].Trim().Equals(selectedCity, StringComparison.OrdinalIgnoreCase));
            File.WriteAllLines(fullNameAndCitySelectionFile, fullNameAndCitySelection);
        }
    }
}
