using System;
using Velocitech.Utils.RustCodeGenerationTool.Common;

namespace Velocitech.Utils.RustCodeGenerationTool.Types
{
    public class RustString : IRenderVariable
    {
        public RustString()
        {

        }

        public string Render()
        {
            return "String";
        }
    }
}
