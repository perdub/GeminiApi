using System.Text;

namespace GeminiApi;

public static class StringHelper
{
    private static readonly string[] separators = new string[] 
            { " ", "\t", ",", ".", "?", "!", ":", "/", "-", "(", ")", "<", ">", "+", "'", Environment.NewLine };

    private static readonly char[] charSeparators = new char[] 
            { ' ', '\t', ',', '.', '?', '!', ':', '/', '-', '(', ')', '<', '>', '+', '\'', '\n', '\r' };

    public static string[] splitToWords(this string str){
        return str
            .ToLowerInvariant()
            .Split(separators, StringSplitOptions.RemoveEmptyEntries)
            ;
    }
    public static string Normalize(this string str){
        StringBuilder bld = new StringBuilder(str.Length);
        for(int i = 0; i<str.Length; i++){
            if(!charSeparators.Contains(str[i])){
                bld.Append(str[i]);
            }
        }
        return bld.ToString();
    }
}
