using System;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.Numbers
{
    public class U32 : Number
    {

        public U32(string value)
        {
            try
            {
                variableType = uint.Parse(value);
            }
            catch (Exception)
            {
                throw new NumberFormatException($"The value {value} can not be converted to a u32 representation");
            }
        }

        public override string GetRustType()
        {
            return EnumNumberTypes.u32.ToString();
        }

    }

}
