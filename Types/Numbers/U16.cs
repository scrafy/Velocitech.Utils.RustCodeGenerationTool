namespace Velocitech.Utils.RustCodeGenerationTool.Types.Numbers
{
    public class U16 : Number<ushort>
    {
        public U16()
        {
            minValue = ushort.Parse("0");
            maxValue = ushort.Parse("65535");
        }

        public override string GetRustType()
        {
            return EnumNumberTypes.u16.ToString();
        }

    }

}
