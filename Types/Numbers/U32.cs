namespace Velocitech.Utils.RustCodeGenerationTool.Types.Numbers
{
    public class U32 : Number<uint>
    {

        public U32()
        {
            minValue = uint.Parse("0");
            maxValue = uint.Parse("4294967295");
        }

        public override string GetRustType()
        {
            return EnumNumberTypes.u32.ToString();
        }

    }

}
