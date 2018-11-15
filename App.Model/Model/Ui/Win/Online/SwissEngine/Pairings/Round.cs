using System;
using twinfeats.db;
namespace twinfeats.pairings
{
	
	/// <summary>  A tournament round for a player
	/// 
	/// </summary>
	/// <author>      Kent L. Smotherman
	/// @created    July 18, 2002
	/// </author>
	[Serializable]
	public class Round : System.Runtime.Serialization.ISerializable
	{
		public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			throw new NotImplementedException();
		}

		private void  InitBlock()
		{
			text = SHORT;
		}
		/// <summary>  Get opponent
		/// 
		/// </summary>
		/// <returns>    The opponent value
		/// </returns>
		virtual public Card Opponent
		{
			get
			{
				return opponent;
			}
			
		}
		/// <summary>  Get the numeric color for the player
		/// 
		/// </summary>
		/// <returns>    The colorCode value
		/// </returns>
		virtual public int Color
		{
			get
			{
				return color;
			}
			
		}
		/// <summary>  Get the String color for the player
		/// 
		/// </summary>
		/// <returns>    The color value
		/// </returns>
		virtual public System.String ColorString
		{
			get
			{
				return Card.COLORS[color].ToString();
			}
			
		}
		/// <summary>  Gets the numeric result
		/// 
		/// </summary>
		/// <returns>    The resultCode value
		/// </returns>
		virtual public int Result
		{
			get
			{
				return result;
			}
			
		}
		virtual public System.String ResultCrosstable
		{
			get
			{
				if (result == Card.UNPLAYED)
					return "U";
				return resultsCrosstable.Substring(result, (result + 1) - (result));
			}
			
		}
		/// <summary>  Gets String result
		/// 
		/// </summary>
		/// <returns>    The result value
		/// </returns>
		virtual public System.String ResultString
		{
			get
			{
				if (result == Card.UNPLAYED)
					return "";
				if (text == SHORT)
				{
					return resultsShort[result].ToString();
				}
				else
				{
					return resultsLong[result];
				}
			}
			
		}
		internal const long serialVersionUID = 1L;
		
		/// <summary>  short result format</summary>
		public const int SHORT = 0;
		/// <summary>  long result format</summary>
		public const int LONG = 1;
		
		internal const System.String resultsCrosstable = "LDWBFXH";
		/// <summary>  Description of the Field</summary>
		public static int UNPLAYED = - 1;
		/// <summary>  short result values</summary>
		public const System.String resultsShort = "-=+ -+";
		/// <summary>  long result values</summary>
		public static readonly System.String[] resultsLong = new System.String[]{"0", "1/2", "1", "", "F0", "F1"};
		//UPGRADE_NOTE: The initialization of  'text' was moved to method 'InitBlock'. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1005"'
		internal int text;
		internal Card opponent;
		internal int color;
		internal int result;
		
		
		/// <summary>  Constructor for the Round object</summary>
		public Round()
		{
			InitBlock();
			result = Card.UNPLAYED;
		}
	}
}