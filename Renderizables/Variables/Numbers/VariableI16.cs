using System;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;
using Velocitech.Utils.RustCodeGenerationTool.Types.Numbers;


namespace Velocitech.Utils.RustCodeGenerationTool.Renderizables.Variables.Numbers
{
    public class VariableI16: NumericVariable<I16, short>, IRenderAsVariable
    {
       
        public VariableI16(string label, string value, NumericVariableTypeRender typeRender)
        {
            variableType = new I16();

            try
            {
                var parsed = short.Parse(value);

                if (!(variableType.MinValue <= parsed && parsed <= variableType.MaxValue))
                    throw new NumberFormatException($"The value {value} can not be converted to a i16 representation");
            }
            catch (Exception)
            {
                throw new NumberFormatException($"The value {value} can not be converted to a i16 representation");
            }
            this.value = value;
            this.label = label;
            this.typeRender = typeRender;
        }

    }
}
