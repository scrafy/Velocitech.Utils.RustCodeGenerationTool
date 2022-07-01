using System;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.Numbers
{
    public class I64 : Number<long>
    {
        public I64()
        {
            minValue = long.Parse("-9223372036854775808");
            maxValue = long.Parse("9223372036854775807");
        }

        public override string GetRustType()
        {
            return EnumNumberTypes.i64.ToString();
        }

    }

}
