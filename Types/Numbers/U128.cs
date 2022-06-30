using System.Text.RegularExpressions;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;
using Velocitech.Utils.RustCodeGenerationTool.Utils;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.Numbers
{
    public class U128 : Number
    {
        private const string MAX = "340282366920938463463374607431768211455";

        public U128(string value)
        {
            value = value.Trim();

            if (!Regex.Match(value, "^[0-9]+$").Success)

                throw new NumberFormatException($"Invalid U128 number: {value}");

            if (CompareStringNumbers.CompareNumbers(value, MAX) == 1)

                throw new NumberOverflowException($"The number {value} can not be stored in an U128 Rust type. Number too big");

            variableType = value;
        }

        public override string GetRustType()
        {
            return EnumNumberTypes.u128.ToString();

        }

    }

}
