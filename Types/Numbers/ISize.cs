using System;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.Numbers
{

    public class ISize : Number<long>
    {

        public ISize()
        {
            if (Environment.Is64BitOperatingSystem)
            {
                minValue = long.Parse("-9223372036854775808");
                maxValue = long.Parse("9223372036854775807");
            }
            else
            {
                minValue = int.Parse("-2147483648");
                maxValue = int.Parse("2147483647");

            }

        }

        public override string GetRustType()
        {
            return EnumNumberTypes.isize.ToString();
        }

    }
}
