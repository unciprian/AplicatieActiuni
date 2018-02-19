using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics;

namespace BusinessLogicActiuni
{
    public class Statistics
    {
        public Statistics(List <Financial_Instrument> list)
        {
            List = list;
        }

        public List<Financial_Instrument> List { get; }
        /// <summary>
        /// return null if not found
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public decimal? AveragePrice( string symbol)
        {


            int k = List.Where(it => it.Symbol == symbol).Count();
            if (k == 0)
                return null;
            decimal Sum = List
                            .Where(it => it.Symbol == symbol)
                            .Select(it => it.Price)
                            .Sum();
            decimal AvgPrice = Sum/k;
            
            //foreach (var asset in List)
            //{
            //    if (symbol == asset.Symbol)
            //    {
            //        k++;
            //        Sum += asset.Price;
            //    }
            //    //Console.WriteLine(k);
            //    //Console.WriteLine(Sum);
                
                
            //    //Console.ReadLine();
            //}
            //if (k == 0)
            //    return null;

            AvgPrice = Sum / k;

            return (AvgPrice);
        }
        public decimal? AverageVolume(string symbol)
        {


            int k = List.Where(it => it.Symbol == symbol).Count();
            if (k == 0)
                return null;
            decimal Sum = List
                            .Where(it => it.Symbol == symbol)
                            .Select(it => it.Volume)
                            .Sum();
            decimal AvgVolume = Sum / k;
            return (AvgVolume);
        }

        public decimal? StandardDev(string symbol)
        {


            int k = List.Where(it => it.Symbol == symbol).Count();
            if (k == 0)
                return null;

            //decimal SumOfSquares = List
            //    .Where(it => it.Symbol == symbol)
            //    .Sum(it => Math.Pow(it.Price - AverageVolume, 2));  //de ce nu merge asa din moment ce eu am deja calculat Average Price?


            decimal Avg = List.Where(it => it.Symbol == symbol).Average(it => it.Price);
            double SumOfSquares = List
                .Where(it => it.Symbol == symbol)
                .Sum(it => Math.Pow((double)(it.Price - Avg), 2));

            double StDev = Math.Sqrt(SumOfSquares / (k - 1));
            return (decimal) StDev;

           }

        public IEnumerable<string> DistinctSymbol()
        {
            //List<string> result = new List<string>();
            //foreach (var item in List)
            //{
            //    if (result.Contains(item.Symbol))
            //    {
            //        continue;
            //    }
            //    result.Add(item.Symbol);
            //}

            //HashSet<string> result=new HashSet<string>();
            //foreach (var item in List)
            //{

            //    result.Add(item.Symbol);
            //}

            var result = List.Select(it => it.Symbol).Distinct().ToArray();
            return result;
        }
    }
    
}
