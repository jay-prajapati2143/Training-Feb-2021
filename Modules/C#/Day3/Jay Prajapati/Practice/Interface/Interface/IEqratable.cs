﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    interface IEqratable<T>
    {
        bool Equals(T obj);
    }


    public class Car : IEquatable<Car>
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }

        // Implementation of IEquatable<T> interface
        public bool Equals(Car car)
        {
            return (this.Make, this.Model, this.Year) ==
                (car.Make, car.Model, car.Year);
        }
    }
}