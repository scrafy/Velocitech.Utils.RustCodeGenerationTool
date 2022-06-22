using System.Text.RegularExpressions;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;
using Velocitech.Utils.RustCodeGenerationTool.Utils;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.NumericTypes
{
    public class I128 
    {
        private const string MIN = "170141183460469231731687303715884105728";
        private const string MAX = "170141183460469231731687303715884105727";
        private EnumNumberTypes _label;
        private string _value;
        private bool _isNegative = false;

        public EnumNumberTypes Label { get => _label; set => _label = value; }
        public string Value {

            get { return _value; }

            set
            {
                value = value.Trim();

                if (!Regex.Match(value, "/^[0-9]+$|^-{1}[0-9]+$/s").Success)
                
                    throw new NumberFormatException($"Invalid I128 number: {value}");

                if(value[0] == '-')
                {
                    _isNegative = true;
                    value = value.Remove(1);

                    if (CompareStringNumbers.CompareNumbers(value, MIN) == 1)

                        throw new NumberOverflowException($"The number {value} can not be stored in an I128 Rust type. Number too small");
                }
                else
                {
                    if (CompareStringNumbers.CompareNumbers(value, MAX) == 1)

                        throw new NumberOverflowException($"The number {value} can not be stored in an I128 Rust type. Number too big");
                }
                _value = value;
            }
        }

    }

}
