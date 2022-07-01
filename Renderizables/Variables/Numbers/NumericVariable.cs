using Velocitech.Utils.RustCodeGenerationTool.Exceptions;
using Velocitech.Utils.RustCodeGenerationTool.Types.Numbers;

namespace Velocitech.Utils.RustCodeGenerationTool.Renderizables.Variables.Numbers
{
    public abstract class NumericVariable<T,V> where T : Number<V>
    {
        protected string value;
        protected NumericVariableTypeRender typeRender;
        protected string label;
        protected T variableType;

        protected virtual string GetRustType()
        {
            return variableType.GetRustType();
        }

        public virtual string Render()
        {
            if (typeRender == NumericVariableTypeRender.NUMERIC_MUTABLE_VARIABLE_AS_VALUE)
            {
                return MutableAsValue();
            }
            if (typeRender == NumericVariableTypeRender.NUMERIC_MUTABLE_VARIABLE_AS_REFERENCE)
            {
                return MutableAsReference();
            }
            if (typeRender == NumericVariableTypeRender.NUMERIC_MUTABLE_VARIABLE_AS_MUTABLE_REFERENCE)
            {
                return MutableAsMutableReference();
            }
            if (typeRender == NumericVariableTypeRender.NUMERIC_INMUTABLE_VARIABLE_AS_MUTABLE_REFERENCE)
            {
                return InmutableAsMutableReference();
            }
            if (typeRender == NumericVariableTypeRender.NUMERIC_INMUTABLE_VARIABLE_AS_VALUE)
            {
                return InmutableAsValue();
            }
            if (typeRender == NumericVariableTypeRender.NUMERIC_INMUTABLE_VARIABLE_AS_REFERENCE)
            {
                return InmutableAsReference();
            }
            throw new RenderException($"The variable with name {label} with value {value}");
        }

        protected virtual string MutableAsValue()
        {
            return $"let mut {label}:{GetRustType()} = {value};";
        }

        protected virtual string MutableAsMutableReference()
        {
            return $"let mut {label}:&mut {GetRustType()} = &mut {value};";
        }
        protected virtual string MutableAsReference()
        {
            return $"let mut {label}:&{GetRustType()} = &{value};";
        }

        protected virtual string InmutableAsValue()
        {
            return $"let {label}:{GetRustType()} = {value};";
        }

        protected virtual string InmutableAsReference()
        {
            return $"let {label}:&{GetRustType()} = &{value};";
        }

        protected virtual string InmutableAsMutableReference()
        {
            return $"let {label}:&mut {GetRustType()} = &mut {value};";
        }
    }
}
