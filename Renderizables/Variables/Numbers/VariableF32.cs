using System;
using System.Globalization;
using Velocitech.Utils.RustCodeGenerationTool.Common;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;
using Velocitech.Utils.RustCodeGenerationTool.Types.Numbers;

namespace Velocitech.Utils.RustCodeGenerationTool.Renderizables.Variables.Numbers
{
    public class VariableF32: NumericVariable<F32, float>, IRenderAsVariable
    {
       
        public VariableF32(string label, string value, NumericVariableTypeRender typeRender)
        {
            variableType = new F32();
            
            if (value.IndexOf(',') != -1)
                throw new NumberFormatException($"The value {value} can not be converted to a f32 representation. Not add char ','");

            try
            {
                var parsed = float.Parse(value, new NumberFormatInfo() { NumberDecimalSeparator = "." });

                if (!(variableType.MinValue <= parsed && parsed <= variableType.MaxValue))
                    throw new NumberFormatException($"The value {value} can not be converted to a f32 representation");

                this.value = value;
                this.label = label;
                this.typeRender = typeRender;                
            }
            catch (Exception)
            {
                throw new NumberFormatException($"The value {value} can not be converted to a f32 representation");
            }
        }
    
    }
}
