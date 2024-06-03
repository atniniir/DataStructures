//реализация кэша
using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    class NativeCache<T>
    {
        public int size;
        public String[] slots;
        public T[] values;
        public int[] hits;

        public NativeCache(int sz)
        {
            size = sz;
            slots = new string[size]; // ключи
            values = new T[size]; // данные
            hits = new int[size]; // обращения
        }

        public int HashFun(string key)
        {
            // всегда возвращает корректный индекс слота
            int sum = 0;
            for (int i = 0; i < key.Length; i++)
            {
                sum += key[i];
            }
            return (sum % size);
        }

        public int FindKey(string key)
        {
            // для случаев, когда не срабатывает по хеш-функции
            for (int i = 0; i < size; i++)
            {
                if (slots[i] == key) return i;
            }
            return -1;
        }

        public bool IsKey(string key)
        {
            // возвращает true если ключ имеется,
            // иначе false
            if (slots[HashFun(key)] == key) return true;
            else
            {
                int index = FindKey(key);
                if (index != -1)
                {
                    if (slots[FindKey(key)] == key) return true;
                }
            }
            return false;
        }

        public void Put(string key, T value)
        {
            // если слот свободен - записываем в него
            // иначе ищем самый невостребованный и перезаписываем на его место
            int index = HashFun(key);
            if (slots[index] == null)
            {
                slots[index] = key;
                values[index] = value;
            }
            else
            {
                int imin = GetMin();
                slots[imin] = key;
                values[imin] = value;
                hits[imin] = 1;
            }
        }

        public T Get(string key)
        {
            // возвращает value для key, 
            // или null если ключ не найден
            if (FindKey(key) != -1) {
                hits[FindKey(key)]++;
                return values[HashFun(key)]; }
            return default(T);
        }

        public int GetMin()
        {
            // возвращает индекс эл-та, к которому обращаются реже всего
            int imin = 0;
            for (int i = 1; i < size; i++)
            {
                if (hits[i] < hits[imin])
                {
                    imin = i;
                }
            }
                return imin;
        }

        public void Out()
        {
            for (int i = 0; i < size; i++)
            {
                if (slots[i] == null) Console.Write("0 ");
                else Console.Write(slots[i] + "-" + values[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
