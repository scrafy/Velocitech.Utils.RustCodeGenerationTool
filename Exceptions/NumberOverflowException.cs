
using System;

namespace Velocitech.Utils.RustCodeGenerationTool.Exceptions
{
    public class NumberOverflowException : Exception
    {
        public NumberOverflowException(string message): base(message) { }
        
    }
}
