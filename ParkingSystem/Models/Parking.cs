namespace ParkingSystem.Models
{
    internal class Parking
    {
        private decimal initialPrice;
        private decimal pricePerHour;
        private decimal totalPay;
        private List<string> vehiclePlates;

        public Parking(decimal initialPrice, decimal pricePerHour)
        {
            this.initialPrice = initialPrice;
            this.pricePerHour = pricePerHour;
            vehiclePlates = new List<string>();
        }
        public void AddVehicles(string plate)
        {
            vehiclePlates.Add(plate.ToUpper());
        }
        public void RemoveVehicles(string plate)
        {
            if (vehiclePlates.Contains(plate.ToUpper()))
            {
                decimal totalPay;

                Console.Write("Enter the number of hours the vehicle was parked: ");
                bool input = decimal.TryParse(Console.ReadLine(), out decimal hoursParked);
                if (input)
                {
                    if (hoursParked > 2)
                    {
                        totalPay = initialPrice + ((hoursParked - 2) * pricePerHour);
                    }
                    else
                    {
                        totalPay = initialPrice;
                    }
                    Console.WriteLine($"The amount due is $ {totalPay:F2}.");
                }
                else
                {
                    Console.WriteLine("Invalid Input!");
                }
                vehiclePlates.Remove(plate.ToUpper());
            }
            else
            {
                Console.WriteLine("Unregistered vehicle!");
            }
        }
        public void ListVehicles() 
        {
            if (vehiclePlates.Any())
            {
                Console.WriteLine("The vehicles that are parked are: ");   
                foreach (string plate in vehiclePlates) 
                { 
                    Console.WriteLine(plate); 
                }
            } 
            else
            {
                Console.WriteLine("There aren't any vehicles parked!");
            }           
        }
    }
}
