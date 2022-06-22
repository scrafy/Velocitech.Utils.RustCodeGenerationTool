namespace Velocitech.Utils.RustCodeGenerationTool.Types.NumericTypes
{
    public class U32 
    {
        private EnumNumberTypes _label;
        private uint _value;

        public EnumNumberTypes Label { get => _label; set => _label = value; }
        public uint Value { get => _value; set => _value = value; }
    }

}
