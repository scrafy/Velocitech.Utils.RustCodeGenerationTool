
using System;

namespace Velocitech.Utils.RustCodeGenerationTool.Exceptions
{
    public class NumberFormatException : Exception
    {
        public NumberFormatException(string message): base(message) { }
        
    }
}
