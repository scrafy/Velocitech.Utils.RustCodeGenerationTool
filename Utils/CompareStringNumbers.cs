namespace Velocitech.Utils.RustCodeGenerationTool.Utils
{
    public static class CompareStringNumbers
    {
        public static int CompareNumbers(string x, string y)
        {
            if (x.Length > y.Length) y = y.PadLeft(x.Length, '0');
            else if (y.Length > x.Length) x = x.PadLeft(y.Length, '0');

            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] < y[i]) return -1;
                if (x[i] > y[i]) return 1;
            }
            return 0;
        }
    }
}
