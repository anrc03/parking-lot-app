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
            Console.WriteLine();
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
            Console.WriteLine("|+++++++ PARK A VEHICLE ++++++++|");
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
            Console.WriteLine();
        }

        void ParkACar()
        {
            bool available = this.parkingLot.CheckIfParkingLotAvailable();
            if (available) {
                Console.WriteLine("Please enter your vehicle info");
                string licenseNumber = Utility.HandlePlateInput("Enter license number (X-XXXX-XXX format): ");
                string colour = Utility.HandleColourInput("Enter car colour: ");
                this.parkingLot.Park(new Car(licenseNumber, colour));
            }
            else Console.WriteLine("Sorry, parking lot is full\n");
        }

        void ParkAMotorcycle()
        {
            bool available = this.parkingLot.CheckIfParkingLotAvailable();
            if (available)
            {
                Console.WriteLine("Please enter your vehicle info");
                string licenseNumber = Utility.HandlePlateInput("Enter license number (X-XXXX-XXX format): ");
                string colour = Utility.HandleColourInput("Enter motorcycle colour: ");
                this.parkingLot.Park(new Motorcycle(licenseNumber, colour));
            }
            else Console.WriteLine("Sorry, parking lot is full\n");
        }

        void LeaveFromParkingLot()
        {
            while (true)
            {
                bool empty = this.parkingLot.CheckIfParkingLotEmpty();
                if (!empty)
                {
                    this.parkingLot.DisplayParkingStatus();
                    Console.WriteLine("Enter the slot number of vehicle that's going to leave: ");
                    string input = Console.ReadLine().Trim().ToLower();
                    if (input == "exit") break;
                    var isNumber = int.TryParse(input, out int slot);
                    if (isNumber)
                    {
                        this.parkingLot.Leave(slot);
                        break;
                    }
                    else continue;
                }
                else {
                    Console.WriteLine("Parking lot is currently empty\n");
                    break;
                }
            }
        }

        void PrintCheckInfoMenu()
        {
            Console.WriteLine("|-------------------------------|");
            Console.WriteLine("|++++++++++++ INFO +++++++++++++|");
            Console.WriteLine("|-------------------------------|");
            Console.WriteLine("| 1. Parking lot status         |");
            Console.WriteLine("| 2. Vehicle with odd plate     |");
            Console.WriteLine("| 3. Vehicle with even plate    |");
            Console.WriteLine("| 4. Slot number by color       |");
            Console.WriteLine("| 5. Number of car              |");
            Console.WriteLine("| 6. Number of motorcycle       |");
            Console.WriteLine("| 7. Back                       |");
            Console.WriteLine("|-------------------------------|");
        }

        void CheckInfo()
        {
            while (true)
            {
                PrintCheckInfoMenu();
                Console.Write("Choose a menu (1-7): ");
                string input = Console.ReadLine().Trim().ToLower();
                switch (input)
                {
                    case "1":
                        this.parkingLot.DisplayParkingStatus();
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
                        this.parkingLot.CarCount();
                        break;
                    case "6":
                        this.parkingLot.MotorcycleCount();
                        break;
                    case "7":
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
            Console.WriteLine();
        }
    }
}
