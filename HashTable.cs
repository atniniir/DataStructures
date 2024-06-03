//реализация хэш-таблицы
using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class HashTable
    {
        public int size; // размер таблицы
        public int step; // длина шага
        public string[] slots; // хранилище

        public HashTable(int sz, int stp)
        {
            // инициализация хеш-таблицы
            size = sz;
            step = stp;
            slots = new string[size];
            for (int i = 0; i < size; i++) slots[i] = null;
        }

        public int HashFun(string value)
        {
            // хеш-функция: возвращает корректный индекс слота
            // вычисляем сумму кодов строки, индекс - остаток от деления этой суммы
            int sum = 0;
            for (int i = 0; i < value.Length; i++)
            {
                sum += value[i];
            }
            return (sum % size);
        }

        public int SeekSlot(string value)
        {
            // функция поиска слота по знач. с учётом коллизий
            // если слот занят, то ищем свободный
            if (slots[HashFun(value)] != null)
            {
                //начинаем с занятого
                int start = HashFun(value);
                //полное количество оборотов - цел-й остаток от size / step, т.к. надо учитывать полный обход (с начала)
                for (int i = 1; i <= size / step; i++)
                {
                    //если размер превышен - берём остаток
                if (slots[ (start + step * i) % size ] == null)
                    {
                        return (start + step * i) % size;
                    }
                    }
            }
            else return HashFun(value);
            // находит индекс пустого слота для значения, или -1
            return -1;
        }

        public int Put(string value)
        {
            // записываем значение по хэш-функции
            // возвращается индекс слота или -1
            // если из-за коллизий элемент не удаётся разместить 
            int index = SeekSlot(value);
            if (index == -1)
            {
                return -1;
            }
            else
            {
                slots[index] = value;
                return index;
            }
        }

        public int Find(string value)
        {
            // находит индекс слота со значением, или -1
            for (int i = 0; i < size; i++)
            {
                if (slots[i] == value) return i;
            }
            return -1;
        }

        public void HashOut ()
        {
            // вывод в консоль
            for (int i = 0; i < size; i++)
            {
                if (slots[i] == null) Console.Write("0 ");
                else Console.Write(slots[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
