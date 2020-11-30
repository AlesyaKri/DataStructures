using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.DLL
{

    public class DLinkedList

    {
        public int Length { get; set; }

        private Node _root;
        private Node _tail;

        public DLinkedList() //пустой констр. Не должен обращаться с рутом, тк если будет ссылка на к-то объект, то мы уже создали объект с 0 индексм
        {
            Length = 0;
            _root = null;
            _tail = null;
        }
        public DLinkedList(int value) //на основе 1 элемента. 
        {
            _root = new Node(value); //в _root хранится ссылка на первую ноду, у кот уже есть конкретное значение value (т.е рут равен новой первой ноде)
            _tail = _root;
            Length = 1;
        }
  
        public DLinkedList(int[] array)
        {
            if (array.Length != 0)
            {
               
                _root = new Node(array[0]); //потому что ссылка из рут на первый элемент массива, т.е. [0]
                Node tmp = _root;//должны создать временную (temprorary) переменную, ссылаетс на тот же элемент что рут, т.е первый (0)

                for (int i = 1; i < array.Length; i++) //циклом пройтись по всему массиву и каждый новый элемент записать в конец нашего списка 
                {
                    tmp.Next = new Node(array[i]);  //tmp.Next - обащение к полю типа ноды где хранится ссылка на след элемент (т.е обратились к самому элементу, где ест значение и ссылка на след элемет

                    //ВАЖНО!  tmp.Next = new Node(array[i]);  Сначала выполняется действие справа. при этом создается на куче новый объект, 
                    //туда передается цифра. И как рез-т работы, возвращаем ссылку на этот объект, которая попадает в левую сторону tmp.Next, т.е в поле Next предыдущей ноды

                    // При обращении к ссылке (tmp.Next) мы обращаемся к объекту, который лежит по этой ссылке )
                    tmp.Next.Prev = tmp;
                    tmp = tmp.Next; //переопределии ссылку. tmp хранила ссылку рут на первый (0) элемент, а теперь ссылку на след элемент в листе 
                    
                }
                _tail = tmp;
                Length = array.Length;
            }
            else
            {
                Length = 0;
                _root = null;
                _tail =  null;
            }
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index > Length)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {

                    Node tmp = _root;

                    if (index < Length / 2)
                    {
                        for (int i = 0; i < index; i++)
                        {
                            tmp = tmp.Next;
                        }
                    }
                    else
                    {
                        tmp = _tail;

                        for (int i =Length - 1; i > index; i--)
                        {
                            tmp = tmp.Prev;
                        }
                    }

                    return tmp.Value; 
                }
            }
            set
            {
                Node tmp = _root;

                if (index < Length / 2)
                {

                    for (int i = 0; i < index; i++)
                    {
                        tmp = tmp.Next;
                    }
                }
                else
                {
                    tmp = _tail;

                    for (int i = Length - 1; i > index; i--)
                    {
                        tmp = tmp.Next;
                    }
                }

                tmp.Value = value;
            }
        }

        public void AddToEnd(int value)
        {

            if (Length == 0)
            {
                _root = new Node(value); //в _root хранится ссылка на первую ноду, у кот уже есть конкретное значение value (т.е рут равен новой первой ноде)
                _tail = _root;
            }
           
                Node current = _tail;
                _tail.Next = new Node(value);
                current.Next.Prev = current;
                _tail = current.Next ;
                Length++;

            
        }

        public void AddToBeginning(int value)
        {

            if (Length == 0)
            {
                _root = new Node(value); //в _root хранится ссылка на первую ноду, у кот уже есть конкретное значение value (т.е рут равен новой первой ноде)
                _tail = _root;
            }
                Node tmp = _root;
            _root = new Node(value);
            _root.Next = tmp;
            _root.Next.Prev = _root;
            Length++;
        }

        //добавление по индексу 
        public void AddByIndex(int index, int value) //ДОБАВИТЬ ИСКЛЮЧЕНИЕ, ЕСЛИ ПУСТОЙ МАССИВ
        {
            if (index == 0)
            {
                Node tmp = _root;
                _root = new Node(value);
                _root.Next = tmp;
                _root.Next.Prev = _root;

            }
            //else if (index == Length -1)
            //{
            //    AddToEnd(value);
            //    Length++;
            //}
            else
            {

                Node a = GetNodeByIndex(index);
                a = a.Prev;
                Node b = new Node(value);
                Node c = a.Next;

                b.Prev = a;
                a.Next = b;
                b.Next = c;
                c.Prev = b;

                Length++;
            }
        }

        //удаление из конца
        public void RemoveFromEnd()
        {
           if (Length !=0)
            {
                _tail = _tail.Prev;
                Length--;
            }
            
        }

        //удаление из начала 
        public void RemoveFromBeginning ()
        {
            _root = _root.Next;
            Length--;
        } //ДОБАВИТЬ ИСКЛЮЧЕНИЕ ПУСТОЙ МАССИВ

        // удаление по индексу
        public void RemoveByIndex (int index)
        {
            if (index == 0)
            {
                RemoveFromBeginning();
            }
            else if (index == Length - 1)
            {
                RemoveFromEnd();
                
            }
            else
            {
                Node a = GetNodeByIndex(index);

                Node b = a.Next;
                a = a.Prev;
                a.Next = b;
                b.Prev = a;
                Length--;
            }
           
        }

        // вернуть индекс по значению
        public int GetIndexByValue (int value)
        {
            
            int index = 0;
            Node current = _root;

            for (int i = 1; i<Length; i++)
            {
                if (current.Value == value)
                {
                    index = i;
                    break;
                }
                current = current.Next;
            }
            return index;
        }

        //изменение по индексу 
        public void ChangeByIndex(int index, int value)
        {
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                Node current = GetNodeByIndex(index);
                current.Value = value;
            }

        }

     

        public int GetMaximum()
        {

            Node tmp = _root;
            int max = tmp.Value;

            for (int i = 1; i<=Length; i++ )
            {
               
                if (tmp.Value > max)
                {
                    max = tmp.Value;
                   
                }
               
                tmp = tmp.Next;
             
            }
            return max;
        }

   
        public override bool Equals(object obj)
        {
            DLinkedList linkedList = (DLinkedList)obj;


            //    if (Length !=linkedList.Length) //сначала мы сравниывем длины, если разные (объекы не одинаковые),то возвращем false.
            //    {
            //        return false;
            //    }
            //for (int i = 0; i <Length; i++) //затем поэлементно с помощью перегруженного индексатора 
            //{
            //   if (this [i] != linkedList [i]) //перегруженный индексатор 
            //    {
            //        return false; //если хоть одна пара не совпадает, возвращаем false
            //    }
            //}


            //этот метод сравнения быстрее 

            Node tmp1 = _root; //начало первого списка
            Node tmp2 = linkedList._root;  //начало второго списка

            while (tmp1 != null)
            {
                if (tmp1.Value != tmp2.Value)
                {
                    return false;
                }
                tmp1 = tmp1.Next;
                tmp2 = tmp2.Next;
            }
            //добавляем такое же условие, только для тейл. Но добавляем цикл, который бежит назад, для проверки правильности связки ссылок  
            tmp1 = _tail; 
            tmp2 = linkedList._tail;

            while (tmp1 != null)
            {
                if (tmp1.Value != tmp2.Value)
                {
                    return false;
                }
                tmp1 = tmp1.Prev;
                tmp2 = tmp2.Prev;
            }
            return true;
        }

        public override string ToString()
        {
            string s = "";

            if (_root != null)
            {
                Node tmp = _root;

                while (tmp != null)
                {
                    s += tmp.Value + ";";
                    tmp = tmp.Next;
                }
            }
            return s;
        }

       

    
        private Node GetNodeByIndex (int index)
        {
            Node tmp = _root;

            if (index < Length / 2)
            {
                for (int i = 0; i < index; i++)
                {
                    tmp = tmp.Next;
                }
            }
            else
            {
                tmp = _tail;

                for (int i = Length - 1; i > index; i--)
                {
                    tmp = tmp.Prev;
                }
            }

            return tmp;
            
        }

    }
}
