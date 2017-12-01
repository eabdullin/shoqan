using System;

namespace Shoqan.TensorFlow
{
	public abstract class NativeHandle : IDisposable
	{
		protected NativeHandle(IntPtr handle)
		{
			Handle = handle;
		}
		internal IntPtr Handle { get; private set; }
		protected abstract void Clean(IntPtr handle);

		~NativeHandle()
		{
			Dispose();
		}
		public void Dispose()
		{
			if (Handle != IntPtr.Zero)
			{
				Clean(Handle);
				Handle = IntPtr.Zero;
			}
		}
	}
}