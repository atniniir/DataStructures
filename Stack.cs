//реализация стека
using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Stack<T>
    {
        public T[] array; //дин. массив для хранения эл-в
        public int count; //текущее кол-во эл-в в стеке
        public Stack()
        {
            // инициализация внутреннего хранилища стека
            count = 0;
            array = new T[0];
        }

        public int Size()
        {
            // размер текущего стека		  
            return count;
        }

        public T Pop()
        {
            //удаление элемента
            //если стек не пустой - пересоздаём массив без последнего эл-та, выдаём удалённый эл-т
            if (count > 0)
            {
                T val = array[count-1];

                T[] temp = new T[count - 1];
                Array.Copy(array, temp, count - 1);
                array = new T[count - 1];
                Array.Copy(temp, array, count - 1);
                count--;
                return val;
            }
            else return default(T); // null, если стек пустой
        }

        public void Push(T val)
        {
            // вставка элемента
            // копируем массив, добавляем в конец
            T[] temp = new T[count];
            Array.Copy(array, temp, count);
            array = new T[count + 1];
            Array.Copy(temp, array, count);
            array[count] = val;
            count++;
        }

        public T Peek()
        {
        // просмотр последнего элемента
            if (count > 0)
            {
                T val = array[count - 1];    
                return val;
            }
            else return default(T); // null, если стек пустой
        }

        public void Write()
        {
        // вывод в консоль
            for (int i = 0; i<count; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("count: " + count);
        }
    }
}
