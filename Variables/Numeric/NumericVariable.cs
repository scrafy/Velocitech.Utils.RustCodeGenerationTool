using System;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;
using Velocitech.Utils.RustCodeGenerationTool.Types;


namespace Velocitech.Utils.RustCodeGenerationTool.Variables.Numeric
{
    internal class NumericVariable<T> : Variable
        where T : Type<T>
    {
        private string _label;
        private T _value;
        private NumericVariableTypeRender _renderTypes;

        public NumericVariable(string label, T value, NumericVariableTypeRender renderTypes)
        {
            if (string.IsNullOrEmpty(label)){

                label = Guid.NewGuid().ToString();
            }
            _label = label;
            _value = value;
            _renderTypes = renderTypes;
        }       
      
        public override string Render()
        {
            if(_renderTypes == NumericVariableTypeRender.RENDER_NUMERIC_MUTABLE_VARIABLE_AS_REFERENCE_INMUTABLE)
            {
                return RenderNumericMutableVariableAsReferenceInmutable();
            }
            if (_renderTypes == NumericVariableTypeRender.RENDER_NUMERIC_MUTABLE_VARIABLE_AS_REFERENCE_MUTABLE)
            {
                return RenderNumericMutableVariableAsReferenceMutable();
            }
            if (_renderTypes == NumericVariableTypeRender.RENDER_NUMERIC_VARIABLE_AS_INMUTABLE)
            {
                return RenderNumericVariableAsInmutable();
            }
            if (_renderTypes == NumericVariableTypeRender.RENDER_NUMERIC_VARIABLE_MUTABLE)
            {
                return RenderNumericVariableAsMutable();
            }
            if (_renderTypes == NumericVariableTypeRender.RENDER_NUMERIC_VARIABLE_MUTABLE)
            {
                return RenderNumericVariableAsMutable();
            }
            throw new RenderException($"The variable with name {_label} with value {_value.Value}");
        }

        private string RenderNumericVariableAsMutable()
        {
            return $"let mut {_label}:{_value.GetRustType()} = {_value.Value};";
        }

        private string RenderNumericVariableAsInmutable()
        {
            return $"let {_label}:{_value.GetRustType()} = {_value.Value};";
        }

        private string RenderNumericVariableAsReferenceInmutable()
        {
            return $"let {_label}:&{_value.GetRustType()} = &{_value.Value};";
        }

        private string RenderNumericMutableVariableAsReferenceInmutable()
        {
            return $"let mut {_label}:&{_value.GetRustType()} = &{_value.Value};";
        }

        private string RenderNumericMutableVariableAsReferenceMutable()
        {
            return $"let mut {_label}:&mut {_value.GetRustType()} = &mut {_value.Value};";
        }
    }
}
