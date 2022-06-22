namespace Velocitech.Utils.RustCodeGenerationTool.Types.NumericTypes
{
    public class U8 
    {
        private EnumNumberTypes _label;
        private byte _value;

        public EnumNumberTypes Label { get => _label; set => _label = value; }
        public byte Value { get => _value; set => _value = value; }
    }

}
