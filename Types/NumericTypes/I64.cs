using System;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.NumericTypes
{
    public class I64 : Type<long>
    {
        public I64(string value)
        {
            try
            {
                _value = long.Parse(value);
            }
            catch (Exception)
            {
                throw new NumberFormatException($"The value {value} can not be converted to a long representation");
            }
        }

        public override string GetRustType()
        {
            return EnumNumberTypes.i64.ToString();
        }

    }

}
