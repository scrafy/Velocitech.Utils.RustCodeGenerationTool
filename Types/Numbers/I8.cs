using System;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.Numbers
{
    public class I8 : Number
    {
        public I8(string value)
        {
            try
            {
                variableType = sbyte.Parse(value);
            }
            catch (Exception)
            {
                throw new NumberFormatException($"The value {value} can not be converted to a i8 representation");
            }
        }

        public override string GetRustType()
        {
            return EnumNumberTypes.i8.ToString();
        }

    }

}
