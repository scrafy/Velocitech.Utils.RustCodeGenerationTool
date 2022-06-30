namespace Velocitech.Utils.RustCodeGenerationTool.Types
{
    public abstract class Type<T>
    {
        protected T _value;
        public T Value { get => _value; }
        public abstract string GetRustType();
        
    }

}
