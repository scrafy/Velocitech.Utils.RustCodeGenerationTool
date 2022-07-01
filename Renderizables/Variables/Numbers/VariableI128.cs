using System.Text.RegularExpressions;
using Velocitech.Utils.RustCodeGenerationTool.Common;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;
using Velocitech.Utils.RustCodeGenerationTool.Types.Numbers;
using Velocitech.Utils.RustCodeGenerationTool.Utils;

namespace Velocitech.Utils.RustCodeGenerationTool.Renderizables.Variables.Numbers
{
    public class VariableI128: NumericVariable<I128, string>, IRenderizable
    {
        public VariableI128(string label, string value, NumericVariableTypeRender typeRender)
        {
            variableType = new I128();

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
            this.value = value;
            this.label = label;
            this.typeRender = typeRender;            
        }
       
    }
}
