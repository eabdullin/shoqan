namespace Shoqan.TensorFlow.Operations
{
	public static class MathOperations
	{
		public static Output MatMul(this Graph graph, Output a, Output b, string name, bool? transposeA = null, bool? transposeB = null)
		{
			return graph.OperationBuilder("MatMul", name)
				.AddInput(a)
				.AddInput(b)
				.If(transposeA.HasValue, builder => builder.SetAttr("transpose_a", transposeA.Value))
				.If(transposeB.HasValue, builder => builder.SetAttr("transpose_b", transposeB.Value))
				.Build()
				.GetOutput(0);
		}

		public static Output Add(this Graph graph, Output x, Output y, string name)
		{
			return graph.OperationBuilder("Add", name)
				.AddInput(x)
				.AddInput(y)
				.Build()
				.GetOutput(0);
		}
	}
}