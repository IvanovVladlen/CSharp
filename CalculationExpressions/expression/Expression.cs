using CalculationExpressions.analyzer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace CalculationExpressions
{
    class Expression
    {
        private static ExpressionAnalyzer expressionAnalyzer;

        public Expression(string expression)
        {
            expressionAnalyzer = new ExpressionAnalyzer(expression);
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        const int WM_CHAR = 0x102;

        public void StartCalcAndWriterResult(string pathOutput)
        {
            IntPtr calcHandle = FindWindow("CalcFrame", "Калькулятор");

            List<Lexeme> lexemes = expressionAnalyzer.GetLexemes();

            for (int i = 0; i < lexemes.Count; i++)
            {
                PostMessage(calcHandle, WM_CHAR, (IntPtr)lexemes[i].GetValue()[0], IntPtr.Zero);
                Thread.Sleep(500);
            }

            List<IntPtr> allChildWindows = new WindowHandleInfo(calcHandle).GetAllChildHandles();

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < allChildWindows.Count; i++)
            {
                GetWindowText(allChildWindows[i], result, result.Capacity);

                if (IsDigitsOnly(result.ToString()) && result.Length > 0)
                {
                    break;
                }
            }

            using StreamWriter writer = new StreamWriter(pathOutput, true);
            try
            {
                writer.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e);
            }
        }
        static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }
    }
}