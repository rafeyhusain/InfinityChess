using System;
namespace twinfeats.pairings
{
	
	/// <summary>  Description of the Class
	/// 
	/// </summary>
	/// <author>      kent
	/// @created    July 28, 2002
	/// </author>
	[Serializable]
	public class Tournament : System.Runtime.Serialization.ISerializable
	{
		public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			throw new NotImplementedException();
		}

		private void  InitBlock()
		{
			tieBreaks = new int[6];
			sections = new System.Collections.ArrayList(10);
		}
		/// <summary>  Gets the numSections attribute of the Tournament object
		/// 
		/// </summary>
		/// <returns>    The numSections value
		/// </returns>
		virtual public int NumSections
		{
			get
			{
				return sections.Count;
			}
			
		}
		virtual public int NumRatedSections
		{
			get
			{
				int i;
				int n = sections.Count;
				TournamentSection ts;
				int c = 0;
				for (i = 0; i < n; i++)
				{
					ts = (TournamentSection) sections[i];
					if (!ts.isFlag(4))
						c++;
				}
				return c;
			}
			
		}
		//UPGRADE_NOTE: Respective javadoc comments were merged.  It should be changed in order to comply with .NET documentation conventions.
		/// <summary>  Gets the name attribute of the Tournament object
		/// 
		/// </summary>
		/// <returns>    The name value
		/// </returns>
		/// <summary>  Sets the name attribute of the Tournament object
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
		/// <summary>  Gets the date attribute of the Tournament object
		/// 
		/// </summary>
		/// <returns>    The date value
		/// </returns>
		virtual public System.String Date
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
		internal const long serialVersionUID = 1L;
		
		//UPGRADE_NOTE: The initialization of  'sections' was moved to method 'InitBlock'. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1005"'
		internal System.Collections.ArrayList sections;
		internal System.String name;
		internal System.String date;
		//UPGRADE_NOTE: The initialization of  'tieBreaks' was moved to method 'InitBlock'. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1005"'
		internal int[] tieBreaks;
		
		
		/// <summary>  Constructor for the Tournament object</summary>
		public Tournament()
		{
			InitBlock();
		}
		
		
		/// <summary>  Gets the tieBreak attribute of the Tournament object
		/// 
		/// </summary>
		/// <param name="idx"> Description of the Parameter
		/// </param>
		/// <returns>      The tieBreak value
		/// </returns>
		public virtual int getTieBreak(int idx)
		{
			return tieBreaks[idx];
		}
		
		
		/// <summary>  Sets the tieBreak attribute of the Tournament object
		/// 
		/// </summary>
		/// <param name="idx">    The new tieBreak value
		/// </param>
		/// <param name="method"> The new tieBreak value
		/// </param>
		public virtual void  setTieBreak(int idx, int method)
		{
			tieBreaks[idx] = method;
		}
		
		/// <summary>  Description of the Method</summary>
		public virtual void  unmarkAll()
		{
			int i;
			int n = sections.Count;
			TournamentSection ts;
			for (i = 0; i < n; i++)
			{
				ts = (TournamentSection) sections[i];
				ts.Marked = false;
			}
		}
		
		
		/// <summary>  Description of the Method</summary>
		public virtual void  purgeUnmarked()
		{
			TournamentSection ts;
			System.Collections.IEnumerator i = sections.GetEnumerator();

			Object[] sect = sections.ToArray();

			System.Collections.ArrayList lst = new System.Collections.ArrayList();
			lst.AddRange(sect);
			
			for(int j = 0; j< lst.Count; j++)
			{
				ts = (TournamentSection)lst[j];
				if (!ts.marked)
				{
					i = null;
				}
			}


			//UPGRADE_TODO: Method 'java.util.Iterator.hasNext' was converted to 'System.Collections.IEnumerator.MoveNext' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073_javautilIteratorhasNext"'
//			while (i.MoveNext())
//			{
//				//UPGRADE_TODO: Method 'java.util.Iterator.next' was converted to 'System.Collections.IEnumerator.Current' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073_javautilIteratornext"'
//				ts = (TournamentSection) i.Current;
//				;
//				if (!ts.Marked)
//				{					
//					//UPGRADE_ISSUE: Method 'java.util.Iterator.remove' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1000_javautilIteratorremove"'
//					
//					i.remove();
//				}
//			}
		}
		
		
		
		/// <summary>  Gets the section attribute of the Tournament object
		/// 
		/// </summary>
		/// <param name="i"> Description of the Parameter
		/// </param>
		/// <returns>    The section value
		/// </returns>
		public virtual TournamentSection getSection(int i)
		{
			return (TournamentSection) sections[i];
		}
		
		public virtual TournamentSection getRatedSection(int idx)
		{
			int n = NumSections;
			for (int i = 0; i < n; i++)
			{
				TournamentSection s = (TournamentSection) sections[i];
				if (!s.isFlag(4))
				{
					if (idx == 0)
						return s;
					idx--;
				}
			}
			return null;
		}
		/// <summary>  Gets the section attribute of the Tournament object
		/// 
		/// </summary>
		/// <param name="name"> Description of the Parameter
		/// </param>
		/// <returns>       The section value
		/// </returns>
		public virtual TournamentSection getSection(System.String name)
		{
			int i;
			int n = sections.Count;
			TournamentSection ts = null;
			for (i = 0; i < n; i++)
			{
				ts = (TournamentSection) sections[i];
				if (ts.Name.Equals(name))
					return ts;
			}
			return null;
		}
		
		public virtual void  updatePlayer(Player p)
		{
			int i;
			int n = sections.Count;
			TournamentSection ts = null;
			for (i = 0; i < n; i++)
			{
				ts = (TournamentSection) sections[i];
				ts.updatePlayer(p);
			}
		}
		
		
		/// <summary>  Adds a feature to the Section attribute of the Tournament object
		/// 
		/// </summary>
		/// <param name="v"> The feature to be added to the Section attribute
		/// </param>
		public virtual void  addSection(TournamentSection v)
		{
			sections.Add(v);
		}
		
		public virtual void  removeSection(TournamentSection v)
		{
			System.Object temp_object;
			System.Boolean temp_boolean;
			temp_object = v;
			temp_boolean = sections.Contains(temp_object);
			sections.Remove(temp_object);
			bool generatedAux = temp_boolean;
		}
	}
}