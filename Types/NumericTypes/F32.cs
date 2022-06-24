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
                if (!value.EndsWith('f'))
                    value = value + "f";

                _value = float.Parse(value);

            }catch(Exception)
            {
                throw new NumberFormatException($"The value {value} can not be converted to a f32 representation");
            }
        }

        public override string GetRustType()
        {
            return EnumNumberTypes.f32.ToString();
        }

    }

}
