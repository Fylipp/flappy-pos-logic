using System.Linq;

namespace FlappyPosLogic {
    public class Network {
        public readonly Layer[] Layers;

        public Network(Layer[] layers) {
            Layers = layers;
        }

        public static Network Generate(int[] layerSizes) {
            var layers = new Layer[layerSizes.Length];

            for (var i = 0; i < layers.Length; i++) {
                var size = layerSizes[i];
                
                if (i == 0) {
                    var neurons = new Neuron[size];

                    for (var j = 0; j < neurons.Length; j++) {
                        neurons[j] = new Neuron(new float[size].Select(x => 1f).ToArray());
                    }
                    
                    layers[i] = new Layer(neurons);
                } else {
                    layers[i] = Layer.Generate(size, layerSizes[i - 1]);
                }
            }
            
            return new Network(layers);
        }

        public float[] Calculate(float[] inputs) {
            return Layers.Aggregate(inputs, (values, layer) => layer.Calculate(values));
        }
    }
}
