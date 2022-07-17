using System;
using Velocitech.Utils.RustCodeGenerationTool.Common;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;
using Velocitech.Utils.RustCodeGenerationTool.Types.Numbers;


namespace Velocitech.Utils.RustCodeGenerationTool.Renderizables.Variables.Numbers
{
    public class VariableU32: NumericVariable<U32, uint>, IRenderAsVariable
    {
   
        public VariableU32(string label, string value, NumericVariableTypeRender typeRender)
        {
            variableType = new U32();

            try
            {
                var parsed = uint.Parse(value);

                if (!(variableType.MinValue <= parsed && parsed <= variableType.MaxValue))
                    throw new NumberFormatException($"The value {value} can not be converted to a u32 representation");
            }
            catch (Exception)
            {
                throw new NumberFormatException($"The value {value} can not be converted to a u32 representation");
            }
            this.value = value;
            this.label = label;
            this.typeRender = typeRender;
        }

    }
}
