using System;

namespace lab9
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Часть 1
            //Демонстрация работы конструкторов
            Discipline firstDiscipline = new Discipline(); //Конструктор со значениями по умолчанию
            Discipline secondDiscipline = new Discipline("ТОИ", 120, 73); //Конструктор с заданными атрибутами
            Discipline thirdDiscipline = new Discipline(secondDiscipline); //Конструктор глубокой копии
            thirdDiscipline.Name = "Копия ТОИ"; //Редактирование атрибута, чтобы продемонстрировать, что копирование глубокое
            //Вывод информации о созданных объектах
            OutputData.ShowDiscipline(firstDiscipline);
            OutputData.ShowDiscipline(secondDiscipline);
            OutputData.ShowDiscipline(thirdDiscipline);
            //Вывод вычисленных кредитов при помощи статической и нестатической функций
            OutputData.ShowCalculatedCredits(firstDiscipline);
            OutputData.ShowStaticCalculatedCredits(secondDiscipline);
            //Создание объекта с ручным вводом атрибутов
            try
            {
                Discipline discipline = InputData.InputAttributes();
                OutputData.ShowDiscipline(discipline);
                OutputData.ShowCalculatedCredits(discipline);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            OutputData.ShowObjectsCount();
            #endregion Часть 1

            #region Часть 2
            //Унарные и бинарные операции, явное и неявное приведение типов
            try
            {
                Discipline discipline = InputData.InputAttributes();
                OutputData.ShowDiscipline(discipline);
                OutputData.ShowFractionSelfHours(discipline); //Процентное соотношение самостоятельной работы к общему количеству часов
                Discipline disciplineRecalculated = ++discipline; //Увеличение аудиторного количества часов на 2
                OutputData.ShowDiscipline(discipline);
                OutputData.ShowFractionContactHours(discipline); //Доля аудиторной работы от общего количества часов (явное приведение)
                OutputData.ShowNumberClassroomLessons(discipline); //Количество аудиторных занятий на дисциплину (неявное приведение)
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Сравнение трудоемкостей дисциплин
            try
            {
                Discipline firstManualDiscipline = InputData.InputAttributes();
                Discipline secondManualDiscipline = InputData.InputAttributes();
                OutputData.ShowDiscipline(firstManualDiscipline);
                OutputData.ShowDiscipline(secondManualDiscipline);
                OutputData.ShowDisciplinesComparisons(firstManualDiscipline, secondManualDiscipline); //Демонстрация сравнения
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion Часть 2

            #region Часть 3
            //Демонстрация работы конструкторов
            DisciplineArray firstDisciplineArray = new DisciplineArray(); //Конструктор со значениями по умолчанию
            DisciplineArray secondDisciplineArray = new DisciplineArray(6); //Конструктор коллекции с параметрами, заполняющий случайными значениями
            DisciplineArray thirdDisciplineArray = new DisciplineArray(secondDisciplineArray); //Конструктор глубокой копии
            thirdDisciplineArray[0].Name = "Это копия";
            //Вывод элементов созданных коллекций
            OutputData.ShowElementsArray(firstDisciplineArray);
            OutputData.ShowElementsArray(secondDisciplineArray);
            OutputData.ShowElementsArray(thirdDisciplineArray);
            //Ручной ввод массива
            int lengthArray = InputData.ReadNumber("\nВведите длину массива: ", 0, 100);
            DisciplineArray manualDisciplineArray = InputData.InputElementsArray(lengthArray);
            OutputData.ShowElementsArray(manualDisciplineArray);
            //Запись с существующим и несуществующим индексами
            try
            {
                DisciplineArray disciplineArray = InputData.InputElementsArray(2);
                OutputData.ShowElementsArray(disciplineArray);
                disciplineArray[0] = new Discipline("Новая дисциплина", 10, 11);
                OutputData.ShowElementsArray(disciplineArray);
                disciplineArray[1234] = new Discipline("Новая дисциплина", 10, 11);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Чтение с существующим и несуществующим индексами
            try
            {
                DisciplineArray disciplineArray = InputData.InputElementsArray(2);
                OutputData.ShowElementsArray(disciplineArray);
                OutputData.ShowDiscipline(disciplineArray[0]);
                OutputData.ShowDiscipline(disciplineArray[1234]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Вычисление средневзвешенного значения всех дисциплин
            DisciplineArray fourthDisciplineArray = InputData.InputElementsArray(5);
            OutputData.ShowElementsArray(fourthDisciplineArray);
            double result = CalculateWeightedAverageCredits(fourthDisciplineArray);
            OutputData.ShowWeightedAverageCredits(result);
            OutputData.ShowObjectsCount();
            OutputData.ShowCollectionsCount();
            #endregion Часть 3
        }

        //Вычисления средневзвешенного значения зачётных единиц по всем дисциплинам в массиве
        public static double CalculateWeightedAverageCredits(DisciplineArray disciplineArray)
        {
            int sumCredits = 0;
            double weightedSum = 0; //Используем double для точности
            if (disciplineArray.GetLengthArray != 0)
            {
                //Вычисляем сумму кредитов по всем дисциплинам
                for (int i = 0; i < disciplineArray.GetLengthArray; i++)
                {
                    int credits = disciplineArray[i].CalculateCredits();
                    sumCredits += credits;
                    weightedSum += credits * credits;
                }
            }
            double weightedAverageCredits = sumCredits == 0 ? 0 : weightedSum / sumCredits;
            return Math.Round(weightedAverageCredits, 4);
        }
    }
}
