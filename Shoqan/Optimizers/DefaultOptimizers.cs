// Filename: DefaultOptimizers.cs
// Date Created: 14/11/2017
// Author: Yelaman Abdullin
// 
namespace Shoqan.Optimizers
{
    public static class DefaultOptimizers
    {
        public static IOptimizer SGD
        {
            get { return new SGD(); }
        }
    }
}