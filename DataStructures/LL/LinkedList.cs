using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.LL
{
    public class LinkedList //здесь будут методы. Все что тут хранится - это ссылка на первую ноду root

    {
        public int Length { get; set; }

        private Node _root; // приватная, пользователь не имеет к ней доступа 

        //Индексатор
        public int this[int index]
        {
            get
            {
                if (index <0 || index > Length)
                {
                    throw new IndexOutOfRangeException();
                }
                else 
                {
                    Node tmp = _root; //здечь tmp хранит ссылку на 0 элемент

                    for (int i = 1; i <= index; i++) //отсчет с 1, потому что ссылка на 0 элемент уже в руте и в tmp
                    {
                        tmp = tmp.Next; //переопределяет ссылку на 0 на 1 элемент. Теперь tmp указывает на следующий (1) элемент.
                    }

                    return tmp.Value; //здесь выдает значение 1 элемента
                }
            }
            set
            {
                Node tmp = _root;

                for (int i = 1; i <= index; i++)
                {
                    tmp = tmp.Next;
                }

                tmp.Value = value;
            }
        }

        //конструкторы
        public LinkedList() //пустой констр. Не должен обращаться с рутом, тк если будет ссылка на к-то объект, то мы уже создали объект с 0 индексм
        {
            Length = 0;
            _root = null;
        }
        public LinkedList(int value) //на основе 1 элемента. 
        {
            _root = new Node(value); //в _root хранится ссылка на первую ноду, у кот уже есть конкретное значение value (т.е рут равен новой первой ноде)
            Length = 1;
        }
        public LinkedList(int[] array)
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
                    
                    tmp = tmp.Next; //переопределии ссылку. tmp хранила ссылку рут на первый (0) элемент, а теперь ссылку на след элемент в листе 
                }
                Length = array.Length;
            }
            else
            {
                Length = 0;
                _root = null;
            }
        } //на основе массива


        //добавление по индексу 
        public void AddByIndex(int index, int value)
        {
            if (index == 0)
            {
                Node tmp = _root;
                _root = new Node(value);
                _root.Next = tmp;
            }
            else
            {
                Node current = _root; //current - текущее значение, ссылается туда же, куда рут, т.е на 1 элемент в списке (0)

                for (int i = 1; i < index; i++) //идем по списку, доходим до элемента, котрый неаходится на 1 позицию раньше, 
                                                //чтобы оттуда сослаться на новый элемент tmp
                {
                    current = current.Next;
                }
                Node tmp = current.Next;   //tmp  - временная переменная. Сохраняем в нейсссылку из текущей (current.Next). 
                current.Next = new Node(value); //new Node(value) - создали новый элемент. ссылка current.Next теперь ведет на этот  элемент 

                current.Next.Next = tmp;

                Length++;
            }
        }

        //добавление значения в конец
        public void AddToEnd(int value)
        {
            if (_root == null)
            {
                Node tmp = _root;
                _root = new Node(value);
                _root.Next = tmp;
                ///еще способ: 
                ///_root = new Node (value)
                ///Length = 1;
            }
            else
            {
                Node current = _root;
                for (int i = 1; i < Length; i++)
                {
                    current = current.Next;
                }

                Node tmp = current.Next;
                current.Next = new Node(value);

                current.Next.Next = tmp;
            }
            Length++;
        }

        //Добавление значения в начало 
        public void AddToBeginning (int value)
        {
            Node tmp = _root;
            _root = new Node(value);
            _root.Next = tmp; 
 
            Length++;
        }

        //удаление значения из конца
        public void RemoveFromEnd()
        {
            Node current = _root;
            for (int i = 0; i < Length - 1; i++)
            {
                current = current.Next;
            }
            current.Next = null;
            Length--;
        }

        //удаление из начала 
        public void RemoveFromBeginning ()
        {
            for (int i = 1; i < Length; i++)
            {
                if (i == 1)
                _root = _root.Next;
            }
        }

        //удаление значения по индексу
        public void RemoveByIndex(int index)
        {
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                if (index == 0)
                {
                    Node tmp = _root;
                    _root = tmp.Next;
                }
                else
                {
                    Node current = _root;
                    for (int i = 0; i < index - 1; i++)
                    {
                        current = current.Next;
                    }
                    current.Next = current.Next.Next;
                }
            }
        }

        //Метод получения длины (он не нужен, т.к можно просто обращаться к свойству Length )
        public int GetLength()
        {
            int count = 0;
            Node current = _root;
            for (int i = 0; i < Length; i++)
            {
                current = current.Next;
                count++;
            }

            return count;
        }


        //получение индекса по значению
        public int GetIndexByValue(int value)
        {
            int index = 0;
            Node current = _root;
            for (int i = 0; i < Length; i++)
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

       // изменение значения по индексу
        public void ChangeByIndex(int index, int value)
        {
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                Node current = _root;

                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                current.Value = value;
            }
        }

        //получить маскимальногоо элемента
        public int GetMaximum()
        {
            Node current = _root;
            
            int max = current.Value;

            for (int i = 1; i <  Length; i++)
            {
                current = current.Next;
                if (current.Value > max)
                {
                     max = current.Value;
                }
            }
            
            return max;
        }

        //получить  миниимальногоо элемента
        public int GetMinimum()
        {
            Node current = _root;

            int min = current.Value;

            for (int i = 1; i < Length; i++)
            {
                current = current.Next;
                if (current.Value < min)
                {
                    min = current.Value;
                }
            }

            return min;
        }

        //получить индекс маскимальногоо элемента
        public int GetIndexOfMaximum ()
        {
            Node current = _root;
            int max = current.Value;
            int maxIndex = 0;

            for (int i = 1; i < Length; i++)
            {
                current = current.Next;
                if (current.Value > max)
                {
                    max = current.Value;
                    maxIndex = i;
                }
               
            }
            return maxIndex;
        }

        //получить индекс миниимальногоо элемента
        public int GetIndexOfMinimum()
        {
            Node current = _root;
            int min = current.Value;
            int minIndex = 0;

            for (int i = 1; i<Length; i++)
            {
                current = current.Next;
                if (current.Value <min)
                {
                    min = current.Value;
                    minIndex = i;
                }
            }
            return minIndex;
        }

        //удаление первого элемента по значению
        public void RemoveFirstByValue(int value)
        {
            if (Length <= 0)
            {
                throw new NullReferenceException();
            }
            else
            {
                int index = GetIndexByValue(value);

                RemoveByIndex(index);

            }
        }

        //удаление всех одинаковых элементов по значению
        public void RemoveAllByValue(int value)
        {
          
         if (Length ==0)
            {
                return;
            }
            while (_root.Value == value)
            {
                _root = _root.Next;
                Length--;
            }

            Node current = _root;
            while (current != null && current.Next !=null)
            {
                if (current.Next.Value == value)
                    current.Next = current.Next.Next;
                Length--;
                current = current.Next;
            }
           

        }

        //метод реверс
        public void Revers ()
        {
            Node oldRoot = _root;
            Node tmp;

            while (oldRoot.Next != null) 
            {
                tmp = oldRoot.Next; 
                oldRoot.Next = oldRoot.Next.Next; 
                tmp.Next = _root; 
                _root = tmp; 

            }
        }

        //добавление массива в конец
        public void AddArrayToTheEnd (int [] array)
        {
            Node current = _root;
            for (int i = 1; i<Length; i++)
            {
                current = current.Next; 
            }

            for (int i = array.Length -1; i >=0; i--)
            {
                Node tmp = current.Next;
                current.Next = new Node(array[i]);
                current.Next.Next = tmp;
                Length++;
            }
        }

        //добавление массива в начало 
        public void AddArrayToBeginning (int[] array)
        {
            for (int i = array.Length - 1;  i >= 0; i--)
            {
                Node tmp = _root;
                _root = new Node(array[i]);
                _root.Next = tmp;
                Length++;
            }
        }

        //добавление массива по индексу 
        public void AddArrayByIndex (int index, int[] array)
        {
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                if (index == array.Length - 1)
                {
                    AddArrayToTheEnd(array);
                }
                else
                {
                    Node current = _root;
                    for (int i = 0;  i< index; i++)
                    {
                        current = current.Next;
                    }
                    for (int i = array.Length - 1; i >= 0; i--)
                    {
                        Node tmp = current.Next;
                        current.Next = new Node(array[i]);
                        current.Next.Next = tmp;
                        Length++;
                    }
                }
            }
        }

        //удаление N элементов из конца
        public void RemoveNElementsFromTheEnd (int number)
        {
            Node current = _root;
            
            for (int i = 0; i < Length -number; i++)
            {
                current = current.Next;
            }
            Length -= number;
        }

        //удаление N элементов из начала
        public void RemoveNElementsFromBeginning (int number)
        {
            if (Length < 0)
            {
                throw new NullReferenceException();
            }
            else
            {
                Node current = _root;
                for (int i = 1; i < number; i++)
                {
                    current = current.Next;
                }
                _root = current.Next;
                Length -= number;
            }
        }

        //удаление по индексу N элементов
        public void RemoveNElementsByIndex(int index, int number)
        {
            for (int i = 0; i<number; i++)
            {
                RemoveByIndex(index);
            }
        }


        
        //метод для сравнения списков. Нужен, потому что по умолчанию Equals у объектов сравнивает не значения, которые в них а ссылки. Equals выподняеся только в том случае, если обе ссылки указывают на один и тот же обект в куче  
        public override bool Equals(object obj)
        {
            LinkedList linkedList = (LinkedList)obj;


            if (Length != linkedList.Length) //сначала мы сравниывем длины, если разные (объекы не одинаковые),то возвращем false.
            {
                return false;
            }
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

            for (int i = 0; i < Length; i++) //сравниваем поэлементно значения списков
            {
                if (tmp1.Value != tmp2.Value)
                {
                    return false;
                }
                tmp1 = tmp1.Next; 
                tmp2 = tmp2.Next;
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

       

    }
}
