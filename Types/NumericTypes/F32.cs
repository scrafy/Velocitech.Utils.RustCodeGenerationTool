namespace Velocitech.Utils.RustCodeGenerationTool.Types.NumericTypes
{
    public class F32
    {
        private EnumNumberTypes _label;
        private float _value;

        public EnumNumberTypes Label { get => _label; set => _label = value; }
        public float Value { get => _value; set => _value = value; }
    }

}
