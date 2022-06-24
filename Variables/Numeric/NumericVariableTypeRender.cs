using System;
using System.Collections.Generic;
using System.Text;

namespace Velocitech.Utils.RustCodeGenerationTool.Variables.Numeric
{
    internal enum NumericVariableTypeRender
    {
        RENDER_NUMERIC_VARIABLE_MUTABLE,
        RENDER_NUMERIC_VARIABLE_AS_INMUTABLE,
        RENDER_NUMERIC_VARIABLE_AS_REFERENCE_INMUTABLE,
        RENDER_NUMERIC_MUTABLE_VARIABLE_AS_REFERENCE_INMUTABLE,
        RENDER_NUMERIC_MUTABLE_VARIABLE_AS_REFERENCE_MUTABLE
    }
}
