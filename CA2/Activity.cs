using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    public enum ActivityType { Air, Water, Land}
    class Activity :IComparable
    {
        //Properties
        public string Name { get; set; }

        public DateTime ActivityDate { get; set; }

        public decimal Cost { get; set; }

        public ActivityType TypeOfActivity { get; set; }

        public string _description;

        public static decimal TotalCost;

        //ctors
         public string Description
        {
            get { return _description + " " + Cost;  }
            set
            {
                _description = value;
            }
        }
        public Activity(string name, DateTime activityDate, decimal cost, ActivityType activityType, string description)
        {
            Name = name;
            ActivityDate = activityDate;
            Cost = cost;
            TypeOfActivity = activityType;
            Description = description;

            TotalCost += cost;
        }

        public Activity()
        {
        }

        //method

        public override string ToString()
        {
            return $"{Name} - {ActivityDate}";
        }

        public int CompareTo(object obj)
        {
            return ActivityDate.CompareTo(obj);
        }
    }
}
