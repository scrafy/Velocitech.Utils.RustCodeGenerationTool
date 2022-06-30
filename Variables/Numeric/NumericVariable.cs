using System;
using Velocitech.Utils.RustCodeGenerationTool.Common;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;
using Velocitech.Utils.RustCodeGenerationTool.Types;

namespace Velocitech.Utils.RustCodeGenerationTool.Variables.Numeric
{
    public class NumericVariable<T> : IRenderizable        
    {
        private string _label;
        private Type<T> _value;
        private NumericVariableTypeRender _renderTypes;

        public NumericVariable(string label, Type<T> value, NumericVariableTypeRender renderTypes)
        {
            if (string.IsNullOrEmpty(label)){

                label = Guid.NewGuid().ToString();
            }
            _label = label;
            _value = value;
            _renderTypes = renderTypes;
        }       
      
        public string Render()
        {
            if(_renderTypes == NumericVariableTypeRender.NUMERIC_MUTABLE_VARIABLE_AS_VALUE)
            {
                return MutableAsValue();
            }
            if (_renderTypes == NumericVariableTypeRender.NUMERIC_MUTABLE_VARIABLE_AS_REFERENCE)
            {
                return MutableAsReference();
            }
            if (_renderTypes == NumericVariableTypeRender.NUMERIC_MUTABLE_VARIABLE_AS_MUTABLE_REFERENCE)
            {
                return MutableAsMutableReference();
            }
            if (_renderTypes == NumericVariableTypeRender.NUMERIC_INMUTABLE_VARIABLE_AS_MUTABLE_REFERENCE)
            {
                return InmutableAsMutableReference();
            }
            if (_renderTypes == NumericVariableTypeRender.NUMERIC_INMUTABLE_VARIABLE_AS_VALUE)
            {
                return InmutableAsValue();
            }
            if (_renderTypes == NumericVariableTypeRender.NUMERIC_INMUTABLE_VARIABLE_AS_REFERENCE)
            {
                return InmutableAsReference();
            }
            throw new RenderException($"The variable with name {_label} with value {_value.Value}");
        }

        private string MutableAsValue()
        {
            return $"let mut {_label}:{_value.GetRustType()} = {_value.Value};";
        }

        private string MutableAsMutableReference()
        {
            return $"let mut {_label}:&mut {_value.GetRustType()} = &mut {_value.Value};";
        }
        private string MutableAsReference()
        {
            return $"let mut {_label}:&{_value.GetRustType()} = &{_value.Value};";
        }

        private string InmutableAsValue()
        {
            return $"let {_label}:{_value.GetRustType()} = {_value.Value};";
        }

        private string InmutableAsReference()
        {
            return $"let {_label}:&{_value.GetRustType()} = &{_value.Value};";
        }

        private string InmutableAsMutableReference()
        {
            return $"let {_label}:&mut {_value.GetRustType()} = &mut {_value.Value};";
        }

    }
}
