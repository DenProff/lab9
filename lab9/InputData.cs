using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static int ReadNumber(string message)
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

        //Ввода строки
        public static string ReadString(string message)
        {
            Console.Write(message);
            string sentence = Console.ReadLine();
            return sentence;
        }
    }
}
