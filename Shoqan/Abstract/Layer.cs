// Filename: Layer.cs
// Date Created: 14/11/2017
// Author: Yelaman Abdullin
// 

using Shoqan.TensorFlow;

namespace Shoqan.Abstract
{
	public abstract class Layer : ILayer
	{
		private Shape _batchInputShape;
		public string Name { get; protected set; }
		private bool _built;
//		protected abstract ITensor Compute(ITensor inputs);
//
//		protected abstract void Build(Shape inputShape);


	}
}