using System;
using System.Collections.Generic;
using System.Text;
using DataStructures.LL;
using NUnit.Framework;

namespace DataStructures.Tests
{
    public class LinkedListTests
    {

        [TestCase(new int[] { 1, 2, 3, }, 1, 4, new int[] { 1, 4, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, }, 0, 4, new int[] { 4, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, }, 3, 4, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { }, 0, 4, new int[] { 4 })]
        [TestCase(new int[] { 1 }, 0, 4, new int[] { 4, 1 })]


        public void AddByIndexTest(int[] array, int index, int value, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);

            actual.AddByIndex(index, value);
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, 2, 3, }, 4, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2 }, 4, new int[] { 1, 2, 4 })]
        [TestCase(new int[] { }, 4, new int[] { 4 })]

        public void AddToEndTest(int[] array, int value, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);

            actual.AddToEnd(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, }, 4, new int[] { 4, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2 }, 4, new int[] { 4, 1, 2 })]
        [TestCase(new int[] { }, 4, new int[] { 4 })]

        public void AddToBeginningTest(int[] array, int value, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);

            actual.AddToBeginning(value);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2 }, new int[] { 1 })]
      
        public void RemoveFromEndTest(int[] array, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);

            actual.RemoveFromEnd();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 2, 3, 4 })]
        [TestCase(new int[] { 1, 2 }, new int[] { 2 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        [TestCase(new int[] { }, new int[] { })]
        public void RemoveFromBeginningTest(int[] array, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);

            actual.RemoveFromBeginning();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 0, new int[] { 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 1, new int[] { 1, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 3, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 3, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1 }, 0, new int[] { })]

        public void RemoveByIndexTest(int[] array, int index, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);

            actual.RemoveByIndex(index);

            Assert.AreEqual(expected, actual);
        }


       //Получить длину(не надо метода)
        [TestCase(new int[] { 1, 2, 3, 4 }, 4)]
        [TestCase(new int[] { 1, 2, 3 }, 3)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { }, 0)]
        public void GetLengthTest(int[] array, int expLength)
        {
            int expected = expLength;
            LinkedList ll = new LinkedList(array);
            int result = ll.Length;

            Assert.AreEqual(expected, result);
        }


        //Доступ по индексу 

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 5)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 1)]
        [TestCase(new int[] { 1 }, 0, 1)]

        public void GetByIndexTest(int[] array, int index, int expected)
        {

            LinkedList ll = new LinkedList(array);

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
            LinkedList ll = new LinkedList(array);
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
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.ChangeByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { 8, 3, 5, 4 }, 8)]
        [TestCase(new int[] { 1, 6, 2, 3 }, 6)]
        [TestCase(new int[] { 1 }, 1)]
        public void GetMaximumTest(int[] array, int expected)
        {
            LinkedList ll = new LinkedList(array);

            int actual = ll.GetMaximum();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1)]
        [TestCase(new int[] { 8, 3, 5, 4 }, 3)]
        [TestCase(new int[] { 3, 6, 2, 1 }, 1)]
        [TestCase(new int[] { 1 }, 1)]
        public void GetMinimumTest(int[] array, int expected)
        {
            LinkedList ll = new LinkedList(array);

            int actual = ll.GetMinimum();

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4)]
        [TestCase(new int[] { 8, 3, 5, 4 }, 0)]
        [TestCase(new int[] { 3, 6, 2, 1 }, 1)]
        [TestCase(new int[] { 1 }, 0)]
      

        public void GetIndexOfMaximumTest(int[] array, int index)
        {
            int expected = index;
            LinkedList ll = new LinkedList(array);
            int actual = ll.GetIndexOfMaximum();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0)]
        [TestCase(new int[] { 8, 3, 5, 4 }, 1)]
        [TestCase(new int[] { 3, 6, 2, 1 }, 3)]
        [TestCase(new int[] { 1 }, 0)]
      
        public void GetIndexOfMinimumTest(int[] array, int index)
        {
            int expected = index;
            LinkedList ll = new LinkedList(array);
            int actual = ll.GetIndexOfMinimum();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 2, 5 }, 2, new int[] { 1, 3, 2, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, new int[] { 1, 2, 3, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, new int[] { 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1 }, 1, new int[] { })]

        public void RemoveFirstByValueTest(int[] array, int value, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.RemoveFirstByValue(value);

            Assert.AreEqual(expected, actual);
        }



        [TestCase(new int[] { 1, 2, 3, 2, 5 }, 2, new int[] { 1, 3, 5 })]
        [TestCase(new int[] { 1, 1, 3, 2, 5 }, 1, new int[] { 3, 2, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 4 }, 4, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 1 }, 1, new int[] { })]
        public void RemoveAllByValueTest(int[] array, int value, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.RemoveAllByValue(value);

            Assert.AreEqual(expected, actual);
        }



        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 8, 5, 3, 4, 2 }, new int[] { 2, 4, 3, 5, 8 })]

        public void ReversTest(int[] array, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.Revers();
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 6, 7, 8 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 6, 7, 8 }, new int[] { 1, 2, 3, 6, 7, 8 })]
        public void AddArrayToTheEndTest(int[] array, int[] addArray, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.AddArrayToTheEnd(addArray);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 6, 7, 8 }, new int[] { 6, 7, 8, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 6, 7, 8 }, new int[] { 6, 7, 8, 1, 2, 3 })]
        public void AddArrayToBeginningdTest(int[] array, int[] addArray, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.AddArrayToBeginning(addArray);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, new int[] { 6, 7, 8 }, new int[] { 1, 2, 6, 7, 8, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3 }, 0, new int[] { 6, 7, 8 }, new int[] { 1, 6, 7, 8, 2, 3 })]

        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 6, 7, 8 }, new int[] { 1, 2, 3, 6, 7, 8 })]

        public void AddArrayByIndexTest(int[] array, int index, int[] addArray, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.AddArrayByIndex(index, addArray);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3 }, 3, new int[] { })]
        public void RemoveNElementsFromTheEndTest(int[] array, int number, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.RemoveNElementsFromTheEnd(number);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, new int[] { 4, 5 })]
        [TestCase(new int[] { 1, 2, 3 }, 3, new int[] { })]
       
        public void RemoveNElementsFromBeginningTest(int[] array, int number, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.RemoveNElementsFromBeginning(number);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, 2, new int[] { 1, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 2, new int[] { 1, 2,3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 2, new int[] { 3, 4, 5})]
        public void RemoveNElementsByIndexTest(int[] array, int index, int number, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.RemoveNElementsByIndex(index, number);
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { }, 1)]

        public void RemoveByIndexNegative(int[] arr, int index)
        {
            LinkedList ll = new LinkedList(arr);

            Assert.Throws<IndexOutOfRangeException>(() => ll.RemoveByIndex(index));
        }


        [TestCase(new int[] { }, 1)]

        public void GetByIndexNegative(int[] arr, int index)
        {
            LinkedList ll = new LinkedList(arr);

            try
            {
                int actual = ll[index];
            }
            catch (IndexOutOfRangeException)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }



        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5, 6)]
        [TestCase(new int[] { }, 0, 5)]

        public void ChangeByIndexNegative(int[] arr, int index, int value)
        {
            LinkedList ll = new LinkedList(arr);

            Assert.Throws<IndexOutOfRangeException>(() => ll.ChangeByIndex(index, value));
        }


        [TestCase(new int[] { }, 6)]
        [TestCase(new int[] { }, 5)]

        public void RemoveFirstByValueNegative(int[] arr, int value)
        {
            LinkedList ll = new LinkedList(arr);

            Assert.Throws<NullReferenceException>(() => ll.RemoveFirstByValue(value));
        }

        [TestCase(new int[] { }, 5)]
        public void RemoveNElementsFromBeginningNegative(int[] array, int number)
        {
            LinkedList ll = new LinkedList(array);

            Assert.Throws<NullReferenceException>(() => ll.RemoveNElementsFromBeginning(number));
        }
    }

}
