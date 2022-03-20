using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class Program_UI
    {
        private readonly Developer_Repo _dRepo = new Developer_Repo();
        private readonly DevTeam_Repo _dTeamRepo = new DevTeam_Repo();

        public void Run()
        {
            SeedData();
            RunApplication();
        }
        
        private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                System.Console.WriteLine("=== Komodo Insurance Developer Team Management Application === ");
                System.Console.WriteLine("Please Make a Selection: \n" +
                "== Developer Database ==\n" +
                "1. Add Developer to Database\n" +
                "2. View All Developers\n" +
                "3. View Developer by ID\n" +
                "-------------------------------\n" +
                "== DevTeam Database ==\n" +
                "4. Add DevTeam to Database\n" +
                // Add/Remove Deveolper from team
                // Add/Remove Multiple Deveolpers from a team
                "5. View All DevTeams\n" +
                "6. View DevTeam by ID\n" +
                "7. Update DevTeam Data\n" +
                "8. Delete DevTeam Data\n" +
                "-------------------------------\n" +
                "00. Close Application");

                var userInput = Console.ReadLine();

                switch(userInput)
                {
                    case "1":
                        AddDeveloperToDatabase();
                        break;
                    case "2":
                        ViewAllDevelopers();
                        break;
                    case "3":
                        ViewDeveloperByID();
                        break;
                    case "4":
                        AddDevTeamToDatabase();
                        break;
                    case "5":
                        ViewAllDevTeams();
                        break;
                    case "6":
                        ViewDevTeamByID();
                        break;
                    case "7":
                        UpdateDevTeamData();
                        break;
                    case "8":
                        DeleteDevTeamData();
                        break;
                    case "00":
                        isRunning = CloseApplication();
                        break;
                        default:
                        System.Console.WriteLine("Ivalid Selection");
                        PressAnyKeyToContinue();
                        break;
                }
            }
        }

    private bool CloseApplication()
    {
        Console.Clear();
        System.Console.WriteLine("Thank you, Have a Nice Day!");
        PressAnyKeyToContinue();
        return false;
    }

    private void PressAnyKeyToContinue()
    {
        System.Console.WriteLine("Press Any Key To Continue");
        Console.ReadKey();
    }

    private void DeleteDevTeamData()
    {
        Console.Clear();
        System.Console.WriteLine("== DevTeam Removal Page ==");

        var devTeams = _dTeamRepo.GetAllDevTeams();
        foreach(DevTeam devTeam in devTeams)
        {
            DisplayDevTeamListing(devTeam);
        }

        try
        {
            System.Console.WriteLine("Please select a DevTeam by its ID: ");
            var userInputSelectedDevTeam = int.Parse(Console.ReadLine());
            bool isSuccesful = _dTeamRepo.DeleteDevTeamData(userInputSelectedDevTeam);
            if(isSuccesful)
            {
                System.Console.WriteLine("DevTeam was Succesfully Deleted.");
            }
            else
            {
                System.Console.WriteLine("Store Failed to be Deleted.");
            }
        }

        catch 
        {
            System.Console.WriteLine("Sorry, Ivalid Selection");
        }

        PressAnyKeyToContinue();
    }

    private void DisplayDevTeamListing(DevTeam devTeam)
    {
        System.Console.WriteLine($" DevTeam ID: {devTeam.ID}\n DevTeam Name: {devTeam.Name}\n" +
        "-------------------------------------------------\n");

    }

    private void UpdateDevTeamData()
    {
        Console.Clear();
        var availDevTeams = _dTeamRepo.GetAllDevTeams();
        foreach(var devTeam in availDevTeams)
        {
            DisplayDevTeamListing(devTeam);
        }

        System.Console.WriteLine("Please enter a valid DevTeam ID: ");
        var userInputDevTeamID = int.Parse(Console.ReadLine());
        var userSelectedDevTeam = _dTeamRepo.GetDevTeamByID(userInputDevTeamID);

        if(userSelectedDevTeam != null)
        {
            Console.Clear();
            var newDevTeam = new DevTeam();

            var currentDeveloper = _dRepo.GetAllDevelopers();

            System.Console.WriteLine("Please enter a DevTeam Name: ");
            newDevTeam.Name = Console.ReadLine();

            bool hasAssignedDeveloper = false;
            while(!hasAssignedDeveloper)
            {
                System.Console.WriteLine("Do you want to add any Deveolpers? y/n");
                var userInputHasDevelopers = Console.ReadLine();

                if(userInputHasDevelopers == "Y".ToLower())
                {
                    foreach(var developer in currentDeveloper)
                    {
                        System.Console.WriteLine($"{developer.ID} {developer.FirstName} {developer.LastName} {developer.PluralSight}");
                    }
                    

                    var userInputHasDevelopersSelection = int.Parse(Console.ReadLine());
                    var selectedDeveloper = _dRepo.GetDeveloperByID(userInputHasDevelopersSelection);

                    if(selectedDeveloper != null)
                    {
                        newDevTeam.Developers.Add(selectedDeveloper);
                        currentDeveloper.Remove(selectedDeveloper);
                    }
                    else
                    {
                        System.Console.WriteLine($"Sorry, the developer with the ID: {userInputHasDevelopersSelection} doesn't exist.");
                    }
                }
                else
                {
                    hasAssignedDeveloper = true;
                }
            }
                var isSuccesful = _dTeamRepo.UpdateDevTeamData(userSelectedDevTeam.ID,newDevTeam);
                if(isSuccesful)
                {
                    System.Console.WriteLine("SUCCESS!");
                }
                else
                {
                    System.Console.WriteLine("FAILURE!");
                }
        }
        else
        {
            System.Console.WriteLine($"Sorry the DevTeam with the ID: {userInputDevTeamID} doesn't exist.");
        }
        PressAnyKeyToContinue();
    }

    private void ViewDevTeamByID()
    {
        Console.Clear();
        System.Console.WriteLine("=== DevTeam Details ===\n");

        var devTeams = _dTeamRepo.GetAllDevTeams();
        foreach(DevTeam devTeam in devTeams)
        {
            DisplayDevTeamListing(devTeam);
        }

        try
        {
            System.Console.WriteLine("Please select a DevTeam by its ID: ");
            var userInputSelectedDevTeam = int.Parse(Console.ReadLine());
            var selectedDevTeam = _dTeamRepo.GetDevTeamByID(userInputSelectedDevTeam);
            if(selectedDevTeam != null)
            {
                DisplayDevTeamDetails(selectedDevTeam);
            }
            else
            {
                System.Console.WriteLine($"Sorry the selected DevTeam with the ID: {userInputSelectedDevTeam} dosen't exist. ");
            }
        }
        catch
        {
            System.Console.WriteLine("Sorry, Invalid selection.");
        }

        PressAnyKeyToContinue();
    }

    private void DisplayDevTeamDetails(DevTeam selectedDevTeam)
    {
        Console.Clear();
        System.Console.WriteLine($"DevTeam ID: {selectedDevTeam.ID}\n" + 
        $"DevTeam Name: {selectedDevTeam.Name}\n");

        try
        {
            System.Console.WriteLine("-- Devolpers --");
            if(selectedDevTeam.Developers.Count > 0 )
            {
                foreach(var developer in selectedDevTeam.Developers)
                {
                    DisplayDeveloperInfo(developer);
                }
            }
            else
            {
                System.Console.WriteLine("There are no Developers");
            }
        }
        catch
        {
            System.Console.WriteLine("Sorry, Invalid selection.");
        }
    }


    private void ViewAllDevTeams()
    {
        Console.Clear();
        System.Console.WriteLine("=== DevTeam Listing ===\n");
        var devTeamInDb = _dTeamRepo.GetAllDevTeams();

        foreach(var devTeam in devTeamInDb)
        {
            DisplayDevTeamListing(devTeam);
        }
        PressAnyKeyToContinue();
    }

    private void AddDevTeamToDatabase()
    {
        Console.Clear();
        var newDevTeam = new DevTeam();

        var currentDeveloper = _dRepo.GetAllDevelopers();

        System.Console.WriteLine("Please enter a DevTeam Name: ");
            newDevTeam.Name = Console.ReadLine();

            bool hasAssignedDeveloper = false;
            while(!hasAssignedDeveloper)
            {
                System.Console.WriteLine("Do you want to add any Deveolpers? y/n");
                var userInputHasDevelopers = Console.ReadLine();

                if(userInputHasDevelopers == "Y".ToLower())
                {
                    foreach(var developer in currentDeveloper)
                    {
                        System.Console.WriteLine($"{developer.ID} {developer.FirstName} {developer.LastName} {developer.PluralSight}");
                    }
                    

                    var userInputHasDevelopersSelection = int.Parse(Console.ReadLine());
                    var selectedDeveloper = _dRepo.GetDeveloperByID(userInputHasDevelopersSelection);

                    if(selectedDeveloper != null)
                    {
                        newDevTeam.Developers.Add(selectedDeveloper);
                        currentDeveloper.Remove(selectedDeveloper);
                    }
                    else
                    {
                        System.Console.WriteLine($"Sorry, the developer with the ID: {userInputHasDevelopersSelection} doesn't exist.");
                    }
                }
                else
                {
                    hasAssignedDeveloper = true;
                }
            }

            bool isSuccesful = _dTeamRepo.AddDevTeamToDatabase(newDevTeam);
            if(isSuccesful)
            {
                System.Console.WriteLine($"Store: {newDevTeam.Name} was Added to the Database.");
            }
            else
            {
                System.Console.WriteLine("Store was failed to be Added to the Database.");
            }
            PressAnyKeyToContinue();
    }

    private void DisplayDeveloperInfo(Developer developer)
    {
        System.Console.WriteLine($"Developer ID: {developer.ID}\n" +
        $"Developer Name: {developer.FirstName} {developer.LastName}\n" +
        $"PluralSight access: {developer.PluralSight}\n" +
        "------------------------------\n");
    }

    private void ViewDeveloperByID()
    {
        Console.Clear();
        System.Console.WriteLine("=== Developer Detail Menu ===\n");
        System.Console.WriteLine("Please enter a Developer ID: \n");
        var userInputDeveloperID = int.Parse(Console.ReadLine());

        var developer =  _dRepo.GetDeveloperByID(userInputDeveloperID);
        try
        {
            if(developer != null)
            {
                DisplayDeveloperInfo(developer);
            }
            else
            {
                System.Console.WriteLine($"The Developer with the ID: {userInputDeveloperID} doesn't exist");
            }
        }
        catch
        {
            System.Console.WriteLine("Sorry, Invalid selection.");
        }
        PressAnyKeyToContinue();
    }

    private void ViewAllDevelopers()
    {
        Console.Clear();
        List<Developer> developersInDb = _dRepo.GetAllDevelopers();

        try
        {
            if(developersInDb.Count > 0)
            {
                foreach(Developer developer in developersInDb)
                {
                    DisplayDeveloperInfo(developer);
                }
            }
            else
            {
                System.Console.WriteLine("There are no Developers.");
            }
        }
        catch
        {
            System.Console.WriteLine("Sorry, Invalid selection.");
        }
        PressAnyKeyToContinue();
    }

    private void AddDeveloperToDatabase()
    {
        Console.Clear();
        var newDeveloper = new Developer();

        try
        {
            System.Console.WriteLine("=== Developer Enlisting Form ===\n");

            System.Console.WriteLine("Please enter a Developer First Name: ");
            newDeveloper.FirstName = Console.ReadLine();

            System.Console.WriteLine("Please enter a Developer Last Name: ");
            newDeveloper.LastName = Console.ReadLine();

            System.Console.WriteLine("Does this Developer have access to PluralSight (true/false):  ");
            newDeveloper.PluralSight = Convert.ToBoolean(Console.ReadLine()); 

            bool isSuccesful = _dRepo.AddDeveloperToDatabase(newDeveloper);
            if(isSuccesful)
            {
                System.Console.WriteLine($"{newDeveloper.FirstName} - {newDeveloper.LastName} : PluralSight {newDeveloper.PluralSight} was added to the Database");
            }
            else
            {
                System.Console.WriteLine("Developer Failed to be Added to the Database.");
            }
        }
        catch
        {
            System.Console.WriteLine("Sorry, Invalid selection.");
        }

        PressAnyKeyToContinue();
    }

    private void SeedData ()
        {
            //Create Developers
            var john = new Developer("John","Doe", true);
            var jane = new Developer("Jane","Doe", true);
            var person = new Developer("Person","People", false);
            var human = new Developer("Human","Being", false);

            //add to _dRepo
            _dRepo.AddDeveloperToDatabase(john);
            _dRepo.AddDeveloperToDatabase(jane);
            _dRepo.AddDeveloperToDatabase(person);
            _dRepo.AddDeveloperToDatabase(human);

            //create devTeams
            var alpha = new DevTeam("Team Alpha",
            new List<Developer>
            {
                john,
                person
            });
            var beta = new DevTeam("Team Beta",
            new List<Developer>
            {
                jane,
                human
            });

            //add to _dTeamRepo
            _dTeamRepo.AddDevTeamToDatabase(alpha);
            _dTeamRepo.AddDevTeamToDatabase(beta);
        }
    }
