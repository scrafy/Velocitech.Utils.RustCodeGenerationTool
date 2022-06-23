namespace Velocitech.Utils.RustCodeGenerationTool.Types.NumericTypes
{
    public class U16 : Type<ushort>
    {
        public override string GetRustType()
        {
            return EnumNumberTypes.f32.ToString();
        }
    }

}
