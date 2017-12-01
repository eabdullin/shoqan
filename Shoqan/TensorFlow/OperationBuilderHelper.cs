using System;

namespace Shoqan.TensorFlow
{
	public static class OperationBuilderHelper
	{
		public static OperationBuilder If(this OperationBuilder opBuilder, bool condition, Action<OperationBuilder> action)
	    {
		    if (condition)
		    {
			    action(opBuilder);
		    }
		    return opBuilder;
	    }
	}
}