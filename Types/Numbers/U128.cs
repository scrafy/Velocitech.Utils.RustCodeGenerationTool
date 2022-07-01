namespace Velocitech.Utils.RustCodeGenerationTool.Types.Numbers
{
    public class U128 : Number<string>
    {
        public U128()
        {
            maxValue = "340_282_366_920_938_463_463_374_607_431_768_211_455";
            minValue = "0";
        }

        public override string GetRustType()
        {
            return EnumNumberTypes.u128.ToString();

        }

    }

}
