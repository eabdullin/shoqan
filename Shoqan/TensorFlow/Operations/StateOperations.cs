namespace Shoqan.TensorFlow.Operations
{
	public static class StateOperations
	{
		public static Output Assign(this Graph graph, Output refr, Output val, string name, bool? valShape = null, bool? useLocking = null)
		{
			return graph.OperationBuilder("Assign", name)
				.AddInput(refr)
				.AddInput(val)
				.If(valShape != null, builder => builder.SetAttr("validate_shape", valShape.Value))
				.If(useLocking != null, builder => builder.SetAttr("use_locking",useLocking.Value))
				.Build()
				.GetOutput(0);
		}

		public static Output VariableV2(this Graph graph, Shape shape, DType dType, string name, string container= null, string sharedName = null)
		{
			return graph.OperationBuilder("VariableV2", name)
				.SetAttr("dtype", dType)
				.SetAttr("shape", shape)
				.Build()
				.GetOutput(0);
		}
	}
}