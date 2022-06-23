using System;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.NumericTypes
{
    public class F64 : Type<double>
    {
        public F64(string value)
        {
            try
            {
                Value = double.Parse(value);

            }
            catch (Exception)
            {
                throw new NumberFormatException($"The value {value} can not be converted to a double representation");
            }
        }

        public override string GetRustType()
        {
            return EnumNumberTypes.f64.ToString();
        }
    }

}
