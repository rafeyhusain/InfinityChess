using System;
namespace twinfeats.db
{
	
	/// <summary>  Description of the Class
	/// 
	/// </summary>
	/// <author>      smok01
	/// @created    July 25, 2002
	/// </author>
	public class SimpleDB
	{
		/// <summary>  Gets the count attribute of the SimpleDB object
		/// 
		/// </summary>
		/// <returns>                  The count value
		/// </returns>
		/// <exception cref="">  IOException  Description of the Exception
		/// </exception>
		virtual public int Count
		{
			get
			{
				return count;
			}
			
		}
		/// <summary>  Description of the Field</summary>
		public static long HEADER_SIZE = 4L;
		
		internal System.IO.FileStream file;
		internal int recordSize, count;
		internal sbyte[] readBuffer, writeBuffer, zapBuffer;
		internal sbyte[] bigBuffer;
		internal int bufferIdx = - 100;
		
		/// <summary>  The main program for the SimpleDB class
		/// 
		/// </summary>
		/// <param name="args">          The command line arguments
		/// </param>
		/// <exception cref="">  Exception  Description of the Exception
		/// </exception>
		[STAThread]
		public static void  Main1(System.String[] args)
		{
			SimpleDB db = new SimpleDB("simple.db", 100, false);
			for (int i = 0; i < 10000; i++)
				db.write("Just some text line number " + i);
			for (int i = 0; i < db.Count; i++)
				System.Console.Out.WriteLine(db.read(i));
			db.close();
		}
		
		
		/// <summary>  Constructor for the SimpleDB object
		/// 
		/// </summary>
		/// <param name="name">                      Description of the Parameter
		/// </param>
		/// <param name="readOnly">                  Description of the Parameter
		/// </param>
		/// <exception cref="">  FileNotFoundException  Description of the Exception
		/// </exception>
		/// <exception cref="">  IOException            Description of the Exception
		/// </exception>
		public SimpleDB(System.String name, bool readOnly)
		{
			System.IO.FileInfo f = new System.IO.FileInfo(name);
			bool tmpBool;
			if (System.IO.File.Exists(f.FullName))
				tmpBool = true;
			else
				tmpBool = System.IO.Directory.Exists(f.FullName);
			if (!tmpBool)
				throw new System.IO.FileNotFoundException("name");
			file = SupportClass.RandomAccessFileSupport.CreateRandomAccessFile(name, readOnly?"r":"rw");
			file.Seek(0, System.IO.SeekOrigin.Begin);
			System.IO.BinaryReader temp_BinaryReader;
			temp_BinaryReader = new System.IO.BinaryReader(file);
			temp_BinaryReader.BaseStream.Position = file.Position;
			recordSize = temp_BinaryReader.ReadInt32();
			readBuffer = new sbyte[recordSize];
			bigBuffer = new sbyte[recordSize * 100];
			writeBuffer = new sbyte[recordSize];
			createZapBuffer();
			long size = file.Length;
			count = (int) ((size - HEADER_SIZE) / recordSize);
		}
		
		
		/// <summary>  Constructor for the SimpleDB object
		/// 
		/// </summary>
		/// <param name="name">                      Description of the Parameter
		/// </param>
		/// <param name="recordSize">                Description of the Parameter
		/// </param>
		/// <param name="readOnly">                  Description of the Parameter
		/// </param>
		/// <exception cref="">  FileNotFoundException  Description of the Exception
		/// </exception>
		/// <exception cref="">  IOException            Description of the Exception
		/// </exception>
		public SimpleDB(System.String name, int recordSize, bool readOnly)
		{
			this.recordSize = recordSize + 1; //account for \n at end for manual editing convenience
			System.IO.FileInfo f = new System.IO.FileInfo(name);
			bool tmpBool;
			if (System.IO.File.Exists(f.FullName))
				tmpBool = true;
			else
				tmpBool = System.IO.Directory.Exists(f.FullName);
			bool exists = tmpBool;
			file = SupportClass.RandomAccessFileSupport.CreateRandomAccessFile(name, readOnly?"r":"rw");
			if (!exists)
			{
				System.IO.BinaryWriter temp_BinaryWriter;
				temp_BinaryWriter = new System.IO.BinaryWriter(file);
				temp_BinaryWriter.Write((System.Int32) this.recordSize);
			}
			else
			{
				file.Seek(0, System.IO.SeekOrigin.Begin);
				System.IO.BinaryReader temp_BinaryReader;
				temp_BinaryReader = new System.IO.BinaryReader(file);
				temp_BinaryReader.BaseStream.Position = file.Position;
				this.recordSize = temp_BinaryReader.ReadInt32();
			}
			readBuffer = new sbyte[this.recordSize];
			writeBuffer = new sbyte[this.recordSize];
			bigBuffer = new sbyte[this.recordSize * 100];
			createZapBuffer();
			long size = file.Length;
			count = (int) ((size - HEADER_SIZE) / this.recordSize);
		}
		
		
		/// <summary>  Constructor for the createZapBuffer object</summary>
		private void  createZapBuffer()
		{
			zapBuffer = new sbyte[recordSize];
			for (int i = 0; i < recordSize - 1; i++)
				zapBuffer[i] = Convert.ToSByte('^');
			zapBuffer[recordSize - 1] = Convert.ToSByte('\n');
		}
		
		
		/// <summary>  Description of the Method
		/// 
		/// </summary>
		/// <exception cref="">  IOException  Description of the Exception
		/// </exception>
		public virtual void  close()
		{
			file.Close();
		}
		
		
		
		/// <summary>  Description of the Method
		/// 
		/// </summary>
		/// <param name="recordNumber">    Description of the Parameter
		/// </param>
		/// <returns>                  Description of the Return Value
		/// </returns>
		/// <exception cref="">  IOException  Description of the Exception
		/// </exception>
		//UPGRADE_NOTE: Synchronized keyword was removed from method 'read'. Lock expression was added. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1027"'
		public virtual System.String read(int recordNumber)
		{
			lock (this)
			{
				if (recordNumber < bufferIdx || recordNumber >= bufferIdx + 100)
				{
					bufferIdx = (recordNumber / 100) * 100;
					file.Seek(bufferIdx * recordSize + HEADER_SIZE, System.IO.SeekOrigin.Begin);
					if (bufferIdx + 100 >= count)
					{
						SupportClass.ReadInput(file, ref bigBuffer, 0, (count - bufferIdx) * recordSize);
					}
					else
					{
						SupportClass.ReadInput(file, ref bigBuffer, 0, bigBuffer.Length);
					}
				}
				//		long idx = (long)recordNumber * (long)recordSize + HEADER_SIZE;
				int idx = (recordNumber - bufferIdx) * recordSize;
				//		System.out.println("rn="+recordNumber+",bi="+bufferIdx+",idx="+idx+",rs="+recordSize+",bbs="+bigBuffer.length+",bs="+readBuffer.length);
				try
				{
					Array.Copy(SupportClass.ToByteArray(bigBuffer), idx, SupportClass.ToByteArray(readBuffer), 0, recordSize);
					//Array.Copy(SupportClass.ToByteArray((System.Array) bigBuffer), idx, SupportClass.ToByteArray((System.Array) readBuffer), 0, recordSize);
				}
				catch (System.Exception e)
				{
					SupportClass.WriteStackTrace(e, Console.Error);
					System.Console.Out.WriteLine("rn=" + recordNumber + ",bi=" + bufferIdx + ",idx=" + idx + ",rs=" + recordSize + ",bbs=" + bigBuffer.Length + ",bs=" + readBuffer.Length);
				}
				/*
				file.seek(idx);
				file.readFully(readBuffer);*/
				//		System.out.println("read id="+recordNumber+":"+(new String(readBuffer,0,recordSize)));
				for (int i = 0; i < recordSize; i++)
					if (readBuffer[i] == '^')
					{
						char[] tmpChar;
						tmpChar = new char[readBuffer.Length];
						readBuffer.CopyTo(tmpChar, 0);
						return new System.String(tmpChar, 0, i);
					}
				char[] tmpChar2;
				tmpChar2 = new char[readBuffer.Length];
				readBuffer.CopyTo(tmpChar2, 0);
				return new System.String(tmpChar2, 0, recordSize - 1);
			}
		}
		
		
		/// <summary>  Description of the Method
		/// 
		/// </summary>
		/// <param name="recordNumber">    Description of the Parameter
		/// </param>
		/// <exception cref="">  IOException  Description of the Exception
		/// </exception>
		public virtual void  remove(int recordNumber)
		{
			long size = file.Length;
			long idx = (long) (recordNumber + 1) * (long) recordSize + HEADER_SIZE;
			if (recordNumber == count - 1)
			{
				//UPGRADE_TODO: Method 'java.io.RandomAccessFile.setLength' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1095"'
				file.SetLength(idx);
			}
			else
			{
				sbyte[] bigBuffer = new sbyte[(int) (size - idx)];
				file.Seek(idx, System.IO.SeekOrigin.Begin);
				SupportClass.ReadInput(file, ref bigBuffer, 0, bigBuffer.Length);
				file.Seek(idx - recordSize, System.IO.SeekOrigin.Begin);
				SupportClass.RandomAccessFileSupport.WriteRandomFile(bigBuffer, file);
				//UPGRADE_TODO: Method 'java.io.RandomAccessFile.setLength' was not converted. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1095"'
				file.SetLength(size - recordSize);
			}
		}
		
		
		/// <summary>  Description of the Method
		/// 
		/// </summary>
		/// <param name="value">           Description of the Parameter
		/// </param>
		/// <param name="recordNumber">    Description of the Parameter
		/// </param>
		/// <returns>                  Description of the Return Value
		/// </returns>
		/// <exception cref="">  IOException  Description of the Exception
		/// </exception>
		public virtual bool write(System.String value_Renamed, int recordNumber)
		{
			if (recordNumber >= count)
				return false;
			fillWriteBuffer(value_Renamed);
			long idx = (long) recordNumber * (long) recordSize + HEADER_SIZE;
			file.Seek(idx, System.IO.SeekOrigin.Begin);
			SupportClass.RandomAccessFileSupport.WriteRandomFile(writeBuffer, file);
			bufferIdx = - 100;
			return true;
		}
		
		
		/// <summary>  Description of the Method
		/// 
		/// </summary>
		/// <param name="value">           Description of the Parameter
		/// </param>
		/// <returns>                  Description of the Return Value
		/// </returns>
		/// <exception cref="">  IOException  Description of the Exception
		/// </exception>
		public virtual int write(System.String value_Renamed)
		{
			fillWriteBuffer(value_Renamed);
			file.Seek(file.Length, System.IO.SeekOrigin.Begin);
			SupportClass.RandomAccessFileSupport.WriteRandomFile(writeBuffer, file);
			bufferIdx = - 100;
			return count++;
		}
		
		
		/// <summary>  Description of the Method
		/// 
		/// </summary>
		/// <param name="value"> Description of the Parameter
		/// </param>
		private void  fillWriteBuffer(System.String value_Renamed)
		{
			int len = value_Renamed.Length;
			sbyte[] buffer = SupportClass.ToSByteArray(SupportClass.ToByteArray(value_Renamed));
			
			if (len < (recordSize - 1))
			{
				//account for end of line char
				Array.Copy(SupportClass.ToByteArray(buffer), 0, SupportClass.ToByteArray(writeBuffer), 0, len);
				Array.Copy(SupportClass.ToByteArray(zapBuffer), 0, SupportClass.ToByteArray(writeBuffer), len, recordSize - len - 1);
				writeBuffer[recordSize - 1] = Convert.ToSByte('\n');
			}
			else
			{
				Array.Copy(SupportClass.ToByteArray(buffer), 0, SupportClass.ToByteArray(writeBuffer), 0, recordSize - 1);
				writeBuffer[recordSize - 1] = zapBuffer[recordSize - 1];
			}
		}
	}
}