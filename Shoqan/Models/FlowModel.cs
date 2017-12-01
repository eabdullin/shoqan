using System.Collections.Generic;
using Shoqan.Layers;
using Shoqan.TensorFlow;

namespace Shoqan.Models
{
	public class FlowModel : Model
	{
		private FlowModel()
		{
			
		}
		public static FlowModel Create()
		{
			return new FlowModel();
		}

		public FlowModel Input(Shape shape)
		{
			Layers.Add(new Input(shape));
			return this;
		}
		public FlowModel Dense(int units, IActivation activation = null, bool useBias = true)
		{
			Layers.Add(new Dense(units,activation,useBias));
			return this;
		}

		public FlowModel Dropout(double rate)
		{
			Layers.Add(new Dropout(rate));
			return this;
		}
	}
}