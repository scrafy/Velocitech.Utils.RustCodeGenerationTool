using System;
using Velocitech.Utils.RustCodeGenerationTool.Common;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;
using Velocitech.Utils.RustCodeGenerationTool.Types.Numbers;


namespace Velocitech.Utils.RustCodeGenerationTool.Renderizables.Variables.Numbers
{
    public class VariableI8: NumericVariable<I8, sbyte>, IRenderAsVariable
    {
        public VariableI8(string label, string value, NumericVariableTypeRender typeRender)
        {
            variableType = new I8();

            try
            {
                var parsed = sbyte.Parse(value);

                if (!(variableType.MinValue <= parsed && parsed <= variableType.MaxValue))
                    throw new NumberFormatException($"The value {value} can not be converted to a i8 representation");
            }
            catch (Exception)
            {
                throw new NumberFormatException($"The value {value} can not be converted to a i8 representation");
            }
            this.value = value;
            this.label = label;
            this.typeRender = typeRender;
        }

    }
}
