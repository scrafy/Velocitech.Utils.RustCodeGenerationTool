namespace Velocitech.Utils.RustCodeGenerationTool.Types.Numbers
{
    public class U128 : Number<string>
    {
        public U128()
        {
            maxValue = "340282366920938463463374607431768211455";
            minValue = "0";
        }

        public override string GetRustType()
        {
            return EnumNumberTypes.u128.ToString();

        }

    }

}
