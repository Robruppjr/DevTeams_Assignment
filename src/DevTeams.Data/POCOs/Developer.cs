using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class Developer
    {
        public Developer(){}

        public Developer(string firstName, string lastName, bool pluralSight)
        {
            FirstName = firstName;
            LastName = lastName;
            PluralSight = pluralSight;
        }

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool PluralSight { get; set; }
    }
