using System;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.NumericTypes
{

    public class USize
    {
        private EnumNumberTypes _label;
        private ulong _value;

        public EnumNumberTypes Label { get => _label; set => _label = value; }
        public ulong Value
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
                    catch (Exception ex)
                    {
                        throw new NumberOverflowException($"The OS architechture is 32 bits. The more higher integer the OS can manages is {uint.MaxValue}");
                    }

                }
            }
        }

    }
}
