using System;
using DataStructures.LL;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 4 };
            LinkedList list = new LinkedList(a);
            list.AddToEnd(5);
           
            for (int i = 0; i < list.Length; i++)
            {

                Console.WriteLine(list[i]);
            }
        }
    }
}
