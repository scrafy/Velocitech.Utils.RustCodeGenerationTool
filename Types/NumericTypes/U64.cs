using System;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.NumericTypes
{
    public class U64 : Type<ulong>
    {
        public U64(string value)
        {
            try
            {
                _value = ulong.Parse(value);
            }
            catch (Exception)
            {
                throw new NumberFormatException($"The value {value} can not be converted to a u64 representation");
            }
        }

        public override string GetRustType()
        {
            return EnumNumberTypes.u64.ToString();
        }

    }

}
