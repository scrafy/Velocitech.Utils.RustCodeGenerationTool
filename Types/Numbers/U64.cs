using System;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.Numbers
{
    public class U64 : Number
    {
        public U64(string value)
        {
            try
            {
                variableType = ulong.Parse(value);
            }
            catch (Exception)
            {
                throw new NumberFormatException($"The value {value} can not be converted to a u64 representation");
            }
        }

        public override string GetRustType()
        {
            return EnumNumberTypes.u64.ToString();
        }

    }

}
