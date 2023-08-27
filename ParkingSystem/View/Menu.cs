using ParkingSystem.Models;

namespace ParkingSystem.View
{
    internal static class Menu
    {
        public static void InitialMenu()
        {
            bool exit = true;

            while (exit)
            {
                Console.WriteLine("Parking Management System");
                Console.Write("Please input the value for the initial two hours: ");
                bool input1 = decimal.TryParse(Console.ReadLine(), out decimal initialPrice);

                Console.Write("Please input the additional hourly rate: ");
                bool input2 = decimal.TryParse(Console.ReadLine(), out decimal pricePerHour);

                if (input1 && input2)
                {
                    Parking parking = new(initialPrice, pricePerHour);
                    OperationsMenu(parking);
                    exit = false;
                }
                else
                {
                    Console.WriteLine("Please input a valid value.");
                }
            }            
        }

        public static void OperationsMenu(Parking parking)
        {
            bool exit = true;
            while (exit)
            {
                Console.Clear();
                Console.WriteLine("Please enter the number of your desired option: ");
                Console.WriteLine("1 - Register Vehicle");
                Console.WriteLine("2 - Remove Vehicle");
                Console.WriteLine("3 - List Vehicles");
                Console.WriteLine("4 - Close");
                bool input1 = int.TryParse(Console.ReadLine(), out int option);

                if (input1)
                {
                    switch (option)
                    {
                        case 1:
                            Console.Write("Enter the vehicle plate: ");
                            string plate = Console.ReadLine();
                            parking.AddVehicles(plate);
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                        break;

                        case 2:
                            Console.Write("Enter the vehicle plate: ");
                            plate = Console.ReadLine();
                            parking.RemoveVehicles(plate);
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            break;
                        case 3:
                            parking.ListVehicles();
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            break;
                        case 4:
                            exit = false;
                        break;
                        default:
                            Console.WriteLine("Please input a valid value.");
                        break;

                    }
                }

            }
        }
    }
}
