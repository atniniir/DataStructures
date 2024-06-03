//реализация динамического массива на основе буфера
using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class DynArray<T>
    {
        public T[] array;
        public int count;
        public int capacity;

        public DynArray()
        {
            count = 0;
            MakeArray(16);
        }

        public void MakeArray(int new_capacity)
        {
            // формирование блока памяти заданного размера; меняет размер массива array, копируя при необходимости текущие объекты
            if (new_capacity > 0)
            {
                //если новая ёмкость меньше 16, то делаем 16
                    if (new_capacity <= 16) { capacity = 16; }
                    else { capacity = new_capacity; }
                //пересоздаём массив, копируем содержимое
                if (array != null)
                {
                    T[] temp = new T[count];
                    Array.Copy(array, temp, count);
                    array = new T[new_capacity];
                    Array.Copy(temp, array, count);
                }
                else
                {
                    array = new T[new_capacity];
                }
            }
            else throw new ArgumentOutOfRangeException();
        }

        public T GetItem(int index)
        {
            // получение объекта по его индексу
            // если индекс указан неккоректно (не попадает в диапазон) - исключение
            if (index < 0 || index > count)
            {
                return array[index];
            }
            else throw new ArgumentOutOfRangeException();
        }

        public void Append(T itm)
        {
            // добавление нового элемента в конец массива
            // если вместе с новым элементом идёт превышение длины - увеличиваем ёмкость в 2 раза
            if(count + 1 > capacity)
                {
                MakeArray(capacity * 2);
            }
            //т.к. индексация массива идёт с 0, то вызываем по [count], увеличиваем кол-во на 1
            array[count] = itm;
            count++;
        }

        public void Insert(T itm, int index)
        {
            // вставляет в i-ю позицию объект item, сдвигая вперёд все последующие элементы
            if (index >= 0 && index <= count)
            {
                //если вместе с новым элементом идёт превышение длины - увеличиваем ёмкость в 2 раза
                if (count + 1 > capacity)
                {
                    MakeArray(capacity * 2);
                }
                //сдвигаем элементы массива вправо
                for (int i = count; i > index; i--)
                {
                    array[i] = array[i - 1];
                }
                //в нужное место вставляем элемент; увеличиваем кол-во эл-в
                array[index] = itm;
                count++;
            }
            else throw new ArgumentOutOfRangeException();
        }

        public void Remove(int index)
        {
            // удаляет объект из i-й позиции, при необходимости выполняя сжатие буфера
            if (index >= 0 && index < count)
            {
                // сдвигаем элементы массива вправо
                for (int i = index; i < count - 1; i++)
                {
                    array[i] = array[i + 1];
                }
                count--;
                array[count] = default(T);

                // если занято меньше 50% массива - уменьшаем размер буфера в 1.5 раза (устраняем лишний вызов, если ёмкость уже минимальная)
                if ((float)count / (float)capacity < 0.5 && capacity != 16)
                {
                    int new_cap = (int)((float)capacity / 1.5);
                    if (new_cap < 16) new_cap = 16;
                    MakeArray(new_cap);
                }
            }
            else throw new ArgumentOutOfRangeException();
        }

        public void Write()
        {
        // вывод в консоль
            for (int i = 0; i < count; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("count: " + count + " capacity: " + capacity);
        }
    }
}
