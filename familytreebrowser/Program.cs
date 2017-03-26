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

                       if(args[2] == "-search")
                        {
                        string searchCriteria = args[3];
                        Search(henkiloLista, searchCriteria);
                        break;
                        }

                   } 

               }   
        }

    public static void PrintEveryOne(dynamic json)      // Method prints every objects firstname, lastname, age and the Mr or Ms depending on the objects Gender. Finally there is the functionality to print 10 at a time.
    {
            int counter = 0;
                foreach (var obj in json)
                {
                if(obj.Gender == "Male")
                    Console.WriteLine("Mr " + obj.FirsName + " " + obj.LastName + " " + obj.Age);
                else
                    Console.WriteLine("Ms " + obj.FirsName + " " + obj.LastName + " " + obj.Age);
                counter++;
                //Functionality to print 10 at a time. Only works till 70
                if (counter == 10 || counter == 20 || counter == 30 || counter == 40 || counter == 50 || counter == 60 || counter == 70)
                {
                    Console.WriteLine("Press Enter to show next  values");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                        continue;

                }

                if (obj.Children != null)
                        PrintEveryOne(obj.Children);

                }            
        }

    public static void SortByAge(List<Henkilo> list)    //Method sorts the list by Age using LINQ and then prints them out in order using same functionality as the method above.
        {
            List<Henkilo> sortedByAgeList = list.OrderBy(o => o.Age).ToList();
            int counter = 0;
            foreach(var i in sortedByAgeList)
            {
                if (i.Gender == "Male")
                    Console.WriteLine("Mr " + i.FirsName + " " + i.LastName + " " + i.Age);
                else
                    Console.WriteLine("Ms " + i.FirsName + " " + i.LastName + " " + i.Age);

                counter++;
                if (counter == 10 || counter == 20 || counter == 30 || counter == 40 || counter == 50 || counter == 60 || counter == 70)
                {
                    Console.WriteLine("Press Enter to show next  values");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                        continue;
                }
            }
        }

    public static void SortByLastName(List<Henkilo> list)   //Method sorts the list lastname using LINQ. Works pretty much as the above method.
        {
            List<Henkilo> sortedByLastname = list.OrderBy(o => o.LastName).ToList();
            int counter = 0;

            foreach (var i in sortedByLastname)
            {
                if (i.Gender == "Male")
                    Console.WriteLine("Mr " + i.FirsName + " " + i.LastName + " " + i.Age);
                else
                    Console.WriteLine("Ms " + i.FirsName + " " + i.LastName + " " + i.Age);

                counter++;
                if (counter == 10 || counter == 20 || counter == 30 || counter == 40)
                {
                    Console.WriteLine("Press Enter to show next  values");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                        continue;
                }
            }
        }


    public static void MakeList(dynamic json)   //This method Loops through the file and adds objects to a list using a constructor.
        {
            foreach (var obj in json)
            {
                // While looping through each object, save objects to a list using a constructor
                henkiloLista.Add(new Henkilo(obj.FirsName, obj.LastName, obj.Gender, obj.Age));

                if (obj.Children != null)
                    MakeList(obj.Children);
            }

        }
    
    public static void Search(List<Henkilo> list , string str)  //This method searches the list and checks if the firstname or lastname contains the string given. 
        {
            foreach(var i in list)
            {
                if(i.FirsName.Contains(str) || i.LastName.Contains(str))
                {
                    if (i.Gender == "Male")
                        Console.WriteLine("Mr " + i.FirsName + " " + i.LastName + " " + i.Age);
                    else
                        Console.WriteLine("Ms " + i.FirsName + " " + i.LastName + " " + i.Age);
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
