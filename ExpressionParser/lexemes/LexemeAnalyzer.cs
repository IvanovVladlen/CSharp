using ExpressionParser.exception;
using System.Collections.Generic;
using System.Text;

namespace ExpressionParser.Lexemes
{
    public class LexemeAnalyzer
    {
        private protected List<Lexeme> lexemes = new List<Lexeme>();

        public LexemeAnalyzer(string expression)
        {
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

                        StringBuilder number = new StringBuilder();

                        do
                        {
                            number.Append(s[i]);
                            i++;
                        } while ((i < s.Length) && char.IsDigit(s[i]));

                        lexemes.Add(new Lexeme(LexemeType.Number, number.ToString()));

                        i--;
                        break;
                }
            }
        }
    }
}