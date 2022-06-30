using System;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.NumericTypes
{
    public class I32 : Type<int>
    {
        public I32(string value)
        {
            try
            {
                _value = int.Parse(value);
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
