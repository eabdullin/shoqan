using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoqan.Layers;
using Shoqan.Losses;
using Shoqan.Models;
using Shoqan.Optimizers;
using Shoqan.TensorFlow;

namespace Shoqan.Test.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            int numClasses = 10;
            var model = FlowModel.Create()
				.Input(new Shape())
				.Dense(512)
				.Dropout(0.2)
				.Dense(256)
				.Dropout(0.2)
				.Dense(numClasses);

            

            model.Compile(lossFunction: DefaultLosses.MSE, optimizer: DefaultOptimizers.SGD);
	        System.Console.Write(model.GetSummary());
			ITensor x = null;
            ITensor y = null;
            var history = model.Fit(x, y);
        }
    }
}
