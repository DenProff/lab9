using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    public class Discipline
    {
        string name; //Название дисциплины
        int contactHours; //Часы аудиторной работы
        int selfHours; //Часы самостоятельной работы

        static int objectsCount = 0; //статическая переменная для подсчета количества созданных объектов

        //Свойство для обработки названия дисциплины
        public string Name
        {
            get => name;
            set => name = value;
        }

        //Свойство для обработки часов аудиторной работы
        public int ContactHours
        {
            get => contactHours;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("\nЧасы аудиторной работы не могут быть отрицательными");
                contactHours = value;
            }
        }

        //Свойство для обработки часов самостоятельной работы
        public int SelfHours
        {
            get => selfHours;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("\nЧасы самостоятельной работы не могут быть отрицательными");
                selfHours = value;
            }
        }

        //Конструктор объекта со значениями по умолчанию
        public Discipline()
        {
            Name = "Nameless";
            ContactHours = 0;
            SelfHours = 0;
            objectsCount++;
        }

        //Конструктор объекта по заданному названию дисциплины и количеству часов
        public Discipline(string name, int contactHours, int selfHours)
        {
            Name = name;
            ContactHours = contactHours;
            SelfHours = selfHours;
            objectsCount++;
        }

        //Конструктор глубокой копии существующего объекта типа Discipline
        public Discipline(Discipline discipline)
        {
            Name = discipline.Name;
            ContactHours = discipline.ContactHours;
            SelfHours = discipline.SelfHours;
            objectsCount++;
        }

        //Получение информации об атрибутах объекта
        public string GetAttributes()
        {
            return $"\nДисциплина: {Name}, часы аудиторной работы: {ContactHours}, часы самостоятельной работы: {SelfHours}";
        }

        //Метод для вычисления количества зачетных единиц (округление в меньшую сторону)
        public int CalculateCredits()
        {
            CheckOverflow(ContactHours, SelfHours);
            return (ContactHours + SelfHours) / 38;
        }

        //Статический метод для вычисления количества зачетных единиц
        public static int CalculateCredits(Discipline discipline)
        {
            CheckOverflow(discipline.ContactHours, discipline.SelfHours);
            return (discipline.ContactHours + discipline.SelfHours) / 38;
        }

        //Операция по вычислению процентного соотношения самостоятельной работы к общему количеству часов
        public static double operator !(Discipline discipline)
        {
            CheckOverflow(discipline.ContactHours, discipline.SelfHours);
            if (discipline.SelfHours + discipline.ContactHours == 0) //общее количество часов равно нулю
                return 0;
            else
                return (double)discipline.SelfHours / (discipline.SelfHours + discipline.ContactHours) * 100;
        }

        //Операция по увеличению аудиторного количества часов на 2
        public static Discipline operator ++(Discipline discipline)
        {
            if (discipline.SelfHours >= 2)
            {
                CheckOverflow(discipline.ContactHours, 2);
                Discipline result = new Discipline(discipline);
                result.SelfHours -= 2;
                result.ContactHours += 2;
                return result;
            }
            else //невозможно отнять два часа от времени самостоятельной работы
                return discipline;
        }

        //Операция явного приведения в тип double
        public static explicit operator double(Discipline discipline)
        {
            CheckOverflow(discipline.ContactHours, discipline.SelfHours);
            if (discipline.SelfHours + discipline.ContactHours == 0)
                return 0;
            else
                return (double)discipline.ContactHours / (discipline.SelfHours + discipline.ContactHours);
        }

        //Операция неявного преобразования в тип int
        public static implicit operator int(Discipline discipline)
        {
            return discipline.ContactHours / 2;
        }

        //Операции сравнения трудоемкости двух дисциплин
        public static bool operator >=(Discipline discipline1, Discipline discipline2)
        {
            CheckOverflow(discipline1.ContactHours, discipline1.SelfHours);
            CheckOverflow(discipline2.ContactHours, discipline2.SelfHours);
            return (discipline1.ContactHours + discipline1.SelfHours) >= (discipline2.ContactHours + discipline2.SelfHours);
        }

        public static bool operator <=(Discipline discipline1, Discipline discipline2)
        {
            CheckOverflow(discipline1.ContactHours, discipline1.SelfHours);
            CheckOverflow(discipline2.ContactHours, discipline2.SelfHours);
            return (discipline1.ContactHours + discipline1.SelfHours) <= (discipline2.ContactHours + discipline2.SelfHours);
        }

        //Метод для получения количества созданных объектов
        public static int GetCount => objectsCount;

        //Метод для обновления счетчика
        public static void ClearCount() => objectsCount = 0;

        //Закрытый метод для проверки на переполнение типа int
        private static void CheckOverflow(int firstNumber, int secondNumber)
        {
            try
            {
                int result = checked(firstNumber + secondNumber);
            }
            catch (OverflowException)
            {
                throw new OverflowException("\nПереполнение типа int");
            }
        }

        //Метод для сравнения двух объектов класса Discipline
        public override bool Equals(object? obj)
        {
            return obj is Discipline discipline
                   && Name == discipline.Name
                   && ContactHours == discipline.ContactHours
                   && SelfHours == discipline.SelfHours;
        }

    }
}
