namespace Velocitech.Utils.RustCodeGenerationTool.Utils
{
    public static class CapitalizeString
    {
        public static string Capitalize(this string str )
        {
            str = str.ToLower();
            return char.ToUpper(str[0]) + str.Substring(1);
        }
    }
}
