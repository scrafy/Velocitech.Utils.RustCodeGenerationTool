using System;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.NumericTypes
{
    internal class U32 : Type<uint>
    {

        public U32(string value)
        {
            try
            {
                _value = uint.Parse(value);
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
