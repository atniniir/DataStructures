//реализация двусторонней очереди
using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    class Deque<T>
    {
        T[] array;
        int count;
        
        public Deque()
        {
            // инициализация внутреннего хранилища
            count = 0;
            array = new T[0];
        }

        public void AddFront(T item)
        {
            // добавление в голову
            T[] temp = new T[count];
            Array.Copy(array, temp, count);
            array = new T[count + 1];
            Array.Copy(temp, 0, array, 1, count);
            array[0] = item;
            count++;

        }

        public void AddTail(T item)
        {
            // добавление в хвост
            T[] temp = new T[count];
            Array.Copy(array, temp, count);
            array = new T[count + 1];
            Array.Copy(temp, array, count);
            array[count] = item;
            count++;
        }

        public T RemoveFront()
        {
            // удаление из головы
            if (count > 0)
            {
                T item = array[0];

                T[] temp = new T[count - 1];
                Array.Copy(array, 1, temp, 0, count - 1);
                array = new T[count - 1];
                Array.Copy(temp, array, count - 1);
                count--;
                return item;
            }
            else return default(T);
        }

        public T RemoveTail()
        {
            // удаление из хвоста
            if (count > 0)
            {
                T item = array[count - 1];

                T[] temp = new T[count - 1];
                Array.Copy(array, temp, count - 1);
                array = new T[count - 1];
                Array.Copy(temp, array, count - 1);
                count--;
                return item;
            }
            else return default(T);
        }

        public int Size()
        {
            return count; // размер очереди
        }


        public bool isPalindrom(string str)
        {
        // проверка, является ли число палиндромом
            Deque<char> temp = new Deque<char>();
            for (int i = 0; i < str.Length; i++)
            {
                temp.AddTail(str[i]);
            }

            for (int i = 0; i < str.Length % 2; i++)
            {
                if (temp.RemoveFront() != temp.RemoveTail())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
