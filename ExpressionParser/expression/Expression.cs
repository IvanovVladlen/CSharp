using ExpressionParser.exception;
using ExpressionParser.Lexemes;
using System;

namespace ExpressionParser.parser
{

    /// <summary>
    ///  Recursive descent parser
    //    Calc : PlusMinus* EOF ;
    //    PlusMinus: MultDiv ( ( '+' | '-' ) MultDiv )* ;
    //    MultDiv : Factor ( ( '*' | '/' ) Factor )* ;
    //    Factor : NUMBER | '(' Calc ')' ;
    /// </summary>
    class Expression
    {
        private LexemeAnalyzer lexemeAnalyzer;
        public Expression(string expression)
        {
            lexemeAnalyzer = new LexemeAnalyzer(expression);
        }

        public int Calc()
        {
            Lexeme lexeme = lexemeAnalyzer.Next();

            if (lexeme.GetLexemeType() == LexemeType.End)
            {
                throw new ParsingException("empty expression");
            }

            lexemeAnalyzer.Back();
            return PlusMinus(lexemeAnalyzer);
        }
        public int PlusMinus(LexemeAnalyzer lexemeAnalyzer)
        {
            int result = MultDiv(lexemeAnalyzer);
            while (true)
            {
                Lexeme lexeme = lexemeAnalyzer.Next();
                switch (lexeme.GetLexemeType())
                {
                    case LexemeType.Plus:
                        result += MultDiv(lexemeAnalyzer);
                        break;

                    case LexemeType.Minus:
                        result -= MultDiv(lexemeAnalyzer);
                        break;

                    case LexemeType.End:
                    case LexemeType.RightBracket:
                        lexemeAnalyzer.Back();
                        return result;

                    default:
                        throw new PositionLexemeException(lexeme.GetValue().ToString());
                }
            }
        }
        public int MultDiv(LexemeAnalyzer lexemeAnalyzer)
        {
            int result = Factor(lexemeAnalyzer);
            while (true)
            {
                Lexeme lexeme = lexemeAnalyzer.Next();
                switch (lexeme.GetLexemeType())
                {
                    case LexemeType.Mul:
                        result *= Factor(lexemeAnalyzer);
                        break;

                    case LexemeType.Div:
                        result /= Factor(lexemeAnalyzer);
                        break;

                    case LexemeType.End:
                    case LexemeType.RightBracket:
                    case LexemeType.Plus:
                    case LexemeType.Minus:
                        lexemeAnalyzer.Back();
                        return result;

                    default:
                        throw new PositionLexemeException(lexeme.GetValue().ToString());
                }
            }
        }
        public int Factor(LexemeAnalyzer lexemeAnalyzer)
        {
            Lexeme lexeme = lexemeAnalyzer.Next();

            switch (lexeme.GetLexemeType())
            {
                case LexemeType.Number:
                    return Convert.ToInt32(lexeme.GetValue());

                case LexemeType.LeftBracket:
                    int result = PlusMinus(lexemeAnalyzer);
                    lexeme = lexemeAnalyzer.Next();

                    if (lexeme.GetLexemeType() != LexemeType.RightBracket)
                    {
                        throw new PositionLexemeException(lexeme.GetValue().ToString());
                    }
                    return result;

                default:
                    throw new PositionLexemeException(lexeme.GetValue().ToString());
            }
        }
    }
}