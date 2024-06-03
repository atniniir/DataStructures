//реализация словаря (ассоциативнрого массива)
using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class NativeDictionary<T>
    {
        public int size;
        public string[] slots;
        public T[] values;

        public NativeDictionary(int sz)
        {
            size = sz;
            slots = new string[size];
            values = new T[size];
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

        public bool IsKey(string key)
        {
            // возвращает true если ключ имеется,
            // иначе false
            for (int i = 0; i < size; i++)
            {
                if (slots[i] == key) return true;
            }
            return false;
        }

        public void Put(string key, T value)
        {
            // гарантированно записываем 
            // значение value по ключу key
            int index = HashFun(key);
            slots[index] = key;
            values[index] = value;
        }

        public T Get(string key)
        {
            // возвращает value для key, 
            // или null если ключ не найден
            if (IsKey(key) == true) return values[HashFun(key)];
            return default(T);
        }

        public void DictionaryOut()
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
 