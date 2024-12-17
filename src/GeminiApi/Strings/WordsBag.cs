using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeminiApi;

public class WordsBag
{
    public Guid Id { get; set; } = Guid.NewGuid(); // Уникальный идентификатор
    public string[] Words { get; set; } = Array.Empty<string>(); // Массив слов
    public int[] Frequencies { get; set; } = Array.Empty<int>(); // Массив частот
    public WordsBag()
    {
        
    }
    public WordsBag(string str)
    {
        var words = str.splitToWords();
        var bag = new Dictionary<string, int>();

        foreach (var w in words)
        {
            if (bag.ContainsKey(w))
            {
                bag[w]++;
            }
            else
            {
                bag[w] = 1;
            }
        }

        Words = bag.Keys.ToArray();
        Frequencies = bag.Values.ToArray();
    }
    //TODO: rewrite this shit
    public int GetWord(string word){
        var w = word.splitToWords().FirstOrDefault();
        for(int i = 0; i<Words.Length; i++){
            if(Words[i] == w)
                return Frequencies[i];
        }
        return 0;
    }
}


/*
public class WordsBag : IEnumerable
{
    public Guid BagId{get;set;} = Guid.NewGuid();
    public Dictionary<string, int> Bag = new Dictionary<string, int>();
    private int len = 0;
    [NotMapped]
    public int Length{
        get{
            return len;
        }
    }
    public WordsBag(string str)
    {
        HashSet<string> strings = new HashSet<string>();
        var words = str.splitToWords();

        foreach(var w in words){
            bool isExsist = Bag.TryGetValue(w, out int val);
            if(isExsist){
                Bag[w]++;
            }
            else{
                Bag.Add(w, 1);
                len++;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return Bag.Reverse().Select(a=>(a.Key, a.Value)).GetEnumerator();
    }

    public int GetWord(string word){
        int res = 0;
        Bag.TryGetValue(word, out res);
        return res;
    }
}

public class Words{
    public string Word{get;set;} = string.Empty;
    public int Frequency{get;set;} = 0;
}*/