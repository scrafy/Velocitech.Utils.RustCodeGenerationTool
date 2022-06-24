using Velocitech.Utils.RustCodeGenerationTool.Common;

namespace Velocitech.Utils.RustCodeGenerationTool.Types
{
    internal abstract class Type<T>
    {
        protected T _value;
        public T Value { get => _value; }

        public abstract string GetRustType();
        
    }

}
