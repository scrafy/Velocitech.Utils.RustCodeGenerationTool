using System;
using System.Globalization;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.Numbers
{
    public class F32 : Number<float>
    {
        
        public F32()
        {
            maxValue = float.Parse("3.40282347e+38", new NumberFormatInfo() { NumberDecimalSeparator = "." });
            minValue = float.Parse("-3.40282347e+38", new NumberFormatInfo() { NumberDecimalSeparator = "." });
        }
        
        public override string GetRustType()
        {
            return EnumNumberTypes.f32.ToString();
        }

    }

}




