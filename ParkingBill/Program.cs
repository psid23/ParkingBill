using ParkingBill;

string entryTime;
do{
    Console.WriteLine("Enter Entry time in HH:MM where HH is between 00 and 23 inclusive and MM is between 00 and 59 inclusive");
    entryTime =  Console.ReadLine() ?? string.Empty;
} while (string.IsNullOrEmpty(entryTime) || string.IsNullOrWhiteSpace(entryTime) || !Ticket.IsInputTimeValid(entryTime));

string exitTime;
do{
    Console.WriteLine("Enter Exit time in HH:MM where HH is between 00 and 23 inclusive and MM is between 00 and 59 inclusive");
    exitTime = Console.ReadLine()??string.Empty;
} while (string.IsNullOrEmpty(exitTime) || string.IsNullOrWhiteSpace(exitTime) || !Ticket.IsInputTimeValid(exitTime));

Console.WriteLine("Please pay your parking fees of USD " + Ticket.CalculateTotalParkingFees(entryTime, exitTime) +" for parking from : " + Ticket.GetParkingTime(entryTime) + " to : " + Ticket.GetParkingTime(exitTime));
Console.ReadLine();