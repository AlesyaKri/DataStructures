using System;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;

namespace DataStructures
{
    public class ArrayList
    {
        public int Length { get; private set; } // Полезная длина. Свойство,т.к. будем обращаться извне

        private int[] _array; // Поле. должно быть приватным, т.к. доступ д.б. только к полезной длине массива + всю функциональность вынесены в методы

        private int _TrueLength
        {
            get
            {
                return _array.Length;
            }
        }

        public ArrayList() //Cоздаем конструктор 
        {
            _array = new int[9]; //создаем начальный массив длины 9
            Length = 0; //Начальная длина 
        }

        public ArrayList(int[] array) //Конструктор, принимающий массив на вход. 
        {
            _array = new int[(int)(array.Length * 1.33)];
            Length = array.Length;
            Array.Copy(array, _array, array.Length );
        }



        //Индексатор у классов (по сути метод)
        public int this [int i] //this - обращение именно к тому классу, где пишется индексатор 
        {
            get
            {
                if (i >= Length || i < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                return _array[i];
            }
            set
            {
                if (i >= Length || i < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                _array[i] = value;
            }
        }

        //для тетстов
        public override string ToString()
        {
            return string.Join(";", _array.Take(Length));
        }
        //для тестов
        public override bool Equals(object obj)
        {
            ArrayList arrayList = (ArrayList)obj;

            if (Length != arrayList.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < Length; i++)
                {
                    if (_array[i] != arrayList._array[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        
        
        //Добавление значения в конец листа

        public void Add(int value) //Создаем метод добавления. value - число, которое добавляем в конец масива
        {
            if (_TrueLength <= Length) //сначала проверяем, есть ли место в массиве перед тем как добавлять значение 
            {
                IncreaseLength(); //если не хватает места, то увеличиваем размер по методу IncreaseLength
            }
            _array[Length] = value; //кладем value на индекс массива (значение длины) Напирмер длина 3. добавляем число 6. Тогда _array[3] = 6.Это на четвертое место(3й индек) в массиве пойдет 6. то есть в конец 
            Length++; //полезная длина массива увеличесвается на 1
        }

        // Добавление значения по индексу 

        public void AddElementByIndex(int index, int value)
        
        {
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                if (_TrueLength <= Length)
                {
                    IncreaseLength();
                }
            MoveElementsToTheRight(index);
            _array[index] = value;
            }
        }
        
        //Удаление элемента по индексу
        public void DeleteElementByIndex (int index)
        {

            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else

                for (int i = index; i < Length - 1; i++)
            {
                    _array[i] = _array[i+1];
            }

            _array[Length - 1] = 0;

            Length--;

            if (_TrueLength / 2 >= Length)
            {
                DecreaseLength();
            }
        }

        //Добавляем элемент в начале списка

        public void AddElementAtBeginning( int index = 0, int value=1)
        {
            if (_TrueLength <= Length)
            {
                IncreaseLength();
            }

            AddElementByIndex(index, value);
           
        }

        //Удаление элемента из конца

        public void DeleteElementFromTheEnd ()
        {
            if (Length ==0)
            {
                throw new Exception();
            }
            
            Length--;

            if (_TrueLength / 2 >= Length )
            {
                DecreaseLength();
            }
        }

    
        //Индекс по значению

        public int AccessByValue (int value)
        {
            int index = 0;
            for (int i = 0; i < Length; i++)
            {
               if ( _array[i] == value)
                {
                   index = i;
                }
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
                _array[index] = value;
            }
        }

        public void Revers()
        {
            for (int i = 0; i < Length / 2; i++)
            {
                int a = _array[i];

                _array[i] = _array[Length - 1 - i];
                _array[Length - 1 - i] = a;
            }

        }

            //поиск макс элемента 
         public int FindMaxElement (int [] array)
        { 
            int max = _array[0];
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                }
            }
            return max;
        }


        //поиск мин элемента 
        public int FindMinElement(int[] array)
        {
            int min = _array[0];
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] < min)
                {
                    min= _array[i];
                }
            }
            return min;
        }

        //поиск идекса макс элемента
        public int FindMaxIndex(int[] array)
        {
            int max = _array[0];
            int maxIndex = 0;

            for (int i = 1; i < Length; i++)

                if (_array[i] > max)
                {
                    max = _array[i];
                    maxIndex = i;
                }
            return maxIndex;
        }

        //поиск идекса мин элемента 
        public int FindMinIndex(int[] array)
        {
            int min = _array[0];
            int minIndex = 0;

            for (int i = 1; i < Length; i++)

                if (_array[i] < min)
                {
                    min = _array[i];
                    minIndex = i;
                }
            return minIndex;
        }

        public void RemoveElementFromBeginning ()
        {
            DeleteElementByIndex(0);

            if (_TrueLength / 2 >= Length)
            {
                DecreaseLength();
            }
        }

        private void IncreaseLength(int number = 1)// Метод увеличения длины, если нет места. Приватный метод, где клиент воодит число. По умолч 1 
        {
            int newLength = _TrueLength;
            while (newLength <= Length + number) //до тех пор, пока новая длдина <= текущей +1,  мы 
            {
                newLength = (int)(newLength * 1.33 + 1); //увеличиваем длдину на 33%. Добавляем 1 на всячкий случай 
            }
            int[] newArray = new int[newLength];
            Array.Copy(_array, newArray, _TrueLength);

            _array = newArray;
        }
        private void DecreaseLength(int number = 1)
        {
            int newLength = _TrueLength;
            while (newLength >= 2 * (Length - number))
            {
                newLength = (newLength * 2 / 3 + 1);
            }
            int[] newArray = new int[newLength];
            Array.Copy(_array, newArray, Length);

            _array = newArray;
        }


        //сдвиг значений вправо 

        private void MoveElementsToTheRight (int index)
        {
            for (int i = Length; i > index; i--)
            {
                _array[i] = _array[i - 1];
            }
            Length++;
        }
       

    }
}
