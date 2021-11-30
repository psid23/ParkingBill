using ParkingBill;

Console.WriteLine("Enter 1 for Calculation Method 1 and Enter 2 for Calculation Method 2 or Enter x to exit");
string? method = Console.ReadLine();
    switch (method)
    {
        case "1":
            string entryTime;
            do
            {
                Console.WriteLine("Enter Entry time in HH:MM where HH is between 00 and 23 inclusive and MM is between 00 and 59 inclusive");
                entryTime = Console.ReadLine() ?? string.Empty;
            } while (string.IsNullOrEmpty(entryTime) || string.IsNullOrWhiteSpace(entryTime) || !Ticket.IsInputTimeValid(entryTime));
            string exitTime;
            do
            {
                Console.WriteLine("Enter Exit time in HH:MM where HH is between 00 and 23 inclusive and MM is between 00 and 59 inclusive");
                exitTime = Console.ReadLine() ?? string.Empty;
            } while (string.IsNullOrEmpty(exitTime) || string.IsNullOrWhiteSpace(exitTime) || !Ticket.IsInputTimeValid(exitTime));
            Console.WriteLine("Please pay your parking fees of USD " + Ticket.CalculateTotalParkingFees(entryTime, exitTime) + " for parking from : " + Ticket.GetParkingTime(entryTime) + " to : " + Ticket.GetParkingTime(exitTime));
            Console.ReadLine();
            break;
        case "2":
            string parkingEntryTime;
            do
            {
                Console.WriteLine("Enter Entry time in HH:MM where HH is between 00 and 23 inclusive and MM is between 00 and 59 inclusive");
                parkingEntryTime = Console.ReadLine() ?? string.Empty;
            } while (string.IsNullOrEmpty(parkingEntryTime) || string.IsNullOrWhiteSpace(parkingEntryTime) || !Ticket.IsInputTimeValid(parkingEntryTime));
            string parkingExitTime;
            do
            {
                Console.WriteLine("Enter Exit time in HH:MM where HH is between 00 and 23 inclusive and MM is between 00 and 59 inclusive");
                parkingExitTime = Console.ReadLine() ?? string.Empty;
            } while (string.IsNullOrEmpty(parkingExitTime) || string.IsNullOrWhiteSpace(parkingExitTime) || !Ticket.IsInputTimeValid(parkingExitTime));
            ParkingTicket parkingTicket = new(parkingEntryTime, parkingExitTime);
            parkingTicket.CalculateTotalParkingFees();
            Console.WriteLine("Please pay your parking fees of USD " + parkingTicket.TotalParkingFees + " for parking from : " + parkingTicket.ParkingEntryTime + " to : " + parkingTicket.ParkingExitTime);
            Console.ReadLine();
            break;
        case "x":
            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
            break;
        default:
            Console.WriteLine("You entered the wrong input! Press enter to exit...");
            Console.ReadLine();
            break;
    }