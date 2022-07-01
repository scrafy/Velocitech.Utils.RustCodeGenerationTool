using System;
using System.Globalization;
using Velocitech.Utils.RustCodeGenerationTool.Common;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;
using Velocitech.Utils.RustCodeGenerationTool.Types.Numbers;

namespace Velocitech.Utils.RustCodeGenerationTool.Renderizables.Variables.Numbers
{
    public class VariableF64: NumericVariable<F64, double>, IRenderizable
    {
        
        public VariableF64(string label, string value, NumericVariableTypeRender typeRender)
        {
            variableType = new F64();

            if (value.IndexOf(',') != -1)
                throw new NumberFormatException($"The value {value} can not be converted to a f64 representation. Not add char ','");

            try
            {
                var parsed = double.Parse(value, new NumberFormatInfo() { NumberDecimalSeparator = "." });

                if (!(variableType.MinValue <= parsed && parsed <= variableType.MaxValue))
                    throw new NumberFormatException($"The value {value} can not be converted to a f64 representation");

                this.value = value;
                this.label = label;
                this.typeRender = typeRender;
                this.variableType = variableType;
            }
            catch (Exception)
            {
                throw new NumberFormatException($"The value {value} can not be converted to a f64 representation");
            }
        }
    }
}
