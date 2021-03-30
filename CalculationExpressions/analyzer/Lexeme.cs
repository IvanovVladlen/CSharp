using System;
using System.Collections.Generic;
using System.Text;

namespace CalculationExpressions.analyzer
{
    class Lexeme
    {
        private LexemeType lexemeType;
        private string value;

        public LexemeType GetLexemeType()
        {
            return lexemeType;
        }

        public string GetValue()
        {
            return value;
        }

        public Lexeme(LexemeType lexemeType, string value)
        {
            this.lexemeType = lexemeType;
            this.value = value;
        }
    }
}