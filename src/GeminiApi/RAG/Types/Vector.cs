using System.Numerics;
using System.Text.Json.Serialization;

namespace GeminiApi.RAG.Types
{
    public class Vector
    {
        public const int DEFAULT_VECTOR_SIZE = 256;
        [JsonPropertyName("values")]
        public float[] Values { get; set; } = new float[DEFAULT_VECTOR_SIZE];


        public static double getCosineSimilarity(Vector a, Vector b)
        {
            if (a.Values.Length != b.Values.Length)
            {
                throw new ArgumentException("Both vectors should have same number of dimentions.");
            }

            float a_b = multiplicateAndSum(a, b);

            double a_sqrt = Math.Sqrt((double)multiplicateAndSum(a));
            double b_sqrt = Math.Sqrt((double)multiplicateAndSum(b));

            return a_b/(a_sqrt*b_sqrt);
        }


        private static float multiplicateAndSum(Vector a, Vector b)
        {
            return multiplicateAndSum(a.Values, b.Values);
        }
        private static float multiplicateAndSum(float[] arr1, float[] arr2)
        {
            int vectorSize = Vector<float>.Count;
            var sumVect = Vector<float>.Zero;
            int i;
            
            for (i = 0; i < arr1.Length - vectorSize; i += vectorSize)
            {
                var v1 = new Vector<float>(arr1, i);
                var v2 = new Vector<float>(arr2, i);
                var tmp1 = System.Numerics.Vector.Multiply(v1, v2);
                sumVect = System.Numerics.Vector.Add(sumVect, tmp1);
            }
            float result = System.Numerics.Vector.Dot(sumVect, Vector<float>.One);
            for (; i < arr1.Length; i++)
            {
                result += arr1[i]*arr2[i];
            }
            return result;
        }
        private static float multiplicateAndSum(Vector a)
        {
            return multiplicateAndSum(a.Values);
        }
        private static float multiplicateAndSum(float[] arr1)
        {
            int vectorSize = Vector<float>.Count;
            var sumVect = Vector<float>.Zero;
            int i;
            
            for (i = 0; i < arr1.Length - vectorSize; i += vectorSize)
            {
                var v1 = new Vector<float>(arr1, i);
                var tmp1 = System.Numerics.Vector.Multiply(v1, v1);
                sumVect = System.Numerics.Vector.Add(sumVect, tmp1);
            }
            float result = System.Numerics.Vector.Dot(sumVect, Vector<float>.One);
            for (; i < arr1.Length; i++)
            {
                result += arr1[i]*arr1[i];
            }
            return result;
        }
    }
}