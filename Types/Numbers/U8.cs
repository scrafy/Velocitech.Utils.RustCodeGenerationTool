namespace Velocitech.Utils.RustCodeGenerationTool.Types.Numbers
{
    public class U8 : Number<byte>
    {
        public U8()
        {
            minValue = byte.Parse("0");
            maxValue = byte.Parse("255");
        }


        public override string GetRustType()
        {
            return EnumNumberTypes.u8.ToString();
        }

    }

}
