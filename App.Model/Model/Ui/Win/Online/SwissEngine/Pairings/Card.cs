using System;
using System.Runtime.InteropServices;
using twinfeats.db;
namespace twinfeats.pairings
{
	
	/// <summary>  Pairing card
	/// 
	/// </summary>
	/// <author>      Kent L. Smotherman
	/// @created    July 17, 2002
	/// </author>
	[Serializable]
	public class Card : System.Runtime.Serialization.ISerializable
	{
		public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			throw new NotImplementedException();
		}
		private void  InitBlock()
		{
			//UPGRADE_ISSUE: Class hierarchy differences between 'java.util.ArrayList' and 'System.Collections.ArrayList' may cause compilation errors. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1186"'
			alreadyTried = new System.Collections.ArrayList();
		}
		virtual public bool Quick
		{
			get
			{
				return quick;
			}
			
			set
			{
				this.quick = value;
			}
			
		}
		virtual public int PairingScore
		{
			get
			{
				return pairingScore;
			}
			
		}
		virtual public int Rating
		{
			get
			{
				int r = 0;
				if (quick)
				{
					r = player.QuickRating;
					if (r == 0)
						r = player.Rating;
				}
				else
				{
					r = player.Rating;
					if (r == 0)
						r = player.QuickRating;
				}
				return r;
			}
			
		}
		/// <summary>  Gets the score for this player
		/// 
		/// </summary>
		/// <returns>    The score value
		/// </returns>
		virtual public System.String ScoreString
		{
			get
			{
				System.Text.StringBuilder sb = new System.Text.StringBuilder(10);
				sb.Append(score >> 1);
				sb.Append(".");
				if ((score & 1) == 0)
					sb.Append("0");
				else
					sb.Append("5");
				return sb.ToString();
			}
			
		}
		/// <summary>  Gets the pairingNumber attribute of the Card object
		/// 
		/// </summary>
		/// <returns>    The pairingNumber value
		/// </returns>
		virtual public int PairingNumber
		{
			get
			{
				return pairingNumber;
			}
			
			set
			{
				pairingNumber = value;
			}
			
		}
		/// <summary>  Gets the player attribute of the Card object
		/// 
		/// </summary>
		/// <returns>    The player value
		/// </returns>
		virtual public Player Player
		{
			get
			{
				return player;
			}
			
		}
		/// <summary>  Gets the team attribute of the Card object
		/// 
		/// </summary>
		/// <returns>    The team value
		/// </returns>
		virtual public System.String Team
		{
			get
			{
				return player.team;
			}
			
		}
		/// <summary>  Gets the rounds attribute of the Card object
		/// 
		/// </summary>
		/// <returns>    The rounds value
		/// </returns>
		virtual public Round[] Rounds
		{
			get
			{
				return rounds;
			}
			
		}
		/// <summary>  Gets the withdrawn attribute of the Card object
		/// 
		/// </summary>
		/// <returns>    The withdrawn value
		/// </returns>
		virtual public bool Withdrawn
		{
			get
			{
				return withdrawn;
			}
			
			set
			{
				withdrawn = value;
			}
			
		}
		/// <summary>  Gets the score attribute of the Card object
		/// 
		/// </summary>
		/// <returns>    The score value
		/// </returns>
		virtual public int Score
		{
			get
			{
				return score;
			}
			
		}
		virtual public bool HadBye
		{
			get
			{
				return hadBye;
			}
			
			set
			{
				this.hadBye = value;
			}
			
		}
		internal const long serialVersionUID = 1L;
		
		/// <summary>  Playing white</summary>
		public const int WHITE = 0;
		/// <summary>  Playing black</summary>
		public const int BLACK = 1;
		
		/// <summary>  Playing neither color (bye)</summary>
		public const int NONE = 2;
		
		/// <summary>  String mapping of the colors</summary>
		public const System.String COLORS = "WB ";
		
		/// <summary>  Points for a loss</summary>
		public static int LOSS = 0;
		
		public static int DRAW = 1;
		/// <summary>  Points for a win</summary>
		public static int WIN = 2;
		/// <summary>  BYE indicator value</summary>
		public static int BYE = 3;
		
		public static int FORFEITLOSS = 4;
		public static int FORFEITWIN = 5;
		public static int HALFPOINTBYE = 6;
		
		
		/// <summary>  Description of the Field</summary>
		public static int UNPLAYED = - 1;
		
		internal Player player;
		internal Round[] rounds;
		internal bool hadBye;
		internal bool withdrawn;
		internal int score;
		internal int pairingScore;
		internal int colorScore;
		internal int pairingNumber;
		internal int[] tieBreakScores;
		internal bool quick;
		//UPGRADE_ISSUE: Class hierarchy differences between 'java.util.ArrayList' and 'System.Collections.ArrayList' may cause compilation errors. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1186"'
		//UPGRADE_NOTE: The initialization of  'alreadyTried' was moved to method 'InitBlock'. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1005"'
		[NonSerialized()]
		internal System.Collections.ArrayList alreadyTried;
		
		/// <summary>  Constructor for the Card object
		/// 
		/// </summary>
		/// <param name="player">    Player
		/// </param>
		/// <param name="numRounds"> Number of rounds
		/// </param>
		public Card(Player player, int numRounds)
		{
			InitBlock();
			this.player = player;
			init(numRounds);
		}
		
		
		/// <summary>  Constructor for the Card object
		/// 
		/// </summary>
		/// <param name="player"> Description of the Parameter
		/// </param>
		public Card(Player player)
		{
			InitBlock();
			this.player = player;
		}
		
		
		/// <summary>  Prepare card for next round</summary>
		public virtual void  prepareNextRound()
		{
			if (alreadyTried == null)
			{
				//UPGRADE_ISSUE: Class hierarchy differences between 'java.util.ArrayList' and 'System.Collections.ArrayList' may cause compilation errors. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1186"'
				alreadyTried = new System.Collections.ArrayList();
			}
			alreadyTried.Clear();
		}
		
		
		/// <summary>  Init the card for the tournament
		/// 
		/// </summary>
		/// <param name="numRounds"> Number of rounds
		/// </param>
		public virtual void  init(int numRounds)
		{
			score = 0;
			colorScore = 0;
			rounds = new Round[numRounds];
			for (int i = 0; i < numRounds; i++)
				rounds[i] = new Round();
			hadBye = false;
			withdrawn = false;
			tieBreakScores = new int[6];
			alreadyTried.Clear();
		}
		
		/// <summary>  Update the pairing card result for the indicated round
		/// 
		/// </summary>
		/// <param name="roundNumber"> Round number to update
		/// </param>
		/// <param name="result">      Result (From this player's perspective)
		/// </param>
		public virtual void  updateResult(Engine eng, int roundNumber, int result)
		{
			int s = 0;
			if (rounds[roundNumber].result != Card.UNPLAYED)
			{
				switch (rounds[roundNumber].result)
				{
					
					case 0: 
						s = 0;
						break;
					
					case 1: 
						s = 1;
						score -= 1;
						break;
					
					case 2: 
						s = 2;
						score -= 2;
						break;
					
					case 3: 
						s = eng.ByePoints;
						score -= eng.ByePoints;
						break;
					
					case 4: 
						s = 0;
						break;
					
					case 5: 
						s = 2;
						score -= 2;
						break;
					
					case 6: 
						s = 1;
						score -= 1;
						break;
					}
				//			score -= rounds[roundNumber].result;
				pairingScore -= s;
			}
			rounds[roundNumber].result = result;
			s = 0;
			if (result == Card.FORFEITWIN)
				s = 2;
			else if (result == Card.FORFEITLOSS)
				s = 0;
			else if (result == Card.HALFPOINTBYE)
				s = 1;
			else if (result == Card.BYE)
				s = eng.ByePoints;
			else if (result != Card.UNPLAYED)
				s = result;
			score += s;
			pairingScore += s;
		}
		
		
		/// <summary>  Gets the round attribute of the Card object
		/// 
		/// </summary>
		/// <param name="round"> Description of the Parameter
		/// </param>
		/// <returns>        The round value
		/// </returns>
		public virtual Round getRound(int round)
		{
			return rounds[round];
		}
		
		
		/// <summary>  Description of the Method
		/// 
		/// </summary>
		/// <returns>    Description of the Return Value
		/// </returns>
		public virtual int calcSolkoff()
		{
			int score = 0;
			for (int i = 0; i < rounds.Length; i++)
			{
				if (rounds[i].opponent != null)
					score += rounds[i].opponent.score;
			}
			return score;
		}
		
		
		/// <summary>  Description of the Method
		/// 
		/// </summary>
		/// <returns>    Description of the Return Value
		/// </returns>
		public virtual int calcMedian()
		{
			int score = 0;
			int hi = 0;
			int low = rounds.Length;
			for (int i = 0; i < rounds.Length; i++)
			{
				if (rounds[i].opponent != null && rounds[i].opponent.score > 0)
					hi = rounds[i].opponent.score;
				if (rounds[i].opponent != null && rounds[i].opponent.score < low)
					low = rounds[i].opponent.score;
				if (rounds[i].opponent != null)
					score += rounds[i].opponent.score;
			}
			return score - hi - low;
		}
		
		
		/// <summary>  Description of the Method
		/// 
		/// </summary>
		/// <returns>    Description of the Return Value
		/// </returns>
		public virtual int calcCumulative()
		{
			int score = 0;
			for (int i = 0; i < rounds.Length; i++)
			{
				score += rounds[i].result * (rounds.Length - i);
			}
			return score;
		}
		
		
		/// <summary>  Description of the Method
		/// 
		/// </summary>
		/// <returns>    Description of the Return Value
		/// </returns>
		public virtual int calcKashdan()
		{
			int score = 0;
			for (int i = 0; i < rounds.Length; i++)
			{
				score += (rounds[i].result * 4 + rounds[i].result == LOSS?1:0);
			}
			return score;
		}
		
		
		/// <summary>  Description of the Method
		/// 
		/// </summary>
		/// <returns>    Description of the Return Value
		/// </returns>
		public virtual int calcCumulativeOpposition()
		{
			int score = 0;
			for (int i = 0; i < rounds.Length; i++)
			{
				if (rounds[i].opponent != null)
					score += rounds[i].opponent.calcCumulative();
			}
			return score;
		}
	}
}