// Filename: Shape.cs
// Date Created: 14/11/2017
// Author: Yelaman Abdullin
// 

using System;
using System.Runtime.InteropServices;

namespace Shoqan.TensorFlow
{
	public class Shape
	{
	    public static Shape Unknown => new Shape(null);
	    public static Shape Scalar => new Shape(new long[0]);
	    private long[] _shape;
        public long Size(int i)
	    {
	        return _shape[i];
	    }
	    public Shape(params long[] shape)
	    {
	        this._shape = shape;
	    }

	    public override string ToString()
	    {
	        if (_shape == null)
	        {
	            return "<unknown>";
	        }
	        return $"({string.Join(",", _shape)})";
	    }

		public long[] AsArray()
		{
			return _shape;
		}
		public int NumDimensions => _shape?.Length ?? -1;

		[DllImport(TensorFlowApi.LibraryName)]
		static extern unsafe int TF_GraphGetTensorNumDims(IntPtr graph, Output output, IntPtr status);
		[DllImport(TensorFlowApi.LibraryName)]
		static extern unsafe void TF_GraphGetTensorShape(IntPtr graph, Output output, long[] dims, int num_dims, IntPtr status);
		public static Shape FromOp(Graph g, Output op, Status status = null)
		{
			if (status == null)
			{
				status = new Status();
			}
			var ndims = TF_GraphGetTensorNumDims(g.Handle, op, status.Handle);
			if (status.Code != StatusCode.Ok)
			{
				return null;
			}
			if (ndims == 0)
				return new Shape(null);
			var ret = new long[ndims];
			TF_GraphGetTensorShape(g.Handle, op, ret, ndims, status.Handle);
			if (status.Code != StatusCode.Ok)
			{
				throw new StatusException(status);
			}
			return new Shape(ret);
		}
	}
}