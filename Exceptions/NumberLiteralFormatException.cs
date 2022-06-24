
using System;

namespace Velocitech.Utils.RustCodeGenerationTool.Exceptions
{
    internal class NumberLiteralFormatException : Exception
    {
        public NumberLiteralFormatException(string message): base(message) { }
        
    }
}
