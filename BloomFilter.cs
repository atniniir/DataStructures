//реализация фильтра Блюма
using System.Collections.Generic;
using System;
using System.IO;
using System.Collections;

namespace AlgorithmsDataStructures
{
    public class BloomFilter
    {
        public int filter_len;
        BitArray bits;

        public BloomFilter(int f_len)
        {
            filter_len = f_len;
            // создаём битовый массив длиной f_len ...
            bits = new BitArray(f_len,false);
        }

        // хэш-функции
        public int Hash1(string str1)
        {
            // 17
            int res = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                int code = (int)str1[i];
                res = (res * 17 + code) % 128;
            }
            return res;
        }
        public int Hash2(string str1)
        {
            // 223
            int res = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                int code = (int)str1[i];
                res = (res * 223 + code) % 128;
            }
            return res;
        }

        public void Add(string str1)
        {
            // добавляем строку str1 в фильтр
            int[] h1 = new int[1] { Hash1(str1) };
            int[] h2 = new int[1] { Hash2(str1) };
            BitArray b1 = new BitArray(h1);
            BitArray b2 = new BitArray(h2);
            bits.Or(b1); bits.Or(b2);
        }

        public bool IsValue(string str1)
        {
            // проверка, имеется ли строка str1 в фильтре
            int h1 = Hash1(str1);
            int h2 = Hash2(str1);
            BitArray temp = new BitArray(filter_len);
            BitArray b1 = new BitArray(BitConverter.GetBytes(h1));
            BitArray b2 = new BitArray(BitConverter.GetBytes(h2));
            temp.Or(b1);
            temp.Or(b2);

            BitArray res = new BitArray(filter_len);
            BitArray temp1 = new BitArray(temp);
            res = temp1.And(bits);

            for (int i = 0; i < filter_len; i++)
            {
                if (temp[i] != res[i]) return false;
            }

            return true;
        }

        public void Out ()
        {
            for (int i = 0; i < filter_len; i++)
            {
                if (bits[i] == false) Console.Write("0 ");
                else Console.Write("1 ");
            }
            Console.WriteLine();
        }
    }
}
