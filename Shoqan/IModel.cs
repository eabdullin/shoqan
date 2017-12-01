// Filename: IModel.cs
// Date Created: 14/11/2017
// Author: Yelaman Abdullin
// 
namespace Shoqan
{
    public interface IModel
    {
        /// <summary>
        /// Configures the model for training.
        /// </summary>
        /// <param name="optimizer"></param>
        /// <param name="lossFunction"></param>
        /// <param name="metrics"></param>
        /// <param name="lossWeights"></param>
        void Compile(IOptimizer optimizer, ILossFunction lossFunction, IMetric[] metrics = null,
            IWeights lossWeights = null);

        FitHistory Fit(
            ITensor x,
            ITensor y,
            int batchSize = 32,
            int epochs = 1,
            Verbosity verbose = Verbosity.Default,
            ICallback[] callbacks = null,
            float validationSplit = 0,
            ITensor[] validationData = null,
            bool shuffle = false);

        string GetSummary();
    }
}