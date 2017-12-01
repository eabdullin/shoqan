// Filename: Operation.cs
// Date Created: 14/11/2017
// Author: Yelaman Abdullin
// 

using System;

namespace Shoqan.TensorFlow
{
	public class Operation
	{

	    private Graph _graph;
	    private IntPtr _nativeHandle;

		public Operation(Graph graph, IntPtr nativeHandle)
		{
			_graph = graph;
			_nativeHandle = nativeHandle;
		}

		public Output GetOutput(int index)
		{
			return new Output(_nativeHandle,index);
		}
	}
}