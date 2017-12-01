// Filename: Tensorflow.cs
// Date Created: 14/11/2017
// Author: Yelaman Abdullin
// 

namespace Shoqan.TensorFlow
{
	public static class Tensorflow
	{

		public static Output Variable(this Graph graph, DType dType, Shape shape)
		{
			return graph.OperationBuilder("Variable", "Variable")
				.SetAttr("dtype", dType)
				.SetAttr("shape", shape)
				.Build()
				.GetOutput(0);
		}


	}
}