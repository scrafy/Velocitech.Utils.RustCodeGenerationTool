namespace Velocitech.Utils.RustCodeGenerationTool.Types.NumericTypes
{
    public class I8 
    {
        private EnumNumberTypes _label;
        private sbyte _value;

        public EnumNumberTypes Label { get => _label; set => _label = value; }
        public sbyte Value { get => _value; set => _value = value; }
    }

}
