using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class Developer_Repo
    {
        //Create fake Database
        private readonly List<Developer> _devoloperDatabase = new List<Developer>();
        //ID Counter implement
        private int _count;
        //C.R.U.D.
        //Create
        public bool AddDeveloperToDatabase(Developer developer)
        {
            if(developer != null)
            {
                _count++;
                developer.ID=_count;
                _devoloperDatabase.Add(developer);
                return true;
            }
            else
            {
                return false;
            }
        }
        //Read gives user list of all developers
        public List<Developer> GetAllDevelopers()
        {
            return _devoloperDatabase;
        }
        //Read gives user a single deveolper by ID
        public Developer GetDeveloperByID(int id)
        {
            foreach(var developer in _devoloperDatabase)
            {
                if(developer.ID == id)
                    {
                        return developer;
                    }
            }
            return null;
        }

        //Update updates exisiting Developer in Database.
        public bool UpdateDeveloperData (int developerID, Developer newDeveoloperData)
        {
            Developer oldDeveolperData = GetDeveloperByID(developerID);

            if(oldDeveolperData != null)
            {
                oldDeveolperData.FirstName = newDeveoloperData.FirstName;
                oldDeveolperData.LastName = newDeveoloperData.LastName;
                oldDeveolperData.PluralSight = newDeveoloperData.PluralSight;
                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete

        public bool DeleteDeveloperData (int id)
        {
            var developer = GetDeveloperByID(id);
            if(developer != null)
            {
                _devoloperDatabase.Remove(developer);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
