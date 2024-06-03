//реализация двунаправленного связного списка
using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Node
    {
        // узел - хранит значение и ссылку на пред. и след.
        public int value;
        public Node next, prev;

        public Node(int _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class LinkedList2
    {
        // хранит ссылки на хвост и голову
        public Node head;
        public Node tail;

        public LinkedList2()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            // вставка в хвост
            // если голова пуста - вставка в неё, иначе за хвостом
            if (head == null)
            {
                head = _item;
                head.next = null;
                head.prev = null;
            }
            else
            {
                tail.next = _item;
                _item.prev = tail;
            }
            tail = _item;
        }

        public Node Find(int _value)
        {
            // поиск узла по заданному значению
            // совершаем обход; если элемент найден - возвращаем его
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) { return node; }
                node = node.next;
            }
            return null;
        }

        public List<Node> FindAll(int _value)
        {
            // поиск всех узлов по заданному значению
            // если элемент найден - заносим в список
            List<Node> nodes = new List<Node>();
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) { nodes.Add(node); }
                node = node.next;
            }
            return nodes;
        }

        public bool Remove(int _value)
        {
            // удаление одного узла по заданному значению
            // для удаления нужно устранить связность текущего узла (т.е. предыдущий должен ссылаться не на текущий, а на следующий после текущего)
            Node node = head;
            while (node != null)
            {
                // если элемент найден
                if (node.value == _value)
                {
                    // если предыдущий - пустой, то искомый - 1й элемент; 2й становится головой списка
                    if (node.prev == null)
                    {
                        // если следующий за головой пустой, то в списке 1 элемент
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
                    // если предыдущий есть, то искомый в середине или в конце
                    else
                    {
                        // если следующий - пустой, то искомый - последний эл-т; предыдущий становится хвостом списка
                        if (node.next == null)
                        {
                            node.prev.next = null;
                            tail = node.prev;
                        }
                        // если следующий есть, то искомый в середине
                        else
                        {
                            node.prev.next = node.next;
                            node.next.prev = node.prev;
                        }
                    }
                    // элемент найден - возвращаем true; прекращаем проход
                    return true;
                }
                // элемент не найден - проход дальше
                else
                {
                    node = node.next;
                }
            }
           // обход завершён, элемент не найден - возвращаем false;
            return false;
        }

        public void RemoveAll(int _value)
        {
            // здесь будет ваш код удаления всех узлов по заданному значению
            // по аналогии с Remove
            Node node = head;
            while (node != null)
            {
                // элемент найден
                if (node.value == _value)
                {
                    // если предыдущий - пустой, то искомый - 1й элемент; 2й становится головой списка
                    if (node.prev == null)
                    {
                        // если следующий - пустой, то в списке один элемент
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
                    // если предыдущий есть, то искомый в середине или в конце
                    else
                    {
                        // если следующий - пустой, то искомый - последний эл-т; предыдущий становится хвостом списка
                        if (node.next == null)
                        {
                            node.prev.next = null;
                            tail = node.prev;
                        }
                        // если следующий есть, то искомый в середине
                        else
                        {
                            node.prev.next = node.next;
                            node.next.prev = node.prev;
                        }
                    }
                }
                //т.к. нужны все вхождения - продолжаем обход
                node = node.next;
            }
        }

        public void Clear()
        {
            // очистка всего списка
            // устраняем связность
            head = null;
            tail = null;
        }

        public int Count()
        {
            // подсчёт количества элементов в списке
            int counter = 0;
            Node node = head;
            while (node != null)
            {
                counter++;
                node = node.next;
            }

            return counter; 
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            // вставка узла после заданного 
            // если заданный - пустой, добавляем в начало;
            if (_nodeAfter == null)
            {
                //если голова пуста, то в списке нет элементов
                if (head == null)
                {
                    head = _nodeToInsert;
                    tail = _nodeToInsert;
                    _nodeToInsert.next = null;
                    _nodeToInsert.prev = null;
                }
                //иначе ставим на первое место
                else
                {
                    head.prev = _nodeToInsert;
                    _nodeToInsert.next = head;
                    head = _nodeToInsert;
                }
            }
            else
            {
                // соверашем обход; если элемент найден - вставляем
                Node node = head;
                while (node != null)
                {
                    // элемент найден
                    if (node.value == _nodeAfter.value)
                    {
                        // если следующий - пустой, то заданный - последний эл-т; вставляем в конец
                        if (node.next == null)
                        {
                            node.next = _nodeToInsert;
                            _nodeToInsert.prev = node;
                            _nodeToInsert.next = null;
                            tail = _nodeToInsert;
                        }
                        else
                        {
                            _nodeToInsert.next = node.next;
                            _nodeToInsert.prev = node;
                            node.next = _nodeToInsert;
                            node.next.prev = _nodeToInsert;
                        }
                    }
                    // элемент не найден - идём дальше
                    node = node.next;
                }
            }
        }
        public void ShowLinkedList()
        {
            // вывод в консоль
            Node node = head;
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
