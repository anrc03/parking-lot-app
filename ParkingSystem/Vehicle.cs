using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    internal class Vehicle
    {
        public string Type { get; set; }
        public string LicenseNumber { get; set; }
        public string Colour { get; set; }

        public Vehicle(string licenseNumber, string colour) {
            this.LicenseNumber = licenseNumber;
            this.Colour = colour;
        }

        public override string ToString() { 
            return $"{LicenseNumber}\t{Type}\t{Colour}";
        }
    }
}
