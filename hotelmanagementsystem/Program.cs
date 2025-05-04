using System;

namespace hotelmanagementsystem;

class Program
{ 
 
    // Declare variables
    private static string[,] roomAvailability; //Room Number, Type, Price, Status    
    private static string[,] paymentDetails; // Room Number, Payment Method, Amount, Date, Transaction ID
    private static string[,] checkInOutDetails;  // Room Number, Name, Contact Number, Check-in Date, Check-out Date
    
    static Program()
    {
        // Initialize room availability data
        roomAvailability = new string[,]
        {
            { "101", "Single", "1000", "Available" }, 
            { "102", "Double", "1500", "Occupied" }, 
            { "103", "Suite", "2000", "Under Maintenance" }
        };

        // Initialize payment details data
        paymentDetails = new string[,]
        {
            { "101", "Cash", "1000", "2025-05-01", "20250501080101" },
            { "102", "Credit", "1500", "2025-05-02", "20250502080101" }
        };

        // Initialize check-in/out details data
        checkInOutDetails = new string[,]
        {
            { "101", "John Doe", "09123456789", "2025-05-01", "2025-05-02" },
            { "102", "Jane Smith", "09876543210", "2025-05-02", "" }
        };
    }

    private static void Main(string[] args)
    {
        Program.Start();
    }

    private static void Start()
    {
        LoginMenu();
    }

    private static void LoginMenu()
    {
        try
            {
                Console.WriteLine("Bato Hotel Management System");
                Console.WriteLine("============================");
                Console.WriteLine("[1] Login");
                Console.WriteLine("[2] Exit");
                Console.WriteLine("============================");
                Console.Write("Select an option: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Login();
                        break;
                    case "2":
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
    }

    private static void Login()
    {
        Console.WriteLine("Welcome to Bato Hotel Management System");
        Console.WriteLine("========================================");
        Console.Write("Username: ");
        string? username = Console.ReadLine();
        Console.Write("Password: ");
        string? password = Console.ReadLine();

        // Add login logic here
        if (username == "admin" && password == "admin")
        {
            Console.WriteLine("Login successful!");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            Menu();
        }
        else
        {
            Console.WriteLine("Invalid username or password. Please try again.");
            System.Threading.Thread.Sleep(1000);
            Login();
        }
    }

    private static void Menu()
    {           
        Console.WriteLine("Bato Hotel Management System");
        Console.WriteLine("============================");
        Console.WriteLine("[1] Check-In");
        Console.WriteLine("[2] Check-Out");
        Console.WriteLine("[3] View Room Availability");
        Console.WriteLine("[4] Manage Rooms");
        Console.WriteLine("[5] Reports");
        Console.WriteLine("[6] Exit");
        Console.WriteLine("============================");

        Console.Write("Select an option: ");
        string? choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                CheckIn();
                break;
            case "2":
                CheckOut();
                break;
            case "3":
                ViewRooms();
                break;
            case "4":
                ManageRooms();
                break;
            case "5":
                Report();
                break;
            case "6":
                Exit();
                return;
            default:
                Console.WriteLine("Invalid choice. Please try again.");                
                break;
        }
        Menu();
    }
    private static void Greetings()
    {
        Console.WriteLine("Thank you for using Bato Hotel Management System");
        Console.WriteLine("================================================");
    }

    private static void CheckIn()
    {
        CheckInDetails();
    }
    private static void CheckOut()
    {
        CheckOutDetails();
    }
    private static void ViewRooms()
    {
        Console.WriteLine("Room Availablity");
        Console.WriteLine("Number | Type       | Price            | Status");
        Console.WriteLine("===========================================================");
        for (int row = 0; row < roomAvailability.GetLength(0); row++)
        {
            Console.WriteLine($"{roomAvailability[row, 0].PadRight(6)} | {roomAvailability[row, 1].PadRight(10)} | Php {string.Format("{0:#,##0.00}", Decimal.Parse(roomAvailability[row, 2])).PadLeft(12)} | {roomAvailability[row, 3]}");
        }
        Console.WriteLine("===========================================================");
    }
    private static void Exit()
    {
        Greetings();
        Console.WriteLine("Exiting the system...");
    }    
   
    private static void Report()
    {
        Console.WriteLine("Generate Sales Reports");
        Console.WriteLine("============================");
        Console.WriteLine("[1] Daily");
        Console.WriteLine("[2] Weekly");
        Console.WriteLine("[3] Monthly");
        Console.WriteLine("[4] Yearly");
        Console.WriteLine("[5] Back to Main Menu");
        Console.WriteLine("============================");
        Console.Write("Select an option: ");
        string? choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                // Generate Daily Report
                GenerateReport("Daily");
                Console.WriteLine("Generating Daily Sales Report...");
                // Add report generation logic here
                break;
            case "2":
                // Generate Weekly Report
                GenerateReport("Weekly");
                Console.WriteLine("Generating Weekly Sales Report...");
                // Add report generation logic here
                break;
             case "3":
                // Generate Monthly Report
                GenerateReport("Monthly");
                Console.WriteLine("Generating Monthly Sales Report...");
                // Add report generation logic here
                break;
             case "4":
                // Generate Yearly Report
                GenerateReport("Yearly");
                Console.WriteLine("Generating Yearly Sales Report...");
                // Add report generation logic here
                break;
            case "5":
                Menu();
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
        Report();
    }
    private static string GenerateTransactionID()
    {
        return DateTime.Now.ToString("yyyyMMddHHmmss");
    }    

    private static void OccupiedRoom(string roomNumber)
    {
        // Check if the room is already occupied
        for (int row = 0; row < roomAvailability.GetLength(0); row++)
        {
            if (roomAvailability[row, 0] == roomNumber)
            {
                if (roomAvailability[row, 3] == "Available")
                {
                    // Update room status to occupied
                    roomAvailability[row, 3] = "Occupied";
                    Console.WriteLine("Room is now occupied.");
                    return;
                }
                Console.WriteLine("Room is already occupied.");
                return;
            }
        }

        Console.WriteLine("Room is occupied.");
    }

    private static void VacateRoom(string roomNumber)
    {
        // update the room status to available
        for (int row = 0; row < roomAvailability.GetLength(0); row++)
        {
            if (roomAvailability[row, 0] == roomNumber)
            {
                if (roomAvailability[row, 3] == "Occupied")
                {
                    // Update room status to available
                    roomAvailability[row, 3] = "Available";
                    Console.WriteLine("Room is now available.");
                    return;
                }
                Console.WriteLine("Room is already available.");
                return;
            }
        }
        Console.WriteLine("Room is available.");
        Console.WriteLine("Room updated successfully.");        
    }

    private static void PaymentDetails(string roomNumber, decimal totalAmount)
    {
        Console.WriteLine("Enter payment details:");
        Console.Write("Payment Method [Cash/Credit]: ");
        string? paymentMethod = Console.ReadLine();
        Console.Write("Amount Pay Php: ");
        string? amount = Console.ReadLine();

        if(decimal.Parse(amount) > totalAmount)
        {
            Console.WriteLine("Change Php: " + string.Format("{0:#,##0.00}", Decimal.Parse(amount) - totalAmount));            
        }
        string transactionID = GenerateTransactionID();

        // Add new payment details to the array
        var newPaymentDetails = new string[paymentDetails.GetLength(0) + 1, paymentDetails.GetLength(1)];
        // Copy existing payment details to new array
        for (int row = 0; row < paymentDetails.GetLength(0); row++)
        {
            for (int column = 0; column < paymentDetails.GetLength(1); column++)
            {
                newPaymentDetails[row, column] = paymentDetails[row, column];
            }
        }
        // Add new payment details to the last row of the new array

        int noOfPaymentRecords = newPaymentDetails.GetLength(0) - 1; // Get the last row index
        newPaymentDetails[noOfPaymentRecords, 0] = roomNumber ?? string.Empty; // Room Number
        newPaymentDetails[noOfPaymentRecords, 1] = paymentMethod ?? string.Empty; // Payment Method
        newPaymentDetails[noOfPaymentRecords, 2] = totalAmount.ToString() ?? string.Empty; // Amount
        newPaymentDetails[noOfPaymentRecords, 3] = DateTime.Now.ToString("yyyy-MM-dd"); // Date
        newPaymentDetails[noOfPaymentRecords, 4] = transactionID ?? string.Empty; // Transaction ID

        paymentDetails = newPaymentDetails;
        Console.WriteLine("Transaction ID: " + transactionID); 
        Console.WriteLine("Payment details added successfully.");
    }
    private static void BillingDetails(string roomNumber, string checkInDate, out decimal totalAmount)
    {
   
        Console.Write("Check-Out Date [YYYY-MM-DD]: ");
        string? checkOutDate = Console.ReadLine();

        if (string.IsNullOrEmpty(checkOutDate) || string.IsNullOrEmpty(checkOutDate))
        {
            Console.WriteLine("Check-Out dates cannot be null or empty.");
        }

        // Update the check-out date in the check-in/out details array 
        for (int row = 0; row < checkInOutDetails.GetLength(0); row++)
        {
            if (checkInOutDetails[row, 0] == roomNumber && checkInOutDetails[row, 3] == checkInDate)
            {                
                checkInOutDetails[row, 4] = checkOutDate ?? string.Empty; // Check-out Date
                break;
            }
        }   

        int totalDays = (DateTime.Parse(checkOutDate) - DateTime.Parse(checkInDate)).Days;
        Console.WriteLine("Number Of Day(s): " + totalDays);

        // Get the room price from the room availability array
        decimal roomPrice = 0;
        for (int row = 0; row < roomAvailability.GetLength(0); row++)
        {
            if (roomAvailability[row, 0] == roomNumber)
            {
                roomPrice = Decimal.Parse(roomAvailability[row, 2]);
                break;
            }
        }

        totalAmount = totalDays * Decimal.Parse(roomPrice.ToString()); 
        Console.WriteLine("Total Amount Php: " + string.Format("{0:#,##0.00}", totalAmount));
    }
    private static void CheckInDetails()
    {
        Console.WriteLine("Check-In Details:");
        Console.Write("Name: ");
        string? name = Console.ReadLine();
        Console.Write("Contact Number: ");
        string? contactNumber = Console.ReadLine();
        Console.Write("Room Number: ");
        string? roomNumber = Console.ReadLine();

        // Check if room is available
        while (!string.IsNullOrEmpty(roomNumber) && FindRoom(roomNumber) == false)
        {
            Console.WriteLine("Room not found.");
            Console.Write("Room Number: ");
            roomNumber = Console.ReadLine();
        }
       
        // Check if room is available
        while (!string.IsNullOrEmpty(roomNumber) && IsRoomAvailable(roomNumber) == false)
        {
            Console.WriteLine("Room is not available. Please choose another room.");
            Console.Write("Room Number: ");
            roomNumber = Console.ReadLine();
        }

        Console.Write("Check-In Date[YYYY-MM-DD]: ");
        string? checkInDate = Console.ReadLine();

        // add new check-in details to the array
        var newCheckInOutDetails = new string[checkInOutDetails.GetLength(0) + 1, checkInOutDetails.GetLength(1)];

        // Copy existing check-in details to new array
        for (int row = 0; row < checkInOutDetails.GetLength(0); row++)
        {
            for (int column = 0; column < checkInOutDetails.GetLength(1); column++)
            {
                newCheckInOutDetails[row, column] = checkInOutDetails[row, column];
            }
        }

        int noOfCheckInRecords = newCheckInOutDetails.GetLength(0) - 1; // Get the last row index

        newCheckInOutDetails[noOfCheckInRecords, 0] = roomNumber ?? string.Empty; // Room Number
        newCheckInOutDetails[noOfCheckInRecords, 1] = name ?? string.Empty; // Name
        newCheckInOutDetails[noOfCheckInRecords, 2] = contactNumber ?? string.Empty; // Contact Number
        newCheckInOutDetails[noOfCheckInRecords, 3] = checkInDate ?? string.Empty; // Check-in Date
        newCheckInOutDetails[noOfCheckInRecords, 4] = string.Empty; // Check-out Date

        // Assign the new array to the check-in details variable
        checkInOutDetails = newCheckInOutDetails;

        if (!string.IsNullOrEmpty(roomNumber))
        {
            OccupiedRoom(roomNumber);
        }
        else
        {
            Console.WriteLine("Room number cannot be null or empty.");
        }

        Console.WriteLine("Room: " + roomNumber);
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Contact Number: " + contactNumber);
        Console.WriteLine("Check-In Date: " + checkInDate);
        Console.WriteLine();
        Console.WriteLine("Customer details added successfully.");
    }
    private static void CheckOutDetails()
    {
        Console.WriteLine("Check-Out Details:");
        Console.Write("Room Number: ");
        string? roomNumber = Console.ReadLine();

        // check if room is existing
        while (!string.IsNullOrEmpty(roomNumber) && FindRoom(roomNumber) == false)
        {
            Console.WriteLine("Room not found. Please choose another room.");
            Console.Write("Room Number: ");
            roomNumber = Console.ReadLine();
        }
        // check if room is occupied
        while (!string.IsNullOrEmpty(roomNumber) && RoomStatus(roomNumber) != "Occupied")
        {
            Console.WriteLine("Room is not yet occupied. Please choose another room.");
            Console.Write("Room Number: ");
            roomNumber = Console.ReadLine();
        }
        
        Console.Write("Check-In Date [YYYY-MM-DD]: ");
        string? checkInDate = Console.ReadLine();

        BillingDetails(roomNumber, checkInDate, out decimal totalAmount);
        PaymentDetails(roomNumber, totalAmount);
        VacateRoom(roomNumber);
        Console.WriteLine("Check-out successful.");
    }
    private static void ManageRooms()
    {
        Console.WriteLine("Manage Rooms");
        Console.WriteLine("[1] Add Room");
        Console.WriteLine("[2] View Rooms");
        Console.WriteLine("[3] Update Room");
        Console.WriteLine("[4] Delete Room");
        Console.WriteLine("[5] Back to Main Menu");
        Console.WriteLine("============================");

        Console.Write("Select an option: ");
        string? choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                // Add new room details
                Console.WriteLine("Enter new room add:");
                Console.Write("Room Number: ");
                string? roomNumber = Console.ReadLine();
                Console.Write("Room Type: ");
                string? roomType = Console.ReadLine();
                Console.Write("Room Price: ");
                string? roomPrice = Console.ReadLine();
                Console.Write("Room Status: ");
                string? roomStatus = Console.ReadLine();

                // Add new room to the room availability array                
                AddRoom(new string[] { roomNumber ?? string.Empty, roomType ?? string.Empty, roomPrice ?? string.Empty, roomStatus ?? string.Empty });
                ViewRooms();
                break;
            case "2":
                // View room details
                ViewRooms();
                break;
            case "3":
                // Update room details
                Console.WriteLine("Enter new room update:");
                Console.Write("Room Number: ");
                string? updateRoomNumber = Console.ReadLine();

                if (string.IsNullOrEmpty(updateRoomNumber))
                {
                    Console.WriteLine("Room number cannot be null or empty.");
                    break;
                }   
                // Check if room exists
                while (!string.IsNullOrEmpty(updateRoomNumber) && FindRoom(updateRoomNumber) == false)
                {
                    Console.Write("Room Number: ");
                    updateRoomNumber = Console.ReadLine();
                }

                Console.Write("Room Type: ");
                string? updateRoomType = Console.ReadLine();    
                Console.Write("Room Price: ");
                string? updateRoomPrice = Console.ReadLine();
                Console.Write("Room Status: ");
                string? updateRoomStatus = Console.ReadLine();

                UpdateRoom(new string[] { 
                    updateRoomNumber, 
                    updateRoomType ?? string.Empty, 
                    updateRoomPrice ?? string.Empty, 
                    updateRoomStatus ?? string.Empty 
                });
                ViewRooms();
                break;
            case "4":
                // Delete room
                Console.WriteLine("Enter room number to delete:");
                Console.Write("Room Number: ");
                string? deleteRoomNumber = Console.ReadLine();
                if (string.IsNullOrEmpty(deleteRoomNumber))
                {
                    Console.WriteLine("Room number cannot be null or empty.");
                    break;
                }   
                // Delete room
                DeleteRoom(deleteRoomNumber);
                ViewRooms();
                break;
            case "5":
                Menu();
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");                
                break;
        }
        ManageRooms();
    }
    private static void AddRoom(string[] addRoom)
    {
        // Add new room to the room availability array
        var newRoomAvailability = new string[roomAvailability.GetLength(0) + 1, roomAvailability.GetLength(1)];

        // Copy existing room availability to new array
        for (int row = 0; row < roomAvailability.GetLength(0); row++)
        {
            for (int column = 0; column < roomAvailability.GetLength(1); column++)
            {
                newRoomAvailability[row, column] = roomAvailability[row, column];
            }
        }
        // Add new room details to the last row of the new array
        for (int column = 0; column < addRoom.Length; column++)
        {
            // Assign the new room details to the last row of the new array
            newRoomAvailability[roomAvailability.GetLength(0), column] = addRoom[column];
        }
        // Assign the new array to the room availability variable
        roomAvailability = newRoomAvailability;
        Console.WriteLine("Room added successfully.");
    }
    private static void ViewRoom(string roomNumber)
    {
        for (int row = 0; row < roomAvailability.GetLength(0); row++)
        {
            if (roomAvailability[row, 0] == roomNumber)
            {
                Console.WriteLine("Number | Type       | Price            | Status");
                Console.WriteLine("===========================================================");
                Console.WriteLine($"{roomAvailability[row, 0].PadRight(6)} | {roomAvailability[row, 1].PadRight(10)} | Php {string.Format("{0:#,##0.00}", Decimal.Parse(roomAvailability[row, 2])).PadLeft(12)} | {roomAvailability[row, 3]}");
                Console.WriteLine("===========================================================");
                break;
            }            
        }
    }   

    private static bool FindRoom(string roomNumber)
    {
        for (int row = 0; row < roomAvailability.GetLength(0); row++)
        {
            if (roomAvailability[row, 0] == roomNumber)
            {                
                return true;
            }
        }
        Console.WriteLine("Room not found.");
        return false;
    } 

    private static bool IsRoomAvailable(string roomNumber)
    {
        for (int row = 0; row < roomAvailability.GetLength(0); row++)
        {
            if (roomAvailability[row, 0] == roomNumber)
            {
                if (roomAvailability[row, 3] == "Available")
                {
                    return true;
                }             
            }
        }
        return false;
    } 

    private static string RoomStatus(string roomNumber)
    {
        string status = string.Empty;
        for (int row = 0; row < roomAvailability.GetLength(0); row++)
        {
            if (roomAvailability[row, 0] == roomNumber)
            {
                status = roomAvailability[row, 3];
                break;
            }
        }
        return status;        
    } 

    private static void UpdateRoom(string[] roomDetail)
    {        
        //roomDetail = number|type|price|status

        // Add new room to the room availability array
        var newRoomAvailability = new string[roomAvailability.GetLength(0), roomAvailability.GetLength(1)];

        // Copy existing room availability to new array
        for (int row = 0; row < roomAvailability.GetLength(0); row++)
        {
            if (roomAvailability[row, 0] != roomDetail[0]) // add only if the room number is not equal to the room number to be updated
            {
                for (int column = 0; column < roomAvailability.GetLength(1); column++)
                {
                    newRoomAvailability[row, column] = roomAvailability[row, column];
                }
            } else {
                // Update the room details in the new array
                for (int column = 0; column < roomAvailability.GetLength(1); column++)
                {
                    newRoomAvailability[row, column] = roomDetail[column];
                }
            }           
        }

        // Assign the new array to the room availability variable
        roomAvailability = newRoomAvailability;
        Console.WriteLine("Room updated successfully.");
    }
    
    private static void DeleteRoom(string roomNumber)
    {   
        var newRoomAvailability = new string[roomAvailability.GetLength(0) - 1, roomAvailability.GetLength(1)];
        int newRow = 0;

        // Copy existing room availability to new array
        for (int row = 0; row < roomAvailability.GetLength(0); row++)
        {
            if (roomAvailability[row, 0] != roomNumber) // add only if the room number is not equal to the room number to be deleted
            {
                for (int column = 0; column < roomAvailability.GetLength(1); column++)
                {
                    newRoomAvailability[newRow, column] = roomAvailability[row, column];
                }
                newRow++;
            }            
        }
       
        // Assign the new array to the room availability variable
        roomAvailability = newRoomAvailability;        
        Console.WriteLine("Room deleted successfully.");
    }

    private static void GenerateReport(string reportType)
    {
        switch (reportType)
        {
            case "Daily":
                Console.Write("Enter Date[YYYY-MM-DD]: ");
                string? date = Console.ReadLine();
                if (string.IsNullOrEmpty(date))
                {
                    Console.WriteLine("Date cannot be null or empty.");
                    return;
                }
                GenerateDailyReport(date);
                break;
            case "Weekly":
                Console.Write("Enter Starting Date [YYYY-MM-DD]: ");
                string? week = Console.ReadLine();
                if (string.IsNullOrEmpty(week))
                {
                    Console.WriteLine("Date cannot be null or empty.");
                    return;
                }
                GenerateWeeklyReport(week);
                break;
            case "Monthly":
                Console.Write("Enter Month and Year [YYYY-MM]: ");
                string? month = Console.ReadLine();
                if (string.IsNullOrEmpty(month))
                {
                    Console.WriteLine("Month cannot be null or empty.");
                    return;
                }
                GenerateMonthlyReport(month);
                break;
            case "Yearly":
                Console.Write("Enter Year [YYYY]: ");
                string? year = Console.ReadLine();
                if (string.IsNullOrEmpty(year))
                {
                    Console.WriteLine("Year cannot be null or empty.");
                    return;
                }
                GenerateYearlyReport(year);
                break;
            default:
                Console.WriteLine("Invalid report type.");
                break;
        }
    }

    private static void GenerateYearlyReport(string year)
    {
         int records = 0;
         // Get all payment details by date
        Console.WriteLine("Sales Details:");
        Console.WriteLine("Room | Payment | Amount           | Date       | Transaction ID");
        Console.WriteLine("===============================================================");
        for (int row = 0; row < paymentDetails.GetLength(0); row++)
        {            
            if (DateTime.Parse(paymentDetails[row, 3]).ToString("yyyy") == year)
            {
                Console.WriteLine($"{paymentDetails[row, 0].PadRight(4)} | {paymentDetails[row, 1].PadRight(7)} | Php {string.Format("{0:#,##0.00}", Decimal.Parse(paymentDetails[row, 2])).PadLeft(8)} | {paymentDetails[row, 3]} | {paymentDetails[row, 4]}");
                records++;                
            }
        }
        Console.WriteLine("===============================================================");
        Console.WriteLine($"No. Of Records: {records}");
    }

    private static void GenerateMonthlyReport(string month)
    {
         int records = 0;
         // Get all payment details by date
        Console.WriteLine("Sales Details:");
        Console.WriteLine("Room | Payment | Amount           | Date       | Transaction ID");
        Console.WriteLine("===============================================================");
        for (int row = 0; row < paymentDetails.GetLength(0); row++)
        {
           if (DateTime.Parse(paymentDetails[row, 3]).ToString("yyyy-MM") == month)
            {
                Console.WriteLine($"{paymentDetails[row, 0].PadRight(4)} | {paymentDetails[row, 1].PadRight(7)} | Php {string.Format("{0:#,##0.00}", Decimal.Parse(paymentDetails[row, 2])).PadLeft(12)} | {paymentDetails[row, 3]} | {paymentDetails[row, 4]}");
                records++;                
            }
        }
        Console.WriteLine("===============================================================");
        Console.WriteLine($"No. Of Records: {records}");
    }

    private static void GenerateWeeklyReport(string date)
    {
         int records = 0;
         DateTime dateFrom = DateTime.Parse(date);
         DateTime dateTo = dateFrom.AddDays(7);
         // Get all payment details by date
        Console.WriteLine("Sales Details:");
        Console.WriteLine("Room | Payment | Amount           | Date       | Transaction ID");
        Console.WriteLine("===============================================================");
        for (int row = 0; row < paymentDetails.GetLength(0); row++)
        {
            DateTime transactionDate = DateTime.Parse(paymentDetails[row, 3]);
            if (transactionDate >= dateFrom && transactionDate <= dateTo)
            {
                Console.WriteLine($"{paymentDetails[row, 0].PadRight(4)} | {paymentDetails[row, 1].PadRight(7)} | Php {string.Format("{0:#,##0.00}", Decimal.Parse(paymentDetails[row, 2])).PadLeft(12)} | {paymentDetails[row, 3]} | {paymentDetails[row, 4]}");
                records++;                
            }
        }            
        Console.WriteLine("===============================================================");
        Console.WriteLine($"No. Of Records: {records}");
    }

    private static void GenerateDailyReport(string date)
    {
         int records = 0;
         // Get all payment details by date
        Console.WriteLine("Sales Details:");
        Console.WriteLine("Room | Payment | Amount           | Date       | Transaction ID");
        Console.WriteLine("===============================================================");
        for (int row = 0; row < paymentDetails.GetLength(0); row++)
        {
            if (DateTime.Parse(paymentDetails[row, 3]).ToString("yyyy-MM-dd") == date)
            {
                Console.WriteLine($"{paymentDetails[row, 0].PadRight(4)} | {paymentDetails[row, 1].PadRight(7)} | Php {string.Format("{0:#,##0.00}", Decimal.Parse(paymentDetails[row, 2])).PadLeft(12)} | {paymentDetails[row, 3]} | {paymentDetails[row, 4]}");
                records++;                
            }        
        }
        Console.WriteLine("===============================================================");
        Console.WriteLine($"No. Of Records: {records}");
    }
}
