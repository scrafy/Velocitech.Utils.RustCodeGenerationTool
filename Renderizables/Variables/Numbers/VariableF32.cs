using System;
using System.Globalization;
using Velocitech.Utils.RustCodeGenerationTool.Common;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;
using Velocitech.Utils.RustCodeGenerationTool.Types.Numbers;

namespace Velocitech.Utils.RustCodeGenerationTool.Renderizables.Variables.Numbers
{
    public class VariableF32: IRenderizable
    {
        private string _value;
        private NumericVariableTypeRender _typeRender;
        private string _label;
        private F32 _variableType;

        public VariableF32(string label, string value, NumericVariableTypeRender typeRender, F32 variableType)
        {
            if (variableType == null)
                throw new NumberFormatException($"The type parameter can not be null");

            if (value.IndexOf(',') != -1)
                throw new NumberFormatException($"The value {value} can not be converted to a f32 representation. Not add char ','");

            try
            {
                var parsed = float.Parse(value, new NumberFormatInfo() { NumberDecimalSeparator = "." });

                if (!(variableType.MinValue <= parsed && parsed <= variableType.MaxValue))
                    throw new NumberFormatException($"The value {value} can not be converted to a f32 representation");

                _value = value;
                _label = label;
                _typeRender = typeRender;
                _variableType = variableType;
            }
            catch (Exception)
            {
                throw new NumberFormatException($"The value {value} can not be converted to a f32 representation");
            }
        }

        public string Render()
        {
            if (_typeRender == NumericVariableTypeRender.NUMERIC_MUTABLE_VARIABLE_AS_VALUE)
            {
                return MutableAsValue();
            }
            if (_typeRender == NumericVariableTypeRender.NUMERIC_MUTABLE_VARIABLE_AS_REFERENCE)
            {
                return MutableAsReference();
            }
            if (_typeRender == NumericVariableTypeRender.NUMERIC_MUTABLE_VARIABLE_AS_MUTABLE_REFERENCE)
            {
                return MutableAsMutableReference();
            }
            if (_typeRender == NumericVariableTypeRender.NUMERIC_INMUTABLE_VARIABLE_AS_MUTABLE_REFERENCE)
            {
                return InmutableAsMutableReference();
            }
            if (_typeRender == NumericVariableTypeRender.NUMERIC_INMUTABLE_VARIABLE_AS_VALUE)
            {
                return InmutableAsValue();
            }
            if (_typeRender == NumericVariableTypeRender.NUMERIC_INMUTABLE_VARIABLE_AS_REFERENCE)
            {
                return InmutableAsReference();
            }
            throw new RenderException($"The variable with name {_label} with value {_value}");
        }

        private string MutableAsValue()
        {
            return $"let mut {_label}:{_variableType.GetRustType()} = {_value};";
        }

        private string MutableAsMutableReference()
        {
            return $"let mut {_label}:&mut {_variableType.GetRustType()} = &mut {_variableType.ToString()};";
        }
        private string MutableAsReference()
        {
            return $"let mut {_label}:&{_variableType.GetRustType()} = &{_variableType.ToString()};";
        }

        private string InmutableAsValue()
        {
            return $"let {_label}:{_variableType.GetRustType()} = {_value};";
        }

        private string InmutableAsReference()
        {
            return $"let {_label}:&{_variableType.GetRustType()} = &{_value};";
        }

        private string InmutableAsMutableReference()
        {
            return $"let {_label}:&mut {_variableType.GetRustType()} = &mut {_value};";
        }
    }
}
