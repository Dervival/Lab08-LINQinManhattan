using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using LINQ_In_Manhattan.Classes;

namespace LINQ_In_Manhattan
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Console.WriteLine("Hello World!");
            JObject Json = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(@"../../../../../data.json"));
            //at this point the JObject can probably be operated on, but let's force it into our classes instead
            string jsonType = (string)Json["type"];
            List<Feature> features = new List<Feature>();
            foreach (JToken feature in Json["features"])
            {
                    //type
                    string featType = (string)feature["type"];
                    //geometry
                    string geoType = (string)feature["geometry"]["type"];
                    //coordinates
                    double longitude = (double)feature["geometry"]["coordinates"][0];
                    double latitude = (double)feature["geometry"]["coordinates"][1];
                    Coords coordinates = new Coords(longitude, latitude);
                    Geometry geometry = new Geometry(geoType, coordinates);

                    //properties
                    string zip = (string)feature["properties"]["zip"];
                    string city = (string)feature["properties"]["city"];
                    string state = (string)feature["properties"]["state"];
                    string address = (string)feature["properties"]["address"];
                    string borough = (string)feature["properties"]["borough"];
                    string neighborhood = (string)feature["properties"]["neighborhood"];
                    string country = (string)feature["properties"]["country"];
                    Properties property = new Properties(zip, city, state, address, borough, neighborhood, country);
                    Feature feat = new Feature(featType, geometry, property);
                    features.Add(feat);
                    //Console.WriteLine(property.Neighborhood);
                    //feature["properties"];
                    //Console.WriteLine(feature);
            }
            SerializedJSON JSON = new SerializedJSON(jsonType, features);
            List<string> allNeighborhoods = new List<string>();
            foreach(Feature feature in JSON)
            {
                allNeighborhoods.Add(feature.Property.Neighborhood);
                //Console.Write(feature.Property.Neighborhood + "; ");
            }
            //Console.WriteLine(JSON.Features[0].Property.Neighborhood);
            List<string> filterNeighborhoods = new List<string>();
            filterNeighborhoods = AnswerLinqQuestionOne(allNeighborhoods);
            Console.WriteLine(filterNeighborhoods.Count + " neighborhoods returned from the first query.");
        }

        static List<string> AnswerLinqQuestionOne(List<string> data)
        {
            Console.WriteLine("What all of the neighborhoods in this data list, including duplicates and null values?");
            IEnumerable<string> results = from neighborhood in data
                                          select neighborhood;

            List<string> filteredNeighborhoods = new List<string>();
            foreach (string place in results)
            {
                Console.Write(place + "; ");
                filteredNeighborhoods.Add(place);
            }
            Console.WriteLine("\n");
            return filteredNeighborhoods;
        }
    }
}
