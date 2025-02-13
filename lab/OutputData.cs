using System;

namespace lab9
{
    public class OutputData
    {
        //Вывод аттрибутов объекта
        public static void ShowDiscipline(Discipline discipline)
        {
            Console.WriteLine(discipline.GetAttributes());
        }

        //Вывод элементов массива
        public static void ShowElementsArray(DisciplineArray array)
        {
            Console.WriteLine(array.GetElements());
        }

        //Вывод количества зачетных единиц по дисциплине
        public static void ShowCalculatedCredits(Discipline discipline)
        {
            Console.WriteLine($"\nКоличество зачетных единиц по дисциплине: {discipline.CalculateCredits()}"); //метод класса
        }

        //Вывод количества зачетных единиц по дисциплине (статический метод)
        public static void ShowStaticCalculatedCredits(Discipline discipline)
        {
            Console.WriteLine($"\nКоличество зачетных единиц по дисциплине: {Discipline.CalculateCredits(discipline)}");
        }

        //Вывод соотношения часов самостоятельной работы к общему количеству часов
        public static void ShowFractionSelfHours(Discipline discipline)
        {
            Console.WriteLine($"\nПроцентное соотношение самостоятельной работы к общему количеству часов: {!discipline}");
        }

        //Вывод соотношения часов самостоятельной работы к общему количеству часов
        public static void ShowFractionContactHours(Discipline discipline)
        {
            Console.WriteLine($"\nДоля часов аудиторной работы от общего количества часов: {(double) discipline}");
        }

        //Вывод количества аудиторных занятий, выделенных на дисциплину
        public static void ShowNumberClassroomLessons(Discipline discipline)
        {
            int classroomLessons = discipline;
            Console.WriteLine($"\nКоличество аудиторных занятий выделенных на дисциплину: {classroomLessons}");
        }

        //Вывод сравнения трудоемкостей дисциплин
        public static void ShowDisciplinesComparisons(Discipline discipline1, Discipline discipline2)
        {
            Console.WriteLine($"\nПервая дисциплина не менее трудоемка, чем вторая: {discipline1 >= discipline2}");
            Console.WriteLine($"Вторая дисциплина не менее трудоемка, чем первая: {discipline1 <= discipline2}");
        }

        //Вывод средневзвешенных единиц по всем дисциплинам
        public static void ShowWeightedAverageCredits(double result)
        {
            Console.WriteLine($"\nСредневзвешенное зачетных единиц по всем дисциплинам: {result}");
        }

        //Вывод количества созданных объектов класса Discipline
        public static void ShowObjectsCount()
        {
            Console.WriteLine($"\nКоличество созданных объектов класса Discipline: {Discipline.GetCount}");
        }

        //Вывод количества созданных коллекций класса DisciplineArray
        public static void ShowCollectionsCount()
        {
            Console.WriteLine($"\nКоличество созданных коллекций класса DisciplineArray: {DisciplineArray.GetCount}");
        }
    }
}
