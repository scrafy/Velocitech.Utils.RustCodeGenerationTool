using System;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.NumericTypes
{
    public class I8 : Type<sbyte>
    {
        public I8(string value)
        {
            try
            {
                _value = sbyte.Parse(value);
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
