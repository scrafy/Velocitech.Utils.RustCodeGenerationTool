using System;
using Velocitech.Utils.RustCodeGenerationTool.Common;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;
using Velocitech.Utils.RustCodeGenerationTool.Types.Numbers;


namespace Velocitech.Utils.RustCodeGenerationTool.Renderizables.Variables.Numbers
{
    public class VariableISize: NumericVariable<ISize, long>, IRenderizable
    {
        public VariableISize(string label, string value, NumericVariableTypeRender typeRender)
        {
            variableType = new ISize();

            try
            {              

                if (Environment.Is64BitOperatingSystem)
                {
                    var parsed = long.Parse(value);
                    if (!(variableType.MinValue <= parsed && parsed <= variableType.MaxValue))
                        throw new NumberFormatException($"The value {value} can not be converted to a isize representation");
                }
                else
                {
                    var parsed = int.Parse(value);
                    if (!(variableType.MinValue <= parsed && parsed <= variableType.MaxValue))
                        throw new NumberFormatException($"The value {value} can not be converted to a isize representation");

                }

                
            }
            catch (Exception)
            {
                throw new NumberFormatException($"The value {value} can not be converted to a isize representation");
            }
            this.value = value;
            this.label = label;
            this.typeRender = typeRender;
        }

    }
}
