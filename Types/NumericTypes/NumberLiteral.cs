using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;
using System;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.NumericTypes
{
    internal class NumberLiteral : Type<string>
    {

        public NumberLiteral(string value)
        {
            var _suffix = string.Empty;
            var _regularExpressions = new List<Regex>() {

                new Regex("/^[1-9]{1}[0-9_]*(([eE]{1}[-+]?[0-9_]+)|(.[0-9_]+(([eE]{1}[-+]?)?[0-9_]+)?))?$/s"),
                new Regex("/^0[0-9_]*(([eE]{1}[-+]?[0-9_]+)|(.[0-9_]+(([eE]{1}[-+]?)?[0-9_]+)?))?$/s"),
                new Regex("/^0x[0-9abcdefABCDEF_]+$/s"),
                new Regex("/^0b[01_]+$/s"),
                new Regex("/^0o[0-7_]+$/s"),               

             };

            _suffix = Enum.GetNames(Type.GetType("EnumNumberTypes")).ToList().FirstOrDefault(type =>
            {
                return value.EndsWith(type);

            }) ?? string.Empty;

            if (!string.IsNullOrEmpty(_suffix))
            {
                value = value.Substring(0, value.IndexOf(_suffix));
            }
            _value = _regularExpressions.FirstOrDefault(regex =>
            {
                return regex.IsMatch(value);

            })?.Match(value).Value + _suffix ?? throw new NumberLiteralFormatException("The number literal has not the correct format");
        }

        public override string GetRustType()
        {
            return string.Empty;
        }

    }
}
