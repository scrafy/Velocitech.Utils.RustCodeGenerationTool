using Velocitech.Utils.RustCodeGenerationTool.Common;

namespace Velocitech.Utils.RustCodeGenerationTool.Types
{
    public class Vec<T> : Type, IRenderAsType
        where T : Type
    {

        private T _type;

        public Vec(T type)
        {
            _type = type;
        }

        public override string GetRustType()
        {
            return $"Vec<{_type.GetRustType()}>";
        }

        public string RenderAsType()
        {
            return $"Vec<{_type.GetRustType()}>";
        }
    }
}
