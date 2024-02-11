using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace ParkingSystem
{
    internal class ParkingLot
    {
        public int Capacity {  get; }
        public Vehicle[] Slots { get; set; }


        public ParkingLot(int capacity)
        {
            this.Capacity = capacity;
            this.Slots = new Vehicle[this.Capacity];
            Console.WriteLine($"Created a parking lot with {this.Capacity} slots\n");
        }

        public void Park(Vehicle vehicle)
        {
            Boolean allocated = false;
            for (int i = 0; i < Slots.Length; i++)
            {
                if (Slots[i] == null)
                {
                    Slots[i] = vehicle;
                    Console.WriteLine($"Allocated slot number: {i + 1}\n");
                    allocated = true;
                    break;
                }
            }
            if (!allocated) Console.WriteLine("Sorry, parking lot is full\n");

        }

        public void Leave(int slotNumber)
        {
            if (slotNumber < 1 || slotNumber > Slots.Length)
            {
                Console.WriteLine("There's no such number on the allocated slots");
            }
            else
            {
                Slots[slotNumber-1] = null;
                Console.WriteLine($"Slot number {slotNumber} is free");
            }
        }

        public void DisplayParkingStatus()
        {
            bool empty = CheckIfParkingLotEmpty();
            if (empty) Console.WriteLine("Parking lot is currently empty");
            else
            {
                Console.WriteLine("Slot\tNo.\t\tType\t\tColour");
                for (int i = 0; i < this.Slots.Length; i++)
                {
                    Console.WriteLine($"{i + 1}\t{Slots[i]}");
                }
                Console.WriteLine();
            }
        }

        public void CarCount()
        {
            int count = 0;
            foreach (Vehicle vehicle in this.Slots)
            {
                if (vehicle != null)
                {
                    if (vehicle.Type == "Car") count++;
                }
            }
            Console.WriteLine($"Car in parking lot: {count}\n");
        }

        public void MotorcycleCount()
        {
            int count = 0;
            foreach (Vehicle vehicle in this.Slots)
            {
                if (vehicle != null)
                {
                    if (vehicle.Type == "Motorcycle") count++;
                }
            }
            Console.WriteLine($"Motorcycle in parking lot: {count}\n");
        }

        public void CheckColour(string colour)
        {
            int count = 1;
            List<int> slots = new List<int>();
            foreach (Vehicle vehicle in this.Slots)
            {
                if (vehicle != null)
                {
                    if (vehicle.Colour == colour) slots.Add(count);
                }
                count++;
            }
            count = 1;
            Console.Write($"Slots of vehicle with colour {colour}: ");
            if (slots.Count == 0) Console.WriteLine("None");
            foreach (int slot in slots)
            {
                if (count == 1) Console.Write($"{slot}");
                else Console.Write($", {slot}\n");
                count++;
            }
            Console.WriteLine();
        }

        public void CheckEvenPlate()
        {
            List<string> plate = new List<string>();
            foreach (Vehicle vehicle in this.Slots)
            {
                if (vehicle != null)
                {
                    if (int.Parse(vehicle.LicenseNumber.Split("-")[1]) % 2 != 0) plate.Add(vehicle.LicenseNumber);
                }
            }
            Console.Write("List of license number with even plate: ");
            if (plate.Count == 0 ) Console.WriteLine("None");
            else
            {
                int count = 1;
                foreach (var item in plate)
                {
                    if (count == 1) Console.Write($"{item}");
                    else Console.Write($", {item}\n");
                    count++;
                }
                Console.WriteLine();
            }
        }

        public void CheckOddPlate()
        {
            List<string> plate = new List<string>();
            foreach (Vehicle vehicle in this.Slots)
            {
                if (vehicle != null)
                {
                    if (int.Parse(vehicle.LicenseNumber.Split("-")[1]) % 2 != 0) plate.Add(vehicle.LicenseNumber);
                }
            }
            Console.Write("List of license number with odd plate: ");
            if (plate.Count == 0) Console.WriteLine("None");
            else
            {
                int count = 1;
                foreach (var item in plate)
                {
                    if (count == 1) Console.Write($"{item}");
                    else Console.Write($", {item}\n");
                    count++;
                }
                Console.WriteLine();
            }
        }

        public bool CheckIfParkingLotEmpty() 
        {
            foreach (Vehicle vehicle in Slots)
            {
                if (vehicle != null) return false;
            }
            return true;
        }

        public bool CheckIfParkingLotAvailable()
        {
            foreach (Vehicle vehicle in Slots)
            {
                if (vehicle == null) return true;
            }
            return false;
        }
    }
}
