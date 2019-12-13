using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> TestList = new List<int>(){6,34,5,22,1,9};
            DynamicArray<int> MyArray = new DynamicArray<int>(0);

            ShowArray(MyArray);

            MyArray.Add(7);
            MyArray.Add(8);
            MyArray.Add(14);

            ShowArray(MyArray);

            MyArray.AddRange(TestList);

            ShowArray(MyArray);

            MyArray.Insert(3, 100);

            ShowArray(MyArray);

            MyArray.Delete(3);
            MyArray.Add(1000);
            MyArray[3] = 8000;
            MyArray[-3] = 2000;

            ShowArray(MyArray);

            var MyArray3 = MyArray.Clone();
            ShowArray((DynamicArray<int>)MyArray3);
            
            CycledDynamicArray<int> MyArray2 = new CycledDynamicArray<int>
            {
                6,
                5,
                60,
                64
            };

            int j = 0;
            foreach (var elem in MyArray2)
            {
                j++;
                if (j == 30) { break; }
                Console.WriteLine(elem);
            }

            Console.ReadKey();
        }
        static void ShowArray<T>(DynamicArray<T> array)
        {
            Console.WriteLine(array.Length);
            Console.WriteLine(array.Capacity);
            Console.WriteLine();
            foreach (var elem in array)
            {
                Console.WriteLine(elem);
            }
            Console.WriteLine();
        }
    }



}
