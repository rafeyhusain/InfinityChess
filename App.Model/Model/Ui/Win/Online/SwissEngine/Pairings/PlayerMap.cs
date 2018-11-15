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
	[Serializable]
	public class PlayerMap : System.Runtime.Serialization.ISerializable, System.IComparable
	{
		public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			throw new NotImplementedException();
		}

		virtual public int Idx
		{
			get
			{
				return idx;
			}
			
			set
			{
				this.idx = value;
			}
			
		}
		virtual public System.String Key
		{
			get
			{
				return key;
			}
			
			set
			{
				this.key = value;
			}
			
		}
		internal const long serialVersionUID = 1L;
		
		internal int idx;
		internal System.String key;
		
		public PlayerMap(System.String key, int idx)
		{
			this.key = key;
			this.idx = idx;
		}
		
		public virtual int CompareTo(System.Object arg0)
		{
			PlayerMap p = (PlayerMap) arg0;
			return System.String.Compare(key, p.Key, false);
		}
	}
}