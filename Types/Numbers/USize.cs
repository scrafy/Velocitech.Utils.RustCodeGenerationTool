using System;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.Numbers
{

    public class USize : Number
    {
        public USize(string value) {

            try
            {
                if (Environment.Is64BitOperatingSystem)
                {
                    variableType = ulong.Parse(value);
                }
                else
                {
                    variableType = uint.Parse(value);
                }
            }
            catch (Exception)
            {
                throw new NumberFormatException($"The value {value} can not be converted to a usize representation");
            }

        }

        public override string GetRustType()
        {
            return EnumNumberTypes.usize.ToString();
        }

    }
}
