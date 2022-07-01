using System;
using Velocitech.Utils.RustCodeGenerationTool.Common;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;
using Velocitech.Utils.RustCodeGenerationTool.Types.Numbers;


namespace Velocitech.Utils.RustCodeGenerationTool.Renderizables.Variables.Numbers
{
    public class VariableU16: NumericVariable<U16, ushort>, IRenderizable
    {
        public VariableU16(string label, string value, NumericVariableTypeRender typeRender)
        {
            variableType = new U16();

            try
            {
                var parsed = ushort.Parse(value);

                if (!(variableType.MinValue <= parsed && parsed <= variableType.MaxValue))
                    throw new NumberFormatException($"The value {value} can not be converted to a u16 representation");
            }
            catch (Exception)
            {
                throw new NumberFormatException($"The value {value} can not be converted to a u16 representation");
            }
            this.value = value;
            this.label = label;
            this.typeRender = typeRender;
        }

    }
}
