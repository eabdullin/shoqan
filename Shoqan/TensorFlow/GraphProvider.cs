namespace Shoqan.TensorFlow
{
	public class GraphProvider
	{
		private GraphProvider()
		{
			
		}
		private Graph _currentGraph;
		private static GraphProvider _instance;

		public static GraphProvider Instance => _instance ?? (_instance = new GraphProvider());

		public Graph DefaultGraph
		{
			get { return _currentGraph ?? (_currentGraph = new Graph()); }
			set { _currentGraph = value; }
		}
	}
}