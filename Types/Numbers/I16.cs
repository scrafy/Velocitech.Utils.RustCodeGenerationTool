using System;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.Numbers
{
    public class I16 : Number<short>
    {
        public I16()
        {
            minValue = short.Parse("-32768");
            maxValue = short.Parse("32767");
        }

        public override string GetRustType()
        {
            return EnumNumberTypes.i16.ToString();
        }

    }

}
