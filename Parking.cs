using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Indexator {
    class Parking : IEnumerable{
        private List<Car> _cars = new List<Car>();
        private const int MAX_CARS = 100;
        public int Count => _cars.Count;
        public string Name{ get; set; }
        
        public Car this[string number] {
            get {
                return _cars.FirstOrDefault(c => c.Number == number);
            }
        }

        public Car this[int pos] {
            get {
                if (pos < Count) {
                    return _cars[pos];
                }
                return null;
            }
            set {
                if (pos < Count) {
                    _cars[pos] = value;
                }
            }
        }

        public int Add(Car car) {
            if (car == null) {
                throw new ArgumentException(nameof(car), "Car is null");
            }
            if (Count < MAX_CARS) {
                _cars.Add(car);
                return _cars.Count - 1;
            }

            return -1;
            
        }
        public void GoOut (string number) {
            if (string.IsNullOrWhiteSpace(number)) {
                throw new ArgumentNullException(nameof(number), "Number is null or empty");
            }

            var car = _cars.FirstOrDefault(c => c.Number == number);
            if (car != null) {
                _cars.Remove(car);
            }
        }

        public IEnumerator GetEnumerator() {
            foreach(var car in _cars) {
                yield return car;
            }
        }
        public IEnumerable GetNames() {
            foreach (var car in _cars) {
                yield return car.Name;
            }
        }

        //public IEnumerator<Car> GetEnumerator() {
        //    return _cars.GetEnumerator();
        //}

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable)_cars).GetEnumerator();
        }
    }

}
