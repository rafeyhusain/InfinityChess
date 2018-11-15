using System;
using twinfeats.db;
namespace twinfeats.pairings
{
	
	/// <summary>  A pairing
	/// 
	/// </summary>
	/// <author>      Kent L. Smotherman
	/// @created    July 17, 2002
	/// </author>
	[Serializable]
	public class Pairing : System.Runtime.Serialization.ISerializable
	{
		public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			throw new NotImplementedException();
		}

		/// <summary>  Gets the playerToPair attribute of the Pairing object
		/// 
		/// </summary>
		/// <returns>    The playerToPair value
		/// </returns>
		virtual public Card PlayerToPair
		{
			get
			{
				return playerToPair;
			}
			
			set
			{
				this.playerToPair = value;
			}
			
		}
		/// <summary>  Gets the opponent attribute of the Pairing object
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
			
			set
			{
				this.opponent = value;
			}
			
		}
		/// <summary>  Gets the playerColor attribute of the Pairing object
		/// 
		/// </summary>
		/// <returns>    The playerColor value
		/// </returns>
		virtual public int PlayerColor
		{
			get
			{
				return playerColor;
			}
			
			set
			{
				this.playerColor = value;
			}
			
		}
		/// <summary>  Gets the playerColorString attribute of the Pairing object
		/// 
		/// </summary>
		/// <returns>    The playerColorString value
		/// </returns>
		virtual public System.String PlayerColorString
		{
			get
			{
				return Card.COLORS[playerColor].ToString();
			}
			
		}
		internal const long serialVersionUID = 1L;
		
		/// <summary>  Description of the Field</summary>
		internal Card playerToPair;
		//higher rated opponent
		/// <summary>  Description of the Field</summary>
		internal Card opponent;
		//lower rated opponent (null for a bye)
		
		/// <summary>  Description of the Field</summary>
		internal int playerColor;
		//playerToPair color for this pairing
		//UPGRADE_TODO: Method 'java.lang.System.currentTimeMillis' was converted to 'System.DateTime.Now' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073_javalangSystemcurrentTimeMillis"'
		//UPGRADE_NOTE: The initialization of  'nextColor' was moved to static method 'twinfeats.pairings.Pairing'. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1005"'
		internal static int nextColor;
		//used for 1st round
		
		
		public Pairing()
		{
		}
		/// <summary>  Make a pairing, including deciding player colors
		/// 
		/// </summary>
		/// <param name="player">      Higher rated player
		/// </param>
		/// <param name="opponent">    Lower rated opponent
		/// </param>
		/// <param name="roundNumber"> Round number
		/// </param>
		public Pairing(Card player, Card opponent, int roundNumber)
		{
			if (Engine.debug)
				System.Console.Out.WriteLine("Pairing " + player.pairingNumber + ":" + (opponent != null?opponent.pairingNumber.ToString():"BYE"));
			playerToPair = player;
			playerColor = Card.NONE;
			this.opponent = opponent;
			if (opponent == null)
				return ;
			if (roundNumber > 0)
			{
				if (System.Math.Abs(player.colorScore) > System.Math.Abs(opponent.colorScore))
				{
					//assign color to greater preference
					if (player.colorScore > 0)
						playerColor = Card.BLACK;
					else if (player.colorScore < 0)
						playerColor = Card.WHITE;
				}
				else if (System.Math.Abs(player.colorScore) < System.Math.Abs(opponent.colorScore))
				{
					if (opponent.colorScore > 0)
						playerColor = Card.WHITE;
					else if (opponent.colorScore < 0)
						playerColor = Card.BLACK;
				}
				else
				{
					playerColor = playerToPair.rounds[roundNumber - 1].color == Card.WHITE?Card.BLACK:Card.WHITE;
				}
				if (roundNumber > 1)
				{
					if ((playerColor == player.rounds[roundNumber - 1].color && playerColor == player.rounds[roundNumber - 2].color) || (playerColor != opponent.rounds[roundNumber - 1].color && playerColor != opponent.rounds[roundNumber - 2].color))
					{
						if (playerColor == Card.WHITE)
							playerColor = Card.BLACK;
						else
							playerColor = Card.WHITE;
					}
				}
			}
			else
			{
				if (Engine.debug)
					System.Console.Out.WriteLine(player.player.memberNumber + Card.COLORS[nextColor] + "-" + player.player.memberNumber);
				playerColor = nextColor;
				if (nextColor == Card.BLACK)
					nextColor = Card.WHITE;
				else
					nextColor = Card.BLACK;
			}
		}
		static Pairing()
		{
			nextColor = ((System.DateTime.Now.Ticks - 621355968000000000) / 10000 & 1) == 0?Card.WHITE:Card.BLACK;
		}
	}
}