using System;
using System.Collections.Generic;
using System.Text;

namespace CalculationExpressions.analyzer
{
    class Lexeme
    {
        private LexemeType LexemeType;
        private string Value;

        public LexemeType GetLexemeType()
        {
            return LexemeType;
        }
        public string GetValue()
        {
            return Value;
        }
        public Lexeme(LexemeType lexemeType, string value)
        {
            LexemeType = lexemeType;
            Value = value;
        }
    }
}