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
            List<Properties> allProperties = new List<Properties>(); 
            foreach(Feature feature in JSON)
            {
                allNeighborhoods.Add(feature.Property.Neighborhood);
                allProperties.Add(feature.Property);
                //Console.Write(feature.Property.Neighborhood + "; ");
            }
            //Console.WriteLine(JSON.Features[0].Property.Neighborhood);
            List<string> filterNeighborhoods = new List<string>();
            //filterNeighborhoods = AnswerLinqQuestionOne(allNeighborhoods);
            filterNeighborhoods = AnswerLinqQuestionOne(allProperties);
            Console.WriteLine(filterNeighborhoods.Count + " neighborhoods returned from the first query.\n");
            filterNeighborhoods = AnswerLinqQuestionTwo(filterNeighborhoods);
            Console.WriteLine(filterNeighborhoods.Count + " neighborhoods returned from the second query.\n");
            filterNeighborhoods = AnswerLinqQuestionThree(filterNeighborhoods);
            Console.WriteLine(filterNeighborhoods.Count + " neighborhoods returned from the third query.\n");
            List<string> filterAllAtOnceNeighborhoods = new List<string>();
            filterAllAtOnceNeighborhoods = AnswerLinqQuestionFour(allProperties);
            Console.WriteLine(filterNeighborhoods.Count + " neighborhoods returned from the fourth query.\n");
        }

        static List<string> AnswerLinqQuestionOne(List<Properties> data)
        {
            Console.WriteLine("What are all of the neighborhoods in this data list, including duplicates and null values?");
            var results = from property in data
                          select property.Neighborhood;

            List<string> filteredNeighborhoods = new List<string>();
            foreach (string place in results)
            {
                Console.Write(place + "; ");
                filteredNeighborhoods.Add(place);
            }
            Console.WriteLine("\n");
            return filteredNeighborhoods;
        }

        static List<string> AnswerLinqQuestionOne(List<string> data)
        {
            Console.WriteLine("What are all of the neighborhoods in this data list, including duplicates and null values?");
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

        static List<string> AnswerLinqQuestionTwo(List<string> data)
        {
            Console.WriteLine("What are all of the neighborhoods in this data list, including duplicates?");
            IEnumerable<string> results = from neighborhood in data
                                          where neighborhood != ""
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

        static List<string> AnswerLinqQuestionThree(List<string> data)
        {
            Console.WriteLine("What are all of the neighborhoods in this data list?");
            IEnumerable<string> dataDistinct = data.Distinct();
            IEnumerable<string> results = from neighborhood in dataDistinct
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

        static List<string> AnswerLinqQuestionFour(List<Properties> data)
        {
            Console.WriteLine("What are all of the neighborhoods in this data list? Only use one query to do this.");
            //IEnumerable<string> dataDistinct = data.Distinct();
            IEnumerable<string> results = from properties in data
                                          where properties.Neighborhood != ""
                                          select properties.Neighborhood;

            List<string> nonNullNeighborhoods = new List<string>();
            foreach (string place in results)
            {
                nonNullNeighborhoods.Add(place);
            }
            IEnumerable<string> nonNullDistinctNeighborhoods = nonNullNeighborhoods.Distinct();
            List<string> filteredNeighborhoods = new List<string>();
            foreach ( string neighborhood in nonNullDistinctNeighborhoods)
            {
                Console.Write(neighborhood + "; ");
                filteredNeighborhoods.Add(neighborhood);
            }
            Console.WriteLine("\n");
            return filteredNeighborhoods;
        }
    }
}
