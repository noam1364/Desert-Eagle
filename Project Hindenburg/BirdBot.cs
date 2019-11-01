


public class BirdBot : Bird
{
    NeuralNetwork brain;
	public BirdBot():base()
    {
        brain = new NeuralNetwork(new int[] { 2, 6, 6, 1 });
        brain.initialize();
    }
}
