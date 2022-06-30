using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Velocitech.Utils.RustCodeGenerationTool.Common;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;
using Velocitech.Utils.RustCodeGenerationTool.Types.Numbers;
using Velocitech.Utils.RustCodeGenerationTool.Utils;

namespace Velocitech.Utils.RustCodeGenerationTool.Renderizables.Variables.Numbers
{
    public class VariableI128: IRenderizable
    {
        private string _value;
        private NumericVariableTypeRender _typeRender;
        private string _label;
        private I128 _variableType;

        public VariableI128(string label, string value, NumericVariableTypeRender typeRender, I128 variableType)
        {
            if (variableType == null)
                throw new NumberFormatException($"The type parameter can not be null");

            value = value.Trim();

            if (!Regex.Match(value, "^[0-9]+$|^-{1}[0-9]+$").Success)

                throw new NumberFormatException($"Invalid I128 number: {value}");

            if (value[0] == '-')
            {

                value = value.Remove(0, 1);

                if (CompareStringNumbers.CompareNumbers(value, variableType.MinValue) == 1)

                    throw new NumberOverflowException($"The number {value} can not be stored in an I128 Rust type. Number too small");

            }
            else
            {
                if (CompareStringNumbers.CompareNumbers(value, variableType.MaxValue) == 1)

                    throw new NumberOverflowException($"The number {value} can not be stored in an I128 Rust type. Number too big");

            }
            _label = label;
            _value = value;
            _typeRender = typeRender;
            _variableType = variableType;
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
