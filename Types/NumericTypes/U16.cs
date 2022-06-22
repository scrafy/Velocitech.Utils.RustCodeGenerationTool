namespace Velocitech.Utils.RustCodeGenerationTool.Types.NumericTypes
{
    public class U16 
    {
        private EnumNumberTypes _label;
        private ushort _value;

        public EnumNumberTypes Label { get => _label; set => _label = value; }
        public ushort Value { get => _value; set => _value = value; }
    }

}
