using System;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.Numbers
{

    public class ISize : Number
    {

        public ISize(string value)
        {
            try {
                if (Environment.Is64BitOperatingSystem)
                {
                    variableType = long.Parse(value);
                }
                else
                {
                    variableType = int.Parse(value);

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
