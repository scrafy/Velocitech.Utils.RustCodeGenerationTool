using System;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.NumericTypes
{
    internal class U16 : Type<ushort>
    {
        public U16(string value)
        {
            try
            {
                _value = ushort.Parse(value);
            }
            catch (Exception)
            {
                throw new NumberFormatException($"The value {value} can not be converted to a u16 representation");
            }
        }

        public override string GetRustType()
        {
            return EnumNumberTypes.u16.ToString(); ;
        }

    }

}
