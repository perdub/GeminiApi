namespace GeminiApi.RAG.Types{
    public class Chunk{
        public Guid ChunkId{get;set;} = Guid.NewGuid();

        public Guid DocumentId {get;set;} = Guid.Empty;

        public Vector? Embedding{get;set;} = null;

        public string? Text{get;set;} = string.Empty;

        //в символах
        public int ChunkSize{get;set;} = 0;

        public int ChunkStartPosition{get;set;} = 0;

        public WordsBag? WordsBag{get;set;} = null;

        /// <summary>
        /// not ready
        /// </summary>
        /// <param name="text"></param>
        [Obsolete]
        public void SetText(string text){
            WordsBag = new WordsBag(text);
        }

        public float TF(string word)
        {
            var w = word.splitToWords().FirstOrDefault();
            var txt = Text.splitToWords();
            int count = WordsBag.GetWord(w);
            return (1.0f * count) / txt.Length;
        }

        internal bool contain(string word){
            return Text.Contains(word);
        }

        public static float IDF(string word, Chunk[] chunks){
            int chunksWithWord = 0;
            foreach(var w in chunks){
                if(w.contain(word)){
                    chunksWithWord++;
                }
            }

            return (float)Math.Log((1.0d * chunks.Length / chunksWithWord));
        }

        public static float TF_IDF(string word, Chunk document, Chunk[] chunks){
            return document.TF(word) * IDF(word, chunks);
        }
    }
}