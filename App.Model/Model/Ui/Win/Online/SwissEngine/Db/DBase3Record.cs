using System;
namespace twinfeats.db
{
	
	/// <summary>  Description of the Class
	/// 
	/// </summary>
	/// <author>      kent
	/// @created    July 25, 2002
	/// </author>
	public class DBase3Record
	{
		virtual public DBase3 Db
		{
			set
			{
				this.db = value;
				values = new System.String[value.fields.Length];
				for (int i = 0; i < value.fields.Length; i++)
				{
					values[i] = "";
				}
			}
			
		}
		virtual public bool Deleted
		{
			get
			{
				return deleted;
			}
			
		}
		virtual public sbyte[] Bytes
		{
			get
			{
				sbyte[] buffer = new sbyte[db.recordSize];
				for (int i = 0; i < db.recordSize; i++)
				{
					buffer[i] = (sbyte) SupportClass.Identity(' ');
				}
				int offset = 1;
				for (int i = 0; i < values.Length; i++)
				{
					for (int j = 0; j < values[i].Length; j++)
					{
						buffer[offset + j] = (sbyte) values[i][j];
					}
					offset += db.fields[i].length;
				}
				return buffer;
			}
			
		}
		internal DBase3 db;
		internal System.String[] values;
		internal bool deleted;
		
		/// <summary>  Constructor for the DBase3Record object
		/// 
		/// </summary>
		/// <param name="db">              Description of the Parameter
		/// </param>
		/// <exception cref="">  IOException  Description of the Exception
		/// </exception>
		public DBase3Record(DBase3 db)
		{
			this.db = db;
			values = new System.String[db.fields.Length];
			sbyte[] buffer = new sbyte[db.longestFieldLength];
			deleted = (db.db.ReadByte() == (int) '*');
			for (int i = 0; i < values.Length; i++)
			{
				//			buffer = new byte[db.fields[i].length];
				if (!db.cache)
					SupportClass.ReadInput(db.db, ref buffer, 0, db.fields[i].length);
				else
				{
					Array.Copy(SupportClass.ToByteArray(db.fileBuffer), db.fileOffset, SupportClass.ToByteArray(buffer), 0, db.fields[i].length);
					db.fileOffset += db.fields[i].length;
				}
				//			System.out.println(new String(buffer));
				values[i] = DBase3.getString(buffer, db.fields[i].length);
				//			System.out.println(values[i]);
			}
		}
		
		public DBase3Record()
		{
		}
		
		public DBase3Record(DBase3 db, int numfields)
		{
			values = new System.String[numfields];
			this.db = db;
		}
		
		public virtual bool setFieldByName(System.String name, System.String value_Renamed)
		{
			System.Int32 i = (System.Int32) db.fieldsHash[name];
			if ((System.Object) i == null)
				return false;
			if ((System.Object) value_Renamed == null)
				value_Renamed = "";
			values[i] = value_Renamed;
			return true;
		}
		
		public virtual void  setField(System.String value_Renamed, int idx)
		{
			values[idx] = value_Renamed;
		}
		
		/// <summary>  Gets the fieldValue attribute of the DBase3Record object
		/// 
		/// </summary>
		/// <param name="idx"> Description of the Parameter
		/// </param>
		/// <returns>      The fieldValue value
		/// </returns>
		public virtual System.String getFieldValue(int idx)
		{
			return values[idx];
		}
		
		
		/// <summary>  Gets the fieldByName attribute of the DBase3Record object
		/// 
		/// </summary>
		/// <param name="name"> Description of the Parameter
		/// </param>
		/// <returns>       The fieldByName value
		/// </returns>
		public virtual System.String getFieldByName(System.String name)
		{
			System.Int32 i = (System.Int32) db.fieldsHash[name];
			if ((System.Object) i == null)
				return null;
			return values[i];
		}
		
		
		/// <summary>  Description of the Method
		/// 
		/// </summary>
		/// <returns>    Description of the Return Value
		/// </returns>
		public override System.String ToString()
		{
			System.Text.StringBuilder buf = new System.Text.StringBuilder(40);
			for (int i = 0; i < values.Length; i++)
			{
				buf.Append(db.getFieldName(i));
				buf.Append("=");
				buf.Append(values[i]);
				buf.Append("^");
			}
			return buf.ToString();
		}
	}
}