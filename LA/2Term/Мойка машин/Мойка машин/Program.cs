using System;
using System.Collections.Generic;

namespace Мойка_машин
{
    public delegate void Clean(Cars car);
    class Garage
    {
        public List<Cars> cars = new List<Cars>();
        public void AddCar(Cars car)
        {
            cars.Add(car);
        }
        public void CleaningCarAll(Clean clean)
        {
            Cleaning cleanCar = new Cleaning();
            foreach (Cars car in cars)
                cleanCar.cleaningCars(clean, car);
        }
    }
    public class Cars
    {
        public string name;
        public string number;
        public Cars(string name, string number)
        {
            this.name = name;
            this.number = number;
        }
    }
    class Cleaning
    {
        public void cleaningCars(Clean clean, Cars car)
        {
            clean(car);
        }
    }
    class Program
    {
        static void Main()
        {
            Garage cars = new Garage();
            cars.AddCar(new Cars("Porsche", "po123ne"));
            cars.AddCar(new Cars("Ferrari", "fe456gt"));
            cars.AddCar(new Cars("Mercedes", "me123sd"));
            cars.AddCar(new Cars("Toyota", "to456fg"));
            cars.AddCar(new Cars("Honda", "ho789gh"));
            cars.AddCar(new Cars("Ford", "fo321cv"));
            cars.AddCar(new Cars("Chevrolet", "ch852xz"));
            cars.AddCar(new Cars("Nissan", "ni963rf"));
            cars.AddCar(new Cars("Volkswagen", "vo147kl"));
            cars.AddCar(new Cars("Lexus", "le258qs"));
            cars.CleaningCarAll(car => Console.WriteLine($"{car.name} {car.number}: помыта"));
        }
    }
}

