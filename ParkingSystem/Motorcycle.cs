using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    internal class Motorcycle : Vehicle
    {

        public Motorcycle(string licenseNumber, string colour) : base(licenseNumber, colour)
        {
            this.Type = "Motorcycle";
        }
    }
}
