// Filename: Dense.cs
// Date Created: 14/11/2017
// Author: Yelaman Abdullin
// 

using Shoqan.Abstract;
using Shoqan.TensorFlow;
using Shoqan.TensorFlow.Operations;

namespace Shoqan.Layers
{
    public class Dense : Layer
    {
	    private int Index { get; set; }
	    private int _units;
	    private Variable _weigths;
	    private Variable _biases;
	    public Dense(int units, IActivation activation = null, bool useBias = true)
	    {
		    
	    }


	    protected Output ComputeOp(Output input)
	    {
		    var graph = GraphProvider.Instance.DefaultGraph;
		    var resultOp = graph.MatMul(input, _weigths.Value, $"{Name}_MatMul");
		    resultOp = graph.Add(resultOp, _biases.Value, $"{Name}_Add");
		    return resultOp;
	    }

	    protected void Build(Shape inputShape)
	    {
		    var graph = GraphProvider.Instance.DefaultGraph;
		    using (var s = new NameScope(Name+"/"+ "Build"))
		    {
			    var random = graph.RandomNormal(inputShape, DType.Double, s.Name);
			    _weigths = new Variable(random);

		    }
		}
    }
}