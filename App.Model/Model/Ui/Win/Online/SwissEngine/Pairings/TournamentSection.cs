using System;
using System.Runtime.InteropServices;
namespace twinfeats.pairings
{
	
	/// <summary>  Description of the Class
	/// 
	/// </summary>
	/// <author>      kent
	/// @created    July 28, 2002
	/// </author>
	[Serializable]
	public class TournamentSection : System.Runtime.Serialization.ISerializable
	{
		public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			throw new NotImplementedException();
		}

		//UPGRADE_NOTE: Respective javadoc comments were merged.  It should be changed in order to comply with .NET documentation conventions.
		/// <summary>  Gets the numRounds attribute of the Tournament object
		/// 
		/// </summary>
		/// <returns>    The numRounds value
		/// </returns>
		/// <summary>  Sets the numRounds attribute of the TournamentSection object
		/// 
		/// </summary>
		/// <param name="v"> The new numRounds value
		/// </param>
		virtual public int NumRounds
		{
			get
			{
				return numRounds;
			}
			
			set
			{
				numRounds = value;
			}
			
		}
		//UPGRADE_NOTE: Respective javadoc comments were merged.  It should be changed in order to comply with .NET documentation conventions.
		/// <summary>  Gets the marked attribute of the TournamentSection object
		/// 
		/// </summary>
		/// <returns>    The marked value
		/// </returns>
		/// <summary>  Sets the marked attribute of the TournamentSection object
		/// 
		/// </summary>
		/// <param name="v"> The new marked value
		/// </param>
		virtual public bool Marked
		{
			get
			{
				return marked;
			}
			
			set
			{
				marked = value;
			}
			
		}
		//UPGRADE_NOTE: Respective javadoc comments were merged.  It should be changed in order to comply with .NET documentation conventions.
		/// <summary>  Gets the name attribute of the Tournament object
		/// 
		/// </summary>
		/// <returns>    The name value
		/// </returns>
		/// <summary>  Sets the name attribute of the TournamentSection object
		/// 
		/// </summary>
		/// <param name="v"> The new name value
		/// </param>
		virtual public System.String Name
		{
			get
			{
				return name;
			}
			
			set
			{
				name = value;
			}
			
		}
		//UPGRADE_NOTE: Respective javadoc comments were merged.  It should be changed in order to comply with .NET documentation conventions.
		/// <summary>  Gets the date attribute of the Tournament object
		/// 
		/// </summary>
		/// <returns>    The date value
		/// </returns>
		/// <summary>  Sets the date attribute of the TournamentSection object
		/// 
		/// </summary>
		/// <param name="v"> The new date value
		/// </param>
		virtual public System.Globalization.GregorianCalendar Date
		{
			get
			{
				return date;
			}
			
			set
			{
				date = value;
			}
			
		}
		//UPGRADE_NOTE: Respective javadoc comments were merged.  It should be changed in order to comply with .NET documentation conventions.
		/// <summary>  Gets the players attribute of the Tournament object
		/// 
		/// </summary>
		/// <returns>    The players value
		/// </returns>
		/// <summary>  Sets the players attribute of the TournamentSection object
		/// 
		/// </summary>
		/// <param name="v"> The new players value
		/// </param>
		virtual public System.Collections.ArrayList Players
		{
			get
			{
				return players;
			}
			
			set
			{
				players = value;
			}
			
		}
		//UPGRADE_NOTE: Respective javadoc comments were merged.  It should be changed in order to comply with .NET documentation conventions.
		/// <summary>  Gets the engine attribute of the TournamentSection object
		/// 
		/// </summary>
		/// <returns>    The engine value
		/// </returns>
		/// <summary>  Sets the engine attribute of the TournamentSection object
		/// 
		/// </summary>
		/// <param name="v"> The new engine value
		/// </param>
		virtual public Engine Engine
		{
			get
			{
				return engine;
			}
			
			set
			{
				engine = value;
			}
			
		}
		//UPGRADE_NOTE: Respective javadoc comments were merged.  It should be changed in order to comply with .NET documentation conventions.
		/// <summary>  Gets the byePoints attribute of the TournamentSection object
		/// 
		/// </summary>
		/// <returns>    The byePoints value
		/// </returns>
		/// <summary>  Sets the byePoints attribute of the TournamentSection object
		/// 
		/// </summary>
		/// <param name="v"> The new byePoints value
		/// </param>
		virtual public int ByePoints
		{
			get
			{
				return byePoints;
			}
			
			set
			{
				byePoints = value;
			}
			
		}
		//UPGRADE_NOTE: Respective javadoc comments were merged.  It should be changed in order to comply with .NET documentation conventions.
		/// <returns> Returns the lastPlayersCount.
		/// </returns>
		/// <param name="lastPlayersCount">The lastPlayersCount to set.
		/// </param>
		virtual public int LastPlayersCount
		{
			get
			{
				return lastPlayersCount;
			}
			
			set
			{
				this.lastPlayersCount = value;
			}
			
		}
		virtual public bool[] Flags
		{
			get
			{
				return flags;
			}
			
		}
		internal const long serialVersionUID = 1L;
		
		internal int numRounds, byePoints;
		internal bool[] flags;
		//	boolean accelPairings, quickRatings, scoreGroups, teamPriority;
		internal System.String name;
		internal System.Globalization.GregorianCalendar date;
		internal System.Collections.ArrayList players;
		internal Engine engine;
		[NonSerialized()]
		internal bool marked;
		[NonSerialized()]
		internal int lastPlayersCount = 0;
		
		
		/// <summary>  Constructor for the Tournament object</summary>
		public TournamentSection()
		{
			flags = new bool[5];
		}
		
		public virtual void  addPlayer(Player p)
		{
			if (players == null)
				players = new System.Collections.ArrayList(10);
			players.Add(p);
		}
		
		public virtual void  removePlayer(Player p)
		{
			System.Object temp_object;
			System.Boolean temp_boolean;
			temp_object = p;
			temp_boolean = players.Contains(temp_object);
			players.Remove(temp_object);
			bool generatedAux = temp_boolean;
		}
		
		public virtual Player updatePlayer(Player player)
		{
			//	    System.out.println("Tournament.updatePlayer ");
			for (int i = 0; i < players.Count; i++)
			{
				Player p = (Player) players[i];
				//	        System.out.println(p.getFullName()+" "+p.getMemberNumber());
				//	        if (p.getMemberNumber() == null || p.getMemberNumber().equals("") || p.getMemberNumber().equals("id#") || p.getMemberNumber().equals("xxxx")) {
				if (p.isEqual(player))
				{
					players[i] = player;
					System.Object generatedAux = player;
					if (engine != null)
					{
						engine.updatePlayer(player);
					}
				}
				/*	        }
				else if (p.equals(player)) {
				players.set(i,player);
				if (engine != null) {
				engine.updatePlayer(player);
				}
				} */
			}
			return null;
		}
		
		public virtual bool isFlag(int idx)
		{
			return flags[idx];
		}
		
		public virtual void  setFlag(bool v, int idx)
		{
			flags[idx] = v;
		}
	}
}