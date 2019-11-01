using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using ConsoleTableExt;
using MathNet.Numerics.LinearAlgebra;
using System.Reflection;

class NeuralNetwork
{
    List<Layer> layers;
    public NeuralNetwork(int[] dims)
    {
        layers = new List<Layer>();
        for(int i = 0;i < dims.Length-1 ;i++)
            layers.Add(new Layer(new int[] { dims[i], dims[i + 1] }));
        layers.Add(new Layer(new int[] { dims[dims.Length-1],0}));///last layer has no synaptic connections,only neurons
        layers[0].bias = null;///first layer has no biases
    }
    public Vector<double> feedNet(Vector<double> input)
    {
        if(input.Count!=layers[0].neurons.Count)return null;///input must be same size as the input layer
        layers[0].neurons = input; ///initiate first layer with the input;
        Layer layer, nextLayer = null;
        for(int i=0;i<layers.Count-1;i++)
        {
            layer = layers[i];nextLayer = layers[i + 1];
            nextLayer.neurons = layer.neurons * layer.synapse;
            nextLayer.neurons = (nextLayer.neurons+nextLayer.bias).PointwiseTanh(); ///activation function
        }
        return nextLayer.neurons;   
    }

    public void initialize(int seed=69)
    {
        Random random = new Random(seed);
        Layer l = null;
        for(int g=0;g<layers.Count-1;g++)   ///not in cluding the last layer,which is a dummy layer
        {
            l = layers[g];
            for(int i=0;i<l.synapse.RowCount;i++)
            {
                if(g!=0)    ///first layer has no biases
                    l.bias[i] = random.NextDouble();
                if(l.synapse.ColumnCount>0) ///if its a last layer,there are no synaptic connections
                {
                    for(int j = 0;j < l.synapse.ColumnCount;j++)
                    {
                        l.synapse[i, j] = random.NextDouble();
                    }
                }
            }
        }
    }
    class Layer
    {
        public Matrix<double> synapse; ///connections synapses to the next layer   |   1st index represents the weights of all 
        ///connections of a specific neuron,and the 2nd index is the weight of the connections of this layer to each neurons in the next layer
        ///example : synape[0,1] is the weight of the connection between the 0 neuron of this layer to the 1 neuron of the next
        ///dims = synape[this.length,next.length]
        ///each row in a neuron
        public Vector<double> neurons;
        public Vector<double> bias;
        public MethodInfo activation;

        public Layer(int[] dims)
        {
            if(dims[1] == 0)
            {
                synapse = null;///if this is a last layer in a network
            }
            else
            {
                synapse = Matrix<double>.Build.Dense(dims[0], dims[1]);
                bias = Vector<double>.Build.Dense(dims[0]);
            }
            activation = null;
            neurons = Vector<double>.Build.Dense(dims[0]);
        }
    }
}