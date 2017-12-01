using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Shoqan.TensorFlow
{
	public class NameScope : IDisposable
	{
		Regex _validNameRegex = new Regex("^[A-Za-z0-9_.\\-/]*$");
		private Graph _graph;
		private string _oldstack;
		public string Name { get; private set; }
		public NameScope(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException(nameof(name));
			}
			if (!_validNameRegex.IsMatch(name))
			{
				throw new ArgumentException($"{nameof(name)} is not valid scope name");
			}
			_graph = GraphProvider.Instance.DefaultGraph;
			_oldstack = _graph.NameStack;
			_graph.NameStack = _oldstack + "/" + name;
			Name = _graph.NameStack;
		}

		public void Dispose()
		{
			_graph.NameStack = _oldstack;
		}


	}
}