using System;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.NumericTypes
{
    internal class F32 : Type<float>
    {
       public F32(string value)
        {
            try
            {
                Value = float.Parse(value);

            }catch(Exception)
            {
                throw new NumberFormatException($"The value {value} can not be converted to a float representation");
            }
        }

        public override string GetRustType()
        {
            return EnumNumberTypes.f32.ToString();
        }
    }

}
