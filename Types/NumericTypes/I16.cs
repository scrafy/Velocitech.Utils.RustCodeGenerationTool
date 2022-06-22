namespace Velocitech.Utils.RustCodeGenerationTool.Types.NumericTypes
{
    public class I16 
    {
        private EnumNumberTypes _label;
        private short _value;

        public EnumNumberTypes Label { get => _label; set => _label = value; }
        public short Value { get => _value; set => _value = value; }
    }

}
