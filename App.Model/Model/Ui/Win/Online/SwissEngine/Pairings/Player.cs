using System;
using DBase3 = twinfeats.db.DBase3;
using DBase3Record = twinfeats.db.DBase3Record;
namespace twinfeats.pairings
{
	
	/// <summary>  A Player
	/// 
	/// </summary>
	/// <author>      Kent L. Smotherman
	/// @created    July 18, 2002
	/// </author>
	[Serializable]
	public class Player : System.Runtime.Serialization.ISerializable
	{
		public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			throw new NotImplementedException();
		}

		//UPGRADE_NOTE: Respective javadoc comments were merged.  It should be changed in order to comply with .NET documentation conventions.
		/// <summary>  Gets the state attribute of the Player object
		/// 
		/// </summary>
		/// <returns>    The state value
		/// </returns>
		/// <summary>  Sets the state attribute of the Player object
		/// 
		/// </summary>
		/// <param name="v"> The new state value
		/// </param>
		virtual public System.String State
		{
			get
			{
				return state;
			}
			
			set
			{
				state = value;
			}
			
		}
		//UPGRADE_NOTE: Respective javadoc comments were merged.  It should be changed in order to comply with .NET documentation conventions.
		/// <summary>  Gets the quickRating attribute of the Player object
		/// 
		/// </summary>
		/// <returns>    The quickRating value
		/// </returns>
		/// <summary>  Sets the quickRating attribute of the Player object
		/// 
		/// </summary>
		/// <param name="v"> The new quickRating value
		/// </param>
		virtual public int QuickRating
		{
			get
			{
				return quickRating;
			}
			
			set
			{
				quickRating = value;
			}
			
		}
		//UPGRADE_NOTE: Respective javadoc comments were merged.  It should be changed in order to comply with .NET documentation conventions.
		/// <summary>  Gets the expires attribute of the Player object
		/// 
		/// </summary>
		/// <returns>    The expires value
		/// </returns>
		/// <summary>  Sets the expires attribute of the Player object
		/// 
		/// </summary>
		/// <param name="v"> The new expires value
		/// </param>
		virtual public System.String Expires
		{
			get
			{
				return expires;
			}
			
			set
			{
				expires = value;
			}
			
		}
		//UPGRADE_NOTE: Respective javadoc comments were merged.  It should be changed in order to comply with .NET documentation conventions.
		/// <summary>  Gets the team attribute of the Player object
		/// 
		/// </summary>
		/// <returns>    The team value
		/// </returns>
		/// <summary>  Sets the team attribute of the Player object
		/// 
		/// </summary>
		/// <param name="v"> The new team value
		/// </param>
		virtual public System.String Team
		{
			get
			{
				return team;
			}
			
			set
			{
				team = value;
			}
			
		}
		//UPGRADE_NOTE: Respective javadoc comments were merged.  It should be changed in order to comply with .NET documentation conventions.
		/// <summary>  Gets the fullName attribute of the Player object
		/// 
		/// </summary>
		/// <returns>    The fullName value
		/// </returns>
		/// <summary>  Sets the fullName attribute of the Player object
		/// 
		/// </summary>
		/// <param name="v"> The new fullName value
		/// </param>
		virtual public System.String FullName
		{
			get
			{
				return fullName;
			}
			
			set
			{
				SupportClass.Tokenizer st = new SupportClass.Tokenizer(value, ",");
				System.String lastName = camelHump(st.NextToken().Trim());
				System.String firstName;
				if (st.HasMoreTokens())
				{
					firstName = camelHump(st.NextToken().Trim());
				}
				else
					firstName = "";
				fullName = lastName + ", " + firstName;
			}
			
		}
		//UPGRADE_NOTE: Respective javadoc comments were merged.  It should be changed in order to comply with .NET documentation conventions.
		/// <summary>  Gets the memberNumber attribute of the Player object
		/// 
		/// </summary>
		/// <returns>    The memberNumber value
		/// </returns>
		/// <summary>  Sets the memberNumber attribute of the Player object
		/// 
		/// </summary>
		/// <param name="v"> The new memberNumber value
		/// </param>
		virtual public System.String MemberNumber
		{
			get
			{
				return memberNumber;
			}
			
			set
			{
				memberNumber = value;
			}
			
		}
		//UPGRADE_NOTE: Respective javadoc comments were merged.  It should be changed in order to comply with .NET documentation conventions.
		/// <summary>  Gets the rating attribute of the Player object
		/// 
		/// </summary>
		/// <returns>    The rating value
		/// </returns>
		/// <summary>  Sets the rating attribute of the Player object
		/// 
		/// </summary>
		/// <param name="v"> The new rating value
		/// </param>
		virtual public int Rating
		{
			get
			{
				return rating;
			}
			
			set
			{
				rating = value;
			}
			
		}
		/// <summary>  Gets the unrated attribute of the Player object
		/// 
		/// </summary>
		/// <returns>    The unrated value
		/// </returns>
		virtual public bool Unrated
		{
			get
			{
				return unrated;
			}
			
		}
		virtual public System.String LastName
		{
			get
			{
				int idx = fullName.IndexOf(",");
				return fullName.Substring(0, (idx) - (0)).Trim();
			}
			
		}
		virtual public System.String FirstName
		{
			get
			{
				int idx = fullName.IndexOf(",");
				return fullName.Substring(idx + 1).Trim();
			}
			
		}
		virtual public System.String Grade
		{
			get
			{
				return grade;
			}
			
			set
			{
				this.grade = value;
			}
			
		}
		internal const long serialVersionUID = 1L;
		
		internal System.String memberNumber = " ", fullName = " ", expires = " ", state = " ";
		internal int rating, quickRating;
		internal bool unrated;
		internal System.String team = " ", grade = " ";
		//UPGRADE_NOTE: The initialization of  'buffer' was moved to static method 'twinfeats.pairings.Player'. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1005"'
		internal static System.Text.StringBuilder buffer;
		
		
		/// <summary>  Constructor for the Player object</summary>
		public Player()
		{
		}
		
		
		/// <summary>  Make a player
		/// 
		/// </summary>
		/// <param name="lastName">     Last name
		/// </param>
		/// <param name="firstName">    First name
		/// </param>
		/// <param name="memberNumber"> Member number (e.g. USCF)
		/// </param>
		/// <param name="rating">       Player's rating (could be estimated for unrated player)
		/// </param>
		/// <param name="unrated">      true if player is unrated
		/// </param>
		public Player(System.String lastName, System.String firstName, System.String memberNumber, int rating, bool unrated)
		{
			fullName = lastName + ", " + firstName;
			this.memberNumber = memberNumber;
			this.rating = rating;
			this.unrated = unrated;
		}
		
		
		/// <summary>  Constructor for the Player object
		/// 
		/// </summary>
		/// <param name="lastName">     Description of the Parameter
		/// </param>
		/// <param name="firstName">    Description of the Parameter
		/// </param>
		/// <param name="memberNumber"> Description of the Parameter
		/// </param>
		/// <param name="rating">       Description of the Parameter
		/// </param>
		/// <param name="unrated">      Description of the Parameter
		/// </param>
		/// <param name="team">         Description of the Parameter
		/// </param>
		public Player(System.String lastName, System.String firstName, System.String memberNumber, int rating, bool unrated, System.String team)
		{
			fullName = lastName + ", " + firstName;
			this.memberNumber = memberNumber;
			this.rating = rating;
			this.unrated = unrated;
			this.team = team;
		}
		
		public Player(System.String text)
		{
//			if (text.Trim().Equals(""))
//				throw new System.ArgumentOutOfRangeException();
//			//UPGRADE_ISSUE: Constructor 'java.util.StringTokenizer.StringTokenizer' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javautilStringTokenizerStringTokenizer_javalangString_javalangString_boolean"'
//			SupportClass.Tokenizer st = new StringTokenizer(text, "\t", true);
//			if (st.Count < 5)
//			{
//				System.Console.Out.WriteLine("Rejected (" + st.Count + ") " + text);
//				throw new System.ArgumentOutOfRangeException();
//			}
//			FullName = nextToken(st).Trim();
//			MemberNumber = nextToken(st).Trim();
//			Expires = nextToken(st).Trim();
//			State = nextToken(st).Trim();
//			System.String t = nextToken(st).Trim();
//			int idx = t.IndexOf("*");
//			if (idx != - 1)
//				t = t.Substring(0, (idx) - (0));
//			idx = t.IndexOf("/");
//			if (idx != - 1)
//				t = t.Substring(0, (idx) - (0));
//			if (t.Equals(""))
//				t = "0";
//			Rating = System.Int32.Parse(t);
//			if (st.HasMoreTokens())
//			{
//				t = nextToken(st).Trim();
//				idx = t.IndexOf("*");
//				if (idx != - 1)
//					t = t.Substring(0, (idx) - (0));
//				idx = t.IndexOf("/");
//				if (idx != - 1)
//					t = t.Substring(0, (idx) - (0));
//				if (t.Equals(""))
//					t = "0";
//				QuickRating = System.Int32.Parse(t);
//			}
		}
		
		public static System.String nextToken(SupportClass.Tokenizer st)
		{
			System.String t = st.NextToken().Trim();
			if (t.Equals("\t"))
				t = "";
			if (st.HasMoreTokens())
				st.NextToken();
			return t;
		}
		/// <summary>  Constructor for the Player object
		/// 
		/// </summary>
		/// <param name="db">  Description of the Parameter
		/// </param>
		/// <param name="rec"> Description of the Parameter
		/// </param>
		public Player(DBase3 db, DBase3Record rec)
		{
			int i;
			int n = db.NumFields;
			System.String field;
			//		System.out.println(rec.toString());
			for (i = 0; i < n; i++)
			{
				field = db.getFieldName(i);
				//			System.out.println(field);
				if (field.Equals("MEM_ID") || field.Equals("R_MEM_ID"))
				{
					memberNumber = rec.getFieldValue(i).Trim();
				}
				else if (field.Equals("MEM_NAME") || field.Equals("R_MEM_NAME"))
				{
					FullName = rec.getFieldValue(i).Trim();
				}
				else if (field.Equals("EXPIRED") || field.Equals("R_EXP_DATE"))
				{
					expires = rec.getFieldValue(i).Trim();
				}
				else if (field.Equals("STATE") || field.Equals("R_STATE"))
				{
					state = rec.getFieldValue(i).Trim();
				}
				else if (field.Equals("R_LPB_RAT") || field.Equals("R_RATING1"))
				{
					System.String t = rec.getFieldValue(i).Trim();
					if (t.Equals(""))
						rating = 0;
					else
					{
						t = strip(t, '*');
						t = removeProvisional(t).Trim();
						if (!t.Equals(""))
							rating = System.Int32.Parse(t);
						else
							rating = 0;
					}
				}
				else if (field.Equals("Q_LPB_RAT") || field.Equals("R_RATING2"))
				{
					System.String t = rec.getFieldValue(i).Trim();
					if (t.Equals(""))
						quickRating = 0;
					else
					{
						t = strip(t, '*');
						t = removeProvisional(t).Trim();
						if (!t.Equals(""))
							quickRating = System.Int32.Parse(t);
						else
							quickRating = 0;
					}
				}
			}
		}
		
		
		/// <summary>  Description of the Method
		/// 
		/// </summary>
		/// <returns>    Description of the Return Value
		/// </returns>
		public override System.String ToString()
		{
			buffer.Length = 0;
			if (fullName.Trim().Equals(""))
			{
				fullName = "-, -";
			}
			buffer.Append(fullName);
			buffer.Append('\t');
			buffer.Append(rating);
			buffer.Append('\t');
			buffer.Append(quickRating);
			buffer.Append('\t');
			if (memberNumber.Trim().Equals(""))
			{
				memberNumber = "-";
			}
			buffer.Append(memberNumber);
			buffer.Append('\t');
			if (expires.Trim().Equals(""))
			{
				expires = "-";
			}
			buffer.Append(expires);
			buffer.Append('\t');
			if (state.Trim().Equals(""))
				state = "--";
			buffer.Append(state);
			return buffer.ToString();
		}
		
		
		/// <summary>  Description of the Method
		/// 
		/// </summary>
		/// <param name="value"> Description of the Parameter
		/// </param>
		/// <returns>        Description of the Return Value
		/// </returns>
		public static Player fromString(System.String value_Renamed)
		{
			//		System.out.println("."+value+".");
			try
			{
				Player player = new Player();
				SupportClass.Tokenizer st = new SupportClass.Tokenizer(value_Renamed, "\t");
				player.FullName = st.NextToken();
				player.Rating = System.Int32.Parse(st.NextToken());
				player.QuickRating = System.Int32.Parse(st.NextToken());
				player.MemberNumber = st.NextToken();
				player.Expires = st.NextToken();
				player.State = st.NextToken();
				return player;
			}
			catch (System.Exception e)
			{
				System.Console.Out.WriteLine(value_Renamed);
				SupportClass.WriteStackTrace(e, Console.Error);
				return null;
			}
		}
		
		/// <summary>  Description of the Method
		/// 
		/// </summary>
		/// <param name="value"> Description of the Parameter
		/// </param>
		/// <returns>        Description of the Return Value
		/// </returns>
		public static System.String camelHump(System.String value_Renamed)
		{
			SupportClass.Tokenizer st = new SupportClass.Tokenizer(value_Renamed, " ");
			System.Text.StringBuilder buffer = new System.Text.StringBuilder(value_Renamed.Length);
			System.String word;
			while (st.HasMoreTokens())
			{
				if (buffer.Length > 0)
					buffer.Append(" ");
				word = st.NextToken();
				buffer.Append(System.Char.ToUpper(word[0]));
				buffer.Append(word.Substring(1).ToLower());
			}
			return buffer.ToString();
		}
		
		
		/// <summary>  Description of the Method
		/// 
		/// </summary>
		/// <param name="value"> Description of the Parameter
		/// </param>
		/// <param name="c">     Description of the Parameter
		/// </param>
		/// <returns>        Description of the Return Value
		/// </returns>
		public static System.String strip(System.String value_Renamed, char c)
		{
			if (value_Renamed[0] == c)
				value_Renamed = value_Renamed.Substring(1);
			if (value_Renamed[value_Renamed.Length - 1] == c)
				value_Renamed = value_Renamed.Substring(0, (value_Renamed.Length - 1) - (0));
			return value_Renamed;
		}
		
		
		/// <summary>  Description of the Method
		/// 
		/// </summary>
		/// <param name="v"> Description of the Parameter
		/// </param>
		/// <returns>    Description of the Return Value
		/// </returns>
		public static System.String removeProvisional(System.String v)
		{
			int idx = v.IndexOf("/");
			if (idx != - 1)
				return v.Substring(0, (idx) - (0));
			idx = v.IndexOf("*");
			if (idx != - 1)
				return v.Substring(0, (idx) - (0));
			return v;
		}
		
		public  override bool Equals(System.Object o)
		{
			Player p = (Player) o;
			return p.FullName.Equals(FullName) && p.MemberNumber.Equals(MemberNumber);
		}
		
		public virtual bool isEqual(Player p)
		{
			//	    System.out.println("isEqual "+getFullName()+"/"+p.getFullName());
			return p.FullName.Equals(FullName);
		}
		static Player()
		{
			buffer = new System.Text.StringBuilder();
		}
	}
}