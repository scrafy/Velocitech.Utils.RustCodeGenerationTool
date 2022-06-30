using System;
using System.Globalization;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.Numbers
{
    public class F64 : Number<double>
    {
      
        public F64()
        {
            minValue = double.Parse("-1.7976931348623157e+308", new NumberFormatInfo() { NumberDecimalSeparator = "." });
            maxValue = double.Parse("1.7976931348623157e+308", new NumberFormatInfo() { NumberDecimalSeparator = "." });
        }

        public override string GetRustType()
        {
            return EnumNumberTypes.f64.ToString();
        }

    }

}
