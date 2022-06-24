
using System;

namespace Velocitech.Utils.RustCodeGenerationTool.Exceptions
{
    internal class NumberOverflowException : Exception
    {
        public NumberOverflowException(string message): base(message) { }
        
    }
}
