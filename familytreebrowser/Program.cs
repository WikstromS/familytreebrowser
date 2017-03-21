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

        public static string path = "C://Users//wiku//Desktop//OOP Coding Assignment//OOP Coding Assignment//familytrees.json";
        static void Main(string[] args)
        {
            
            Console.WriteLine("First name is " + args.input);
            Console.WriteLine("Last name is " + args[1]);

            string json = File.ReadAllText(path);
            dynamic file = JsonConvert.DeserializeObject(json);


            //PrintKaikki(file);

        }

    public static void PrintKaikki(dynamic json)
    {       
            foreach(var obj in json)
            {
                Console.WriteLine(obj.FirsName + " " + obj.LastName + " " + obj.Age);
                
                // TODO luo taulukko, johon lisätään nimet ja iät

                 if (obj.Children != null)
                   PrintKaikki(obj.Children);
            }

        }
    }

}
