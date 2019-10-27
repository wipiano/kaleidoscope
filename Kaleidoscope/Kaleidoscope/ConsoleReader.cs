using System;

namespace Kaleidoscope
{
    /// <summary>
    /// read from standard input
    /// </summary>
    public class ConsoleReader : IReader
    {
        private string _line = string.Empty;
        private int _index = 0;

        public bool TryGetNextChar(out char c) 
        {
            if (_line.Length == _index)
            {
                Console.Write("ready> ");
                _line = Console.ReadLine();
                _index = 0;
                return TryGetNextChar(out c);
            }

            if (_line == "exit")
            {
                c = default;
                return false;
            }

            c = _line[_index++];
            return true;
        }
    }
}