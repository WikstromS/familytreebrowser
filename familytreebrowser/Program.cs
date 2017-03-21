using Newtonsoft.Json.Linq;
using Newtonsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace familytreebrowser
{
    class Program
    {

      public static string path = "familytrees.json";
      public static List<object> persons = new List<object>();
      


        static void Main(string[] args)
        {
           

           /* if (args[0] == "-input")
                path = args[1];
            if (args[0] == "-sort")
                //sortcode
            if (args[0] == "-search")
                    //searchcode
            if (args[0] == "-findduplicateinfamilytree")
                    //duplicatecode
                    { } */

            string json = File.ReadAllText(path);
            dynamic file = JsonConvert.DeserializeObject(json);


            PrintEveryOne(file);

            

            

        }

    public static void PrintEveryOne(dynamic json)
    {       
            foreach(var obj in json)
            {
                Console.WriteLine(obj.FirsName + " " + obj.LastName + " " + obj.Age);
                
                // While looping through each object, i save the objects to sort later on
                persons.Add(obj);

                 if (obj.Children != null)
                   PrintEveryOne(obj.Children);
            }

        }


    }

}
