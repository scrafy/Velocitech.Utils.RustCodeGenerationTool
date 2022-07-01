using System;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.Numbers
{
    public class I32 : Number<int>
    {
        public I32()
        {
            minValue = int.Parse("-2147483648");
            maxValue = int.Parse("2147483647");           
        }

        public override string GetRustType()
        {
            return EnumNumberTypes.i32.ToString();
        }

    }

}
