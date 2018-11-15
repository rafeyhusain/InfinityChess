using System;
using System.Runtime.InteropServices;
namespace twinfeats.pairings
{
	
	/// <summary>  Simple SWISS pairing engine
	/// 
	/// </summary>
	/// <author>      Kent L. Smotherman
	/// @created    July 17, 2002
	/// </author>
	[Serializable]
	public class Engine : System.Runtime.Serialization.ISerializable
	{

		public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			throw new NotImplementedException();
		}
		/// <summary>  Gets the roundNumber attribute of the Engine object
		/// 
		/// </summary>
		/// <returns>    The roundNumber value
		/// </returns>
		virtual public int RoundNumber
		{
			get
			{
				return roundNumber;
			}
			
		}
		/// <summary>  Gets the pairing cards (effectively, the cross table)
		/// 
		/// </summary>
		/// <returns>    The cards value
		/// </returns>
		virtual public System.Collections.ArrayList Cards
		{
			get
			{
				return cards;
			}
			
		}
		/// <summary>  Gets the numRounds attribute of the Engine object
		/// 
		/// </summary>
		/// <returns>    The numRounds value
		/// </returns>
		virtual public int NumRounds
		{
			get
			{
				return numRounds;
			}
			
		}
		/// <summary>  Gets the pairedStack attribute of the Engine object
		/// 
		/// </summary>
		/// <returns>    The pairedStack value
		/// </returns>
		virtual public SupportClass.ListCollectionSupport PairedStack
		{
			get
			{
				return pairedStack;
			}
			
		}
		/// <summary>  Gets the byePoints attribute of the Engine object
		/// 
		/// </summary>
		/// <returns>    The byePoints value
		/// </returns>
		virtual public int ByePoints
		{
			get
			{
				return byePoints;
			}
			
		}
		internal const long serialVersionUID = 1L;
		
		/// <summary>  Debug messages flag</summary>
		public static bool debug = false;
		
		/// <summary>  The list of all players, already sorted by rating (highest rated player is
		/// element 0, etc)
		/// </summary>
		internal System.Collections.ArrayList cards;
		//This is, effectively, the crosstable
		internal int byePoints = 1;
		//points awarded for byes (1=draw)
		internal int roundNumber = - 1;
		//current round number (starts at -1 to indicate tournament not yet underway)
		internal int numRounds = 0;
		//number of rounds in tournament
		internal int acceleratedSplit;
		
		/// <summary>  Description of the Field</summary>
		public const int NORMAL = 0;
		
		public const int FLAG_ACCEL = 0;
		public const int FLAG_QUICK = 1;
		public const int FLAG_COLORPRIORITY = 2;
		public const int FLAG_TEAMPRIORITY = 3;
		internal bool[] flags;
		
		[NonSerialized()]
		internal SupportClass.ListCollectionSupport unpairedStack;
		//stack of unpaired players
		[NonSerialized()]
		internal SupportClass.ListCollectionSupport pairedStack;
		//stack of pairings so far
		[NonSerialized()]
		internal Card currentPlayer;
		//current player being paired
		[NonSerialized()]
		internal bool allow3color;
		[NonSerialized()]
		internal bool allow3colorseq;
		[NonSerialized()]
		internal bool allowteam;
		[NonSerialized()]
		internal bool pairdown;
		
		public Engine()
		{
			unpairedStack = new SupportClass.ListCollectionSupport();
			pairedStack = new SupportClass.ListCollectionSupport();
		}
		
		/// <summary>  Make a new pairing engine with a set of players
		/// 
		/// </summary>
		/// <param name="cards">     Player pairing cards
		/// </param>
		/// <param name="numrounds"> Number of rounds
		/// </param>
		/// <param name="byepoints"> Points for a bye
		/// </param>
		public Engine(System.Collections.ArrayList cards, int numrounds, int byepoints)
		{
			this.cards = cards;
			this.numRounds = numrounds;
			byePoints = byepoints;
			initializeCards();
		}
		
		
		/// <summary>  Make a new pairing engine with a set of players
		/// 
		/// </summary>
		/// <param name="cards">     Player pairing cards
		/// </param>
		/// <param name="numrounds"> Number of rounds
		/// </param>
		/// <param name="byepoints"> Points for a bye
		/// </param>
		/// <param name="method">    Pairing method
		/// </param>
		public Engine(System.Collections.ArrayList cards, int numrounds, int byepoints, bool[] flags)
		{
			this.cards = cards;
			this.flags = flags;
			this.numRounds = numrounds;
			byePoints = byepoints;
			initializeCards();
		}
		
		
		/// <summary>  Constructor for the Engine object
		/// 
		/// </summary>
		/// <param name="numrounds"> Description of the Parameter
		/// </param>
		/// <param name="byepoints"> Description of the Parameter
		/// </param>
		/// <param name="method">    Description of the Parameter
		/// </param>
		/// <param name="players">   Description of the Parameter
		/// </param>
		public Engine(int numrounds, int byepoints, bool[] flags, System.Collections.ArrayList players)
		{
			int i;
			int n = players.Count;
			cards = new System.Collections.ArrayList(n);
			Card c;
			for (i = 0; i < n; i++)
			{
				cards.Add(c = new Card((Player) players[i]));
				c.Quick = flags[1];
			}
			this.numRounds = numrounds;
			this.flags = flags;
			byePoints = byepoints;
			initializeCards();
		}
		
		
		/// <summary>  Create a pairing engine without a set of players
		/// 
		/// </summary>
		/// <param name="numrounds"> Number of rounds
		/// </param>
		/// <param name="byepoints"> Points for a bye
		/// </param>
		public Engine(int numrounds, int byepoints)
		{
			this.numRounds = numrounds;
			byePoints = byepoints;
		}
		
		
		/// <summary>  Create a pairing engine without a set of players
		/// 
		/// </summary>
		/// <param name="numrounds"> Number of rounds
		/// </param>
		/// <param name="byepoints"> Points for a bye
		/// </param>
		/// <param name="method">    Pairing method
		/// </param>
		public Engine(int numrounds, int byepoints, bool[] flags)
		{
			this.numRounds = numrounds;
			byePoints = byepoints;
			this.flags = flags;
		}
		
		
		/// <summary>  Gets the card attribute of the Engine object
		/// 
		/// </summary>
		/// <param name="pairingNumber"> Description of the Parameter
		/// </param>
		/// <returns>                The card value
		/// </returns>
		public virtual Card getCard(int pairingNumber)
		{
			return (Card) cards[pairingNumber];
		}
		
		
		/// <summary>  Add a player to the tournament. Adds the card in rating sorted order if
		/// requested. If cards are added in sorted order, a call to initializeCazds is
		/// required to set the pairing numbers, otherwise this method will set the
		/// pairing number for the added card.
		/// 
		/// </summary>
		/// <param name="player"> Player to add
		/// </param>
		/// <param name="sorted"> true if the card is to be added sorted, false if added to the
		/// end
		/// </param>
		public virtual void  addPlayer(Player player, bool sorted)
		{
			Card card = new Card(player, numRounds);
			card.Quick = flags[1];
			addPlayer(card, sorted);
		}
		
		
		/// <summary>  Description of the Method
		/// 
		/// </summary>
		/// <param name="section"> Description of the Parameter
		/// </param>
		public virtual void  update(TournamentSection section)
		{
			//		cards = section.getCards();	removed to clean up errors, need to look at
			flags = section.Flags;
			byePoints = section.ByePoints;
			numRounds = section.NumRounds;
			//		roundNumber = section.getRoundNumber();	removed to clean up errors, need to look at
		}
		
		
		/// <summary>  Adds a pairing card to the tournament. Adds the card in rating sorted order
		/// if requested. If cards are added in sorted order, a call to initializeCazds
		/// is required to set the pairing numbers, otherwise this method will set the
		/// pairing number for the added card.
		/// 
		/// </summary>
		/// <param name="card">   Pairing card to add
		/// </param>
		/// <param name="sorted"> true if the card is to be added sorted, false if added to the
		/// end
		/// </param>
		public virtual void  addPlayer(Card card, bool sorted)
		{
			if (!sorted)
			{
				cards.Add(card);
				card.pairingNumber = cards.Count;
				card.init(numRounds);
				return ;
			}
			int i;
			int n = cards.Count;
			Card temp;
			for (i = 0; i < n; i++)
			{
				temp = (Card) cards[i];
				if (temp.player.rating < card.player.rating)
				{
					cards.Insert(i, card);
					return ;
				}
			}
			cards.Add(card);
		}
		
		public virtual void  updatePlayer(Player player)
		{
			//	    System.out.println("Engine.updatePlayer");
			int i;
			int n = cards.Count;
			for (i = 0; i < n; i++)
			{
				Card c = (Card) cards[i];
				if (c.player.isEqual(player))
				{
					c.player = player;
					break;
				}
			}
		}
		
		
		/// <summary>  Withdraw a player from the tournament
		/// 
		/// </summary>
		/// <param name="card"> Pairing card to withdraw
		/// </param>
		public virtual void  withdrawPlayer(Card card)
		{
			card.withdrawn = true;
		}
		
		
		/// <summary>  Initialize the pairing cards for a tournament. This assigns pairing numbers
		/// and inits each card.
		/// </summary>
		public virtual void  initializeCards()
		{
			Card card;
			int i;
			int numCards = cards.Count;
			acceleratedSplit = numCards >> 1;
			for (i = 0; i < numCards; i++)
			{
				card = (Card) cards[i];
				card.Quick = flags[1];
				card.pairingNumber = i + 1;
				card.init(numRounds);
				if (flags[0] && i < acceleratedSplit)
				{
					card.pairingScore = 2;
				}
				else
					card.pairingScore = 0;
			}
		}
		
		
		/// <summary>  Prepare data structures for the pairing of the next round</summary>
		public virtual void  prepareNextRound()
		{
			Card card;
			int i;
			int numCards = cards.Count;
			
			pairdown = false;
			allow3color = false;
			allow3colorseq = false;
			allowteam = false;
			
			if (roundNumber == - 1 || anyResultsInCurrentRound())
			{
				roundNumber++;
			}
			if (unpairedStack == null)
				unpairedStack = new SupportClass.ListCollectionSupport();
			if (pairedStack == null)
				pairedStack = new SupportClass.ListCollectionSupport();
			unpairedStack.Clear();
			pairedStack.Clear();
			for (i = 0; i < numCards; i++)
			{
				card = (Card) cards[i];
				if (flags[0] && roundNumber == 2 && i < acceleratedSplit)
					card.pairingScore -= 2;
				if (!card.withdrawn && card.getRound(roundNumber).result == Card.UNPLAYED)
				{
					card.prepareNextRound();
					addCardSorted(card);
				}
			}
		}
		
		
		/// <summary>  Adds a card to the unpaired stack data structure in score and rating sorted
		/// order
		/// 
		/// </summary>
		/// <param name="card"> Card to add
		/// </param>
		public virtual void  addCardSorted(Card card)
		{
			System.Collections.IEnumerator iterator = unpairedStack.ListIterator();
			
			object[] obj = unpairedStack.ListSelection();
			
			System.Collections.ArrayList lst = new System.Collections.ArrayList();

			lst.AddRange(obj);
			Card temp;

			for(int i = 0; i < lst.Count ; i++)
			{
				temp = (Card) lst[i];
				if (temp.pairingScore < card.pairingScore || (temp.pairingScore == card.pairingScore && temp.player.rating < card.player.rating))
				{
					lst.Insert(i-1, card);
					//iterator.previous();
					//iterator.add(card);
					return ;
				}
			}

			unpairedStack.Add(card);

			//UPGRADE_TODO: Method 'java.util.ListIterator.hasNext' was converted to 'System.Collections.IEnumerator.MoveNext' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073_javautilListIteratorhasNext"'
			while (iterator.MoveNext())
			{				
				//UPGRADE_TODO: Method 'java.util.ListIterator.next' was converted to 'System.Collections.IEnumerator.Current' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073_javautilListIteratornext"'
				temp = (Card) iterator.Current;
				if (temp.pairingScore < card.pairingScore || (temp.pairingScore == card.pairingScore && temp.player.rating < card.player.rating))
				{

					//UPGRADE_ISSUE: Method 'java.util.ListIterator.previous' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javautilListIteratorprevious"'
					//iterator.previous();
					//UPGRADE_ISSUE: Method 'java.util.ListIterator.add' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javautilListIteratoradd_javalangObject"'
					//iterator.add(card);
					return ;
				}
			}
			//we never added, so just append
			//unpairedStack.Add(card);
		}

		void ResetList(System.Collections.IEnumerator iterator)
		{
			iterator.Reset();
		}
		
		
		/// <summary>  Description of the Method
		/// 
		/// </summary>
		/// <returns>    Description of the Return Value
		/// </returns>
		public virtual bool readyToPairNextRound()
		{
			int n = cards.Count;
			Round r;
			Card c;
			int i = roundNumber;
			//		for (int i = 0; i <= roundNumber; i++) {
			if (roundNumber >= 0)
			{
				for (int j = 0; j < n; j++)
				{
					c = (Card) cards[j];
					r = c.getRound(i);
					if (r.result == Card.UNPLAYED && !c.Withdrawn)
						return false;
				}
			}
			//		}
			return true;
		}
		
		public virtual bool anyResultsInCurrentRound()
		{
			int n = cards.Count;
			Round r;
			Card c;
			int i = roundNumber;
			//		for (int i = 0; i <= roundNumber; i++) {
			if (i >= 0)
			{
				for (int j = 0; j < n; j++)
				{
					c = (Card) cards[j];
					r = c.getRound(i);
					if (r.result != Card.UNPLAYED && r.result != Card.BYE && r.result != Card.HALFPOINTBYE)
						return true;
				}
			}
			//		}
			return false;
		}
		
		public virtual void  undoPairings()
		{
			int n = cards.Count;
			Round r;
			Card c;
			int i = roundNumber;
			//		for (int i = 0; i <= roundNumber; i++) {
			if (i >= 0)
			{
				for (int j = 0; j < n; j++)
				{
					c = (Card) cards[j];
					undoPairing(c, i);
				}
			}
			//		}
		}
		
		public virtual void  undoPairing(Card c, int round)
		{
			Round r = c.getRound(round);
			if (r.opponent != null)
			{
				if (r.color == Card.WHITE)
				{
					c.colorScore--;
					r.opponent.colorScore++;
				}
				else
				{
					c.colorScore++;
					r.opponent.colorScore--;
				}
				r.opponent.updateResult(this, round, Card.UNPLAYED);
				r.opponent.getRound(round).opponent = null;
				r.opponent.getRound(round).color = Card.NONE;
			}
			c.updateResult(this, round, Card.UNPLAYED);
			c.hadBye = false;
			//		r.result = Card.UNPLAYED;
			r.opponent = null;
			r.color = Card.NONE;
		}
		/// <summary>  Pair the next round. Returns false if no legal pairing seems possible of
		/// 
		/// </summary>
		/// <returns>    Description of the Return Value
		/// </returns>
		public virtual bool pairNextRound()
		{
			Pairing pairing;
			prepareNextRound();
			int lastscore = - 1;
			while (!unpairedStack.IsEmpty())
			{
				currentPlayer = (Card) unpairedStack.RemoveFirst();
				//get highest rated unpaired player
				pairing = pairCurrentPlayer();
				//try to pair
				if (pairing != null)
				{
					//we found a pairing
					pairedStack.Add(pairing); //add the pairing to the paired stack
					if (debug)
					{
						System.Console.Out.WriteLine("got pairing");
					}
					continue;
					//continue with next player
				}
				//current player was not pairable
				//forget list of failed pairings for the current player since a previous pairing will have to be undone to continue
				currentPlayer.alreadyTried.Clear();
				unpairedStack.Insert(0, currentPlayer);
				//replace this player back to the front of the unpaired stack
				if (pairedStack.IsEmpty())
				{
					//no pairings to undo
					if (!pairdown)
					{
						pairdown = true;
						continue; //just try to repair everyone
					}
					//huge honking error here!! We can't pair!
					if (debug)
						System.Console.Out.WriteLine("No legal pairings!");
					return false;
				}
				pairing = (Pairing) pairedStack.RemoveLast();
				//undo the more recent pairing
				if (debug)
					System.Console.Out.WriteLine("Undoing pairing " + pairing.playerToPair.pairingNumber + ":" + pairing.opponent.pairingNumber);
				//The playerToPair is still the currentPlayer being processed, so mark this opponent as already tried for pairing
				
				pairing.PlayerToPair.alreadyTried.Add(pairing.Opponent);
				//pairing.PlayerToPair.alreadyTried.add(pairing.opponent);
				//The opponent may have already gone through some pairing attempts, but since we are breaking this pairing we must forget them all
				pairing.opponent.alreadyTried.Clear();
				addCardSorted(pairing.opponent);
				//replace the failed opponent pairing onto the unpaired stack in score and rating order
				/*
				The playerToPair from the last pairing is the highest rated player of the highest
				score group yet unpaired. So we push it back on to the front of unpairedStack so it will
				come right off again at the top of this loop. The difference is that the opponent from
				the broken pairing is now marked as alreadyTried and so a different pairing will be
				attempted
				*/
				unpairedStack.Insert(0, pairing.playerToPair);
			}
			//yeah! We found a complete set of pairings!
			finalizePairings();
			//update the pairing cards
			return true;
			//indicate we successfully paired
		}
		
		
		/// <summary>  Update pairing cards with the pairings</summary>
		public virtual void  finalizePairings()
		{
			System.Collections.IEnumerator walker = pairedStack.ListIterator();
			Pairing pair;
			//UPGRADE_TODO: Method 'java.util.ListIterator.hasNext' was converted to 'System.Collections.IEnumerator.MoveNext' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073_javautilListIteratorhasNext"'
			while (walker.MoveNext())
			{
				//UPGRADE_TODO: Method 'java.util.ListIterator.next' was converted to 'System.Collections.IEnumerator.Current' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073_javautilListIteratornext"'
				pair = (Pairing) walker.Current;
				pair.playerToPair.rounds[roundNumber].opponent = pair.opponent;
				pair.playerToPair.rounds[roundNumber].color = pair.playerColor;
				if (pair.opponent != null)
				{
					if (pair.playerColor == Card.WHITE)
					{
						pair.playerToPair.colorScore++;
						pair.opponent.colorScore--;
					}
					else
					{
						pair.playerToPair.colorScore--;
						pair.opponent.colorScore++;
					}
					pair.opponent.rounds[roundNumber].opponent = pair.playerToPair;
					pair.opponent.rounds[roundNumber].color = (pair.playerColor == Card.WHITE?Card.BLACK:Card.WHITE);
				}
				else
				{
					pair.playerToPair.hadBye = true;
				}
			}
		}
		
		public virtual void  pairPlayers(Card white, Card black)
		{
			white.rounds[roundNumber].opponent = black;
			white.rounds[roundNumber].color = Card.WHITE;
			white.colorScore++;
			black.rounds[roundNumber].opponent = white;
			black.rounds[roundNumber].color = Card.BLACK;
			black.colorScore--;
		}
		
		/// <summary>  Try to pair the first player on the unpaired stack
		/// 
		/// </summary>
		/// <returns>    Pairing candidate for the current player
		/// </returns>
		public virtual Pairing pairCurrentPlayer()
		{
			if (debug)
			{
				System.Console.Out.WriteLine("pairCurrentPlayer");
			}
			Pairing pairing = null;
			
			Card card = null;
			int idx = 0;
			int start;
			int increment = 1;
			int scoreGroupBounds = findScoreGroupBounds();
			//find index in unpaired stack of first player in next score group
			if (scoreGroupBounds == - 1)
			{
				//odd number of players
				//no one left to pair against, try to assign a bye
				if (debug)
					System.Console.Out.WriteLine("assigning bye");
				if (!currentPlayer.hadBye)
				{
					return new Pairing(currentPlayer, null, roundNumber);
				}
				return null;
				//player has already had a bye, return no pairing possible
			}
			if (scoreGroupBounds > 0)
			{
				//there are unpaired players with the same score as the current player to pair
				
				idx = (scoreGroupBounds - 1) >> 1;
				//find the midpoint of those players with the same score
			}
			else
			{
				//no unpaired players with same score
				idx = 0;
				//so we just start with highest rated player in next score group
				scoreGroupBounds = unpairedStack.Count;
				//and continue through last unpaired player
			}
			start = idx;
			//remember where we started this search
			card = (Card) unpairedStack[idx];
			//get the next player to try to pair against
			while (!validatePairing(card))
			{
				//while the pairing is not valid according to our simple SWISS rules
				idx += increment;
				//go to next player index in our current direction of search
				if (idx == scoreGroupBounds)
				{
					if (debug)
					{
						System.Console.Out.WriteLine("Trying higher players");
					}
					//hit the end of the score group
					idx = start - 1;
					//start with entry previous to where we started in this score group
					increment = - 1;
					//and start searching backwards
				}
				if (idx < 0)
				{
					//we've already tried all players in this score group
					//only break up this score group is prefs say so, or we have to, unless it is last round
					if (!flags[2] || roundNumber == this.numRounds)
					{
						if (!allow3color)
						{
							allow3color = true;
							if (debug)
							{
								System.Console.Out.WriteLine("allow3color retry");
							}
							Pairing rc = pairCurrentPlayer();
							if (rc != null)
							{
								allow3color = false;
								allow3colorseq = false;
								allowteam = false;
								return rc;
							}
						}
						if (!allow3colorseq)
						{
							allow3colorseq = true;
							if (debug)
							{
								System.Console.Out.WriteLine("allow3colorseq retry");
							}
							Pairing rc = pairCurrentPlayer();
							if (rc != null)
							{
								allow3color = false;
								allow3colorseq = false;
								allowteam = false;
								return rc;
							}
						}
					}
					if (!flags[3])
					{
						//could not find pairing in score group, check team flag
						if (!allowteam)
						{
							allowteam = true;
							if (debug)
							{
								System.Console.Out.WriteLine("allowteam retry");
							}
							Pairing rc = pairCurrentPlayer();
							if (rc != null)
							{
								allow3color = false;
								allow3colorseq = false;
								allowteam = false;
								return rc;
							}
						}
					}
					if (pairdown)
					{
						if (debug)
						{
							System.Console.Out.WriteLine("bumping to next scoregroup");
						}
						
						//cannot pair this player in score group, move him!
						idx = scoreGroupBounds;
						//so try first player in next score group
						increment = 1;
						//and start searching forward again
					}
					else
					{
						return null;
					}
				}
				if (idx >= unpairedStack.Count)
				{
					if (debug)
					{
						System.Console.Out.WriteLine("nowhere left to pair");
					}
					//nowhere else left to search!
					//                allow3color = false;
					//                allow3colorseq = false;
					return null;
					//no pairing possible
				}
				card = (Card) unpairedStack[idx];
				//get the next pairing candidate
			}
			
			allow3color = false;
			allow3colorseq = false;
			unpairedStack.RemoveElement(card);
			//we found a good possible pairing! Remove the opponent from the unpaired stack
			return new Pairing(currentPlayer, card, roundNumber);
			//create and return the pairing
		}
		
		
		/// <summary>  Returns index of start of next score group
		/// 
		/// </summary>
		/// <returns>    index into unpaired stack of next score group from current player
		/// </returns>
		public virtual int findScoreGroupBounds()
		{
			if (unpairedStack.IsEmpty())
			{
				return - 1;
			}
			System.Collections.IEnumerator iterator = unpairedStack.ListIterator();
			Card card;
			int idx = 0;
			//UPGRADE_TODO: Method 'java.util.ListIterator.hasNext' was converted to 'System.Collections.IEnumerator.MoveNext' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073_javautilListIteratorhasNext"'
			while (iterator.MoveNext())
			{
				//UPGRADE_TODO: Method 'java.util.ListIterator.next' was converted to 'System.Collections.IEnumerator.Current' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073_javautilListIteratornext"'
				card = (Card) iterator.Current;
				if (card.pairingScore != currentPlayer.pairingScore)
				{
					return idx;
				}
				idx++;
			}
			return unpairedStack.Count;
		}
		
		
		
		/// <summary>  Validate an possbile paring between the current player and the indicated
		/// pairing card. Enforces these (Swiss) rules:
		/// <ul>
		/// <li> Players may not have played before</li>
		/// <li> Players must not have already been attempted to be paired in this
		/// iteration</li>
		/// <li> Color allocation cannot result in same player having same color 3
		/// games in a row</li>
		/// <li> Color allocation cannot result in a player having a color three more
		/// times than the other</li>
		/// <li> Players on the same team never play one another</li>
		/// </ul>
		/// 
		/// 
		/// </summary>
		/// <param name="card"> Description of the Parameter
		/// </param>
		/// <returns>       Description of the Return Value
		/// </returns>
		public virtual bool validatePairing(Card card)
		{
			int i;
			if (debug)
				System.Console.Out.WriteLine("validatePairing " + currentPlayer.pairingNumber + " and " + card.pairingNumber);
			//ensure players have not played before
			for (i = 0; i < roundNumber; i++)
			{
				if (currentPlayer.rounds[i].opponent == card)
				{
					if (debug)
						System.Console.Out.WriteLine("already played");
					return false;
				}
			}
			//ensure no attempted pairing against this player this iteration
			if (currentPlayer.alreadyTried.Contains(card))
			{
				if (debug)
					System.Console.Out.WriteLine("already tried");
				return false;
			}
			//ensure teammates do not play one another
			if (!allowteam && (System.Object) currentPlayer.player.team != null && currentPlayer.player.team.Equals(card.player.team))
			{
				if (debug)
					System.Console.Out.WriteLine("same team");
				return false;
			}
			if (!allow3color)
			{
				//ensure color score cannot exceed 2
				if (currentPlayer.colorScore == card.colorScore && System.Math.Abs(currentPlayer.colorScore) == 2)
				{
					if (debug)
						System.Console.Out.WriteLine("colorScore==2");
					return false;
				}
			}
			if (!allow3colorseq)
			{
				//ensure neither player will be forced into the same color 3 times in a row
				if (roundNumber > 1)
				{
					if (currentPlayer.rounds[roundNumber - 1].color == card.rounds[roundNumber - 1].color && currentPlayer.rounds[roundNumber - 2].color == card.rounds[roundNumber - 2].color && currentPlayer.rounds[roundNumber - 1].color == currentPlayer.rounds[roundNumber - 2].color)
					{
						if (debug)
							System.Console.Out.WriteLine(currentPlayer.pairingNumber + " 3 times in a row with " + card.pairingNumber);
						return false;
					}
				}
			}
			return true;
		}
	}
}