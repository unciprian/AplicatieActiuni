using BusinessLogicActiuni;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;

namespace H2___aplicatie_actiuni
{
    //class Person
    //{
    //    public Person(string name)
    //    {
    //        Name = name;
    //    }

    //    public static string Name { get; set; }
    //}

    
    class Program
    {
        static int i = 5;
        static IEnumerable<int> GetData()
        {
            i = 6;
            yield return i;
            i = 100;
            yield return i;
            i = 500;
            yield return i;
            i = 800;
            yield return i;


        }
        static void Main(string[] args)
        {

            //var x = GetData();
            //Console.WriteLine(i);
            //var nr = x.First();
            //Console.WriteLine(i);
            //var arr = x.ToArray();
            //Console.WriteLine(i);

            //Person p1 = new Person("Andrei");
            //Person p2 = new Person("Ciprian");
            //Console.WriteLine(Person.Name);
            //Console.WriteLine(Person.Name);


            Console.WriteLine("Bine ati venit!");
            Console.WriteLine("Pentru introducerea manuala a datelor, selectati 1 \n" +
                "Pentru citirea datelor dintr-un fisier, selectati 2 \n" + 
                "Pentru citirea datelor dintr-o pagina web, selectati 3 \n");
            int selection = Int32.Parse(Console.ReadLine());

            List<Financial_Instrument> Assets = null;
            if (selection == 1)
            {
                Assets = IntroducereManuala();
            }
            else if (selection == 2)
            {
               Assets = CitireFisier();
            }

            ReadSymbolAndShowStatistics(Assets);

            Console.WriteLine("End program");
            

            List < Firma > Firme = new List<Firma>();
            FirmaTranzactionata Google = new FirmaTranzactionata();
            FirmaNetranzactionata Hidroelectrica = new FirmaNetranzactionata();
            Firme.Add(Google);
            Firme.Add(Hidroelectrica);
            Console.WriteLine(Hidroelectrica.GetMyProperty());
            Console.ReadLine();

        }

        public static List<Financial_Instrument> IntroducereManuala()
        {
            List <Financial_Instrument> Assets = new List<Financial_Instrument>();
            for (int i = 0; i < 1000000; i++)
            {
                Financial_Instrument Asset = new Financial_Instrument();
                Console.WriteLine("Introduceti simbolul instrumentului:");
                Asset.Symbol = Console.ReadLine();
                Console.WriteLine("Introduceti pretul de inchidere al instrumentului:");
                Asset.Price = Decimal.Parse(Console.ReadLine());
                Console.WriteLine("Introduceti volumul de tranzactionare al instrumentului:");
                Asset.Volume = Int32.Parse(Console.ReadLine());
                Console.WriteLine(" Data curenta este" + DateTime.Now +". Introduceti ziua tranzactionarii:");
                Asset.TransactionDate = DateTime.Parse(Console.ReadLine());
                Assets.Add(Asset);
                Console.WriteLine($"Pana acum, lista contine {Assets.Count} elemente");
                Console.WriteLine("Daca doriti sa introduceti un nou intrument, apasati 1:");
                if (Console.ReadLine() == "1")
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
           Console.ReadLine();
           return (Assets);
        }

        public static List<Financial_Instrument> CitireFisier()
        {
            string CurrFile = @"SourceFile.txt";
            string[] lines = File.ReadAllLines(CurrFile);
            List<Financial_Instrument> Assets = new List<Financial_Instrument>();
            int RecordsNumber = lines.Count();
            for (int i = 0; i < RecordsNumber; i++)
            {
                string[] words = lines[i].Split(',');
                Financial_Instrument Asset = new Financial_Instrument
                {
                    Symbol = words[0],
                    Price = Decimal.Parse(words[1]),
                    Volume = Int32.Parse(words[2]),
                    TransactionDate = DateTime.Parse(words[3])
                };
                Assets.Add(Asset);
            }
            var simboluri = Assets.Select(a => a.Symbol).Distinct().ToArray();
            foreach (var item in simboluri)
            {
                Console.WriteLine($"aici {item}");
            }
            
            Console.WriteLine($"Lista contine {Assets.Count} elemente");

            return (Assets);
        }

        static void ReadSymbolAndShowStatistics(List<Financial_Instrument> Assets){
            Console.WriteLine("Introduceti simbolul pentru care doriti sa calculati indicatorul");
            string simbol = Console.ReadLine();
            Statistics stats = new Statistics(Assets);
            decimal? result = stats.AveragePrice(simbol);
            decimal? result1 = stats.AverageVolume(simbol);
            decimal? result2 = stats.StandardDev(simbol);
            Console.WriteLine($"Average price: {result}. Average Volume {result1}. Standard Deviation : {result2}");
        }



        

        //public double GetAveragePrice(List<Financial_Instrument> lista, string Symbol)
        //{
        //    lista.
        //    double result = (from x in lista where lista.symbol);
        //}

        //public int GetAveragePrice(string Symbol)
        //{
        //    int count = Assets.Where(x => x.Equals(occur)).Count();
        //    int AveragePrice =;
        //    return AveragePrice;
        //}

    }
}
