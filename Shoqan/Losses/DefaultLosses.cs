// Filename: DefaultLosses.cs
// Date Created: 14/11/2017
// Author: Yelaman Abdullin
// 
namespace Shoqan.Losses
{
    public static class DefaultLosses
    {
        public static ILossFunction MSE
        {
            get { return new MeanSquaredErrorLoss();}
        } 
    }
}