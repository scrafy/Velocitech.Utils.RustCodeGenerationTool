using System;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.NumericTypes
{

    internal class USize : Type<ulong>
    {
        public USize(string value) {

            if (Environment.Is64BitOperatingSystem)
            {
                _value = ulong.Parse(value);
            }
            else
            {
                try
                {
                    _value = uint.Parse(value);
                }
                catch (Exception)
                {
                    throw new NumberFormatException($"The value {value} can not be converted to a usize representation");
                }

            }
        }

        public override string GetRustType()
        {
            return EnumNumberTypes.usize.ToString();
        }

    }
}
