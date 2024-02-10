using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    internal class ParkingLot
    {
        public int Capacity {  get; }
        public Vehicle[] Slots { get; }
        public int AllocatedSlot { get; set; }

        public ParkingLot(int capacity)
        {
            this.Capacity = capacity;
            this.Slots = new Vehicle[capacity];
            this.AllocatedSlot = Slots.Length;
            Console.WriteLine($"Created a parking lot with {this.Capacity} slots");
        }

        public void Park(Vehicle vehicle)
        {
            
            Console.WriteLine($"Allocated slot number: {this.AllocatedSlot++}");
        }
    }
}
