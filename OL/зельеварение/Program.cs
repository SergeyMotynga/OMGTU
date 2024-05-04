using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Зельеварение
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            while (i != 11)
            {
                string spell = "";
                string input = ($"input" + i + ".txt");
                List<string> actions = new List<string>();
                foreach (var line in File.ReadLines(input))
                {
                    actions.Add(line);
                }
                Dictionary<int, string> results = new Dictionary<int, string>();
                for (int j = 0; j < actions.Count; j++)
                {
                    string action = actions[j];
                    string[] parts = actions[j].Split(' ');
                    string command = parts[0];
                    string result = "";
                    for (int k = 1; k < parts.Length; k++)
                    {
                        if (int.TryParse(parts[k], out int actionNumber))
                        {
                            result += results[actionNumber];
                        }
                        else
                        {
                            result += parts[k];
                        }
                    }
                    switch (command)
                    {
                        case "MIX":
                            result = "MX" + result + "XM";
                            break;
                        case "WATER":
                            result = "WT" + result + "TW";
                            break;
                        case "DUST":
                            result = "DT" + result + "TD";
                            break;
                        case "FIRE":
                            result = "FR" + result + "RF";
                            break;
                    }
                    results.Add(j + 1, result);
                    spell = result;
                }
                Console.WriteLine($"Output{i}: {spell}");
                Console.WriteLine();
                i++;
            }
        }
    }
}
