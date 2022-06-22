namespace Velocitech.Utils.RustCodeGenerationTool.Types.NumericTypes
{
    public class I64
    {
        private EnumNumberTypes _label;
        private long _value;

        public EnumNumberTypes Label { get => _label; set => _label = value; }
        public long Value { get => _value; set => _value = value; }
    }

}
