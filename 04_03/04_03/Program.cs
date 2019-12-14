using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_03
{
    class Program
    {
        public static DelegateForSearch deleg = new DelegateForSearch(SearchForElements);
        static void Main(string[] args)
        {
            
            Random rnd = new Random();
            int itemsNum = 10000;
            int measuresNum = 1001;
            int[] array = new int[itemsNum];

            for (int i = 0; i < itemsNum; i++)
            {
                array[i] = rnd.Next(-1000, 1000);
            }
            List<double> DirectSearch = new List<double>();
            List<double> DelegateSearch = new List<double>();
            List<double> AnonymSearch = new List<double>();
            List<double> LambdaSearch = new List<double>();
            List<double> LINQDirectSearch = new List<double>();
            List<double> LINQDelegateSearch = new List<double>();
            Stopwatch stopWatch = new Stopwatch();
            for (int i=0; i < measuresNum; i++)
            {
                stopWatch.Start();
                GetPositiveElem(array);
                stopWatch.Stop();
                DirectSearch.Add(stopWatch.ElapsedTicks);
                stopWatch.Reset();

                stopWatch.Start();
                GetPositiveElem(array, deleg);
                stopWatch.Stop();
                DelegateSearch.Add(stopWatch.ElapsedTicks);
                stopWatch.Reset();

                stopWatch.Start();
                GetPositiveElem(array, delegate (int val) { return val > 0; });
                stopWatch.Stop();
                AnonymSearch.Add(stopWatch.ElapsedTicks);
                stopWatch.Reset();

                stopWatch.Start();
                GetPositiveElem(array, a=>a>0);
                stopWatch.Stop();
                LambdaSearch.Add(stopWatch.ElapsedTicks);
                stopWatch.Reset();

                stopWatch.Start();
                GetPositiveElemLinq(array);
                stopWatch.Stop();
                LINQDirectSearch.Add(stopWatch.ElapsedTicks);
                stopWatch.Reset();

                stopWatch.Start();
                GetPositiveElemLinq(array, a => a > 0);
                stopWatch.Stop();
                LINQDelegateSearch.Add(stopWatch.ElapsedTicks);
                stopWatch.Reset();
            }
            DirectSearch.Sort();
            DelegateSearch.Sort();
            AnonymSearch.Sort();
            LambdaSearch.Sort();
            LINQDirectSearch.Sort();
            LINQDelegateSearch.Sort();

            Console.WriteLine($"Results:");
            Console.WriteLine($"Direct search: {DirectSearch[measuresNum/2]}");
            Console.WriteLine($"Delegate search: {DelegateSearch[measuresNum / 2]}");
            Console.WriteLine($"Anonym search: {AnonymSearch[measuresNum / 2]}");
            Console.WriteLine($"Lambda search: {LambdaSearch[measuresNum / 2]}");
            Console.WriteLine($"LINQDirect search: {LINQDirectSearch[measuresNum / 2]}");
            Console.WriteLine($"LINQDelegate search: {LINQDelegateSearch[measuresNum / 2]}");
            Console.ReadKey();
        }

        public static IEnumerable<int> GetPositiveElem(int[] array)
        {
            List<int> result = new List<int>();
            foreach (var item in array)
            {
                if (item > 0)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public static IEnumerable<int> GetPositiveElem(int[] array, DelegateForSearch condition)
        {
            List<int> result = new List<int>();
            foreach (var item in array)
            {
                if (condition(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public static IEnumerable<int> GetPositiveElemLinq(int[] array)
        {
            return array.Where(a => a > 0);
        }

        public static IEnumerable<int> GetPositiveElemLinq(int[] array, Func<int,bool> condition)
        {
            return array.Where(condition);
        }
        public delegate bool DelegateForSearch(int value);
        
        public static bool SearchForElements(int value) 
        {
            return value > 0;
        }

    }
}
