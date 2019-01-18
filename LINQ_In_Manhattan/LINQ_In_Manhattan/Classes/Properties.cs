using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_In_Manhattan.Classes
{
    public class Properties
    {
        public string Zip { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string Borough { get; set; }
        public string Neighborhood { get; set; }
        public string Country { get; set; }

        public Properties(string zip, string city, string state, string address, string borough, string neighborhood, string country)
        {
            Zip = zip;
            City = city;
            State = state;
            Address = address;
            Borough = borough;
            Neighborhood = neighborhood;
            Country = country;
        }
    }
}
