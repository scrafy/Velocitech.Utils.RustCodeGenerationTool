namespace Velocitech.Utils.RustCodeGenerationTool.Types
{
    public abstract class Type<T>
    {
        private T _value;
        public virtual T Value { get => _value; set => _value = value; }

        public abstract string GetRustType();
        
    }
}
