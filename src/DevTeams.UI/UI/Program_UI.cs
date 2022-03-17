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
                "4. Update Developer Data\n" +
                "5. Delete Developer Data\n" +
                "-------------------------------\n" +
                "== DevTeam Database ==\n" +
                "6. Add DevTeam to Database\n" +
                // Add/Remove Deveolper from team
                // Add/Remove Multiple Deveolpers from a team
                "7. View All DevTeams\n" +
                "8. View DevTeam by ID\n" +
                "9. Update DevTeam Data\n" +
                "10. Delete DevTeam Data\n" +
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
                        UpdateDeveloperData();
                        break;
                    case "5":
                        DeleteDeveloperData();
                        break;
                    case "6":
                        AddDevTeamToDatabase();
                        break;
                    case "7":
                        ViewAllDevTeams();
                        break;
                    case "8":
                        ViewDevTeamByID();
                        break;
                    case "9":
                        UpdateDevTeamData();
                        break;
                    case "10":
                        DeleteDevTeamData();
                        break;
                    case "00":
                        CloseApplication();
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
        System.Console.WriteLine("Press Any To Continue");
        Console.ReadKey();
    }

    private void DeleteDevTeamData()
    {
        throw new NotImplementedException();
    }

    private void UpdateDevTeamData()
    {
        throw new NotImplementedException();
    }

    private void ViewDevTeamByID()
    {
        throw new NotImplementedException();
    }

    private void ViewAllDevTeams()
    {
        throw new NotImplementedException();
    }

    private void AddDevTeamToDatabase()
    {
        throw new NotImplementedException();
    }

    private void DeleteDeveloperData()
    {
        throw new NotImplementedException();
    }

    private void UpdateDeveloperData()
    {
        throw new NotImplementedException();
    }

    private void ViewDeveloperByID()
    {
        throw new NotImplementedException();
    }

    private void ViewAllDevelopers()
    {
        throw new NotImplementedException();
    }

    private void AddDeveloperToDatabase()
    {
        throw new NotImplementedException();
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
