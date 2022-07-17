using System;
using Velocitech.Utils.RustCodeGenerationTool.Common;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;
using Velocitech.Utils.RustCodeGenerationTool.Types.Numbers;


namespace Velocitech.Utils.RustCodeGenerationTool.Renderizables.Variables.Numbers
{
    public class VariableU64: NumericVariable<U64, ulong>, IRenderAsVariable
    {
        public VariableU64(string label, string value, NumericVariableTypeRender typeRender)
        {
            variableType = new U64();

            try
            {
                var parsed = ulong.Parse(value);

                if (!(variableType.MinValue <= parsed && parsed <= variableType.MaxValue))
                    throw new NumberFormatException($"The value {value} can not be converted to a u64 representation");
            }
            catch (Exception)
            {
                throw new NumberFormatException($"The value {value} can not be converted to a u64 representation");
            }
            this.value = value;
            this.label = label;
            this.typeRender = typeRender;
        }

    }
}
