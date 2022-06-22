using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;
using System;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.NumericTypes
{
    public class NumberLiteral
    {

        private string _value;
        private List<Regex> _regularExpressions;
        private string _suffix = string.Empty;

        public NumberLiteral()
        {
            _regularExpressions = new List<Regex>() {

                new Regex("/^[0-9]+(_?[0-9]+_?)*$/s"),
                new Regex("/^0x[0-9abcdef]+(_?[0-9abcdefABCDEF]+_?)*$/s"),
                new Regex("/^0o[0-9abcdef]+(_?[0-9abcdefABCDEF]+_?)*$/s"),
                new Regex("/^0b[01]+(_?[01]+_?)*$/s")                

             };
        }

        public string Value
        {


            get { return _value; }
            set {

                _suffix = Enum.GetNames(Type.GetType("EnumNumberTypes")).ToList().FirstOrDefault(type =>
                {
                    return value.EndsWith(type);
                });

                _value = _regularExpressions.FirstOrDefault(regex =>
                {
                    return regex.IsMatch(value);
                })?.Match(value).Value + _suffix ?? throw new NumberLiteralFormatException("The number literal has not the correct format");
            }
        }

    }
}
