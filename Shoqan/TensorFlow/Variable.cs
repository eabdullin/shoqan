// Filename: Variable.cs
// Date Created: 14/11/2017
// Author: Yelaman Abdullin
// 

using Shoqan.TensorFlow.Operations;

namespace Shoqan.TensorFlow
{
	public class Variable
	{
		private readonly string _name;
		private Output _assignOp;
		private bool _trainable;
		private Output _variable;
		public Output Value => _variable;
		private Output _snapshot;
		private Output _initializerOp;
		public Variable(Shape shape, DType dType, bool trainable = true, string name = null)
		{
			var graph = GraphProvider.Instance.DefaultGraph;
			_trainable = trainable;
			if (name == null)
				_name = graph.UniqueName("Variable");
			using (var scope = new NameScope(_name))
			{
				_variable = graph.VariableV2(shape, dType, scope.Name);
			}
		}

		public Variable(Output initialValue, bool trainable = true, string name = null)
		{
			var graph = GraphProvider.Instance.DefaultGraph;
			_trainable = trainable;
			if (name == null)
				_name = graph.UniqueName("Variable");
			using (var scope = new NameScope(_name))
			{
				_variable = graph.VariableV2(Shape.FromOp(graph, initialValue), initialValue.DType, scope.Name);
				using (var assignScope = new NameScope("Assign"))
				{
					_initializerOp = graph.Assign(_variable, initialValue, assignScope.Name);
				}
//				using (var readScope = new NameScope("Read"))
//				{
//					_value = graph.OperationBuilder("AssignVariableOp", readScope.Name)
//						.AddInput(varhandle)
//						.SetAttr("dtype", initialValue.DType)
//						.Build()
//						.GetOutput(0);
//				}
			}
		}
	}
}