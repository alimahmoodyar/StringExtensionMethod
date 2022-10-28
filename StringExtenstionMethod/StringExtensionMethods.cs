using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace StringExtensionMethods;

public static class StringExtensionMethods
{
    public static bool IsNumeric(this string Str) => Str.All(char.IsNumber);
    public static bool CheckLength(this string Str, uint length) => Str.Length == length;
    public static bool IsNumeric(this string Str, uint fixedLength) => Str.All(char.IsNumber) && Str.CheckLength(fixedLength);
    public static bool CheckBool(this string Str) => (Str.ToLower() == "y" || Str.ToLower() == "1" || Str.ToLower() == "true");

    public static string PassXSSChars(this string Str)
    {
        string[,] chars = {
            { "&", "&amp;" },
            { "<", "&lt;" },
            { ">", "&gt;" },
            { "\"", "&quot;" },
            { "'", "&#039;" },
        };
        for (int i = 0; i < chars.Length / 2; i++)
            Str = Str.Replace(chars[i, 0], chars[i, 1]);

        return Str;
    }

}