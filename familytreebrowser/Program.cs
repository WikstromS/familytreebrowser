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
using System.Collections;

namespace familytreebrowser
{
    class Program
    {

        public static string path = "familytrees.json";
 
    
      


        static void Main(string[] args)
        {
           
/*
            if (args[0] == "-input")
                //path = args[1];
            if (args[0] == "-sort")
                //sortcode
            if (args[0] == "-search")
                    //searchcode
            if (args[0] == "-findduplicateinfamilytree")
                    //duplicatecode
                     */

            string json = File.ReadAllText(path);
            dynamic file = JsonConvert.DeserializeObject(json);
            //Deserialisoi objektiin ja Henkilo luokkaan. Koska Json tiedosto oli Arraymuodossa tarvitsin muodon Henkilo[]
            var obj = JsonConvert.DeserializeObject<Henkilo[]>(json);
            



            PrintEveryOne(file);
            Console.WriteLine("---------------------");
            Console.WriteLine(obj[0].FirsName);
            for(int i = 0; i <obj.Length;i++ )
            {
                Console.WriteLine(obj[i].FirsName);
            }






        }

    public static void PrintEveryOne(dynamic json)
    {
                foreach (var obj in json)
                {
                    Console.WriteLine(obj.FirsName + " " + obj.LastName + " " + obj.Age);

                // While looping through each object, i save the objects to sort later on
                string values = obj.FirsName + obj.LastName + obj.Age + obj.Gender;
              
    
                 if (obj.Children != null)
                        PrintEveryOne(obj.Children);
                }
                
            
        }


 






    }
    public class Henkilo
    {
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public ICollection<Henkilo> Children { get; set; }
    }

}
