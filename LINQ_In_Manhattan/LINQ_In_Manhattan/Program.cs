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
            ////All we need for this lab is the list of properties from the object
            //List<Properties> allProperties = new List<Properties>(); 
            //foreach(Feature feature in JSON)
            //{
            //    allProperties.Add(feature.Property);
            //}
            ////filterNeighborhoods used for questions 1-3; each question builds on the result of the previous
            //List<string> filterNeighborhoods = new List<string>();
            //filterNeighborhoods = AnswerLinqQuestionOne(allProperties);
            //Console.WriteLine(filterNeighborhoods.Count + " neighborhoods returned from the first query.\n");
            //filterNeighborhoods = AnswerLinqQuestionTwo(filterNeighborhoods);
            //Console.WriteLine(filterNeighborhoods.Count + " neighborhoods returned from the second query.\n");
            //filterNeighborhoods = AnswerLinqQuestionThree(filterNeighborhoods);
            //Console.WriteLine(filterNeighborhoods.Count + " neighborhoods returned from the third query.\n");

            ////for the fourth question, do all actions with one query instead of three
            //List<string> filterAllAtOnceNeighborhoods = new List<string>();
            //filterAllAtOnceNeighborhoods = AnswerLinqQuestionFour(allProperties);
            //Console.WriteLine(filterAllAtOnceNeighborhoods.Count + " neighborhoods returned from the fourth query.\n");

            ////for the fifth question, do all actions with a lambda expression
            //List<string> filterAllAtOnceNeighborhoodsViaLambda = new List<string>();
            //filterAllAtOnceNeighborhoodsViaLambda = AnswerLinqQuestionFive(allProperties);
            //Console.WriteLine(filterAllAtOnceNeighborhoodsViaLambda.Count + " neighborhoods returned from the fifth query.\n");
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
        /// Answers the first question of the lab - listing out all neighborhoods regardless of empty fields or duplicates
        /// </summary>
        /// <param name="data">List of properties representing a portion of the JSON file.</param>
        /// <returns>A list of strings of unfiltered neighborhoods</returns>
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

        /// <summary>
        /// Given a list of strings representing neighborhoods, filter out null values.
        /// </summary>
        /// <param name="data">A list of strings representing neighborhoods. May contain null values</param>
        /// <returns>A list of strings representing neighborhoods.</returns>
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

        /// <summary>
        /// Given a list of strings representing neighborhoods, filter out duplicate values.
        /// </summary>
        /// <param name="data">A list of strings representing neighborhoods. May contain duplicate values</param>
        /// <returns>A list of strings representing neighborhoods.</returns>
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

        /// <summary>
        /// Answers the fourth question of the lab - listing out all non-null, non-duplicate neighborhoods via LINQ expression
        /// </summary>
        /// <param name="data">List of properties representing a portion of the JSON file.</param>
        /// <returns>A list of strings of neighborhoods</returns>
        static List<string> AnswerLinqQuestionFour(List<Properties> data)
        {
            Console.WriteLine("What are all of the neighborhoods in this data list? Only use one query to do this.");
            //IEnumerable<string> dataDistinct = data.Distinct();
            //Since we're passing in properties, .Distinct() won't filter out Properties who have any distinct properties - filter down to neighborhood level then do the .Distinct
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
            foreach (string neighborhood in nonNullDistinctNeighborhoods)
            {
                Console.Write(neighborhood + "; ");
                filteredNeighborhoods.Add(neighborhood);
            }
            Console.WriteLine("\n");
            return filteredNeighborhoods;
        }

        /// <summary>
        /// Answers the fifth question of the lab - listing out all non-null, non-duplicate neighborhoods via lambda expression
        /// </summary>
        /// <param name="data">List of properties representing a portion of the JSON file.</param>
        /// <returns>A list of strings of neighborhoods</returns>
        static List<string> AnswerLinqQuestionFive(List<Properties> data)
        {
            Console.WriteLine("What are all of the neighborhoods in this data list? Use a lambda function isntead of a query to do this.");
            //Implementation of .Where lambda function from https://stackoverflow.com/questions/15253548/filtering-a-list-of-objects-with-a-certain-attribute
            var results = data.Where(property => property.Neighborhood != "");

            List<string> nonNullNeighborhoods = new List<string>();
            foreach (Properties place in results)
            {
                nonNullNeighborhoods.Add(place.Neighborhood);
            }
            IEnumerable<string> nonNullDistinctNeighborhoods = nonNullNeighborhoods.Distinct();
            List<string> filteredNeighborhoods = new List<string>();
            foreach (string neighborhood in nonNullDistinctNeighborhoods)
            {
                Console.Write(neighborhood + "; ");
                filteredNeighborhoods.Add(neighborhood);
            }
            Console.WriteLine("\n");
            return filteredNeighborhoods;
        }

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
