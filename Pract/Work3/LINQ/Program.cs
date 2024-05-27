using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonInput = File.ReadAllText("input.json");
            JObject input = JObject.Parse(jsonInput);
            foreach(var item in input){
                System.Console.WriteLine(item.ToString());
            }
        }
    }
}