using System;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.NumericTypes
{
    public class I16 : Type<short>
    {
        
        public I16(string value)
        {
            try
            {
                _value = short.Parse(value);
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
