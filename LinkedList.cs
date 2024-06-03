//реализация связного списка
using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Node
    {
        // узел - хранит значение и ссылку на след.
        public int value;
        public Node next;
        public Node(int _value) { value = _value; }
    }

    public class LinkedList
    {
        // хранит ссылки на хвост и голову
        public Node head;
        public Node tail;

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            // вставка в хвост
            // если голова пуста - вставка в неё, иначе за хвостом
            if (head == null) head = _item;
            else tail.next = _item;
            tail = _item;
        }

        public Node Find(int _value)
        {
            // поиск по значению
            // продвигаемся с головы, пока не найдём
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) return node;
                node = node.next;
            }
            return null;
        }

        public List<Node> FindAll(int _value)
        {
            // поиск всех узлов по заданному значению
            List<Node> nodes = new List<Node>();

            Node node = head;
            while (node != null)
            {
                //если элемент найден - заносим в список
                if (node.value == _value)
                {
                    nodes.Add(node);
                }
                node = node.next;
            }
            return nodes;
        }

        public bool Remove(int _value)
        {
            // удаление одного узла по заданному значению
            // для удаления нужно устранить связность текущего узла (т.е. предыдущий должен ссылаться не на текущий, а на следующий после текущего)

            Node node = head;
            Node previous = null;
            while (node != null)
            {
                //элемент найден
                if (node.value == _value)
                {
                    //если предыдущий - пустой, то искомый - 1й элемент; 2й становится головой списка
                    if (previous == null)
                    {
                        //если следующий за головой пустой, то в списке 1 элемент
                        if (head.next == null)
                        {
                            head = null;
                            tail = null;
                        }
                        else 
                        {
                            head = head.next;
                        }
                    }
                    //если предыдущий есть, то искомый в середине или в конце
                    else
                    {
                        //если следующий - пустой, то искомый - последний эл-т; предыдущий становится хвостом списка
                        if (node.next == null)
                        {
                            previous.next = null;
                            tail = previous;
                        }
                        //если следующий есть, то искомый в середине
                        else
                        {
                            previous.next = node.next;
                        }
                    }
                    //элемент найден - возвращаем true; прекращаем проход
                    return true;
                }
                //элемент не найден - проход дальше
                else
                {
                    previous = node;
                    node = node.next;
                }
            }
            return false;
        }

        public void RemoveAll(int _value)
        {
            // здесь будет ваш код удаления всех узлов по заданному значению
            // по аналогии с Remove
            Node node = head;
            Node previous = null;
            while (node != null)
            {
                //элемент найден
                if (node.value == _value)
                {
                    //если предыдущий - пустой, то искомый - 1й элемент; 2й становится головой списка
                    if (previous == null)
                    {
                        if (head.next == null)
                        {
                            head = null;
                            tail = null;
                        }
                        else
                        {
                            head = head.next;
                        }
                    }
                    //если предыдущий есть, то искомый в середине или в конце
                    else
                    {
                        //если следующий - пустой, то искомый - последний эл-т; предыдущий становится хвостом списка
                        if (node.next == null)
                        {
                            previous.next = null;
                            tail = previous;
                        }
                        //если следующий есть, то искомый в середине
                        else
                        {
                            previous.next = node.next;
                        }
                    }
                }
                //т.к. нужны все вхождения - продолжаем обход
                if (node.value != _value) previous = node;
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
            // проход по списку, если есть элемент - счётчик + 1
            Node node = head;
            int counter = 0;
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
                // если голова пустая, значит, список пуст
                // иначе всавляем перед головой
                if (head == null)
                {
                    head = _nodeToInsert;
                    tail = _nodeToInsert;
                    _nodeToInsert.next = null;
                }
                else
                {
                    _nodeToInsert.next = head;
                    head = _nodeToInsert;
                }
            }
            else
            {
                // ищем заданный
                Node node = head;

                while (node != null)
                {
                    // элемент найден
                    if (node.value == _nodeAfter.value)
                    {
                        // если следующий - пустой, то заданный - последний эл-т; вставляем в конец
                        // иначе вставляем послез заданного
                        if (node.next == null)
                        {
                            node.next = _nodeToInsert;
                            tail = _nodeToInsert;
                            _nodeToInsert.next = null;
                        }
                        else
                        {
                            _nodeToInsert.next = node.next;
                            node.next = _nodeToInsert;
                        }
                    }
                    // элемент не найден - проход дальше
                    node = node.next;
                }
            }
        }

        public LinkedList Merge(LinkedList l1, LinkedList l2)
        {
            // объединение двух списков - заносится сумма значений элементов
            LinkedList l = new LinkedList();
            //если длины равны и не равны нулю (в таком случае списки пусты)
            if (l1.Count() == l2.Count() && l1.Count() != 0)
            {
                Node node1 = l1.head; Node node2 = l2.head;

                //заносим голову
                l.head = new Node(node1.value + node2.value);

                Node current = l.head;

                //начинаем обход; создаём новый узел и связываем его с предыдущим эл-том
                while (node1 != null)
                {
                    //если следующий - пустой, значит, текущий - конец
                    if (node1.next == null)
                    {
                        l.tail = current;
                        l.tail.next = null;
                    }
                    //иначе создаём новый узел и связываем его с текущим, переходим на него
                    else
                    {
                        current.next = new Node(node1.next.value + node2.next.value);
                        current = current.next;
                    }
                    node1 = node1.next;
                    node2 = node2.next;
                }
            }
            return l;
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
