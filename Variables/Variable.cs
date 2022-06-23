using Velocitech.Utils.RustCodeGenerationTool.Types;

namespace Velocitech.Utils.RustCodeGenerationTool.Variables
{
    public abstract class Variable
    {
        public abstract string RenderAsNonMutableVariable();
        public abstract string RenderAsMutableVariable();

        public abstract string RenderAsMutableReferenceType();

    }
}