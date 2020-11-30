using NUnit.Framework;
using DataStructures;
using System;
using System.Security.Cryptography.X509Certificates;

namespace DataStructures.Tests
{
    public class ArrayListTests
    {

        [TestCase(new int[] { 1, 2, 3, 4, }, 5, new int[] { 1, 2, 3, 4, 5 })]

        public void AddTest(int[] arrAct, int n, int[] arrExp)
        {
            ArrayList expected = new ArrayList(arrExp);
            ArrayList actual = new ArrayList(arrAct);
            actual.Add(n);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 2, 5, new int[] { 1, 2, 5, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 0, 5, new int[] { 5, 1, 2, 3, 4 })]

        public void AddElementByIndexTest(int[] ArrAct, int index, int value, int[] ArrExp)
        {
            ArrayList expected = new ArrayList(ArrExp);
            ArrayList actual = new ArrayList(ArrAct);
            actual.AddElementByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 4, 5)] //В негативных нет act и Exp

        public void AddElementByIndexNegative(int[] array, int index, int value) //на вход массив, индекс на который ставим значение value
        {
            ArrayList a = new ArrayList(array);

            try
            {
                a.AddElementByIndex(index, value); //вызываем метод, в котором прописано уже исключение 
            }
            catch (IndexOutOfRangeException) //если есть конкретное исключение, мы должны в скобках его прописать
            {
                Assert.Pass(); //если вызванный метод попадает под исключение, то тест пройден, если нет, то провален
            }
            Assert.Fail();
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 15, new int[] { 15, 1, 2, 3, 4, 5 })]

        public void AddElementAtBeginningTest(int[] arrAct, int index, int value, int[] arrExp)
        {

            ArrayList expected = new ArrayList(arrExp);
            ArrayList actual = new ArrayList(arrAct);

            actual.AddElementAtBeginning(index, value);
            Assert.AreEqual(actual, expected);

        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3 })]
        public void DeleteElementFromTheEndTest(int[] arrAct, int[] arrExp)
        {
            ArrayList expected = new ArrayList(arrExp);
            ArrayList actual = new ArrayList(arrAct);

            actual.DeleteElementFromTheEnd();
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, new int[]{1,2,4,5})]

        public void DeleteElementByIndexTest(int[] arrAct, int index, int []arrExp)
        {
            ArrayList expected = new ArrayList(arrExp);
            ArrayList actual = new ArrayList(arrAct);

            actual.DeleteElementByIndex(index);

            Assert.AreEqual(expected, actual);
        }
        
        //ДОСТУП ПО ИНДЕКСУ (уже есть в геттере индексатора, просто проверяем)
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 3)]
        public void ArrayListSIndexGetter (int[] array, int index, int expected)
        {

            ArrayList a = new ArrayList(array);

            int actual = a[index]; 

            Assert.AreEqual(expected, actual);

        }
        //ДОСТУП ПО ЗНАЧЕНИЮ (тоже уже есть,ю прописан в геттере наверху  public int Length { get; private set; })

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5, 4)]

        public void AccessByValueTest(int[] array, int value, int expected)
        {
            ArrayList a = new ArrayList(array);

            int actual = a.AccessByValue(value);
            Assert.AreEqual(expected, actual);
        }


        [TestCase (new int [] { 1,2,3,4,5}, 3, 10, new int[] {1,2,3,10,5} )]

        public void ChangeByIndexTest (int[]arrAct, int index, int value, int []arrExp)
        {
            ArrayList expected = new ArrayList(arrExp);
            ArrayList actual = new ArrayList(arrAct);

            actual.ChangeByIndex(index, value);
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5)]
        public void FindMaxElementTest (int []array, int expected)
        {

            ArrayList a = new ArrayList (array);

            int actual = a.FindMaxElement (array);

            Assert.AreEqual(expected, actual);

        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1)]
        public void FindMixElementTest(int[] array, int expected)
        {

            ArrayList a = new ArrayList(array);

            int actual = a.FindMinElement(array);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 2,3,4 })]
        [TestCase(new int[] { 8, 2, 3, 4 }, new int[] { 2, 3, 4 })]
        [TestCase(new int[] { 1 }, new int[] { })]

        public void RemoveElementFromBeginning (int[] array, int[] expArray)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);

            actual.RemoveElementFromBeginning();
            Assert.AreEqual(expected, actual);
        }

        //Assert.Throws <>


        //Assert.Throws<IndexOutOfRangeException>(() => a.AddByIndex(index, value));

    }
}