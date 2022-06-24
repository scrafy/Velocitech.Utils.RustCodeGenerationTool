using System.Text.RegularExpressions;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;
using Velocitech.Utils.RustCodeGenerationTool.Utils;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.NumericTypes
{
    internal class I128 : Type<string>
    {
        private const string MIN = "170141183460469231731687303715884105728";
        private const string MAX = "170141183460469231731687303715884105727";
        
        
        public I128(string value)
        {
            value = value.Trim();

            if (!Regex.Match(value, "/^[0-9]+$|^-{1}[0-9]+$/s").Success)

                throw new NumberFormatException($"Invalid I128 number: {value}");

            if (value[0] == '-')
            {

                value = value.Remove(0, 1);

                if (CompareStringNumbers.CompareNumbers(value, MIN) == 1)

                    throw new NumberOverflowException($"The number {value} can not be stored in an I128 Rust type. Number too small");

                _value = $"-{value}";
            }
            else
            {
                if (CompareStringNumbers.CompareNumbers(value, MAX) == 1)

                    throw new NumberOverflowException($"The number {value} can not be stored in an I128 Rust type. Number too big");

                _value = value;
            }
        }        
        

        public override string GetRustType()
        {
            return EnumNumberTypes.i128.ToString();
        }

  
    }



}
