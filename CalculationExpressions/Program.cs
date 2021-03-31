using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace CalculationExpressions
{
    /// <summary>
    ///     Программа работает только со старой версией калькулятора.
    ///     В ближайшее время исправим эти недоработки
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Process.Start("C:\\Windows\\system32\\calc.exe"); //запуск калькулятора
            Thread.Sleep(3000);

            using StreamReader reader = new StreamReader(@"../../../Input.txt");
            try
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    Expression expression = new Expression(line); //создание объекта выражения и передача ему строки с выражением

                    expression.StartCalcAndWriterResult(@"../../../Output.txt"); //вызов метода отправляющего команды в калькулятор и запись результата в файл
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e);
            }
        }
    }
}