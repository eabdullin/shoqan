// Filename: Graph.cs
// Date Created: 14/11/2017
// Author: Yelaman Abdullin
// 

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace Shoqan.TensorFlow
{
	public sealed class Graph : NativeHandle
	{
		internal Dictionary<string,int> NamesInUse = new Dictionary<string, int>();
		internal string NameStack;
		private Object _nativeHandleLock = new Object();
	    private int _lockersCount = 0;

		[DllImport(TensorFlowApi.LibraryName)]
		static extern unsafe IntPtr TF_NewGraph();
		public Graph() : base(TF_NewGraph())
		{

		}
		public Graph(IntPtr nativeHandle):base(nativeHandle)
	    {
			
	        
	    }
	    public GraphLocker Lock()
	    {
	        return new Graph.GraphLocker(this);
	    }
		
	    public OperationBuilder OperationBuilder(string type, string name)
	    {
	        return new OperationBuilder(this, type,name);
	    } 
	    public class GraphLocker : IDisposable
	    {
	        private Graph _parentGraph;
	        private bool _active;

	        public GraphLocker(Graph parentGraph)
	        {
	            _parentGraph = parentGraph;
	            lock (_parentGraph._nativeHandleLock)
	            {
	                _active = _parentGraph.Handle != IntPtr.Zero;
	                if (!_active)
	                {
	                    throw new InvalidOperationException("Dispose() has been called on the Graph");
	                }
	                _active = true;

                    _parentGraph._lockersCount++;
                }
	        }

	        public void Dispose()
	        {
	            lock (_parentGraph._nativeHandleLock)
	            {
	                if (!_active)
	                {
	                    return;
	                }
	                _active = false;
	                if (--_parentGraph._lockersCount == 0)
	                {
	                    Monitor.PulseAll(_parentGraph._nativeHandleLock);
	                }
	            }
	        }

	        public IntPtr NativeHandle()
	        {
	            lock (_parentGraph._nativeHandleLock) {
	                return _active ? _parentGraph.Handle : IntPtr.Zero;
	            }
	        }

        }

		[DllImport(TensorFlowApi.LibraryName)]
		static extern unsafe void TF_DeleteGraph(IntPtr graph);
		protected override void Clean(IntPtr handle)
		{
			TF_DeleteGraph(handle);
		}

		public string UniqueName(string name)
		{
			if (!NamesInUse.ContainsKey(name))
			{
				NamesInUse.Add(name, 0);
			}
			NamesInUse[name] += 1;

			return $"{name}_{NamesInUse[name]}";

		}

	}
}