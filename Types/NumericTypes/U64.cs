namespace Velocitech.Utils.RustCodeGenerationTool.Types.NumericTypes
{
    public class U64 
    {
        private EnumNumberTypes _label;
        private ulong _value;

        public EnumNumberTypes Label { get => _label; set => _label = value; }
        public ulong Value { get => _value; set => _value = value; }
    }

}
