using System;

namespace lab9
{
    public class DisciplineArray
    {
        private static readonly Random random = new Random();

        //Массив названий дисциплин для реализации случайной генерации
        private static readonly string[] disciplines = ["Математический анализ", "Английский язык", "Проектный семинар", "Теоретические основы информатики", "Программирование", "Дискретная математика", "История России", "Физическая культура", "Правовая грамотность", "Профориентационный семинар"];

        private readonly Discipline[] array;

        private static int collectionsCount = 0; //статическая переменная для подсчета количества созданных коллекций
        
        //Индексатор для доступа к элементам коллекции
        public Discipline this[int index]
        {
            get 
            {
                if (index >= 0 && index < array.Length)
                    return array[index];
                throw new IndexOutOfRangeException("\nВыход за границы массива");
            }
            set
            {
                if (index >= 0 && index < array.Length)
                    array[index] = value;
                else
                    throw new IndexOutOfRangeException("\nВыход за границы массива");
            }
        }

        //Конструктор коллекции со значением по умолчанию
        public DisciplineArray()
        {
            array = new Discipline[0];
            collectionsCount++;
        }

        //Конструктор коллекции с параметрами, заполняющий элементы случайными значениями
        public DisciplineArray(int length)
        {
            array = new Discipline[length];
            for (int i = 0; i < length; i++)
                array[i] = new Discipline(disciplines[random.Next(0,10)], random.Next(0, 500) * 2, random.Next(0, 1000));
            collectionsCount++;
        }

        //Конструктор глубокой копии существующей коллекции типа DisciplineArray
        public DisciplineArray(DisciplineArray disciplineArray)
        {
            array = new Discipline[disciplineArray.GetLengthArray];
            for (int i = 0; i < disciplineArray.GetLengthArray; i++)
                array[i] = new Discipline(disciplineArray[i]);
            collectionsCount++;
        }

        //Метод для получения длины массива
        public int GetLengthArray => array.Length;
        
        //Получение информации об элементах массива
        public string GetElements()
        {
            string result = "";
            for (int i = 0; i < array.Length; i++)
                result += array[i].GetAttributes();
            return result;
        }

        //Метод для получения количества созданных объектов
        public static int GetCount => collectionsCount;

        //Метод для обновления счетчика
        public static void ClearCount() => collectionsCount = 0;

        //Метод для сравнения двух коллекций класса DisciplineArray
        public override bool Equals(object? obj)
        {
            if (obj is not DisciplineArray otherArray)
                return false;

            if (GetLengthArray != otherArray.GetLengthArray)
                return false;

            for (int i = 0; i < GetLengthArray; i++)
            {
                if (!array[i].Equals(otherArray[i]))
                    return false;
            }
            return true;
        }

    }
}
