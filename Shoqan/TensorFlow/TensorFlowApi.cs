// Filename: TensorFlowApi.cs
// Date Created: 14/11/2017
// Author: Yelaman Abdullin
// 

using System;
using System.Runtime.InteropServices;

namespace Shoqan.TensorFlow
{
	public class TensorFlowApi
	{
		public const string LibraryName = "tensorflowlib";


		/// <summary>
		/// Represents a computation graph.  Graphs may be shared between sessions.
		/// Graphs are thread-safe when used as directed below.
		/// </summary>
		/// <returns></returns>
		[DllImport(LibraryName)]
		static extern unsafe IntPtr TF_NewGraph();

		/// <summary>
		/// Destroy an options object.  Graph will be deleted once no more
		/// TFSession's are referencing it.
		/// </summary>
		/// <param name="graph"></param>
		/// <returns></returns>
		[DllImport(LibraryName)]
		static extern unsafe IntPtr TF_DeleteGraph(IntPtr graph);


		/// <summary>
		/// Operation will only be added to *graph when TF_FinishOperation() is called (assuming TF_FinishOperation() does not return an error).
		/// *graph must not be deleted until after TF_FinishOperation() is called.
		/// 
		/// extern TF_OperationDescription* TF_NewOperation(TF_Graph* graph, const char* op_type, const char* oper_name);
		/// </summary>
		/// <param name="graph"></param>
		/// <param name="opType"></param>
		/// <param name="oper_name"></param>
		/// <returns></returns>
		[DllImport(LibraryName)]
		static extern unsafe IntPtr TF_NewOperation(IntPtr graph, string opType, string oper_name);


	    [DllImport(LibraryName)]
	    static extern unsafe void TF_SetAttrType(IntPtr desc, string attr_name, DType value);

    }
}