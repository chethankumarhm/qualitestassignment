using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.helper
{
    internal class helpermethods
    {

        public static string get_value_from_json(string key)


        {

            string filePath = @"C:\Users\cheth\source\repos\SpecFlowProject1\data\TextFile1.json";
            try
            {
     
                string jsonContent = File.ReadAllText(filePath);

                // Parse the JSON content into a JObject
                JObject jsonObject = JObject.Parse(jsonContent);

                // Get the value for the provided key
                JToken value = jsonObject[key];

                // Return the value as a string if it exists
                return value?.ToString();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error: The file '{filePath}' was not found.");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
