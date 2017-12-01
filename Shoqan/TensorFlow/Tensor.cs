// Filename: TFTensor.cs
// Date Created: 14/11/2017
// Author: Yelaman Abdullin
// 

using System;

namespace Shoqan.TensorFlow
{
	public class Tensor : IDisposable
	{
		public int Length { get; }

		public void Dispose()
		{
		}
	}
}