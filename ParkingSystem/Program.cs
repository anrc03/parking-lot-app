using System;

namespace ParkingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var car1 = new Car("B 2023 WOO", "white");
            var car2 = new Car("D 5631 WII", "white");

            Console.WriteLine("$create_parking_lot");
            var parkingLot = new ParkingLot(5);

            Console.WriteLine("$park car");
            parkingLot.Park(car1);
            parkingLot.Park(car2);

            Console.WriteLine("$status");
            parkingLot.ParkingStatus();

            //Console.WriteLine("$leave");
            //parkingLot.Leave(car1);
            //parkingLot.ParkingStatus();

            Console.WriteLine("$check_vehicle_count car");
            parkingLot.CarCount();

            Console.WriteLine("$check_vehicle_count motorcycle");
            parkingLot.MotorcycleCount();

            Console.WriteLine("slot_number_for_vehicle_with_color white");
            parkingLot.CheckColour("white");

        }
    }
}
