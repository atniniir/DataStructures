//реализация двустороннего стека
using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class StackExt<T>
    {
        public T[] array; //дин. массив для хранения эл-в
        public int count; //текущее кол-во эл-в в стеке
        public StackExt()
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
                T val = array[count - 1];

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
        
        public void Write()
        {
        // вывод в консоль
            for (int i = 0; i < count; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("count: " + count);
        }

        public bool IsBalanced(string str)
        {
        // проверка сбалансированности скобок
            StackExt<char> temp = new StackExt<char>();
            for (int i = 0; i < str.Length; i++)
            {
                //встретили откр. скобку - внесли
                if (str[i] == '(')
                {
                    temp.Push('(');
                }
                //иначе встретили закр.
                else
                {
                    //если стек пуст, т.е. нет открывающих скобок - значит, не сбалансирован
                    if (temp.count == 0)
                    {
                        return false;
                    }
                    //если откр. скобка есть, то выталкиваем 
                    else
                    {
                        temp.Pop();
                    }
                }
            }
            // если стек пуст, т.е. не осталось откр. скобок - строка сбалансирована
            if (temp.Size() == 0)
            {
                return true;
            }
            return false;
        }

        public void PushFirst(T val)
        {
            // вставка элемента в начало
            // копируем массив, добавляем
            T[] temp = new T[count];
            Array.Copy(array, temp, count);
            array = new T[count + 1];
            Array.Copy(temp, 0, array, 1, count);
            array[0] = val;
            count++;
        }

        public T PopFirst()
        {
            // удаление первого элемента
            // если стек не пустой - пересоздаём массив без последнего эл-та, выдаём удалённый эл-т
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
            else return default(T); // null, если стек пустой
        }

        public T PeekFirst()
        {
        // просмотр первого элемента
            if (count > 0)
            {
                T val = array[0];
                return val;
            }
            else return default(T); // null, если стек пустой
        }
        
        public int PostFix(string str)
        {
        // вычисление выражения в постфиксной записи для одноразрядных чисел
            StackExt<char> temp1 = new StackExt<char>();
            StackExt<int> temp2 = new StackExt<int>();
            int res = 0;
            // вносим в стек символы без пробелов
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' ') temp1.Push(str[i]);
            }
            int n = temp1.Size();
            // обход по стеку - просматриваем символ
            // если цифра - во второй стек; 
            // если операция - выполняем, результат во второй стек
            for (int i = 0; i < n; i++)
            {
                char t = temp1.PopFirst();
                if (char.IsNumber(t))
                {
                    temp2.Push((int)Char.GetNumericValue(t));
                }
                else
                {
                    if (t == '=')
                    {
                        res = temp2.PeekFirst();
                    }
                    else
                    {
                        int n1 = temp2.Pop();
                        int n2 = temp2.Pop();
                        switch (t)
                        {
                            case '+': temp2.Push(n1 + n2); break;
                            case '-': temp2.Push(n1 - n2); break;
                            case '*': temp2.Push(n1 * n2); break;
                            case '/': temp2.Push(n1 / n2); break;
                            case '=': res = temp2.PeekFirst(); break;
                        }
                    }
                }
            }
            return res;
        }
    }
}
