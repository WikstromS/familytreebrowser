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




            MakeAList(obj); //Luo listan
            PrintEveryOne(obj); // tällä hetkellä PrintEveryOne metodissa lisätään kaikki listaan. TODO. Tee oma metodi, joka käy objektit läpi A'la PrintEveryOne ja lisää listaan.
            Console.WriteLine("---------------------");
            Console.WriteLine(henkiloLista.Count);
            //sorttaa lista by Age
            List<Henkilo> sortedList = henkiloLista.OrderBy(o => o.Age).ToList();
            foreach(var i in sortedList)
            {
                Console.WriteLine(i.Age);
            }
            
            /*
            for(int i = 0; i <obj.Length;i++ )
            {
                Console.WriteLine(obj[i].FirsName);
                if (obj[i].Children != null)
                {
                    foreach (var ob in obj[i].Children)
                    {
                        Console.WriteLine(ob.FirsName);

                        if (ob.Children != null)
                        {
                            foreach (var obb in ob.Children)
                            {
                                Console.WriteLine(obb.FirsName);

                                if(obb.Children != null)
                                {
                                    foreach(var obbb in obb.Children)
                                    {
                                        Console.WriteLine(obbb.FirsName);
                                    }
                                }
                            }
                        }
                    }
                } 

            }

                */

        }

    public static void PrintEveryOne(dynamic json) {
        
                foreach (var obj in json)
                {
                    Console.WriteLine(obj.FirsName + " " + obj.LastName + " " + obj.Age);



                 if (obj.Children != null)
                        PrintEveryOne(obj.Children);
                
                }
                
            
        }

        public static void MakeAList(dynamic json)
        {

            foreach (var obj in json)
            {

                henkiloLista.Add(new Henkilo(obj.FirsName, obj.LastName, obj.Gender, obj.Age));

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
