using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class DevTeam_Repo
    {
        //Create Fake Database
        private readonly List<DevTeam> _devTeamDatabase = new List<DevTeam>();

        //Implement Counter
        private int _count = 0;

        //Create create DevTeam
        public bool AddDevTeamToDatabase(DevTeam devTeam)
        {
            if(devTeam != null)
            {
                _count++;
                devTeam.ID=_count;
                _devTeamDatabase.Add(devTeam);
                return true;
            }
            else
            {
                return false;
            }
        }
        //Read gives usse all DevTeams
        public List<DevTeam> GetAllDevTeams()
        {
            return _devTeamDatabase;
        }

        //Read
        public DevTeam GetDevTeamByID(int id)
        {
            foreach(var devTeam in _devTeamDatabase)
            {
                if(devTeam.ID == id)
                {
                    return devTeam;
                }
            }
            return null;
        }

        //Update
        public bool UpdateDevTeamData(int devTeamID, DevTeam newDevTeamData)
        {
            DevTeam oldDevTeamData = GetDevTeamByID(devTeamID);

            if(oldDevTeamData != null)
            {
                oldDevTeamData.Name = newDevTeamData.Name;
                oldDevTeamData.Developers = newDevTeamData.Developers;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool DeleteDevTeamData (int id)
        {
            DevTeam devTeam = GetDevTeamByID(id);
            if(devTeam != null)
            {
                _devTeamDatabase.Remove(devTeam);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
