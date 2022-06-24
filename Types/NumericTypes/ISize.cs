using System;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.NumericTypes
{

    internal class ISize : Type<long>
    {

        public ISize(string value)
        {
            try {
                if (Environment.Is64BitOperatingSystem)
                {
                    _value = long.Parse(value);
                }
                else
                {
                    _value = int.Parse(value);

                }
            }
            catch (Exception)
            {
                throw new NumberFormatException($"The value {value} can not be converted to a isize representation");
            }

            
        }

        public override string GetRustType()
        {
            return EnumNumberTypes.isize.ToString();
        }

    }
}
