using System;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.Numbers
{
    public class U8 : Number
    {
        public U8(string value)
        {
            try
            {
                variableType = byte.Parse(value);
            }
            catch (Exception)
            {
                throw new NumberFormatException($"The value {value} can not be converted to a u8 representation");
            }
        }

        public override string GetRustType()
        {
            return EnumNumberTypes.u8.ToString();
        }

    }

}
