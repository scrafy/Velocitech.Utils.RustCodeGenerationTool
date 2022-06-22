namespace Velocitech.Utils.RustCodeGenerationTool.Types.NumericTypes
{
    public class F64
    {
        private EnumNumberTypes _label;
        private double _value;

        public EnumNumberTypes Label { get => _label; set => _label = value; }
        public double Value { get => _value; set => _value = value; }
    }

}
