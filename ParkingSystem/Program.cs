using System;

namespace ParkingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var car1 = new Car("B 2023 WOO", "white");
            Console.WriteLine(car1.ToString());
            string[] arr = {"1",  "2"};
            arr[2] = "3";
            Console.WriteLine(arr.Length);
        }
    }
}
