namespace Velocitech.Utils.RustCodeGenerationTool.Types.Numbers
{
    public class I128 : Number<string>
    {
        public I128(string value)
        {
            maxValue = "170141183460469231731687303715884105728";
            minValue = "170141183460469231731687303715884105727";
        }        
        

        public override string GetRustType()
        {
            return EnumNumberTypes.i128.ToString();
        }

  
    }



}
