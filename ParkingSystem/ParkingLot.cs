using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            for (int i = 0; i < Slots.Length; i++)
            {
                if (Slots[i] == null)
                {
                    Slots[i] = vehicle;
                    Console.WriteLine($"Allocated slot number: {i + 1}\n");
                    break;
                }
                else Console.WriteLine("Sorry, parking lot is full\n");
            }
        }

        public void Leave(Vehicle vehicle)
        {
            for (int i = 0; i < Slots.Length; i++)
            {
                if (Slots[i] == vehicle)
                {
                    Slots[i] = null;
                    Console.WriteLine($"Slot number {i + 1} is free\n");
                    break;
                }
                else Console.WriteLine("No such vehicle exist in our parking lot\n");
            }
        }

        public void ParkingStatus()
        {
            Console.WriteLine("Slot\tNo.\t\tType\tColour");
            for (int i = 0; i < this.Slots.Length; i++)
            {
                Console.WriteLine($"{ i+ 1}\t{Slots[i]}");
            }
            Console.WriteLine();
        }

    }
}
