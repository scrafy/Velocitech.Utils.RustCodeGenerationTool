using System;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.NumericTypes
{

    public class ISize : Type<long>
    {

        private long _value;
        
        public override long Value
        {

            get
            {
                return _value;
            }
            set
            {
                if (Environment.Is64BitOperatingSystem)
                {
                    _value = value;
                }
                else
                {
                    try
                    {
                        _value = (int)value;
                    }
                    catch (Exception)
                    {
                        throw new NumberOverflowException($"The OS architechture is 32 bits. The more higher integer the OS can manages is {int.MaxValue} and the more lower integer that the SO can manage is {int.MinValue}");
                    }

                }
            }
        }

        public override string GetRustType()
        {
            throw new NotImplementedException();
        }
    }
}
