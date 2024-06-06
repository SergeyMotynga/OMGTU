using System.Reflection;
using System.IO;
using System.Linq;

namespace Work4
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly asm = Assembly.LoadFrom("core.dll");
            Console.WriteLine($"Текущая исполняемая сборка: {asm.FullName}");
            foreach (Type type in asm.GetTypes())
            {
                if (type.IsClass)
                {
                    Console.WriteLine($"Класс: {type.FullName}");
                }
                else Console.WriteLine($"Интерфейс: {type.FullName}");
                foreach (MethodInfo method in type.GetMethods())
                {
                    Console.WriteLine($"\tМетод: {method.Name}");
                    Console.WriteLine($"\tВозвращаемый тип: {method.ReturnType.Name}");
                    foreach (ParameterInfo param in method.GetParameters())
                    {
                        Console.WriteLine($"\t\t\tИмя параметра: {param.Name}");
                        Console.WriteLine($"\t\t\t\tТип параметра: {param.ParameterType.Name}");
                    }
                }
            }
        }
    }
}