using System;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.Numbers
{
    public class I64 : Number
    {
        public I64(string value)
        {
            try
            {
                variableType = long.Parse(value);
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
