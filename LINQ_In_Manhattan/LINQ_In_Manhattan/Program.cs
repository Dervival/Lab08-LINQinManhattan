using System;
using System.IO;
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
            ////SerializedJSON Json = JsonConvert.DeserializeObject<SerializedJSON>(File.ReadAllText(@"../../../../../data.json"));
            ////Console.WriteLine(Json);

            //// deserialize JSON directly from a file
            ////using (StreamReader file = File.OpenText(@"../../../../../data.json"))
            ////{
            ////    JsonSerializer serializer = new JsonSerializer();
            ////    SerializedJSON json = (SerializedJSON)serializer.Deserialize(file, typeof(SerializedJSON));
            ////    Console.WriteLine(json.JsonType);
            ////}

            ////o ends up being the entire object of the JSON read in
            //using (StreamReader reader = File.OpenText(@"../../../../../data.json"))
            //{
            //    JObject json = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
            //    // do stuff
            //    Console.WriteLine(json["features"]);
            //    int counter = 0;
            //    foreach(JToken feature in json["features"])
            //    {
            //        counter++;
            //        Console.WriteLine("Feature #" + counter);
            //        Console.WriteLine(feature["properties"]["neighborhood"]);
            //    }
            //}
            AnswerLinqQuestionOne();
        }

        static void AnswerLinqQuestionOne()
        {
            Console.WriteLine("What all of the neighborhoods in this data list, including duplicates and null values?");
            using (StreamReader reader = File.OpenText(@"../../../../../data.json"))
            {
                JObject json = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
                //at this point the JObject can probably be operated on, but let's force it into our classes instead
                string jsonType = (string)json["type"];
                List<Feature> features = new List<Feature>();
                foreach(JToken feature in json["features"])
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
                    Console.WriteLine(property.Neighborhood);
                    //feature["properties"];
                    //Console.WriteLine(feature);
                }
                SerializedJSON JSON = new SerializedJSON(jsonType, features);
                Console.WriteLine(JSON.Features[0].Property.Neighborhood);

                //List<string> allNeighborhoods = new List<string>();
                //foreach (JToken feature in json["features"])
                //{
                //    string neighborhood = feature["properties"]["neighborhood"].ToString();
                //    //Console.WriteLine(neighborhood);
                //    allNeighborhoods.Add(neighborhood);
                //    //allNeighborhoods.Add(feature["properties"]["neighborhood"]);
                //}
                //foreach (string neighborhood in allNeighborhoods)
                //{
                //    Console.Write(neighborhood + "; ");
                //}
                //Console.WriteLine();

                //Console.WriteLine(allNeighborhoods);
                //JToken oChildren = o.Children();
                //Console.WriteLine(o.Children());
                //List<JToken> oChild = o.Children();
                //Object testObject = JsonConvert.DeserializeObject(o)
            }
        }
    }
}
