namespace Velocitech.Utils.RustCodeGenerationTool.Types.Numbers
{
    public class U64 : Number<ulong>
    {
        public U64()
        {
            minValue = ulong.Parse("0");
            maxValue = ulong.Parse("18446744073709551615");
        }

        public override string GetRustType()
        {
            return EnumNumberTypes.u64.ToString();
        }

    }

}
