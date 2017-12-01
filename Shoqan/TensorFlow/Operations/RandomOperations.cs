namespace Shoqan.TensorFlow.Operations
{
	public static class RandomOperations
	{
		public static Output RandomNormal(this Graph graph, Shape shape, DType dType, string name)
		{
			return graph.OperationBuilder("RandomNormal", name)
				.SetAttr("shape", shape)
				.SetAttr("dtype", dType)
				.Build()
				.GetOutput(0);
		}
	}
}