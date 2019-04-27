using System;
using System.Collections.Generic;

namespace Indexator {
    class Program {
        static void Main() {
            var cars = new List<Car>() {
                new Car() {Name = "Ford", Number = "A001AA01" },
                new Car() {Name = "Lada", Number = "B727ET77" },
                new Car() {Name = "Kia", Number = "T325BA178" }
            };

            var parking = new Parking();
            foreach (var car in cars) {
                parking.Add(car);
            }

            Console.WriteLine(parking["A001AA01"].Name);
            Console.WriteLine(parking["A001AA02"]?.Name);

            Console.ReadKey();
        }
    }
}
