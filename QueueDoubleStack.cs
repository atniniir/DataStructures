//реализация очереди через два стека
using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class QueueDoubleStack<T>
    { 
        Stack<T> put;
        Stack<T> take;

        public QueueDoubleStack()
        {
            // инициализация внутреннего хранилища очереди
            put = new Stack<T>();
            take = new Stack<T>();
        }
        
        public void Enqueue(T item)
        { // вставка в хвост
          // добавляем в первый стек (т.е. в конец очереди)
            put.Push(item);
        }
        
        public T Dequeue()
        { // удаление из головы
          // если во втором стеке пусто - перегоняем элементы в стек на выдачу и извлекаем
            if (take.Size() == 0)
            {
                int n = put.Size();
                for (int i = 0; i<n; i++)
                {
                    take.Push(put.Pop());
                }
            }
            return take.Pop();
        }
        
        public int Size()
        {
            return take.Size() + put.Size(); // размер очереди
        }
    }
}
