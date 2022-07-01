using System;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.Numbers
{
    public class I8 : Number<sbyte>
    {
        public I8()
        {
            minValue = sbyte.Parse("-128");
            maxValue = sbyte.Parse("127");
        }

        public override string GetRustType()
        {
            return EnumNumberTypes.i8.ToString();
        }

    }

}
