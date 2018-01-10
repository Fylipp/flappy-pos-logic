using System.Linq;
using UnityEngine;

namespace FlappyPosLogic {
    public class Neuron {
        public readonly float[] Weights;

        public Neuron(float[] weights) {
            Weights = weights;
        }

        public static Neuron Generate(int weightCount) {
            var weights = new float[weightCount];

            for (var i = 0; i < weights.Length; i++) {
                weights[i] = UnityEngine.Random.Range(-1, 1);
            }

            return new Neuron(weights);
        }

        public float Calculate(float[] previousLayer) {
            return Activate(Sum(previousLayer));
        }

        private float Sum(float[] previousLayer) {
            var weighted = new float[previousLayer.Length];

            for (var i = 0; i < weighted.Length; i++) {
                weighted[i] = previousLayer[i] * Weights[i];
            }

            return weighted.Aggregate((l, r) => l + r);
        }

        private float Activate(float sum) {
            return 1 / (1 + Mathf.Exp(-sum));
        }
    }
}
