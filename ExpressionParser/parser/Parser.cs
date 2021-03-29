using ExpressionParser.exception;
using ExpressionParser.Lexemes;
using System;

namespace ExpressionParser.parser
{
    class Parser
    {
        private LexemeAnalyzer lexemeAnalyzer;
        public Parser(string expression)
        {
            lexemeAnalyzer = new LexemeAnalyzer(expression);
        }
        public int calc()
        {
            Lexeme lexeme = lexemeAnalyzer.next();
            if (lexeme.GetLexemeType() == LexemeType.End)
            {
                throw new ParsingException("empty expression");
            }

            lexemeAnalyzer.back();
            return plusMinus(lexemeAnalyzer);
        }
        public int plusMinus(LexemeAnalyzer lexemeAnalyzer)
        {
            int result = multDiv(lexemeAnalyzer);
            while (true)
            {
                Lexeme lexeme = lexemeAnalyzer.next();
                switch (lexeme.GetLexemeType())
                {
                    case LexemeType.Plus:
                        result += multDiv(lexemeAnalyzer);
                        break;

                    case LexemeType.Minus:
                        result -= multDiv(lexemeAnalyzer);
                        break;

                    case LexemeType.End:
                    case LexemeType.RightBracket:
                        lexemeAnalyzer.back();
                        return result;

                    default:
                        throw new PositionLexemeException(lexeme.GetValue().ToString());
                }
            }
        }
        public int multDiv(LexemeAnalyzer lexemeAnalyzer)
        {
            int result = factor(lexemeAnalyzer);
            while (true)
            {
                Lexeme lexeme = lexemeAnalyzer.next();
                switch (lexeme.GetLexemeType())
                {
                    case LexemeType.Mul:
                        result *= factor(lexemeAnalyzer);
                        break;

                    case LexemeType.Div:
                        result /= factor(lexemeAnalyzer);
                        break;

                    case LexemeType.End:
                    case LexemeType.RightBracket:
                    case LexemeType.Plus:
                    case LexemeType.Minus:
                        lexemeAnalyzer.back();
                        return result;

                    default:
                        throw new PositionLexemeException(lexeme.GetValue().ToString());
                }
            }
        }
        public int factor(LexemeAnalyzer lexemeAnalyzer)
        {
            Lexeme lexeme = lexemeAnalyzer.next();

            switch (lexeme.GetLexemeType())
            {
                case LexemeType.Number:
                    return Convert.ToInt32(lexeme.GetValue());

                case LexemeType.LeftBracket:
                    int result = plusMinus(lexemeAnalyzer);
                    lexeme = lexemeAnalyzer.next();

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