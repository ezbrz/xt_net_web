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
            
            Console.WriteLine(MyArray.Length);
            Console.WriteLine(MyArray.Capacity);
            Console.WriteLine(""); 
            foreach (var elem in MyArray)
            {
                Console.WriteLine(elem);
            }
            Console.WriteLine("");

            MyArray.Add(7);
            MyArray.Add(8);
            MyArray.Add(14);

            Console.WriteLine(MyArray.Length);
            Console.WriteLine(MyArray.Capacity);
            Console.WriteLine("");
            foreach (var elem in MyArray)
            {
                Console.WriteLine(elem);
            }
            Console.WriteLine("");

            MyArray.AddRange(TestList);

            Console.WriteLine(MyArray.Length);
            Console.WriteLine(MyArray.Capacity);
            Console.WriteLine("");
            foreach (var elem in MyArray)
            {
                Console.WriteLine(elem);
            }
            Console.WriteLine("");

            MyArray.Insert(3, 100);

            Console.WriteLine(MyArray.Length);
            Console.WriteLine(MyArray.Capacity);
            Console.WriteLine("");
            foreach (var elem in MyArray)
            {
                Console.WriteLine(elem);
            }
            Console.WriteLine("");
            MyArray.Delete(3);
            MyArray.Add(1000);

            MyArray[3] = 8000;
            MyArray[-3] = 3000;

            Console.WriteLine(MyArray.Length);
            Console.WriteLine(MyArray.Capacity);
            Console.WriteLine("");
            foreach (var elem in MyArray)
            {
                
                Console.WriteLine(elem);
            }
            Console.WriteLine("");
            var MyArray3 = MyArray.Clone();
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
                if (j == 10) { break; }
                Console.WriteLine(elem);
            }
            Console.WriteLine();
            foreach (var elem in (DynamicArray<int>)MyArray3)
            {
                Console.WriteLine(elem);
            }
            Console.ReadKey();
        }
    }

    class DynamicArray<T> : IEnumerable<T>, IEnumerator<T>, ICloneable
    {
        protected T[] _array;
        protected int _currentPos = -1;

        public T Current
        {
            get
            {
                try
                {
                    return this[_currentPos];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
        public object Clone()
        {
            DynamicArray<T> temp = new DynamicArray<T>(this);
            return temp;
        }
        object IEnumerator.Current => Current;

        public virtual bool MoveNext()
        {
            if (_currentPos == Length - 1)
            {
                Reset();
                return false;
            }
            _currentPos++;
            return true;
        }
        public void Reset()
        {
            _currentPos = -1;
        }
        public void Dispose() { }

        protected int _length;
        protected int _capacity;

        public IEnumerator<T> GetEnumerator()
        {
            //return _array.Take(_length);
            return this;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            //return GetEnumerator();
            return GetEnumerator();
        }
        /// <summary>
        /// Create empty array with capacity = 8
        /// </summary>
        public DynamicArray()
        {
            Capacity = 8;
            _length = 0;
            Array.Resize(ref _array, _capacity);
            
        }
        /// <summary>
        /// Create empty array with selected capacity value
        /// </summary>
        /// <param name="capacity">Capacity of array (not length)</param>
        public DynamicArray(int capacity)
        {
            Capacity = capacity;
            _length = 0;
            Array.Resize(ref _array, _capacity);
        }
        /// <summary>
        /// Create new array with existed data
        /// </summary>
        /// <param name="collection">Can use IENumerable collestons</param>
        public DynamicArray(IEnumerable<T> collection)
        {
            _capacity = 0;
            _length = 0;
            AddRange(collection);

        }
        public int Length
        {
            get => _length;
            private set
            {
                if (value < 0) { throw new ArgumentException("Something wrong with length", "length"); }

                _length = value;
            }
        }
        public int Capacity
        {
            get => _capacity;
            set
            {
                if (value < 0) { throw new ArgumentException("Cannot set capacity <1", "array capacity"); }
                if (value > 0)
                {
                    _capacity = value;
                }
                else
                {
                    _capacity = 8;
                }
                Array.Resize(ref _array, value);
                if (_capacity < _length) { _length = _capacity; }
            }
        }

        /// <summary>
        /// Add element into array
        /// </summary>
        /// <param name="newElement">Type must be equal type of array</param>
        public void Add(T newElement)
        {
            if (_length >= _capacity)
            {
                Capacity *= 2;
            }
            _array[Length++] = newElement;
        }
        /// <summary>
        /// Push new collection to the end of array with autoincrement capacity
        /// </summary>
        /// <param name="newCollection">Can use IENumerable collections</param>
        public void AddRange(IEnumerable<T> newCollection)
        {
            int newCapacity = 0;
            foreach (var elem in newCollection)
            {
                newCapacity++;
            }
            if (newCapacity > 0) {
                if (Length+newCapacity>Capacity) { Capacity += newCapacity; }
                foreach (var elem in newCollection)
                {
                    Add(elem);
                }
            } else { throw new ArgumentException("Empty IENumerable is coming"); } //or -- } else { Add(default); } -- if our array can get empty range
        }
        /// <summary>
        /// Insert new element into array
        /// </summary>
        /// <param name="index">Position of new element</param>
        /// <param name="elem">Value of element</param>
        /// <returns></returns>
        public bool Insert(int index, T elem)
        {
            if ((uint)index > Length) { throw new ArgumentOutOfRangeException("index"); }
            if (Length - index != 0)
            {
                DynamicArray<T> tempArray = new DynamicArray<T>(Length - index);

                for (int i = index; i < Length; i++)
                {
                    tempArray.Add(_array[i]);
                }
                try
                {
                    Length = index;
                    this.Add(elem);
                    this.AddRange(tempArray);
                    return true;
                }
                catch (ArgumentException) { return false; }
            }
            else
            {
                try
                {
                    this.Add(elem);
                    return true;
                }
                catch (ArgumentException) { return false; }
            }
            
        }
        /// <summary>
        /// Delete element from array
        /// </summary>
        /// <param name="index">Position of element to delete</param>
        /// <returns></returns>
        public bool Delete(int index)
        {
            if ((uint)index >= Length) { throw new ArgumentOutOfRangeException("index"); }
            if (Length - index != 1)
            {
                DynamicArray<T> tempArray = new DynamicArray<T>(Length - index);
                _array[Length] = default;
                for (int i = index+1; i < Length; i++)
                {
                    tempArray.Add(_array[i]);
                }
                try
                {
                    Length = index;
                    this.AddRange(tempArray);
                    return true;
                }
                catch (ArgumentException) { return false; }
            }
            else
            {
                try
                {
                    Length--;
                    Add(default);
                    Length--;
                    return true;
                }
                catch (ArgumentException) { return false; }
            }
        }

        public T this[int index]
        {
            get
            {
                if (index > Length - 1)
                    throw new ArgumentOutOfRangeException("index");

                return index >= 0 ? _array[index] : _array[Length + index];
            }

            set
            {
                if (index > Length - 1)
                    throw new ArgumentOutOfRangeException("index");

                if (index >= 0) _array[index] = value;
                else _array[Length + index] = value;
            }
        }
        public T[] ToArray()
        {
            T[] _tempArray = new T[Length];

            for (int i = 0; i < Length; i++)
            {
                _tempArray = _array;
            }

            return _tempArray;
        }
    }
    class CycledDynamicArray<T>: DynamicArray<T>
    {
            public override bool MoveNext()
            {
                if (_currentPos == Length-1)
                {
                    Reset();
                    return true;
                }
                _currentPos++;
                return true;
            }

    }
}
