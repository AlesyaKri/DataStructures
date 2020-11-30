using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.DLL
{
    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
        public Node Prev { get; set; }

        public Node(int value)
        {
            Value = value;
            Next = null;
            Prev = null;
        }
        public Node()
        {
            Next = null;
            Prev = null;
        }

        //конструктор на основе ноды (создаем копию ноды)
        public Node(Node node)
        {
            Next = node.Next;
            Prev = node.Prev;
            Value = node.Value;
        }
    }
}
