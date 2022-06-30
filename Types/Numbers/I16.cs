using System;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.Numbers
{
    public class I16 : Number<short>
    {
        
        public I16(string value)
        {
            try
            {
                variableType = short.Parse(value);
            }
            catch (Exception)
            {
                throw new NumberFormatException($"The value {value} can not be converted to a i16 representation");
            }
        }

        public override string GetRustType()
        {
            return EnumNumberTypes.i16.ToString();
        }

    }

}
