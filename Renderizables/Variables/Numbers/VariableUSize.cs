using System;
using Velocitech.Utils.RustCodeGenerationTool.Common;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;
using Velocitech.Utils.RustCodeGenerationTool.Types.Numbers;


namespace Velocitech.Utils.RustCodeGenerationTool.Renderizables.Variables.Numbers
{
    public class VariableUSize : NumericVariable<USize, ulong>, IRenderAsVariable
    {

        public VariableUSize(string label, string value, NumericVariableTypeRender typeRender)
        {
            variableType = new USize();

            try
            {              

                if (Environment.Is64BitOperatingSystem)
                {
                    var parsed = ulong.Parse(value);
                    if (!(variableType.MinValue <= parsed && parsed <= variableType.MaxValue))
                        throw new NumberFormatException($"The value {value} can not be converted to a usize representation");
                }
                else
                {
                    var parsed = uint.Parse(value);
                    if (!(variableType.MinValue <= parsed && parsed <= variableType.MaxValue))
                        throw new NumberFormatException($"The value {value} can not be converted to a usize representation");

                }

                
            }
            catch (Exception)
            {
                throw new NumberFormatException($"The value {value} can not be converted to a usize representation");
            }
            this.value = value;
            this.label = label;
            this.typeRender = typeRender;
        }
      
    }
}
