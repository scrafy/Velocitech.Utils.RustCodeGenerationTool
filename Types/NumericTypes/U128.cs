using System.Text.RegularExpressions;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;
using Velocitech.Utils.RustCodeGenerationTool.Utils;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.NumericTypes
{
    public class U128 : Type<string>
    {
        private const string MAX = "340282366920938463463374607431768211455";
        
        private string _value;
                
        public override string Value {

            get { return _value; }

            set
            {
                value = value.Trim();

                if (!Regex.Match(value, "/^[0-9]+$/s").Success)
                
                    throw new NumberFormatException($"Invalid U128 number: {value}");
                
                if (CompareStringNumbers.CompareNumbers(value, MAX) == 1)
                
                    throw new NumberOverflowException($"The number {value} can not be stored in an U128 Rust type. Number too big");
                
                _value = value;
            }
        }

        public override string GetRustType()
        {
            throw new System.NotImplementedException();
        }
    }

}
