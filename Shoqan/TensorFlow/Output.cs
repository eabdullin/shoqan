// Filename: OperationOutput.cs
// Date Created: 14/11/2017
// Author: Yelaman Abdullin
// 

using System;
using System.Runtime.InteropServices;

namespace Shoqan.TensorFlow
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Output
	{
		
	    private IntPtr _operationHandle;
	    private int _index;

		public Output(IntPtr operationHandle, int index)
		{
			_operationHandle = operationHandle;
			_index = index;
		}

		// extern TF_DataType TF_OperationOutputType (TF_Output oper_out);
		[DllImport(TensorFlowApi.LibraryName)]
		static extern DType TF_OperationOutputType(Output oper_out);

		public DType DType
		{
			get { return TF_OperationOutputType(this); }
		}

	}
}