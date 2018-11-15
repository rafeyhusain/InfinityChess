using System;
namespace twinfeats.db
{
	
	/// <summary>  Description of the Class
	/// 
	/// </summary>
	/// <author>      kent
	/// @created    July 25, 2002
	/// </author>
	public class DBase3
	{
		private void  InitBlock()
		{
			fieldsHash = new System.Collections.Hashtable();
		}
		/// <summary>  Gets the numRecords attribute of the DBase3 object
		/// 
		/// </summary>
		/// <returns>    The numRecords value
		/// </returns>
		virtual public int NumRecords
		{
			get
			{
				return numRecords;
			}
			
		}
		/// <summary>  Gets the numFields attribute of the DBase3 object
		/// 
		/// </summary>
		/// <returns>    The numFields value
		/// </returns>
		virtual public int NumFields
		{
			get
			{
				return fields.Length;
			}
			
		}
		internal System.IO.FileStream db;
		internal int numRecords;
		internal short recordSize;
		internal FieldDescriptor[] fields;
		internal short hdrSize;
		internal short longestFieldLength;
		internal bool cache;
		internal sbyte[] fileBuffer;
		internal int fileOffset;
		//UPGRADE_NOTE: The initialization of  'fieldsHash' was moved to method 'InitBlock'. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1005"'
		internal System.Collections.Hashtable fieldsHash;
		
		
		/// <summary>  The main program for the DBase3 class
		/// 
		/// </summary>
		/// <param name="args">          The command line arguments
		/// </param>
		/// <exception cref="">  Exception  Description of the Exception
		/// </exception>
		[STAThread]
		public static void  Main1(System.String[] args)
		{
			DBase3 db = new DBase3("dbase3.dbf", false);
			DBase3Record rec = null;
			for (int i = 0; i < db.NumRecords; i++)
			{
				rec = db.read(i);
				//UPGRADE_TODO: Method 'java.io.PrintStream.println' was converted to 'System.Console.WriteLine' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073"'
				System.Console.Out.WriteLine(rec);
			}
			//UPGRADE_TODO: Method 'java.io.PrintStream.println' was converted to 'System.Console.WriteLine' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073"'
			System.Console.Out.WriteLine(rec);
		}
		
		
		/// <summary>  Constructor for the DBase3 object
		/// 
		/// </summary>
		/// <param name="name">                      Description of the Parameter
		/// </param>
		/// <param name="cacheEntireFile">           Description of the Parameter
		/// </param>
		/// <exception cref="">  FileNotFoundException  Description of the Exception
		/// </exception>
		/// <exception cref="">  IOException            Description of the Exception
		/// </exception>
		public DBase3(System.String name, bool cacheEntireFile)
		{
			InitBlock();
			cache = cacheEntireFile;
			System.IO.FileInfo file = new System.IO.FileInfo(name);
			bool tmpBool;
			if (System.IO.File.Exists(file.FullName))
				tmpBool = true;
			else
				tmpBool = System.IO.Directory.Exists(file.FullName);
			if (!tmpBool)
				throw new System.IO.FileNotFoundException(name);
			//		db = new RandomAccessFile(file, readOnly ? "r" : "rw");
			db = SupportClass.RandomAccessFileSupport.CreateRandomAccessFile(file, "r");
			db.Seek(0, System.IO.SeekOrigin.Begin);
			readHeader();
			if (cache)
			{
				int n = (int) db.Length;
				fileBuffer = new sbyte[n];
				db.Seek(0, System.IO.SeekOrigin.Begin);
				SupportClass.ReadInput(db, ref fileBuffer, 0, fileBuffer.Length);
			}
		}
		
		public DBase3(System.String name, int numfields)
		{
			InitBlock();
			recordSize = 1;
			db = SupportClass.RandomAccessFileSupport.CreateRandomAccessFile(name, "rw");
			//UPGRADE_TODO: Method 'java.io.RandomAccessFile.setLength' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1095"'
			
			db.SetLength(0);
			fields = new FieldDescriptor[numfields];
			hdrSize = (short) (33 + 32 * fields.Length);
		}
		
		public virtual void  close()
		{
			db.Close();
			db = null;
		}
		
		public virtual void  setFieldHeader(int idx, System.String name, sbyte length, sbyte type)
		{
			fields[idx] = new FieldDescriptor(this, name, length, type);
			recordSize = (short) (recordSize + length);
		}
		/// <summary>  Description of the Method
		/// 
		/// </summary>
		/// <param name="row">             Description of the Parameter
		/// </param>
		/// <returns>                  Description of the Return Value
		/// </returns>
		/// <exception cref="">  IOException  Description of the Exception
		/// </exception>
		public virtual DBase3Record read(int row)
		{
			long idx = hdrSize + row * recordSize;
			if (!cache)
				db.Seek(idx, System.IO.SeekOrigin.Begin);
			else
				fileOffset = (int) idx;
			return new DBase3Record(this);
		}
		
		public virtual void  write(DBase3Record rec)
		{
			db.Seek(db.Length, System.IO.SeekOrigin.Begin);
			SupportClass.RandomAccessFileSupport.WriteRandomFile(rec.Bytes, db);
			numRecords++;
		}
		
		public virtual void  update(DBase3Record rec, int row)
		{
			long idx = hdrSize + row * recordSize;
			db.Seek(idx, System.IO.SeekOrigin.Begin);
			SupportClass.RandomAccessFileSupport.WriteRandomFile(rec.Bytes, db);
		}
		
		
		/// <summary>  Description of the Method
		/// 
		/// </summary>
		/// <exception cref="">  IOException  Description of the Exception
		/// </exception>
		internal virtual void  readHeader()
		{
			sbyte[] buffer = new sbyte[32];
			db.Seek(4, System.IO.SeekOrigin.Begin);
			numRecords = readInt();
			hdrSize = readShort();
			recordSize = readShort();
			int offset = 32;
			int numFields = (hdrSize - 1 - 32) / 32;
			fields = new FieldDescriptor[numFields];
			for (int i = 0; i < numFields; i++)
			{
				db.Seek(offset, System.IO.SeekOrigin.Begin);
				fields[i] = new FieldDescriptor(this);
				SupportClass.PutElement(fieldsHash, fields[i].name, i);
				if (fields[i].length > longestFieldLength)
					longestFieldLength = fields[i].length;
				offset += 32;
			}
			offset++; //skip 0x0d on the end of the header
			//		hdrSize++;
			if (((db.Length - hdrSize - 1) % recordSize) != 0)
			{
				System.Console.Error.WriteLine("Warning: File sizeindicates a partial record is present");
			}
			int count = (int) ((db.Length - hdrSize - 1) / recordSize);
			if (count != numRecords)
			{
				System.Console.Error.WriteLine("Warning: Number of records does not match filesize, using filesize");
				numRecords = count;
			}
		}
		
		public virtual void  writeHeader()
		{
			db.Seek(0, System.IO.SeekOrigin.Begin);
			db.WriteByte((System.Byte) 0x03);
			System.Globalization.GregorianCalendar gc = new System.Globalization.GregorianCalendar();
			//UPGRADE_TODO: Method 'java.util.Calendar.get' was converted to 'SupportClass.CalendarManager.Get' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073_javautilCalendarget_int"'
			int y = SupportClass.CalendarManager.manager.Get(gc, SupportClass.CalendarManager.YEAR) - 1900;
			//UPGRADE_TODO: Method 'java.util.Calendar.get' was converted to 'SupportClass.CalendarManager.Get' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073_javautilCalendarget_int"'
			int m = SupportClass.CalendarManager.manager.Get(gc, SupportClass.CalendarManager.MONTH) + 1;
			//UPGRADE_TODO: Method 'java.util.Calendar.get' was converted to 'SupportClass.CalendarManager.Get' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073_javautilCalendarget_int"'
			int d = SupportClass.CalendarManager.manager.Get(gc, SupportClass.CalendarManager.DAY_OF_MONTH);
			db.WriteByte((System.Byte) y);
			db.WriteByte((System.Byte) m);
			db.WriteByte((System.Byte) d);
			writeInt(numRecords);
			writeShort(hdrSize);
			writeShort(recordSize);
			for (int i = 0; i < 20; i++)
				db.WriteByte((System.Byte) 0);
			for (int i = 0; i < fields.Length; i++)
			{
				fields[i].writeHeader();
			}
			db.WriteByte((System.Byte) 0x0d);
		}
		
		public virtual void  updateHeaderNumRecords()
		{
			db.Seek(4, System.IO.SeekOrigin.Begin);
			writeInt(numRecords);
		}
		/// <summary>  Description of the Method
		/// 
		/// </summary>
		/// <returns>                  Description of the Return Value
		/// </returns>
		/// <exception cref="">  IOException  Description of the Exception
		/// </exception>
		internal virtual int readInt()
		{
			int b1 = (sbyte) db.ReadByte();
			if (b1 < 0)
				b1 += 256;
			int b2 = (sbyte) db.ReadByte();
			if (b2 < 0)
				b2 += 256;
			int b3 = (sbyte) db.ReadByte();
			if (b3 < 0)
				b3 += 256;
			int b4 = (sbyte) db.ReadByte();
			if (b4 < 0)
				b4 += 256;
			return (b4 << 24) + (b3 << 16) + (b2 << 8) + b1;
		}
		
		internal virtual void  writeInt(int v)
		{
			sbyte b4 = (sbyte) (v >> 24);
			sbyte b3 = (sbyte) ((v & 0x00ff0000) >> 16);
			sbyte b2 = (sbyte) ((v & 0x0000ff00) >> 8);
			sbyte b1 = (sbyte) (v & 0x000000ff);
			db.WriteByte((byte) b1);
			db.WriteByte((byte) b2);
			db.WriteByte((byte) b3);
			db.WriteByte((byte) b4);
		}
		
		internal virtual void  writeShort(short v)
		{
			sbyte b2 = (sbyte) ((v & 0xff00) >> 8);
			sbyte b1 = (sbyte) (v & 0x00ff);
			db.WriteByte((byte) b1);
			db.WriteByte((byte) b2);
		}
		internal virtual void  writeString(System.String v, int length, char pad, bool leftpad)
		{
			System.Text.StringBuilder buf = new System.Text.StringBuilder(length);
			if (v.Length > length)
			{
				v = v.Substring(0, (length) - (0));
			}
			if (leftpad)
			{
				for (int i = v.Length; i < length; i++)
					buf.Append(pad);
			}
			buf.Append(v);
			if (!leftpad)
			{
				for (int i = v.Length; i < length; i++)
					buf.Append(pad);
			}
			SupportClass.RandomAccessFileSupport.WriteBytes(buf.ToString(), db);
		}
		
		public static System.String makeString(System.String v, int length, char pad, bool leftpad)
		{
			System.Text.StringBuilder buf = new System.Text.StringBuilder(length);
			if (v.Length > length)
			{
				v = v.Substring(0, (length) - (0));
			}
			if (leftpad)
			{
				for (int i = v.Length; i < length; i++)
					buf.Append(pad);
			}
			buf.Append(v);
			if (!leftpad)
			{
				for (int i = v.Length; i < length; i++)
					buf.Append(pad);
			}
			return (buf.ToString());
		}
		/// <summary>  Description of the Method
		/// 
		/// </summary>
		/// <returns>                  Description of the Return Value
		/// </returns>
		/// <exception cref="">  IOException  Description of the Exception
		/// </exception>
		internal virtual short readShort()
		{
			short b1 = (sbyte) db.ReadByte();
			if (b1 < 0)
				b1 = (short) (b1 + 256);
			short b2 = (sbyte) db.ReadByte();
			if (b2 < 0)
				b2 = (short) (b2 + 256);
			return (short) ((b2 << 8) + b1);
		}
		
		
		/// <summary>  Gets the fieldName attribute of the DBase3 object
		/// 
		/// </summary>
		/// <param name="i"> Description of the Parameter
		/// </param>
		/// <returns>    The fieldName value
		/// </returns>
		public virtual System.String getFieldName(int i)
		{
			return fields[i].name;
		}
		
		
		//UPGRADE_NOTE: Field 'EnclosingInstance' was added to class 'FieldDescriptor' to access its enclosing instance. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1019"'
		/// <summary>  Description of the Class
		/// 
		/// </summary>
		/// <author>      kent
		/// @created    July 25, 2002
		/// </author>
		internal class FieldDescriptor
		{
			private void  InitBlock(DBase3 enclosingInstance)
			{
				this.enclosingInstance = enclosingInstance;
			}
			private DBase3 enclosingInstance;
			public DBase3 Enclosing_Instance
			{
				get
				{
					return enclosingInstance;
				}
				
			}
			internal System.String name;
			internal sbyte type;
			internal short length;
			
			
			/// <summary>  Constructor for the FieldDescriptor object
			/// 
			/// </summary>
			/// <exception cref="">  IOException  Description of the Exception
			/// </exception>
			internal FieldDescriptor(DBase3 enclosingInstance)
			{
				InitBlock(enclosingInstance);
				sbyte[] buffer = new sbyte[11];
				SupportClass.ReadInput(Enclosing_Instance.db, ref buffer, 0, buffer.Length);
				type = (sbyte) Enclosing_Instance.db.ReadByte();
				Enclosing_Instance.db.Seek(Enclosing_Instance.db.Position + 4, System.IO.SeekOrigin.Begin);
				length = (sbyte) Enclosing_Instance.db.ReadByte();
				name = twinfeats.db.DBase3.getString(buffer, 11);
				if (length < 0)
					length = (short) (length + 256);
			}
			
			internal FieldDescriptor(DBase3 enclosingInstance, System.String name, short length, sbyte type)
			{
				InitBlock(enclosingInstance);
				this.name = name;
				this.length = length;
				this.type = type;
			}
			
			internal virtual void  writeHeader()
			{
				Enclosing_Instance.writeString(name, 10, (char) 0, false);
				Enclosing_Instance.db.WriteByte((System.Byte) 0);
				Enclosing_Instance.db.WriteByte((byte) type);
				System.IO.BinaryWriter temp_BinaryWriter;
				temp_BinaryWriter = new System.IO.BinaryWriter(Enclosing_Instance.db);
				temp_BinaryWriter.Write((System.Int32) 0);
				Enclosing_Instance.db.WriteByte((System.Byte) length);
				for (int i = 0; i < 15; i++)
					Enclosing_Instance.db.WriteByte((System.Byte) 0);
			}
		}
		
		
		/// <summary>  Gets the string attribute of the DBase3 class
		/// 
		/// </summary>
		/// <param name="buffer"> Description of the Parameter
		/// </param>
		/// <param name="len">    Description of the Parameter
		/// </param>
		/// <returns>         The string value
		/// </returns>
		internal static System.String getString(sbyte[] buffer, int len)
		{
			for (int i = 0; i < len; i++)
				if (buffer[i] == 0)
				{
					char[] tmpChar;
					tmpChar = new char[buffer.Length];
					buffer.CopyTo(tmpChar, 0);
					return (new System.String(tmpChar, 0, i)).Trim();
				}
			char[] tmpChar2;
			tmpChar2 = new char[buffer.Length];
			buffer.CopyTo(tmpChar2, 0);
			return (new System.String(tmpChar2, 0, len)).Trim();
		}
	}
}