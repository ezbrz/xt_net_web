using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_04
{
    class MyString
    {
        private char[] _str;
        private int _length;

        public char this[int id]
        {
            get => _str[id];
            set { _str[id] = value; }
        }
        public int Length => _length;

        public MyString()
        {
            _str = new char[0];
            _length = _str.Length;
        }
        public MyString(char[] str)
        {
            this._str = str;
            this._length = _str.Length;
        }
        public MyString(string str)
        {
            char[] temparr = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                temparr[i] = str[i];
            }
            _str = temparr;
            _length = _str.Length;
        }
        public static MyString Append(MyString str1, MyString str2)
        {
            char[] tempstr = new char[str1.Length+str2.Length];
            for (int i=0; i< str1.Length; i++)
            {
                tempstr[i] = str1[i];
            }
            for (int i = 0; i < str2.Length; i++)
            {
                tempstr[i + str1.Length] = str2[i];
            }
            return new MyString(tempstr);
        }
        public static bool IsEqual(MyString str1, MyString str2)
        {
            if (str1.Length != str2.Length) return false;
            for (int i=0; i < str1.Length; i++)
            {
                if (str1[i]!=str2[i]) { return false; }
            }
            return true;
        }
        public override string ToString()
        {
            StringBuilder tempsb = new StringBuilder();
            for (int i = 0; i < this.Length; i++) tempsb.Append(this[i]);
            return tempsb.ToString();
        }
        public char[] ToCharArray()
        {
            return _str;
        }
        public int FindChar(char c)
        {
            if (_str.Contains(c))
            {
                return Array.IndexOf(_str, c);
            }
            else
            {
                return -1;
            }
        }
    }
}
