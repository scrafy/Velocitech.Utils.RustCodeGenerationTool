using System;
using Velocitech.Utils.RustCodeGenerationTool.Common;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;
using Velocitech.Utils.RustCodeGenerationTool.Types.Numbers;


namespace Velocitech.Utils.RustCodeGenerationTool.Renderizables.Variables.Numbers
{
    public class VariableI32: NumericVariable<I32, int>, IRenderizable
    {
        public VariableI32(string label, string value, NumericVariableTypeRender typeRender)
        {
            variableType = new I32();

            try
            {
                var parsed = int.Parse(value);

                if (!(variableType.MinValue <= parsed && parsed <= variableType.MaxValue))
                    throw new NumberFormatException($"The value {value} can not be converted to a i32 representation");
            }
            catch (Exception)
            {
                throw new NumberFormatException($"The value {value} can not be converted to a i32 representation");
            }
            this.value = value;
            this.label = label;
            this.typeRender = typeRender;
        }
       
    }
}
