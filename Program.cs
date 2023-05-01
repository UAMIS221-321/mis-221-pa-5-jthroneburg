using mis_221_pa_5_jthroneburg;

//TODO
//reports
//test logs
//ipo

Trainer[] trainers = new Trainer[50];
Listing[] listings = new Listing[50];
Booking[] bookings = new Booking[50];
TrainerUtility Tutility = new TrainerUtility(trainers);
ListingUtility Lutility = new ListingUtility(listings);
BookingUtility Butility = new BookingUtility(listings);
Reports reports = new Reports(bookings);

int userChoice = GetUserChoice();
while (userChoice != 5) {
    RouteEm(userChoice);
    userChoice = GetUserChoice();
}

//first menu
static int GetUserChoice() {
    DisplayMenu();
    string userChoice = Console.ReadLine();
    if(userChoice == "1" || userChoice == "2" || userChoice == "3"|| userChoice == "4" || userChoice == "5") {
        return int.Parse(userChoice);
    }
    return 0;
}   

static void DisplayMenu() {
    Console.Clear();
    System.Console.WriteLine("Enter 1 to manage trainer data\nEnter 2 to manage listing data\nEnter 3 to manage customer booking data\nEnter 4 to run reports\nEnter 5 to exit");
}

void RouteEm(int menuChoice) {
    if(menuChoice == 1) {
        RouteEmTrainer();
        PauseAction();
    }
    else if(menuChoice == 2) {
        RouteEmListing();
        PauseAction();
    }
    else if(menuChoice == 3) {
        Lutility.GetAllListings();
        Lutility.PrintAllListings(); 
        System.Console.WriteLine("Please enter the id of the listing you would like to book.");
        int searchId = int.Parse(Console.ReadLine());
        int searchVal = Butility.FindListing(searchId);
        Butility.BookListing(searchVal);
        PauseAction();
    }
    else if(menuChoice == 4) {
        RouteEmReports(); //routem reports
        PauseAction();
    }
    else if (menuChoice != 5) {
        PrintInvalid();
        PauseAction();
    } 
}

static void PrintInvalid() {
    System.Console.WriteLine("Invalid choice!");
}

static void PauseAction() {
    System.Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}

//once manage trainer is selected
 void RouteEmTrainer() {
    System.Console.WriteLine("Press 1 to add a trainer\nPress 2 to edit a trainer\nPress 3 to delete a trainer\nPress 4 to exit");
    int userChoiceTrainer = int.Parse(Console.ReadLine());
    while(userChoiceTrainer != 4) {
        if(userChoiceTrainer == 1) {
            Tutility.GetAllTrainers();
            Tutility.AddTrainer();
        }
        else if(userChoiceTrainer == 2) {
            Tutility.GetAllTrainers();
            Tutility.UpdateTrainer();
        }
        else if(userChoiceTrainer == 3) { //probably should have put this in another 
        Tutility.GetAllTrainers();
        Tutility.PrintAllTrainers(); 
        System.Console.WriteLine("Please enter the id of the trainer you would like to delete.");
        int searchId = int.Parse(Console.ReadLine());
        int searchVal = Tutility.FindTrainer(searchId);
        Tutility.DeleteTrainer(searchVal);
        PauseAction();
        }
        else if (userChoiceTrainer != 4) {
            PrintInvalid();
        } 
        System.Console.WriteLine("Press 1 to add a trainer\nPress 2 to edit a trainer\nPress 3 to delete a trainer\nPress 4 to exit");
        userChoiceTrainer = int.Parse(Console.ReadLine());
    }
}

//once manage listing is selected
 void RouteEmListing() {
    System.Console.WriteLine("Press 1 to add a listing\nPress 2 to edit a listing\nPress 3 to delete a listing\nPress 4 to exit");
    int userChoiceTrainer = int.Parse(Console.ReadLine());
    while(userChoiceTrainer != 4) {
        if(userChoiceTrainer == 2) {
            Lutility.GetAllListings();
            Lutility.UpdateListing();
        }
        else if(userChoiceTrainer == 1) {
            Lutility.GetAllListings();
            Lutility.AddListing();
        }
        else if(userChoiceTrainer == 3) { //once again should have done this in a method
        Lutility.GetAllListings();
        Lutility.PrintAllListings(); 
        System.Console.WriteLine("Please enter the id of the listing you would like to delete.");
        int searchId = int.Parse(Console.ReadLine());
        int searchVal = Lutility.Find(searchId); 
        Lutility.DeleteListing(searchVal);
        PauseAction();
        }
        else if (userChoiceTrainer != 4) {
            PrintInvalid();
        } 
        System.Console.WriteLine("Press 1 to add a listing\nPress 2 to edit a listing\nPress 3 to delete a listing\nPress 4 to exit");
        userChoiceTrainer = int.Parse(Console.ReadLine());
    }
}

void RouteEmReports() {
    System.Console.WriteLine("Press 1 to access individual customer reports\nPress 2 to access historical customer sessions\nPress 3 to access a historical revenue report");
    int userChoiceReports = int.Parse(Console.ReadLine());
    if(userChoiceReports == 1) {
        System.Console.WriteLine("Please enter the email of the customer you would like to see data from.");
        string email = Console.ReadLine();
        reports.IndividualSessions(email);
    }
    else if(userChoiceReports == 2) { //all sessions by customer then date 
       reports.Sort();
       Butility.PrintAllBookings();
       reports.SessionsPerCustomer();
    }
    else if (userChoiceReports == 3) {  //revenue by month and year
        reports.SortRevenue();
        Butility.PrintAllBookings();
    }
}




