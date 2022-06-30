using System;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.Numbers
{
    public class I32 : Number
    {
        public I32(string value)
        {
            try
            {
                variableType = int.Parse(value);
            }
            catch (Exception)
            {
                throw new NumberFormatException($"The value {value} can not be converted to a i32 representation");
            }
        }

        public override string GetRustType()
        {
            return EnumNumberTypes.i32.ToString();
        }

    }

}
