using System;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.NumericTypes
{

    public class USize : Type<ulong>
    {
        private ulong _value;
        
        public override ulong Value
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
                        _value = (uint)value;
                    }
                    catch (Exception)
                    {
                        throw new NumberOverflowException($"The OS architechture is 32 bits. The more higher integer the OS can manages is {uint.MaxValue}");
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
