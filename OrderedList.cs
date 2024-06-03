//реализация упорядоченного списка
using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Node<T>
    {
        public T value;
        public Node<T> next, prev;

        public Node(T _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class OrderedList<T>
    {
        public Node<T> head, tail;
        private bool _ascending;

        public OrderedList(bool asc)
        {
            head = null;
            tail = null;
            _ascending = asc;
        }

        public int Compare(T v1, T v2)
        {
        // сравнение элементов списка
            int result = 0;
            if (typeof(T) == typeof(String))
            {
                // версия для лексикографического сравнения строк
                string s1 = Convert.ToString(v1);
                string s2 = Convert.ToString(v2);
                // избавляемся от пробелов в начале и конце
                s1.Trim(); s2.Trim();
                result = String.Compare(s1, s2);
            }
            else
            {
                // универсальное сравнение
                double d1 = Convert.ToDouble(v1);
                double d2 = Convert.ToDouble(v2);
            // -1 если v1 < v2
            // 0 если v1 == v2
            // +1 если v1 > v2
                if (d1 > d2) result = 1;
                else if (d1 == d2) result = 0;
                else result = -1;
            }
            return result;
        }

        public void Add(T value)
        {
            Node<T> new_node = new Node<T>(value);
            // автоматическая вставка value в нужную позицию
            // если голова пустая - вставка в голову
            if (head == null)
            {
                head = new_node;
                head.next = null;
                head.prev = null;
                tail = head;
            }
            // иначе эл-ты есть, просмотр, начиная с головы
            else
            {
                Node<T> node = head;
                while (node != null)
                {
                    // сортировка по возр.; если след. эл-т больше - вставляем перед ним
                    // аналогично по убыв.
                        if ( (_ascending == true && (Compare(value, node.value) == -1 || Compare(value, node.value) == 0)) ||
                             (_ascending == false && (Compare(value, node.value) == 1 || Compare(value, node.value) == 0)) )
                        {
                            //если пред. пуст - вставляем перед головой
                            if (node.prev == null)
                            {
                                head.prev = new_node;
                                new_node.next = head;
                                head = new_node;
                                new_node.prev = null;
                                break;
                            }
                            //иначе вставляем в середину
                            else
                            {
                                node.prev.next = new_node;
                                new_node.prev = node.prev;
                                new_node.next = node;
                                node.prev = new_node;
                                break;
                            }
                        }
                        //если дошли до конца - значит, вставка в хвост
                        else
                        {
                            if (node.next == null)
                            {
                                node.next = new_node;
                                new_node.prev = node;
                                new_node.next = null;
                                tail = new_node;
                                break;
                            }
                        }
                    node = node.next;
                }
                }
        }

        public Node<T> Find(T val)
        {
        // поиск элемента по значению
            Node<T> node = head;

            while (node != null)
            {
                if (Compare(val, node.value) == 0) { return node; }
                //возрастание: если след. больше - эл-та нет, выход; аналогично для убыв.
                if ((_ascending == true && Compare(val, node.value) == -1) ||
                    (_ascending == false && Compare(val, node.value) == 1)) return null;
                node = node.next;
            }
            return null; // здесь будет ваш код
        }

        //нет учёта возр-убыв
        public void Delete(T val)
        {
            Node<T> node = head;
            while (node != null)
            {
                //если элемент найден
                if (Compare(val, node.value) == 0)
                {
                    //если предыдущий - пустой, то искомый - 1й элемент; 2й становится головой списка
                    if (node.prev == null)
                    {
                        //если следующий за головой пустой, то в списке 1 элемент
                        if (head.next == null)
                        {
                            head = null;
                            tail = null;
                        }
                        else
                        {
                            head.next.prev = null;
                            head = head.next;
                        }
                    }
                    //если предыдущий есть, то искомый в середине или в конце
                    else
                    {
                        //если следующий - пустой, то искомый - последний эл-т; предыдущий становится хвостом списка
                        if (node.next == null)
                        {
                            node.prev.next = null;
                            tail = node.prev;
                        }
                        //если следующий есть, то искомый в середине
                        else
                        {
                            node.prev.next = node.next;
                            node.next.prev = node.prev;
                        }
                    }
                    //элемент найден - возвращаем true; прекращаем проход
                    break;
                }
                //элемент не найден - проход дальше
                else
                {
                    node = node.next;
                }
            }
        }

        public void Clear(bool asc)
        {
        // очистка стека
            _ascending = asc;
            head = null;
            tail = null;
        }

        public int Count()
        {
            // подсчёта количества элементов в списке
            int counter = 0;
            Node<T> node = head;
            while (node != null)
            {
                counter++;
                node = node.next;
            }
            return counter;
        }

        List<Node<T>> GetAll() 
        {
        // выдать все элементы упорядоченного списка в виде стандартного списка
            List<Node<T>> r = new List<Node<T>>();
            Node<T> node = head;
            while (node != null)
            {
                r.Add(node);
                node = node.next;
            }
            return r;
        }

        public void ShowLinkedList()
        {
        // вывод списка в консоль
            Node<T> node = head;
            while (node != null)
            {
                Console.Write(node.value + " ");
                node = node.next;
            }
            Console.WriteLine();
            if (head == null && tail == null) { Console.WriteLine("head: null tail: null"); }
            else Console.WriteLine("head: " + head.value + " tail: " + tail.value);
            Console.WriteLine();
        }
    }

}
