namespace Velocitech.Utils.RustCodeGenerationTool.Types.Numbers
{
    public abstract class Number<T> : Type
    {
        protected T minValue;
        protected T maxValue;

        public T MinValue { get => minValue; }
        public T MaxValue { get => maxValue; }

        public abstract string GetRustType();

    }
}
