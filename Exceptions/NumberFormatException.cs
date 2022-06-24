
using System;

namespace Velocitech.Utils.RustCodeGenerationTool.Exceptions
{
    internal class NumberFormatException : Exception
    {
        public NumberFormatException(string message): base(message) { }
        
    }
}
