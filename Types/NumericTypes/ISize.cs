using System;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;

namespace Velocitech.Utils.RustCodeGenerationTool.Types.NumericTypes
{

    public class ISize
    {
        private EnumNumberTypes _label;
        private long _value;

        public EnumNumberTypes Label { get => _label; set => _label = value; }
        public long Value
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
                    catch (Exception ex)
                    {
                        throw new NumberOverflowException($"The OS architechture is 32 bits. The more higher integer the OS can manages is {int.MaxValue} and the more lower integer that the SO can manage is {int.MinValue}");
                    }

                }
            }
        }

    }
}
