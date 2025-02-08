using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    public class DisciplineArray
    {
        static Random rnd = new Random();

        //Массив названий дисциплин для реализации случайной генерации
        static readonly string[] disciplines = ["Математический анализ", "Английский язык", "Проектный семинар", "Теоретические основы информатики", "Программирование", "Дискретная математика", "История России", "Физическая культура", "Правовая грамотность", "Профориентационный семинар"];

        Discipline[] array;

        static int collectionsCount = 0; //статическая переменная для подсчета количества созданных коллекций

        //Метод для получения длины массива
        public int GetLengthArray => array.Length;


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
                array[i] = new Discipline(disciplines[rnd.Next(0,10)], rnd.Next(0, 1000), rnd.Next(0, 1000));
            collectionsCount++;
        }

        //Конструктор глубокой копии существующей коллекции типа DisciplineArray
        public DisciplineArray(DisciplineArray disciplineArray)
        {
            array = new Discipline[disciplineArray.GetLengthArray];
            for (int i = 0; i < disciplineArray.GetLengthArray; i++)
                array[i] = new Discipline(disciplineArray[i].Name, disciplineArray[i].ContactHours, disciplineArray[i].SelfHours);
            collectionsCount++;
        }

        //Получение информации об элементах массива
        public string GetElements()
        {
            string result = "";
            for (int i = 0; i < array.Length; i++)
                result += array[i].GetAttributes();
            return result;
        }

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

        //Метод для получения количества созданных объектов
        public static int GetCount => collectionsCount;

        //Метод для обновления счетчика
        public static void ClearCount() => collectionsCount = 0;

        //
        public override bool Equals(object? obj)
        {
            if (obj is DisciplineArray otherArray)
            {
                if (GetLengthArray != otherArray.GetLengthArray)
                    return false;

                for (int i = 0; i < GetLengthArray; i++)
                {
                    if (!array[i].Equals(otherArray[i]))
                        return false;
                }
                return true;
            }
            return false;
        }

    }
}
