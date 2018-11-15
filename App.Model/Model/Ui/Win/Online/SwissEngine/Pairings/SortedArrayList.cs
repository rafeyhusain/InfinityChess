/*
* Created on Aug 28, 2005
*
*/
using System;
namespace twinfeats.pairings
{
	
	/// <author>  kent
	/// 
	/// </author>
	//UPGRADE_ISSUE: Class hierarchy differences between 'java.util.ArrayList' and 'System.Collections.ArrayList' may cause compilation errors. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1186"'
	[Serializable]
	public class SortedArrayList:System.Collections.ArrayList, System.Runtime.Serialization.ISerializable
	{
		public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			throw new NotImplementedException();
		}

		internal const long serialVersionUID = 1L;
		
		/// <param name="">arg0
		/// </param>
		public SortedArrayList(int arg0):base(arg0)
		{
			//UPGRADE_ISSUE: Class hierarchy differences between 'java.util.ArrayList' and 'System.Collections.ArrayList' may cause compilation errors. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1186"'
		}
		
		/// <summary> </summary>
		public SortedArrayList():base()
		{
			//UPGRADE_ISSUE: Class hierarchy differences between 'java.util.ArrayList' and 'System.Collections.ArrayList' may cause compilation errors. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1186"'
		}
		
		/// <param name="">arg0
		/// </param>
		//UPGRADE_ISSUE: Class hierarchy differences between ''java.util.Collection'' and ''SupportClass.CollectionSupport'' may cause compilation errors. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1186"'
		public SortedArrayList(SupportClass.CollectionSupport arg0):base(arg0)
		{
			//UPGRADE_ISSUE: Constructor 'java.util.ArrayList.ArrayList' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000"'
		}
		
		public int addSorted(System.Object o)
		{
			//UPGRADE_TODO: The equivalent in .NET for method 'java.util.ArrayList.size' may return a different value. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1043"'
			int n = this.Count - 1;
			int i = 0;
			int idx = 0;
			bool insertBefore = true;
			while (i <= n)
			{
				idx = (n + i) >> 1;
				System.IComparable o1 = (System.IComparable) this[idx];
				int rc = o1.CompareTo(o);
				if (rc > 0)
				{
					insertBefore = true;
					n = idx - 1;
				}
				else if (rc < 0)
				{
					i = idx + 1;
					insertBefore = false;
				}
				else
					break; //values equal
			}
			if (!insertBefore)
			{
				idx++;
			}
			this.Insert(idx, o);
			return idx;
		}
		
		public Boolean Add(System.Object o)
		{
			addSorted(o);
			return true;
		}
	}
}