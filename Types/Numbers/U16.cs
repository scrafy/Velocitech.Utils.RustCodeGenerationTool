using System;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.Numbers
{
    public class U16 : Number
    {
        public U16(string value)
        {
            try
            {
                variableType = ushort.Parse(value);
            }
            catch (Exception)
            {
                throw new NumberFormatException($"The value {value} can not be converted to a u16 representation");
            }
        }

        public override string GetRustType()
        {
            return EnumNumberTypes.u16.ToString();
        }

    }

}
