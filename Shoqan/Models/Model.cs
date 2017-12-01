// Filename: Model.cs
// Date Created: 14/11/2017
// Author: Yelaman Abdullin
// 

using System.Linq;
using Shoqan.Abstract;
using System.Collections.Generic;
using Shoqan.TensorFlow;

namespace Shoqan.Models
{
	public class Model : IModel
	{
		protected List<ILayer> InputLayers;
		protected List<ILayer> Layers;
		private object[] _outputs;

		private Output _logits;

		private IOptimizer _optimizer;
		private ILossFunction[] _lossFunctions;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="optimizer">optimizer instance <see cref="IOptimizer"/></param>
		/// <param name="lossFunction">objective function</param>
		/// <param name="metrics"></param>
		/// <param name="lossWeights"></param>
		public void Compile(IOptimizer optimizer, ILossFunction lossFunction, IMetric[] metrics = null, IWeights lossWeights = null)
		{
			_optimizer = optimizer;
			_lossFunctions = new ILossFunction[_outputs.Length];
			for (int i = 0; i < _lossFunctions.Length; i++)
				_lossFunctions[i] = lossFunction;

			throw new System.NotImplementedException();
		}

		protected void CompileInteral()
		{
			
		}
		public FitHistory Fit(ITensor x, ITensor y, int batchSize = 32, int epochs = 1, Verbosity verbose = Verbosity.Default,
			ICallback[] callbacks = null, float validationSplit = 0, ITensor[] validationData = null, bool shuffle = false)
		{
			throw new System.NotImplementedException();
		}

		public string GetSummary()
		{
			throw new System.NotImplementedException();
		}
	}
}