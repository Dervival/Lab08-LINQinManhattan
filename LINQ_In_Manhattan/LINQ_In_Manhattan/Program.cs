using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LINQ_In_Manhattan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using (StreamReader reader = File.OpenText(@"../../data.json"))
            {
                JObject o = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
                // do stuff
            }
        }
    }
}
