using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using DataStructures.DLL;

namespace DataStructures.Tests
{
    public class DLinkedListTests
    {
        [TestCase(new int[] { 1, 2, 3, }, 4, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2 }, 4, new int[] { 1, 2, 4 })]
        [TestCase(new int[] { }, 4, new int[] { 4 })]

        public void AddToEndTest(int[] array, int value, int[] expArray)
        {
            DLinkedList expected = new DLinkedList(expArray);
            DLinkedList actual = new DLinkedList(array);

            actual.AddToEnd(value);

            Assert.AreEqual(expected, actual);
        }

        //добавление по индексу 1 значение 
        [TestCase(new int[] { 1, 2, 3, }, 1, 4, new int[] { 1, 4, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, }, 0, 4, new int[] { 4, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, }, 2, 4, new int[] { 1, 2, 4, 3 })]
        [TestCase(new int[] { }, 0, 4, new int[] { 4 })]
        [TestCase(new int[] { 1 }, 0, 4, new int[] { 4, 1 })]
        public void AddByIndexTest(int[] array, int index, int value, int[] expArray)
        {
            DLinkedList expected = new DLinkedList(expArray);
            DLinkedList actual = new DLinkedList(array);

            actual.AddByIndex (index, value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, }, 4, new int[] { 4, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2 }, 4, new int[] { 4, 1, 2 })]
        [TestCase(new int[] { }, 4, new int[] { 4 })]

        public void AddToBeginningTest(int[] array, int value, int[] expArray)
        {
            DLinkedList expected = new DLinkedList(expArray);
            DLinkedList actual = new DLinkedList(array);

            actual.AddToBeginning(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2 }, new int[] { 1 })]
        [TestCase(new int[] { }, new int[] { })]
        public void RemoveFromEndTest(int[] array, int[] expArray)
        {
            DLinkedList expected = new DLinkedList(expArray);
            DLinkedList actual = new DLinkedList(array);

            actual.RemoveFromEnd();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 2, 3, 4 })]
        [TestCase(new int[] { 1, 2 }, new int[] { 2 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        [TestCase(new int[] { }, new int[] { })]
        public void RemoveFromBeginningTest(int[] array, int[] expArray)
        {
            DLinkedList expected = new DLinkedList(expArray);
            DLinkedList actual = new DLinkedList(array);

            actual.RemoveFromBeginning();

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, 2, 3, 4 }, 0, new int[] { 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 1, new int[] { 1, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 2, new int[] { 1, 2, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 3, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1 }, 0, new int[] { })]

        public void RemoveByIndexTest(int[] array, int index, int[] expArray)
        {
            DLinkedList expected = new DLinkedList(expArray);
            DLinkedList actual = new DLinkedList(array);

            actual.RemoveByIndex(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 4)]
        [TestCase(new int[] { 1, 2, 3 }, 3)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { }, 0)]
        public void GetLengthTest(int[] array, int expLength)
        {
            int expected = expLength;
            DLinkedList ll = new DLinkedList(array);
            int result = ll.Length;

            Assert.AreEqual(expected, result);
        }

        ////Доступ по индексу 

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 5)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 1)]
        [TestCase(new int[] { 1 }, 0, 1)]

        public void GetByIndexTest(int[] array, int index, int expected)
        {

            DLinkedList ll = new DLinkedList(array);

            int actual = ll[index];

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 5, 3, 4, 5 }, 5, 4)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, 0)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5, 4)]
        [TestCase(new int[] { 1 }, 1, 0)]
        [TestCase(new int[] { }, 0, 0)]
        public void GetIndexByValueTest(int[] array, int value, int index)
        {
            int expected = index;
            DLinkedList ll = new DLinkedList(array);
            int actual = ll.GetIndexByValue(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 6, new int[] { 1, 2, 6, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 7, new int[] { 1, 2, 3, 4, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 8, new int[] { 8, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 9, new int[] { 1, 2, 3, 9, 5 })]
        [TestCase(new int[] { 1 }, 0, 10, new int[] { 10 })]


        public void ChangeByIndexTest(int[] array, int index, int value, int[] expArray)
        {
            DLinkedList expected = new DLinkedList(expArray);
            DLinkedList actual = new DLinkedList(array);
            actual.ChangeByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 8, 5, 3, 4, 2 }, new int[] { 2, 4, 3, 5, 8 })]

        //public void ReversTest(int[] array, int[] expArray)
        //{
        //    DLinkedList expected = new DLinkedList(expArray);
        //    DLinkedList actual = new DLinkedList(array);
        //    actual.Revers();
        //    Assert.AreEqual(expected, actual);
        //}

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { 8, 3, 5, 4 }, 8)]
        [TestCase(new int[] { 1, 6, 2, 3 }, 6)]
        [TestCase(new int[] { 1 }, 1)]
        public void GetMaximumTest(int[] array, int expected)
        {
            DLinkedList ll = new DLinkedList(array);

            int actual = ll.GetMaximum();

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5, 6)]
        [TestCase(new int[] { }, 0, 5)]

        public void ChangeByIndexNegative(int[] arr, int index, int value)
        {
            DLinkedList ll = new DLinkedList(arr);

            Assert.Throws<IndexOutOfRangeException>(() => ll.ChangeByIndex(index, value));
        }
    }



}
