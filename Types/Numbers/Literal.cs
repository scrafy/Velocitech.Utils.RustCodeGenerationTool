using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;
using System;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.Numbers
{
    public class Literal : Type
    {
        public Literal(string value)
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
                if ((_suffix.ToLower() == "f32" || _suffix.ToLower() == "f64") && prefixNotAllowedWithFloats.Any( prefix => prefix == value.Substring(0, 2)))
                    throw new NumberLiteralFormatException("The number literal has not the correct format");

                value = value.Substring(0, value.IndexOf(_suffix));
            }
            var regex = _regularExpressions.FirstOrDefault(regex =>
            {
                return regex.IsMatch(value);

            });

            if (regex == null)
                throw new NumberLiteralFormatException("The number literal has not the correct format");

            variableType = value + _suffix;  

        }


    }
}
