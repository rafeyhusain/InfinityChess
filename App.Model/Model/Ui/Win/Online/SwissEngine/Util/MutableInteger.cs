using System;
namespace twinfeats.util
{
	
	[Serializable]
	public class MutableInteger : System.Runtime.Serialization.ISerializable
	{
		public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			throw new NotImplementedException();
		}

		virtual public int Value
		{
			get
			{
				return value_Renamed;
			}
			
			set
			{
				value = value;
			}
			
		}
		internal const long serialVersionUID = 1L;
		internal int value_Renamed;
		
		public MutableInteger(int v)
		{
			value_Renamed = v;
		}
		
		public virtual void  add(int v)
		{
			value_Renamed += v;
		}
	}
}