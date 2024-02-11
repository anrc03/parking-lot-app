using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParkingSystem
{
    internal class Utility
    {
        public static string InputLicenseNumber(string message)
        {
            while (true)
            {
                Console.Write(message);
                string licenseNumber = Console.ReadLine();
                string[] splitted = licenseNumber.Split("-");
                if (splitted.Length != 3)
                {
                    Console.WriteLine("Wrong format. Use \"-\" to separate.");
                    continue;
                }
                if (splitted[0].Length > 2)
                {
                    Console.WriteLine("Please enter a valid license number");
                    continue;
                }
                bool format = true;
                foreach (var item in splitted[0])
                {
                    if (!Char.IsLetter(item))
                    {
                        format = false;
                        break;
                    }
                }
                if (!format)
                {
                    Console.WriteLine("Region code must be a letter!");
                    continue;
                }
                try
                {
                    int.Parse(splitted[1].Trim());
                }
                catch (FormatException)
                {
                    Console.WriteLine($"{splitted[1].Trim()} is not a number!");
                    continue;
                }
                if (splitted[1].Trim().Length > 4)
                {
                    Console.WriteLine("Number cannot be more than 4 digit!");
                    continue;
                }
                return licenseNumber.ToUpper();
            }
        }

        public static string inputColour(string message)
        {
            while(true)
            {
                Console.Write(message);
                string colour = Console.ReadLine();
                bool format = true;
                foreach (var item in colour)
                {
                    if(Char.IsDigit(item))
                    {
                        format = false;
                        break;
                    }
                }
                if (!format) continue;
                return colour.ToUpper();
            }
        }
    }
}
