using System;

namespace ParkingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var car1 = new Car("B 2023 WOO", "white");
            Console.WriteLine(car1.ToString());
            var parkingLot = new ParkingLot(5);
            parkingLot.Park(car1);
            parkingLot.ParkingStatus();
            
        }
    }
}
