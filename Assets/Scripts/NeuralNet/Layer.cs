using System.Linq;

namespace FlappyPosLogic {
    public class Layer {
        public readonly Neuron[] Neurons;

        public Layer(Neuron[] neurons) {
            Neurons = neurons;
        }
               
        public static Layer Generate(int neuronCount, int previousLayerSize) {
            var neurons = new Neuron[neuronCount];

            for (var i = 0; i < neurons.Length; i++) {
                neurons[i] = Neuron.Generate(previousLayerSize);
            }
            
            return new Layer(neurons);
        }

        public float[] Calculate(float[] previousLayer) {
            return Neurons.Select(n => n.Calculate(previousLayer)).ToArray();
        }
    }
}
