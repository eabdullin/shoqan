using System.Collections.Generic;
using Shoqan.TensorFlow;

namespace Shoqan.Optimizers
{
	public enum Gate
	{
		None = 0,
		Op = 1,
		Graph = 2
	}
	public class Optimizer
	{
		//Values for gate_gradients.
		public const int GATE_NONE = 0;

		public const int GATE_OP = 1;
		public const int GATE_GRAPH = 2;

		private bool _useLocking;
		public string Name { get; set; }
		public void Minimize(Tensor loss, Variable globalStep = null, Gate gateGradients = Gate.Op, List<Variable> varList = null)
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="loss">A Tensor containing the value to minimize.</param>
		/// <param name="gateGradients">How to gate the computation of gradients.  Can be `GATE_NONE`, `GATE_OP`, or `GATE_GRAPH`.</param>
		/// <param name="varList"></param>
		public void ComputeGradients(Tensor loss, Gate gateGradients = Gate.Op, List<Variable> varList = null)
		{
			
		}
	}
}