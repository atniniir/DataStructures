//реализация очереди
using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Queue<T>
    {
        public T[] array; //дин. массив для хранения эл-в
        public int count; //текущее кол-во эл-в в очереди
        public Queue()
        {
            // инициализация внутреннего хранилища очереди
            count = 0;
            array = new T[0];
        }

        public void Enqueue(T item)
        {
            // вставка в хвост
            // копируем массив, добавляем в конец
            T[] temp = new T[count];
            Array.Copy(array, temp, count);
            array = new T[count + 1];
            Array.Copy(temp, array, count);
            array[count] = item;
            count++;
        }

        public T Dequeue()
        {
            // выдача из головы
            if (count > 0)
            {
                T val = array[0];

                T[] temp = new T[count - 1];
                Array.Copy(array, 1, temp, 0, count - 1);
                array = new T[count - 1];
                Array.Copy(temp, array, count - 1);
                count--;
                return val;
            }
            else return default(T); // если очередь пустая
        }

        public int Size()
        {
            return count; // размер очереди
        }
      
        public void Rotate (int N)
        { 
          // вращение элементов на N шагов
          for (int i = 0; i < N; i++)
            {
                Enqueue(Dequeue());
            }
        }
    }
}
