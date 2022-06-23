using System;
using Velocitech.Utils.RustCodeGenerationTool.Types.NumericTypes;


namespace Velocitech.Utils.RustCodeGenerationTool.Variables.Numeric
{
    public class VariableF32 : Variable
    {
        private string _label;
        private F32 _value;

        public VariableF32(string label, string value)
        {
            if (string.IsNullOrEmpty(label)){

                label = Guid.NewGuid().ToString();
            }
            _label = label;
            _value = new F32(value);
        }

        public override string RenderAsNonMutableVariable()
        {
            return $"let {_label}:{_value.GetRustType()} = {_value.Value};";
        }

        public override string RenderAsMutableVariable()
        {
            return $"let mut {_label}:{_value.GetRustType()} = {_value.Value};";
        }

        public override string RenderAsMutableReferenceType()
        {
            return $"let {_label}:&mut {_value.GetRustType()} = &mut {_value.Value};";
        }

    }
}
