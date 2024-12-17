namespace GeminiApi;

public static class StringHelper
{
    private static readonly string[] separators = new string[] 
            { " ", "\t", ",", ".", "?", "!", ":", "/", "-", "(", ")", "<", ">", "+", "'", Environment.NewLine };

    public static string[] splitToWords(this string str){
        return str
            .ToLowerInvariant()
            .Split(separators, StringSplitOptions.RemoveEmptyEntries)
            ;
    }
}
