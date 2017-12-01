using System;
using System.Runtime.InteropServices;

namespace Shoqan.TensorFlow
{
	public class Status : NativeHandle
	{
		[DllImport(TensorFlowApi.LibraryName)]
		internal static extern unsafe IntPtr TF_NewStatus();
		public Status():base(TF_NewStatus())
		{

		}
		public Status(IntPtr handle) : base(handle)
		{
		}

		protected override void Clean(IntPtr handle)
		{
			throw new NotImplementedException();
		}

		public StatusCode Code
		{
			get { return TF_GetCode(Handle); } 
		}
		// extern TF_Code TF_GetCode (const TF_Status *s);
		[DllImport(TensorFlowApi.LibraryName)]
		internal static extern unsafe StatusCode TF_GetCode(IntPtr s);

		[DllImport(TensorFlowApi.LibraryName)]
		static extern unsafe IntPtr TF_Message(IntPtr s);

		public string Message
		{
			get
			{
				var messagePointer = TF_Message(Handle);
				return Marshal.PtrToStringAnsi(messagePointer);
			}
		}
	}

	public enum StatusCode
	{
		Ok = 0,
		Cancelled = 1,
		Unknown = 3
	}

	public class StatusException :Exception
	{
		private Status _status;
		public StatusException(Status s):base(s.Message)
		{
			_status = s;
		}
	}
}