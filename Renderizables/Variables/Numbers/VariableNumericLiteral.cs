using System;
using Velocitech.Utils.RustCodeGenerationTool.Common;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;
using Velocitech.Utils.RustCodeGenerationTool.Types.Numbers;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Velocitech.Utils.RustCodeGenerationTool.Renderizables.Variables.Numbers
{
    public class VariableNumericLiteral: IRenderizable
    {
        private string _value;
        private NumericVariableTypeRender _typeRender;
        private string _label;
       

        public VariableNumericLiteral(string label, string value, NumericVariableTypeRender typeRender )
        {
          
            var _suffix = string.Empty;
            var prefixNotAllowedWithFloats = new string[] { "0x", "0b", "0o" };
            var _regularExpressions = new List<Regex>() {

                new Regex("^[1-9]{1}[0-9_]*(([eE]{1}[-+]?[0-9_]+)|([.]{1}[0-9_]+(([eE]{1}[-+]?)?[0-9_]+)?))?$"),
                new Regex("^0[0-9_]*(([eE]{1}[-+]?[0-9_]+)|([.]{1}[0-9_]+(([eE]{1}[-+]?)?[0-9_]+)?))?$"),
                new Regex("^0x[0-9abcdefABCDEF_]+$"),
                new Regex("^0b[01_]+$"),
                new Regex("^0o[0-7_]+$"),

             };

            _suffix = Enum.GetNames(typeof(EnumNumberTypes)).ToList().FirstOrDefault(type =>
            {
                return value.EndsWith(type);

            }) ?? string.Empty;

            if (!string.IsNullOrEmpty(_suffix))
            {

                //if value begins with 0x or 0b or 0o prefix, it can not ends with f32 o f64 suffix.
                if ((_suffix.ToLower() == "f32" || _suffix.ToLower() == "f64") && prefixNotAllowedWithFloats.Any(prefix => prefix == value.Substring(0, 2)))
                    throw new NumberLiteralFormatException("The number literal has not the correct format");

                value = value.Substring(0, value.IndexOf(_suffix));
            }
            var regex = _regularExpressions.FirstOrDefault(regex =>
            {
                return regex.IsMatch(value);

            });

            if (regex == null)
                throw new NumberLiteralFormatException("The number literal has not the correct format");


            _label = label;
            _value = value;
            _typeRender = typeRender;
       
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
            return $"let mut {_label} = {_value};";
        }

        private string MutableAsMutableReference()
        {
            return $"let mut {_label} = &mut {_value};";
        }
        private string MutableAsReference()
        {
            return $"let mut {_label} = &{_value};";
        }

        private string InmutableAsValue()
        {
            return $"let {_label} = {_value};";
        }

        private string InmutableAsReference()
        {
            return $"let {_label} = &{_value};";
        }

        private string InmutableAsMutableReference()
        {
            return $"let {_label} = &mut {_value};";
        }
    }
}
