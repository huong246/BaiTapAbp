namespace BaiTapAbp.Utils;
using System.Globalization;
using System.Text;
public static class StringUtil
{
    public static string ConvertFts(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return str;
        }

        str = str.ToLower();
        str = str.Replace("đ", "d");
        var normalizedString = str.Normalize(NormalizationForm.FormD);
        var result = new StringBuilder();

        foreach (char c in normalizedString)
        {
            var category = CharUnicodeInfo.GetUnicodeCategory(c);
            if (category != UnicodeCategory.NonSpacingMark)
            {
                result.Append(c);
            }
        }

        return result.ToString().Normalize(NormalizationForm.FormC);
    }
}