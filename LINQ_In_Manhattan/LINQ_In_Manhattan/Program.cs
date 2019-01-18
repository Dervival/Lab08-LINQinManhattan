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
            SerializedJSON JSON = TranslateJObjectIntoSerializedJSON(Json);
            AskAllQuestions(JSON);
        }
        /// <summary>
        /// Translates the object created by the NewtonSoft.JSON library into the classes for this project.
        /// </summary>
        /// <param name="Json">JObject created by NewtonSoft parsing of the json file provided</param>
        /// <returns>Translated object representing the JSON in the json provided</returns>
        static SerializedJSON TranslateJObjectIntoSerializedJSON(JObject Json)
        {
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
            }
            SerializedJSON JSON = new SerializedJSON(jsonType, features);
            return JSON;
        }

        /// <summary>
        /// Asks and answers all five questions required by the lab. QueryOne contains all neighborhoods from the JSON file, including duplicates and empty strings. QueryTwo contains all non-null neighborhoods from queryOne, including duplicates. QueryThree contains all unique neighborhoods from queryTwo. QueryFour duplicates the results from queryThree while only using one query. QueryFive duplicates the results from queryFour using a lambda expression. 
        /// </summary>
        /// <param name="json">The object created from the JSON file provided. Only requirement for this object is that it contains an enumerable collection of Feature objects, each of which has a Neighborhood property.</param>
        static void AskAllQuestions(SerializedJSON json)
        {
            //Pulling just the properties from the object
            List<Properties> allProperties = new List<Properties>();
            foreach (Feature feature in json)
            {
                allProperties.Add(feature.Property);
            }
            int neighborhoodCount = 0;

            //Answering question 1
            Console.WriteLine("What are all of the neighborhoods in this data list, including duplicates and null values?");
            var queryOne = from property in allProperties
                           select property.Neighborhood;

            foreach (string place in queryOne)
            {
                Console.Write(place + "; ");
                neighborhoodCount++;
            }
            Console.WriteLine("\n");
            Console.WriteLine(neighborhoodCount + " neighborhoods returned from the first query.\n");

            //Answering question 2
            neighborhoodCount = 0;
            Console.WriteLine("What are all of the neighborhoods in this data list, including duplicates?");
            var queryTwo = from neighborhood in queryOne
                           where neighborhood != ""
                           select neighborhood;

            foreach (string place in queryTwo)
            {
                Console.Write(place + "; ");
                neighborhoodCount++;
            }
            Console.WriteLine("\n");
            Console.WriteLine(neighborhoodCount + " neighborhoods returned from the second query.\n");

            //Answering question 3
            neighborhoodCount = 0;
            Console.WriteLine("What are all of the neighborhoods in this data list?");
            var queryThree = queryTwo.Distinct();

            foreach (string place in queryThree)
            {
                Console.Write(place + "; ");
                neighborhoodCount++;
            }
            Console.WriteLine("\n");
            Console.WriteLine(neighborhoodCount + " neighborhoods returned from the third query.\n");

            //Answering question 4
            neighborhoodCount = 0;
            Console.WriteLine("What are all of the neighborhoods in this data list? Only use one query to do this.");
            var queryFour = from properties in allProperties
                            where properties.Neighborhood != ""
                           select properties.Neighborhood;

            foreach (string place in queryFour.Distinct())
            {
                Console.Write(place + "; ");
                neighborhoodCount++;
            }
            Console.WriteLine("\n");
            Console.WriteLine(neighborhoodCount + " neighborhoods returned from the fourth query.\n");

            //Answering question 5
            neighborhoodCount = 0;
            Console.WriteLine("What are all of the neighborhoods in this data list? Use a lambda function isntead of a query to do this.");
            //Implementation of .Where lambda function from https://stackoverflow.com/questions/15253548/filtering-a-list-of-objects-with-a-certain-attribute
            var queryFive = allProperties.Where(property => property.Neighborhood != "");

            List<string> nonNullNeighborhoods = new List<string>();
            foreach (Properties place in queryFive)
            {
                nonNullNeighborhoods.Add(place.Neighborhood);
            }
            foreach (string neighborhood in nonNullNeighborhoods.Distinct())
            {
                Console.Write(neighborhood + "; ");
                neighborhoodCount++;
            }
            Console.WriteLine("\n");
            Console.WriteLine(neighborhoodCount + " neighborhoods returned from the fifth query.\n");
        }
    }
}
