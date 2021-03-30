using CalculationExpressions.analyzer;
using ExpressionParser.exception;
using System.Collections.Generic;

namespace CalculationExpressions
{
    class ExpressionAnalyzer
    {
        private protected List<Lexeme> lexemes = new List<Lexeme>();
        private string expression;

        public ExpressionAnalyzer(string expression)
        {
            this.expression = expression;
            Analyse(expression);

            lexemes.Add(new Lexeme(LexemeType.End, "="));
            if (lexemes.Count == 1)
            {
                throw new ParsingException("empty expression");
            }
        }

        public List<Lexeme> GetLexemes()
        {
            return lexemes;
        }

        private int pos;
        public Lexeme Next()
        {
            return lexemes[pos++];
        }

        public void Back()
        {
            pos--;
        }

        public int GetPos()
        {
            return pos;
        }

        public void Analyse(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsWhiteSpace(s[i]))
                {
                    continue;
                }

                switch (s[i])
                {
                    case '(':
                        lexemes.Add(new Lexeme(LexemeType.LeftBracket, "("));
                        break;

                    case ')':
                        lexemes.Add(new Lexeme(LexemeType.RightBracket, ")"));
                        break;

                    case '+':
                        lexemes.Add(new Lexeme(LexemeType.Plus, "+"));
                        break;

                    case '-':
                        lexemes.Add(new Lexeme(LexemeType.Minus, "-"));
                        break;
                    case '*':
                        lexemes.Add(new Lexeme(LexemeType.Mul, "*"));
                        break;

                    case '/':
                        lexemes.Add(new Lexeme(LexemeType.Div, "/"));
                        break;

                    default:
                        if (!char.IsDigit(s[i]))
                        {
                            throw new InvalidLexemeException(s[i].ToString(), i);
                        }
                        lexemes.Add(new Lexeme(LexemeType.Number, s[i].ToString()));
                        break;
                }
            }
        }
    }
}