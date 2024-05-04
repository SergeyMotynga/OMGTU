using System;
using System.Collections.Generic;
using System.IO;

class PotionSpell
{
    static void Main(string[] args)
    {
        int i = 1;
        while (i != 11)
        {
            string inputFile = $"tests/Input{i}.txt";
            List<string> actions = new List<string>();
            foreach (var line in File.ReadLines(inputFile))
            {
                actions.Add(line);
            }
            Dictionary<int, string> results = new Dictionary<int, string>();
            string spell = "";

            for (int j = 0; j < actions.Count; j++)
            {
                string action = actions[j];
                string[] parts = action.Split(' ');
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