using System;

namespace lab9
{
    public class InputData
    {
        //Ввод элементов массива
        public static DisciplineArray InputElementsArray(int sizeArray)
        {
            DisciplineArray array = new DisciplineArray(sizeArray);
            for (int i = 0; i < sizeArray; i++)
            {
                Console.WriteLine($"\nВведите атрибуты {i + 1}-го элемента массива");
                array[i].Name = ReadString("Введите название дисциплины: ");
                array[i].ContactHours = ReadNumber("Введите часы аудиторной работы: ");
                array[i].SelfHours = ReadNumber("Введите часы самостоятельной работы: ");
            }
            return array;
        }

        //Ввод атрибутов класса Discipline
        public static Discipline InputAttributes()
        {
            Discipline discipline = new Discipline(
                ReadString("\nВведите название дисциплины: "),
                ReadNumber("Введите количество часов аудиторной работы: "),
                ReadNumber("Введите количество часов самостоятельной работы: "));
            return discipline;
        }

        //Ввод числа
        private static int ReadNumber(string message)
        {
            int number = 0;
            bool isConvert = false;
            do
            {
                try
                {
                    Console.Write(message);
                    number = int.Parse(Console.ReadLine());
                    isConvert = true;
                }
                catch (FormatException) //ошибка неправильного формата входных данных
                {
                    Console.WriteLine("\n" + "Ошибка при вводе данных. Пожалуйста, попробуйте еще раз" + "\n");
                }
                catch (OverflowException) //ошибка переполнения типа int
                {
                    Console.WriteLine("\nВведенное число выходит за пределы типа int. Пожалуйста, попробуйте еще раз\n");
                }
            } while (!isConvert);
            return number;
        }

        //Ввод числа с заданным диапазоном
        public static int ReadNumber(string message, int leftBorder, int rightBorder)
        {
            int number = 0;
            bool isConvert = false;
            do
            {
                try
                {
                    Console.Write(message);
                    number = int.Parse(Console.ReadLine());
                    if (number >= leftBorder && number <= rightBorder)
                        isConvert = true;
                    else
                        Console.WriteLine($"\n Ошибка при вводе длины массива. Пожалуйста, введите целое число от {leftBorder} до {rightBorder}" + "\n");
                }
                catch (FormatException) //ошибка неправильного формата входных данных
                {
                    Console.WriteLine("\n" + "Ошибка при вводе данных. Пожалуйста, попробуйте еще раз" + "\n");
                }
                catch (OverflowException) //ошибка переполнения типа int
                {
                    Console.WriteLine("\nВведенное число выходит за пределы типа int. Пожалуйста, попробуйте еще раз\n");
                }
            } while (!isConvert);

            return number;
        }

        //Ввода строки
        private static string ReadString(string message)
        {
            Console.Write(message);
            string sentence = Console.ReadLine();
            return sentence;
        }
    }
}
