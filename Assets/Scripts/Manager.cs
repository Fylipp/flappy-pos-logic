using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace FlappyPosLogic {
    public class Manager : MonoBehaviour {
        [SerializeField] private Transform _dynamics;
        [SerializeField] private Bird _birdPrefab;
        [SerializeField] private Gate _thingPrefab;

        [SerializeField] private Text _maxScoreText;
        [SerializeField] private Text _runningScoreText;
        [SerializeField] private Text _generationText;

        [SerializeField] private float _obstacleInterval = 5;

        [SerializeField] private int _generationSize = 10;
        [SerializeField] private float _mutationRate = .1f;
        [SerializeField] private float _mutationRange = .5f;

        public Bird[] Birds { get; private set; }

        private int _generation;
        private float _maxScore = float.MinValue;

        private void Awake() {
            NextGeneration();
        }

        private void Update() {
            if (Birds.Count(b => b.Alive) == 0) {
                _maxScore = Mathf.Max(_maxScore, Birds.Select(b => b.Score).Max());
                _maxScoreText.text = "Max. Score: " + _maxScore.ToString("n2");
                NextGeneration();
            } else {
                _runningScoreText.text = "Score: " + Birds.Select(b => b.Score).Max().ToString("n2");
            }
        }

        private void NextGeneration() {
            _generation++;

            _generationText.text = "Generation " + _generation;

            Network[] nets = null;

            if (_generation == 1) {
                nets = LinqHelper.CreateArray(_generationSize, i => Network.Generate(new[] {2, 2, 1}));
            } else {
                nets = EvolveGeneration();
            }

            ClearLevel();

            var first = GenerateLevel();

            Birds = nets.Select(n => CreateBirdFromNetwork(n, first)).ToArray();
        }

        private Gate GenerateLevel() {
            Gate first = null;
            Gate last = null;

            for (var i = 1000; i > 0; i--) {
                var x = i * _obstacleInterval;
                var y = Random.Range(-3, 3);

                var thing = Instantiate(_thingPrefab, _dynamics);
                thing.transform.position = new Vector2(x, y);
                thing.Next = last;

                last = thing;

                if (i == 1) {
                    first = thing;
                }
            }

            return first;
        }

        private void ClearLevel() {
            foreach (Transform dyn in _dynamics) {
                Destroy(dyn.gameObject);
            }
        }

        private Network[] EvolveGeneration() {
            var survivors = Birds
                .OrderBy(b => b.Score)
                .Reverse()
                .Take(_generationSize / 2)
                .Select(s => s.Network)
                .ToArray();
            var breed = new Func<Network, Network>(s => Breed(s, survivors.Where(o => o != s).Random()));
            return survivors.SelectMany(s => LinqHelper.CreateArray(2, i => breed(s))).ToArray();
        }

        private Network Breed(Network left, Network right) {
            var layers = new Layer[left.Layers.Length];

            for (var layerIndex = 0; layerIndex < layers.Length; layerIndex++) {
                var ownLayer = left.Layers[layerIndex].Neurons;
                var mateLayer = right.Layers[layerIndex].Neurons;

                var raw = LinqHelper.CreateArray(ownLayer.Length,
                    neuronIndex => Random.Range(0, 1) > .5f
                        ? ownLayer[neuronIndex].Weights
                        : mateLayer[neuronIndex].Weights);

                var neurons = raw
                    .Select(weights => weights
                        .Select(weight => {
                            if (Random.Range(0, 1) <= _mutationRate) {
                                return weight + Random.Range(-_mutationRange, _mutationRange);
                            } else {
                                return weight;
                            }
                        })
                        .ToArray())
                    .Select(weights => new Neuron(weights))
                    .ToArray();

                layers[layerIndex] = new Layer(neurons);
            }

            return new Network(layers);
        }

        private Bird CreateBirdFromNetwork(Network network, Gate next) {
            var bird = Instantiate(_birdPrefab, _dynamics);

            bird.transform.position = Vector2.zero;
            bird.NextGate = next;
            bird.Network = network;

            return bird;
        }
    }
}
