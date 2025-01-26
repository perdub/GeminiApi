// Dataset.cs
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace GeminiApi.Types
{
    public class Dataset
    {
        [JsonPropertyName("examples")]
        public TuningExamples? Examples { get; set; } = null;


        public static Dataset BuildDataset(string[] inputs, string[] outputs)
        {
            if(inputs.Length != outputs.Length){
                Debug.Print("not equals by size arrays.");
            }

            int size = Math.Max(inputs.Length, outputs.Length);

            Dataset dataset = new Dataset();
            dataset.Examples = new TuningExamples();
            TuningExample[] examples = new TuningExample[size];

            for(int i = 0; i<size; i++)
            {
                TuningExample tuningExample = new TuningExample();

                if(inputs.Length > i-1){
                    tuningExample.TextInput = inputs[i];
                }
                else{
                    tuningExample.TextInput = "Text Input.";
                }

                if(outputs.Length > i-1){
                    tuningExample.Output = outputs[i];
                }
                else{
                    tuningExample.Output = "Text output.";
                }

                examples[i] = tuningExample;
            }

            dataset.Examples.Examples = examples;

            return dataset;

        }
    }
}