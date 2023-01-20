using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewProject.Models
{
    public class Location
    {
        public string LocationKey { get; }
        public string Name { get; }

        public Location(string locationKey, string name)
        {
            LocationKey = locationKey;
            Name = name;
        }
    }
}
