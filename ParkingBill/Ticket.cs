/*
    You parked your car in a parking lot and want to compute the total cost of the ticket. 
    The billing rules are as follows:

    The entrance fee of the car parking lot is 2;
    The first full or partial hour costs 3;
    Each successive full or partial hour (after the first) costs 4.
    You entered the car parking lot at time E and left at time L. 
    In this task, times are represented as strings in the format "HH:MM" (where "HH" is a two-digit number between 0 and 23, which stands for hours, and "MM" is a two-digit number between 0 and 59, which stands for minutes).

    Write a function:

    class Solution { public int solution(string E, string L); }

    that, given strings E and L specifying points in time in the format "HH:MM", returns the total cost of the parking bill from your entry at time E to your exit at time L. 
    You can assume that E describes a time before L on the same day.

    For example, given "10:00" and "13:21" your function should return 17, because the entrance fee equals 2, the first hour costs 3 and there are two more full hours and part of a further hour, so the total cost is 2 + 3 + (3 * 4) = 17. Given "09:42" and "11:42" your function should return 9, because the entrance fee equals 2, the first hour costs 3 and the second hour costs 4, so the total cost is 2 + 3 + 4 = 9.

    Assume that:

    strings E and L follow the format "HH:MM" strictly;
    string E describes a time before L on the same day.
    In your solution, focus on correctness. The performance of your solution will not be the focus of the assessment.
 * */
using System.Text.RegularExpressions;
namespace ParkingBill
{
    internal class Ticket
    {
        #region CONSTANTS
        /// <summary>
        /// Minimum parking hours
        /// </summary>
        const int MINHOURS = 1;
        /// <summary>
        /// Entrance Fees
        /// </summary>
        const int ENTRANCEFEES = 2;
        /// <summary>
        /// First hour parking fee
        /// </summary>
        const int FIRSTHOURFEE = 3;
        /// <summary>
        /// Post first hour parking fee for each hour
        /// </summary>
        const int POSTFIRSTHOURFEE = 4;
        /// <summary>
        /// Minutes in an hour
        /// </summary>
        const int MINSINHOURS = 60;
        /// <summary>
        /// String to append to HH:MM string input to convert to ime
        /// </summary>
        const string ZEROSECONDSINSSFORMAT = ":00";
        /// <summary>
        /// Regular expression to validate the input time in HH:MM format where HH ranges from 00 to 23 and MM ranges from 00 to 59
        /// </summary>
        const string HHMMREGEX = "^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$";
        #endregion
        #region Internal methods
        /// <summary>
        /// Entrance Fees for parking
        /// </summary>
        /// <returns></returns>
        internal static int GetEntranceFees() { return ENTRANCEFEES; }
        /// <summary>
        /// Get the parking time in datetime format for calculations
        /// </summary>
        /// <param name="time">Input time in HH:MM format where HH ranges from 00 to 23 and MM ranges from 00 to 59</param>
        /// <returns>Time appended to today's date</returns>
        internal static DateTime GetParkingTime(string time)
        {
            string parkingTime = string.Concat(time, ZEROSECONDSINSSFORMAT);
            var timeForCalculation = TimeSpan.Parse(parkingTime);
            var dateTimeTimeForCalculation = DateTime.Today.Add(timeForCalculation);
            return dateTimeTimeForCalculation;
        }
        /// <summary>
        /// Get the parking hours as per the business logic
        /// </summary>
        /// <param name="entryTime">Input entry time in HH:MM format where HH ranges from 00 to 23 and MM ranges from 00 to 59</param>
        /// <param name="exitTime">Input exit time in HH:MM format where HH ranges from 00 to 23 and MM ranges from 00 to 59</param>
        /// <returns></returns>
        internal static int CalculateParkingFullHours(string entryTime, string exitTime)
        {
            DateTime entryDateTime = GetParkingTime(entryTime);
            DateTime exitDateTime = GetParkingTime(exitTime);
            double totalMinutes = (exitDateTime - entryDateTime).TotalMinutes;
            int hours = MINHOURS;
            if (totalMinutes > MINSINHOURS)
            {
                hours = (int)Math.Ceiling(totalMinutes / MINSINHOURS);
            }
            return hours;
        }
        /// <summary>
        /// Calculate the parking fees by passing the hours as input and using the business logic to get the output
        /// </summary>
        /// <param name="hours">Hours as an integer value</param>
        /// <returns>Parking fees</returns>
        internal static int CalculateParkingFees(int hours)
        {
            //Fee for first hour
            if (hours <= MINHOURS)
            {
                return FIRSTHOURFEE;
            }
            //Fees for hours past the first hour
            else
            {
                hours--;
                return FIRSTHOURFEE + POSTFIRSTHOURFEE * hours;
            }
        }
        /// <summary>
        /// Calculate the total parking fees - entrance fee + first hour parking fee + post first hour parking fees
        /// </summary>
        /// <param name="entryTime">Input entry time in HH:MM format where HH ranges from 00 to 23 and MM ranges from 00 to 59</param>
        /// <param name="exitTime">Input exit time in HH:MM format where HH ranges from 00 to 23 and MM ranges from 00 to 59</param>
        /// <returns>Total Parking Fees</returns>
        internal static int CalculateTotalParkingFees(string entryTime, string exitTime)
        {
            int hours = CalculateParkingFullHours(entryTime, exitTime);
            int entranceFees = GetEntranceFees();
            int parkingFees = CalculateParkingFees(hours);
            int totalParkingFees = entranceFees + parkingFees;
            return totalParkingFees;
        }
        /// <summary>
        /// Validation for the entered time
        /// </summary>
        /// <param name="time">Input time in HH:MM format where HH ranges from 00 to 23 and MM ranges from 00 to 59</param>
        /// <returns>True if validation succeeds else false</returns>
        internal static bool IsInputTimeValid(string time)
        {
            Regex regex = new(HHMMREGEX, RegexOptions.IgnoreCase);
            bool result = regex.IsMatch(time);
            return result;
        } 
        #endregion
    }
}