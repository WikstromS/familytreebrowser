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
        public static List<Henkilo> henkiloLista = new List<Henkilo>();


        static void Main(string[] args)
        {
            /*
            string json = File.ReadAllText(path);       //Reads the JSON file to a string
            var obj = JsonConvert.DeserializeObject<Henkilo[]>(json);
            MakeList(obj);
            */    
               for (int i = 0; i < args.Length; i++)
               {
                   if(args[0] == "-input")
                   {
                       path = args[1];
                       string json = File.ReadAllText(path);       //Reads the JSON file to a string
                       var obj = JsonConvert.DeserializeObject<Henkilo[]>(json);
                       MakeList(obj);
                       if(args.Length == 2)
                       {
                           PrintEveryOne(henkiloLista);
                           break;
                       }

                       if(args[2] == "-sort" && args[3] == "age")
                       {
                           SortByAge(henkiloLista);
                           break;
                       }
                       if (args[2] == "-sort" && args[3] == "lastname")
                       {
                           SortByLastName(henkiloLista);
                           break;
                       }

                   } 

               }   

            /*
            if (args[0] == "-input")
            {
                path = args[1];
                string json = File.ReadAllText(path);       //Reads the JSON file to a string
                var obj = JsonConvert.DeserializeObject<Henkilo[]>(json);
                MakeList(obj);
                PrintEveryOne(obj);



                if (args[2] == "-sort" && args[3] == "age")
                    SortByAge(henkiloLista);

                if (args[2] == "-sort" && args[3] == "lastname")
                    SortByLastName(henkiloLista);

            }
    */

            //if (args[0] == "-search")
            //searchcode
            //if (args[0] == "-findduplicateinfamilytree")
            //duplicatecode


        }

    public static void PrintEveryOne(dynamic json)
    {
            int counter = 0;
                foreach (var obj in json)
                {
                    Console.WriteLine(obj.FirsName + " " + obj.LastName + " " + obj.Age);
                counter++;
                if (counter == 10 || counter == 20 || counter == 30 || counter == 40)
                {
                    Console.WriteLine("Press Enter to show next  values");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                        continue;

                }

                if (obj.Children != null)
                        PrintEveryOne(obj.Children);

                }            
        }

    public static void SortByAge(List<Henkilo> list)
        {
            List<Henkilo> sortedByAgeList = list.OrderBy(o => o.Age).ToList();
            int counter = 0;
            foreach(var i in sortedByAgeList)
            {
                Console.WriteLine(i.FirsName + " " +  i.LastName + " "+ i.Age);
                counter++;
                if (counter == 10 || counter == 20 || counter == 30 || counter == 40)
                {
                    Console.WriteLine("Press Enter to show next  values");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                        continue;


                }
            }
        }

    public static void SortByLastName(List<Henkilo> list)
        {
            List<Henkilo> sortedByLastname = list.OrderBy(o => o.LastName).ToList();
            int counter = 0;

            foreach (var i in sortedByLastname)
            {
                Console.WriteLine(i.FirsName + " " + i.LastName + " " + i.Age);
                counter++;
                if (counter == 10 || counter == 20 || counter == 30 || counter == 40)
                {
                    Console.WriteLine("Press Enter to show next  values");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                        continue;


                }
            }
        }


    public static void MakeList(dynamic json)
        {
            foreach (var obj in json)
            {
                // While looping through each object, save objects to a list using a constructor
                henkiloLista.Add(new Henkilo(obj.FirsName, obj.LastName, obj.Gender, obj.Age));

                if (obj.Children != null)
                    MakeList(obj.Children);
            }

        }
    
    public static void Search(List<Henkilo> list , string str)
        {
            foreach(var i in list)
            {
                if(i.FirsName.Contains(str) || i.LastName.Contains(str))
                {
                    Console.WriteLine(i.FirsName + " " + i.LastName + " " + i.Age);
                }
            }
        }





    }

    public class Henkilo
    {
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public IList<Henkilo> Children { get; set; }

        public Henkilo(string firstname, string lastname, string gender, int age)
        {
            this.FirsName = firstname;
            this.LastName = lastname;
            this.Gender = gender;
            this.Age = age;
        }
    }

}
