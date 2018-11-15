using System;
namespace twinfeats.util
{
	
	/// <summary> Class to sort a vector of data using the HeapSort algorithm. Note that
	/// the HeapSort class is comprised entirely of static methods so there is
	/// no need to actually instantiate it. Instead simply use it's sort method.
	/// </summary>
	/// <seealso cref="Comparitor">
	/// </seealso>
	/// <author>   Kent L. Smotherman
	/// </author>
	/// <version>  1.0 Jan 2, 1998
	/// </version>
	public class HeapSort : Comparitor
	{
		public virtual int Compare(System.Object o1, System.Object o2)
		{
			return ((System.String) o1).CompareTo((System.String) o2);
		}
		/// <summary> Method for actually performing the heap sort.</summary>
		/// <param name="v">          Vector to sort
		/// </param>
		/// <param name="comp">       Comparitor to compare the elements of the vector
		/// </param>
		/// <exception cref="">   java.lang.Exception     Any exception at all
		/// </exception>
		/// <seealso cref="Comparitor">
		/// </seealso>
		public static void  sort(SupportClass.ListCollectionSupport v, Comparitor comp)
		{
			int N = v.Count;
			if (N < 1)
				return ;
			for (int k = N / 2; k > 0; k--)
			{
				downheap(v, comp, k, N);
			}
			do 
			{
				System.Object T;
				T = v.Get(0);
				v.Set(0, v.Get(N - 1));
				v.Set(N - 1, T);
				N = N - 1;
				downheap(v, comp, 1, N);
			}
			while (N > 1);
		}
		
		private static void  downheap(SupportClass.ListCollectionSupport v, Comparitor comp, int k, int N)
		{
			System.Object T = v.Get(k - 1);
			while (k <= N / 2)
			{
				int j = k + k;
				if ((j < N) && (comp.Compare(v.Get(j - 1), v.Get(j)) < 0))
				{
					j++;
				}
				if (comp.Compare(T, v.Get(j - 1)) >= 0)
					break;
				else
				{
					v.Set(k - 1, v.Get(j - 1));
					k = j;
				}
			}
			v.Set(k - 1, T);
		}
		
		/// <summary> Utility function to make a vector from an enumeration for sorting</summary>
		/// <param name="e">          Enumeration to make into a vector
		/// </param>
		/// <param name="count">      Number of items in the enumeration
		/// </param>
		/// <returns>              Vector of the enumeration
		/// </returns>
		public static System.Collections.ArrayList makeVector(System.Collections.IEnumerator e, int count)
		{
			System.Collections.ArrayList v = new System.Collections.ArrayList(count);
			//UPGRADE_TODO: Method 'java.util.Enumeration.hasMoreElements' was converted to 'System.Collections.IEnumerator.MoveNext' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073"'
			for (int i = 0; e.MoveNext(); i++)
			{
				//UPGRADE_TODO: Method 'java.util.Enumeration.nextElement' was converted to 'System.Collections.IEnumerator.Current' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073"'
				v.Add(e.Current);
			}
			return v;
		}
		
		public static System.String[] makeArray(System.Collections.ArrayList v)
		{
			int i, n = v.Count;
			System.String[] sa = new System.String[n];
			for (i = 0; i < n; i++)
				sa[i] = ((System.String) v[i]);
			return sa;
		}
		
		public static System.Collections.ArrayList makeVector(System.String[] sa)
		{
			System.Collections.ArrayList v = new System.Collections.ArrayList(10);
			for (int i = 0; i < sa.Length; i++)
				v.Add(sa[i]);
			return v;
		}
		
		public static void  makeVector(System.String[] sa, System.Collections.ArrayList v)
		{
			for (int i = 0; i < sa.Length; i++)
				v.Add(sa[i]);
		}
	}
}