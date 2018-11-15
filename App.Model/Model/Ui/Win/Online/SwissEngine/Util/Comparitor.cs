using System;
namespace twinfeats.util
{
	
	/// <summary> This interface is used to compare two arbitrary objects.</summary>
	/// <seealso cref="HeapSort">
	/// </seealso>
	/// <author>   Kent L. Smotherman
	/// </author>
	/// <version>  1.0 Jan 2, 1998
	/// </version>
	public interface Comparitor
		{
			/// <summary> Compares two objects and returns the result of the compare.</summary>
			/// <param name="o1">         An object to compare
			/// </param>
			/// <param name="o2">         An object to compare
			/// </param>
			/// <returns>              -1 if o1 < o2; 0 if o1==o2; 1 if o1>o2
			/// </returns>
			int Compare(System.Object o1, System.Object o2);
		}
}