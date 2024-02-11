using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    internal class View
    {
        ParkingLot parkingLot;

        public View()
        {
            while (true)
            {
                Console.WriteLine("Enter parking lot capacity: ");
                string capacity = Console.ReadLine().Trim().ToLower();
                if (capacity == "exit") Environment.Exit(0);
                try
                {
                    int.Parse(capacity);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"{capacity} is not a number!");
                    continue;
                }
                this.parkingLot = new ParkingLot(int.Parse(capacity));
                break;
            }
        }

        public void Run()
        {
            while (true)
            {
                PrintMenu();
                Console.Write("Choose a menu (1-4): ");
                string input = Console.ReadLine().Trim().ToLower();
                switch (input) {
                    case "1":
                        ParkAVehicle();
                        break;
                    case "2":
                        LeaveFromParkingLot();
                        break;
                    case "3":
                        CheckInfo();
                        break;
                    case "4":
                        return;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        continue;
                }
                Console.WriteLine();
            }
        }

        void PrintMenu()
        {
            Console.WriteLine("|-------------------------------|");
            Console.WriteLine("|+++++++ PARKING LOT APP +++++++|");
            Console.WriteLine("|-------------------------------|");
            Console.WriteLine("| 1. Park a vehicle             |");
            Console.WriteLine("| 2. Leave from parking lot     |");
            Console.WriteLine("| 3. Parking lot info           |");
            Console.WriteLine("| 4. Exit                       |");
            Console.WriteLine("|-------------------------------|");
        }

        void PrintParkAVehicleMenu()
        {
            Console.WriteLine("|-------------------------------|");
            Console.WriteLine("|+++++++ PARKING LOT APP +++++++|");
            Console.WriteLine("|-------------------------------|");
            Console.WriteLine("| 1. Park A Car                 |");
            Console.WriteLine("| 2. Park A Motorcycle          |");
            Console.WriteLine("| 3. Back                       |");
            Console.WriteLine("|-------------------------------|");
        }

        void ParkAVehicle() {
            while (true)
            {
                PrintParkAVehicleMenu();
                Console.Write("Choose a menu (1-3): ");
                string input = Console.ReadLine().Trim().ToLower();
                switch (input)
                {
                    case "1":
                        ParkACar();
                        break;
                    case "2":
                        ParkAMotorcycle();
                        break;
                    case "3":
                        return;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        continue;
                }
                Console.WriteLine();
            }
        }

        void ParkACar()
        {
            Console.WriteLine("|-------------------------------|");
            Console.WriteLine("|+++++++ PARKING LOT APP +++++++|");
            Console.WriteLine("|-------------------------------|");
            Console.WriteLine("|Please enter your vehicle info |");
            string licenseNumber = Utility.InputLicenseNumber("Enter license number (X-XXXX-XXX format): ");
            string colour = Utility.inputColour("Enter car colour: ");
            this.parkingLot.Park(new Car(licenseNumber, colour));
        }

        void ParkAMotorcycle()
        {
            Console.WriteLine("|-------------------------------|");
            Console.WriteLine("|+++++++ PARKING LOT APP +++++++|");
            Console.WriteLine("|-------------------------------|");
            Console.WriteLine("|Please enter your vehicle info |");
            string licenseNumber = Utility.InputLicenseNumber("Enter license number (X-XXXX-XXX format): ");
            string colour = Utility.inputColour("Enter car colour: ");
            this.parkingLot.Park(new Motorcycle(licenseNumber, colour));
        }

        void LeaveFromParkingLot()
        {
            this.parkingLot.Leave(new Vehicle("b", "c"));
        }

        void PrintCheckInfoMenu()
        {
            Console.WriteLine("|-------------------------------|");
            Console.WriteLine("|+++++++ PARKING LOT APP +++++++|");
            Console.WriteLine("|-------------------------------|");
            Console.WriteLine("| 1. Parking lot status         |");
            Console.WriteLine("| 2. Vehicle with odd plate     |");
            Console.WriteLine("| 3. Vehicle with even plate    |");
            Console.WriteLine("| 4. Slot number by color       |");
            Console.WriteLine("| 5. Back                       |");
            Console.WriteLine("|-------------------------------|");
        }

        void CheckInfo()
        {
            while (true)
            {
                PrintCheckInfoMenu();
                Console.Write("Choose a menu (1-5): ");
                string input = Console.ReadLine().Trim().ToLower();
                switch (input)
                {
                    case "1":
                        this.parkingLot.ParkingStatus();
                        break;
                    case "2":
                        this.parkingLot.CheckOddPlate();
                        break;
                    case "3":
                        this.parkingLot.CheckEvenPlate();
                        break;
                    case "4":
                        Console.WriteLine("Enter a colour: ");
                        string colour = Console.ReadLine().Trim();
                        this.parkingLot.CheckColour(colour);
                        break;
                    case "5":
                        return;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        continue;
                }
                Console.WriteLine();
            }
        }
    }
}
