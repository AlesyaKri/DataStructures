using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.LL
{
    public class Node  //Нода это ячейка в списке, в которйо хранися значение ит ссылка на след ноду 
    {
       public int Value { get; set; } //значение которое хоти прочитать 
        public Node Next { get; set; } // в ноде хранится переменная типа Node (в ней храниться не объект а ссылка на следующую ноду (элемент))

        //конструкторы
        public Node (int value)
        {
            Value = value;
            Next = null;   //в любые переменные ссылочного типа можно явно класть null. 
        }
        public Node ()
        {
            Next = null;
        }

        //конструктор на основе ноды (создаем копию ноды)
        public Node(Node node)
        {
            Next = node.Next;
            Value = node.Value;
        }

    }
}
