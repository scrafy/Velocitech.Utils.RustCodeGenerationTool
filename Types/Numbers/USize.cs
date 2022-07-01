using System;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.Numbers
{

    public class USize : Number<ulong>
    {
        public USize()
        {
            if (Environment.Is64BitOperatingSystem)
            {
                minValue = ulong.Parse("0");
                maxValue = ulong.Parse("18446744073709551615");
            }
            else
            {
                minValue = uint.Parse("0");
                maxValue = uint.Parse("4294967295");

            }

        }

        public override string GetRustType()
        {
            return EnumNumberTypes.usize.ToString();
        }

    }
}
