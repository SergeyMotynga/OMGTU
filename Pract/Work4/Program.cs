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
            var types = asm.GetTypes();
            var typesClass = types.Where(t => t.IsClass && t.IsPublic).ToArray();
            var typesInterface = types.Where(t => t.IsInterface && t.IsPublic).ToArray();
            foreach (var type in typesClass)
            {
                Console.WriteLine($"Интерфейс: {type.FullName}");
                foreach (MethodInfo method in type.GetMethods())
                {
                    Console.WriteLine($"\tМетод: {method.Name} Возвращаемый тип: {method.ReturnType.Name}");
                    foreach (ParameterInfo param in method.GetParameters())
                    {
                        Console.WriteLine($"\t\tИмя параметра: {param.Name} Тип параметра: {param.ParameterType.Name}");
                    }
                }
            }
            foreach (var type in typesInterface)
            {
                Console.WriteLine($"Интерфейс: {type.FullName}");
                foreach (MethodInfo method in type.GetMethods())
                {
                    Console.WriteLine($"\tМетод: {method.Name} Возвращаемый тип: {method.ReturnType.Name}");
                    foreach (ParameterInfo param in method.GetParameters())
                    {
                        Console.WriteLine($"\t\tИмя параметра: {param.Name} Тип параметра: {param.ParameterType.Name}");
                    }
                }
            }
        }
    }
}
