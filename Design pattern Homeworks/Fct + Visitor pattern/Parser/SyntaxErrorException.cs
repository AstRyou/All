using System;

namespace Task
{
    class SyntaxErrorException : Exception
    {
        public SyntaxErrorException() : base("SYNTAX_ERROR")
        {

        }
    }
}
