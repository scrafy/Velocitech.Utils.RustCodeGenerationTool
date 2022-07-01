using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Velocitech.Utils.RustCodeGenerationTool.Common;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;
using Velocitech.Utils.RustCodeGenerationTool.Types.Numbers;
using Velocitech.Utils.RustCodeGenerationTool.Utils;

namespace Velocitech.Utils.RustCodeGenerationTool.Renderizables.Variables.Numbers
{
    public class VariableU128: NumericVariable<U128, string>, IRenderizable
    {

        public VariableU128(string label, string value, NumericVariableTypeRender typeRender)
        {
            variableType = new U128();

            value = value.Trim();

            if (!Regex.Match(value, "^[0-9]+$").Success)

                throw new NumberFormatException($"Invalid U128 number: {value}");

            if (CompareStringNumbers.CompareNumbers(value, variableType.MaxValue) == 1)

                throw new NumberOverflowException($"The number {value} can not be stored in an U128 Rust type. Number too big");

            this.value = value;
            this.label = label;
            this.typeRender = typeRender;
        }
        
    }
}
