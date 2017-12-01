// Filename: OperationDescription.cs
// Date Created: 15/11/2017
// Author: Yelaman Abdullin
// 

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Shoqan.TensorFlow
{
    public class OperationBuilder
    {
        private readonly string _operationType;
        private readonly string _operationName;

        private Graph _graph;
        private IntPtr _nativehandle;
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
        [DllImport(TensorFlowApi.LibraryName)]
        static extern IntPtr TF_NewOperation(IntPtr graph, string opType, string oper_name);

        public OperationBuilder(Graph graph, string operationType, string operationName)
        {
            _graph = graph;
            _operationType = operationType;
            _operationName = operationName;
            using (var gl = _graph.Lock())
            {
                _nativehandle = TF_NewOperation(gl.NativeHandle(), _operationType, _operationName);
            }
            
        }
	    [DllImport(TensorFlowApi.LibraryName)]
		static extern unsafe IntPtr TF_FinishOperation(IntPtr desc, IntPtr status);
		public Operation Build()
		{
			using (_graph.Lock())
			{
				var op = new Operation(_graph, TF_FinishOperation(_nativehandle, IntPtr.Zero));
				_nativehandle = IntPtr.Zero;
				return op;
			}
		}
        // extern void TF_AddInput (TF_OperationDescription *desc, TF_Output input);
        [DllImport(TensorFlowApi.LibraryName)]
        static extern void TF_AddInput(IntPtr desc, Output input);

        //extern void TF_AddInputList(TF_OperationDescription* desc, const TF_Output* inputs, int num_inputs);
        [DllImport(TensorFlowApi.LibraryName)]
        static extern void TF_AddInputList(IntPtr desc, Output[] inputs, int num_inputs);

        public OperationBuilder AddInput(Output input)
        {
	        using (_graph.Lock())
	        {
		        TF_AddInput(_nativehandle, input);
		        return this;
	        }
        }

		[DllImport(TensorFlowApi.LibraryName)]
		static extern unsafe void TF_SetAttrString(IntPtr desc, string attr_name, IntPtr value, UIntPtr length);
	    public OperationBuilder SetAttr(string name, string value)
	    {
		    if (name == null)
			    throw new ArgumentNullException(nameof(name));
			using (_graph.Lock())
		    {
			    var bytes = Encoding.UTF8.GetBytes(value);
			    var buf = Marshal.AllocHGlobal(bytes.Length + 1);
			    Marshal.Copy(bytes, 0, buf, bytes.Length);
			    TF_SetAttrString(_nativehandle, name, buf, (UIntPtr)bytes.Length);
		    }
		    return this;
	    }

		[DllImport(TensorFlowApi.LibraryName)]
		static extern unsafe void TF_SetAttrStringList(IntPtr desc, string attr_name, IntPtr[] values, UIntPtr[] lengths, int num_values);

	    [DllImport(TensorFlowApi.LibraryName)]
		static extern unsafe void TF_SetAttrInt(IntPtr desc, string attr_name, long value);
	    public OperationBuilder SetAttr(string name, long value)
	    {
		    if (name == null)
			    throw new ArgumentNullException(nameof(name));
		    using (_graph.Lock())
		    {
			    TF_SetAttrInt(_nativehandle, name, value);
		    }
		    return this;
	    }
		[DllImport(TensorFlowApi.LibraryName)]
		static extern unsafe void TF_SetAttrIntList(IntPtr desc, string attr_name, long[] values, int num_values);
	    public OperationBuilder SetAttr(string name, long[] values)
	    {
		    if (name == null)
			    throw new ArgumentNullException(nameof(name));
		    using (_graph.Lock())
		    {
			    TF_SetAttrIntList(_nativehandle, name, values,values.Length);
		    }
		    return this;
	    }

		[DllImport(TensorFlowApi.LibraryName)]
		static extern unsafe void TF_SetAttrFloat(IntPtr desc, string attr_name, float value);
	    public OperationBuilder SetAttr(string name, float value)
	    {
		    if (name == null)
			    throw new ArgumentNullException(nameof(name));
			using (_graph.Lock())
		    {
			    TF_SetAttrFloat(_nativehandle, name, value);
		    }
		    return this;
	    }
		[DllImport(TensorFlowApi.LibraryName)]
		static extern unsafe void TF_SetAttrFloatList(IntPtr desc, string attr_name, float[] values, int num_values);
	    public OperationBuilder SetAttr(string name, float[] values)
	    {
		    if (name == null)
			    throw new ArgumentNullException(nameof(name));
			using (_graph.Lock())
		    {
			    TF_SetAttrFloatList(_nativehandle, name, values,values.Length);
		    }
		    return this;
	    }

		[DllImport(TensorFlowApi.LibraryName)]
		static extern unsafe void TF_SetAttrBool(IntPtr desc, string attr_name, byte value);
	    public OperationBuilder SetAttr(string name, bool value)
	    {
		    if (name == null)
			    throw new ArgumentNullException(nameof(name));
			using (_graph.Lock())
		    {
			    TF_SetAttrBool(_nativehandle, name, (byte) (value ? 1 : 0));
		    }
		    return this;
	    }

		[DllImport(TensorFlowApi.LibraryName)]
		static extern unsafe void TF_SetAttrBoolList(IntPtr desc, string attr_name, bool[] values, int num_values);
	    public OperationBuilder SetAttr(string name, bool[] values)
	    {
		    if (name == null)
			    throw new ArgumentNullException(nameof(name));
		    if (name == null)
			    throw new ArgumentNullException(nameof(values));
			using (_graph.Lock())
		    {
			    TF_SetAttrBoolList(_nativehandle, name, values, values.Length);
		    }
		    return this;
	    }

		[DllImport(TensorFlowApi.LibraryName)]
		static extern unsafe void TF_SetAttrType(IntPtr desc, string attr_name, DType value);
		[DllImport(TensorFlowApi.LibraryName)]
		static extern unsafe void TF_SetAttrTypeList(IntPtr desc, string attr_name, DType[] values, int num_values);
	    public OperationBuilder SetAttr(string name, params DType[] dataType)
	    {
		    if (name == null)
			    throw new ArgumentNullException(nameof(name));
		    if (dataType == null || dataType.Length == 0)
			    throw new ArgumentNullException(nameof(dataType));
		    using (_graph.Lock())
		    {
			    if (dataType.Length == 1)
			    {
				    TF_SetAttrType(_nativehandle, name, dataType[0]);
			    }
			    else
			    {
				    TF_SetAttrTypeList(_nativehandle, name, dataType, dataType.Length);

			    }
				
		    }

		    return this;
	    }

		[DllImport(TensorFlowApi.LibraryName)]
		static extern unsafe void TF_SetAttrShape(IntPtr desc, string attr_name, long[] dims, int num_dims);
		//[DllImport(TensorFlowApi.LibraryName)]
		//static extern unsafe void TF_SetAttrShape(IntPtr desc, string attr_name, IntPtr dims, int num_dims);
	    public OperationBuilder SetAttr(string name, Shape shape)
	    {
		    if (name == null)
			    throw new ArgumentNullException(nameof(name));
			using (_graph.Lock())
		    {
			    TF_SetAttrShape(_nativehandle, name, shape.AsArray(), shape.NumDimensions);

			}
		    return this;
	    }

		[DllImport(TensorFlowApi.LibraryName)]
		static extern unsafe void TF_SetAttrShapeList(IntPtr desc, string attr_name, IntPtr dims, int[] num_dims, int num_shapes);
//
//	    [DllImport(TensorFlowApi.LibraryName)]
//		static extern unsafe void TF_SetAttrTensorShapeProto(IntPtr desc, string attr_name, IntPtr proto, size_t proto_len, TF_Status status);
//
//	    [DllImport(TensorFlowApi.LibraryName)]
//		static extern unsafe void TF_SetAttrTensorShapeProtoList(IntPtr desc, string attr_name, void** protos, size_t* proto_lens, int num_shapes, TF_Status status);
//
//	    [DllImport(TensorFlowApi.LibraryName)]
//		static extern unsafe void TF_SetAttrTensor(IntPtr desc, string attr_name, TF_Tensor value, TF_Status status);
//
//	    [DllImport(TensorFlowApi.LibraryName)]
//		static extern unsafe void TF_SetAttrTensorList(IntPtr desc, string attr_name, IntPtr[] values, int num_values, TF_Status status);
//
//	    [DllImport(TensorFlowApi.LibraryName)]
//		static extern unsafe void TF_SetAttrValueProto(IntPtr desc, string attr_name, void* proto, size_t proto_len, TF_Status status);

    }
}