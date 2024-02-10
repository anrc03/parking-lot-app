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
        public int AllocatedSlot { get; set; }

        public ParkingLot(int capacity)
        {
            this.Capacity = capacity;
            this.Slots = new Vehicle[this.Capacity];
            this.AllocatedSlot = 0;
            Console.WriteLine($"Created a parking lot with {this.Capacity} slots\n");
        }

        public void Park(Vehicle vehicle)
        {
            try
            {
                Slots[this.AllocatedSlot] = vehicle;
                this.AllocatedSlot++;
                Console.WriteLine($"Allocated slot number: {this.AllocatedSlot}\n");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Sorry, parking lot is full\n");
            }
        }

        public void ParkingStatus()
        {
            Console.WriteLine("Slot\tNo.\t\tType\tColour");
            for (int i = 0; i < this.Slots.Length; i++)
            {
                Console.WriteLine($"{i+1}\t{Slots[i]}");
            }
        }

    }
}
