using System;

namespace Kaleidoscope
{
    public interface ILexer
    {
        /// <summary>
        /// return the next token
        /// </summary>
        /// <returns></returns>
        Token GetToken();
    }
    
    public class Lexer : ILexer
    {
        private readonly IReader _reader;
        private char _last = ' ';

        public Lexer(IReader reader)
        {
            _reader = reader;
        }

        public Token GetToken()
        {
            // Skip any whitespace.
            while (char.IsWhiteSpace(_last))
            {
                if (!_reader.TryGetNextChar(out _last)) goto End;
            }
            
            // identifier: [a-zA-Z][a-zA-Z0-9]*
            if (_last.IsAlphabet())
            {
                string id = _last.ToString();
                while (_reader.TryGetNextChar(out _last) && _last.IsAlphabetOrNumber())
                {
                    // FIXME: way too slow
                    id += _last;
                }
                
                if (id == "def") return DefToken.Value;
                if (id == "extern") return ExternToken.Value;
                return new IdentifierToken(id);
            }

            // Number: [0-9.]+
            if (_last.IsDigit() || _last == '.')
            {
                string tmp = String.Empty;
                do
                {
                    tmp += _last;
                } while (_reader.TryGetNextChar(out _last) && (_last.IsDigit() || _last == '.'));

                return double.TryParse(tmp, out var v)
                    ? new NumberToken(v) as Token
                    : new UnknownToken(tmp);
            }
            
            // Comment until end of line.
            if (_last == '#')
            {
                while (_reader.TryGetNextChar(out _last) && _last != '\n' && _last != '\r') ;

                if (_last != default) return GetToken();
            }
            
            // Check for end of file. Don't eat the EOF.
            if (_last == default) goto End; 
            
            // Otherwise, just return the character as its ascii value.
            {
                var tmp = _last;
                _reader.TryGetNextChar(out _last);
                return new UnknownToken(tmp.ToString());
            }
            
            End:
                return EndOfFileToken.Value;
        }
    }
}