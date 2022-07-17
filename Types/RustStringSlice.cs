using Velocitech.Utils.RustCodeGenerationTool.Common;

namespace Velocitech.Utils.RustCodeGenerationTool.Types
{
    public class RustStringSlice : Type
    {
    
        public RustStringSlice()
        {

        }

        public override string GetRustType()
        {
            return "&'static str";
        }

    }
}
