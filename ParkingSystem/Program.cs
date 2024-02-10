using System;

namespace ParkingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var car1 = new Car("B 2023 WOO", "white");

            Console.WriteLine("$create_parking_lot");
            var parkingLot = new ParkingLot(5);

            Console.WriteLine("$park car");
            parkingLot.Park(car1);

            Console.WriteLine("$status");
            parkingLot.ParkingStatus();

            Console.WriteLine("$leave");
            parkingLot.Leave(car1);
            parkingLot.ParkingStatus();
            
        }
    }
}
