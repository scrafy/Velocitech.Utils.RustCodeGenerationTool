namespace Velocitech.Utils.RustCodeGenerationTool.Types.NumericTypes
{
    public class I32 
    {
        private EnumNumberTypes _label;
        private int _value;

        public EnumNumberTypes Label { get => _label; set => _label = value; }
        public int Value { get => _value; set => _value = value; }
    }

}
