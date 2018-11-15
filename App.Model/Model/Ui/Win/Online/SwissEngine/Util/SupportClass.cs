//
// In order to convert some functionality to Visual C#, the Java Language Conversion Assistant
// creates "support classes" that duplicate the original functionality.  
//
// Support classes replicate the functionality of the original code, but in some cases they are 
// substantially different architecturally. Although every effort is made to preserve the 
// original architecture of the application in the converted project, the user should be aware that 
// the primary goal of these support classes is to replicate functionality, and that at times 
// the architecture of the resulting solution may differ somewhat.
//

using System;

	/// <summary>
	/// This interface should be implemented by any class whose instances are intended 
	/// to be executed by a thread.
	/// </summary>
	public interface IThreadRunnable
	{
		/// <summary>
		/// This method has to be implemented in order that starting of the thread causes the object's 
		/// run method to be called in that separately executing thread.
		/// </summary>
		void Run();
	}

/// <summary>
/// Contains conversion support elements such as classes, interfaces and static methods.
/// </summary>
public class SupportClass
{
	/// <summary>
	/// Converts an array of sbytes to an array of chars
	/// </summary>
	/// <param name="sByteArray">The array of sbytes to convert</param>
	/// <returns>The new array of chars</returns>
	public static char[] ToCharArray(sbyte[] sByteArray) 
	{
		char[] charArray = new char[sByteArray.Length];	   
		sByteArray.CopyTo(charArray, 0);
		return charArray;
	}

	/// <summary>
	/// Converts an array of bytes to an array of chars
	/// </summary>
	/// <param name="byteArray">The array of bytes to convert</param>
	/// <returns>The new array of chars</returns>
	public static char[] ToCharArray(byte[] byteArray) 
	{
		char[] charArray = new char[byteArray.Length];	   
		byteArray.CopyTo(charArray, 0);
		return charArray;
	}

	/*******************************/
	/// <summary>
	/// Converts an array of sbytes to an array of bytes
	/// </summary>
	/// <param name="sbyteArray">The array of sbytes to be converted</param>
	/// <returns>The new array of bytes</returns>
	public static byte[] ToByteArray(sbyte[] sbyteArray)
	{
		byte[] byteArray = new byte[sbyteArray.Length];
		for(int index=0; index < sbyteArray.Length; index++)
			byteArray[index] = (byte) sbyteArray[index];
		return byteArray;
	}

	/// <summary>
	/// Converts a string to an array of bytes
	/// </summary>
	/// <param name="sourceString">The string to be converted</param>
	/// <returns>The new array of bytes</returns>
	public static byte[] ToByteArray(string sourceString)
	{
		byte[] byteArray = new byte[sourceString.Length];
		for (int index=0; index < sourceString.Length; index++)
			byteArray[index] = (byte) sourceString[index];
		return byteArray;
	}

	/// <summary>
	/// Converts a array of object-type instances to a byte-type array.
	/// </summary>
	/// <param name="tempObjectArray">Array to convert.</param>
	/// <returns>An array of byte type elements.</returns>
	public static byte[] ToByteArray(object[] tempObjectArray)
	{
		byte[] byteArray = new byte[tempObjectArray.Length];
		for (int index = 0; index < tempObjectArray.Length; index++)
			byteArray[index] = (byte)tempObjectArray[index];
		return byteArray;
	}


	/*******************************/
	/// <summary>
	/// Receives a byte array and returns it transformed in an sbyte array
	/// </summary>
	/// <param name="byteArray">Byte array to process</param>
	/// <returns>The transformed array</returns>
	public static sbyte[] ToSByteArray(byte[] byteArray)
	{
		sbyte[] sbyteArray = new sbyte[byteArray.Length];
		for(int index=0; index < byteArray.Length; index++)
			sbyteArray[index] = (sbyte) byteArray[index];
		return sbyteArray;
	}
	/*******************************/
	/// <summary>
	/// The class performs token processing from strings
	/// </summary>
	public class Tokenizer
	{
		//Element list identified
		private System.Collections.ArrayList elements;
		//Source string to use
		private string source;
		//The tokenizer uses the default delimiter set: the space character, the tab character, the newline character, and the carriage-return character
		private string delimiters = " \t\n\r";		

		/// <summary>
		/// Initializes a new class instance with a specified string to process
		/// </summary>
		/// <param name="source">String to tokenize</param>
		public Tokenizer(string source)
		{			
			this.elements = new System.Collections.ArrayList();
			this.elements.AddRange(source.Split(this.delimiters.ToCharArray()));
			this.RemoveEmptyStrings();
			this.source = source;
		}

		/// <summary>
		/// Initializes a new class instance with a specified string to process
		/// and the specified token delimiters to use
		/// </summary>
		/// <param name="source">String to tokenize</param>
		/// <param name="delimiters">String containing the delimiters</param>
		public Tokenizer(string source, string delimiters)
		{
			this.elements = new System.Collections.ArrayList();
			this.delimiters = delimiters;
			this.elements.AddRange(source.Split(this.delimiters.ToCharArray()));
			this.RemoveEmptyStrings();
			this.source = source;
		}

		/// <summary>
		/// Current token count for the source string
		/// </summary>
		public int Count
		{
			get
			{
				return (this.elements.Count);
			}
		}

		/// <summary>
		/// Determines if there are more tokens to return from the source string
		/// </summary>
		/// <returns>True or false, depending if there are more tokens</returns>
		public bool HasMoreTokens()
		{
			return (this.elements.Count > 0);			
		}

		/// <summary>
		/// Returns the next token from the token list
		/// </summary>
		/// <returns>The string value of the token</returns>
		public string NextToken()
		{			
			string result;
			if (source == "") throw new System.Exception();
			else
			{
				this.elements = new System.Collections.ArrayList();
				this.elements.AddRange(this.source.Split(delimiters.ToCharArray()));
				RemoveEmptyStrings();		
				result = (string) this.elements[0];
				this.elements.RemoveAt(0);				
				this.source = this.source.Remove(this.source.IndexOf(result),result.Length);
				this.source = this.source.TrimStart(this.delimiters.ToCharArray());
				return result;					
			}			
		}

		/// <summary>
		/// Returns the next token from the source string, using the provided
		/// token delimiters
		/// </summary>
		/// <param name="delimiters">String containing the delimiters to use</param>
		/// <returns>The string value of the token</returns>
		public string NextToken(string delimiters)
		{
			this.delimiters = delimiters;
			return NextToken();
		}

		/// <summary>
		/// Removes all empty strings from the token list
		/// </summary>
		private void RemoveEmptyStrings()
		{
			for (int index=0; index < this.elements.Count; index++)
				if ((string)this.elements[index]== "")
				{
					this.elements.RemoveAt(index);
					index--;
				}
		}
	}

	/*******************************/
	/// <summary>
	/// Adds a new key-and-value pair into the hash table
	/// </summary>
	/// <param name="collection">The collection to work with</param>
	/// <param name="key">Key used to obtain the value</param>
	/// <param name="newValue">Value asociated with the key</param>
	/// <returns>The old element associated with the key</returns>
	public static System.Object PutElement(System.Collections.IDictionary collection, System.Object key, System.Object newValue)
	{
		System.Object element = collection[key];
		collection[key] = newValue;
		return element;
	}

	/*******************************/
	/// <summary>
	/// Creates an instance of a received Type.
	/// </summary>
	/// <param name="classType">The Type of the new class instance to return.</param>
	/// <returns>An Object containing the new instance.</returns>
	public static System.Object CreateNewInstance(System.Type classType)
	{
		System.Object instance = null;
		System.Type[] constructor = new System.Type[]{};
		System.Reflection.ConstructorInfo[] constructors = null;
       
		constructors = classType.GetConstructors();

		if (constructors.Length == 0)
			throw new System.UnauthorizedAccessException();
		else
		{
			for(int i = 0; i < constructors.Length; i++)
			{
				System.Reflection.ParameterInfo[] parameters = constructors[i].GetParameters();

				if (parameters.Length == 0)
				{
					instance = classType.GetConstructor(constructor).Invoke(new System.Object[]{});
					break;
				}
				else if (i == constructors.Length -1)     
					throw new System.MethodAccessException();
			}                       
		}
		return instance;
	}


	/*******************************/
	/// <summary>
	/// Writes an object to the specified Stream
	/// </summary>
	/// <param name="stream">The target Stream</param>
	/// <param name="objectToSend">The object to be sent</param>
	public static void Serialize(System.IO.Stream stream, System.Object objectToSend)
	{
		System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
		formatter.Serialize(stream, objectToSend);
	}

	/// <summary>
	/// Writes an object to the specified BinaryWriter
	/// </summary>
	/// <param name="stream">The target BinaryWriter</param>
	/// <param name="objectToSend">The object to be sent</param>
	public static void Serialize(System.IO.BinaryWriter binaryWriter, System.Object objectToSend)
	{
		System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
		formatter.Serialize(binaryWriter.BaseStream, objectToSend);
	}

	/*******************************/
	/// <summary>
	/// Deserializes an object, or an entire graph of connected objects, and returns the object intance
	/// </summary>
	/// <param name="binaryReader">Reader instance used to read the object</param>
	/// <returns>The object instance</returns>
	public static System.Object Deserialize(System.IO.BinaryReader binaryReader)
	{
		System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
		return formatter.Deserialize(binaryReader.BaseStream);
	}

	/*******************************/
	/// <summary>
	/// Adds an element to the top end of a Stack instance.
	/// </summary>
	/// <param name="stack">The Stack instance</param>
	/// <param name="element">The element to add</param>
	/// <returns>The element added</returns>  
	public static System.Object StackPush(System.Collections.Stack stack, System.Object element)
	{
		stack.Push(element);
		return element;
	}

	/*******************************/
	/// <summary>Reads a number of characters from the current source Stream and writes the data to the target array at the specified index.</summary>
	/// <param name="sourceStream">The source Stream to read from.</param>
	/// <param name="target">Contains the array of characteres read from the source Stream.</param>
	/// <param name="start">The starting index of the target array.</param>
	/// <param name="count">The maximum number of characters to read from the source Stream.</param>
	/// <returns>The number of characters read. The number will be less than or equal to count depending on the data available in the source Stream. Returns -1 if the end of the stream is reached.</returns>
	public static System.Int32 ReadInput(System.IO.Stream sourceStream, ref sbyte[] target, int start, int count)
	{
		// Returns 0 bytes if not enough space in target
		if (target.Length == 0)
			return 0;

		byte[] receiver = new byte[target.Length];
		int bytesRead   = sourceStream.Read(receiver, start, count);

		// Returns -1 if EOF
		if (bytesRead == 0)	
			return -1;
                
		for(int i = start; i < start + bytesRead; i++)
			target[i] = (sbyte)receiver[i];
                
		return bytesRead;
	}

	/// <summary>Reads a number of characters from the current source TextReader and writes the data to the target array at the specified index.</summary>
	/// <param name="sourceTextReader">The source TextReader to read from</param>
	/// <param name="target">Contains the array of characteres read from the source TextReader.</param>
	/// <param name="start">The starting index of the target array.</param>
	/// <param name="count">The maximum number of characters to read from the source TextReader.</param>
	/// <returns>The number of characters read. The number will be less than or equal to count depending on the data available in the source TextReader. Returns -1 if the end of the stream is reached.</returns>
	public static System.Int32 ReadInput(System.IO.TextReader sourceTextReader, ref sbyte[] target, int start, int count)
	{
		// Returns 0 bytes if not enough space in target
		if (target.Length == 0) return 0;

		char[] charArray = new char[target.Length];
		int bytesRead = sourceTextReader.Read(charArray, start, count);

		// Returns -1 if EOF
		if (bytesRead == 0) return -1;

		for(int index=start; index<start+bytesRead; index++)
			target[index] = (sbyte)charArray[index];

		return bytesRead;
	}

	/*******************************/
	/// <summary>
	/// Provides support functions to create read-write random acces files and write functions
	/// </summary>
	public class RandomAccessFileSupport
	{
		/// <summary>
		/// Creates a new random acces stream with read-write or read rights
		/// </summary>
		/// <param name="fileName">A relative or absolute path for the file to open</param>
		/// <param name="mode">Mode to open the file in</param>
		/// <returns>The new System.IO.FileStream</returns>
		public static System.IO.FileStream CreateRandomAccessFile(string fileName, string mode) 
		{
			System.IO.FileStream newFile = null;

			if (mode.CompareTo("rw") == 0)
				newFile =  new System.IO.FileStream(fileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite); 
			else if (mode.CompareTo("r") == 0 )
				newFile =  new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read); 
			else
				throw new System.ArgumentException();

			return newFile;
		}

		/// <summary>
		/// Creates a new random acces stream with read-write or read rights
		/// </summary>
		/// <param name="fileName">File infomation for the file to open</param>
		/// <param name="mode">Mode to open the file in</param>
		/// <returns>The new System.IO.FileStream</returns>
		public static System.IO.FileStream CreateRandomAccessFile(System.IO.FileInfo fileName, string mode)
		{
			return CreateRandomAccessFile(fileName.FullName, mode);
		}

		/// <summary>
		/// Writes the data to the specified file stream
		/// </summary>
		/// <param name="data">Data to write</param>
		/// <param name="fileStream">File to write to</param>
		public static void WriteBytes(string data,System.IO.FileStream fileStream)
		{
			int index = 0;
			int length = data.Length;

			while(index < length)
				fileStream.WriteByte((byte)data[index++]);	
		}

		/// <summary>
		/// Writes the received string to the file stream
		/// </summary>
		/// <param name="data">String of information to write</param>
		/// <param name="fileStream">File to write to</param>
		public static void WriteChars(string data,System.IO.FileStream fileStream)
		{
			WriteBytes(data, fileStream);	
		}

		/// <summary>
		/// Writes the received data to the file stream
		/// </summary>
		/// <param name="sByteArray">Data to write</param>
		/// <param name="fileStream">File to write to</param>
		public static void WriteRandomFile(sbyte[] sByteArray,System.IO.FileStream fileStream)
		{
			byte[] byteArray = ToByteArray(sByteArray);
			fileStream.Write(byteArray, 0, byteArray.Length);
		}
	}

	/*******************************/
	/// <summary>
	/// This class manages different issues for calendars.
	/// The different calendars are internally managed using a hash table structure.
	/// </summary>
	public class CalendarManager
	{
		/// <summary>
		/// Field number for get and set indicating the year.
		/// </summary>
		public const int YEAR = 0;

		/// <summary>
		/// Field number for get and set indicating the month.
		/// </summary>
		public const int MONTH = 1;
		
		/// <summary>
		/// Field number for get and set indicating the day of the month.
		/// </summary>
		public const int DATE = 2;
		
		/// <summary>
		/// Field number for get and set indicating the hour of the morning or afternoon.
		/// </summary>
		public const int HOUR = 3;
		
		/// <summary>
		/// Field number for get and set indicating the minute within the hour.
		/// </summary>
		public const int MINUTE = 4;
		
		/// <summary>
		/// Field number for get and set indicating the second within the minute.
		/// </summary>
		public const int SECOND = 5;
		
		/// <summary>
		/// Field number for get and set indicating the millisecond within the second.
		/// </summary>
		public const int MILLISECOND = 6;
		
		/// <summary>
		/// Field number for get and set indicating the day of the month.
		/// </summary>
		public const int DAY_OF_MONTH = 7;
		
		/// <summary>
		/// Field used to get or set the day of the week.
		/// </summary>
		public const int DAY_OF_WEEK = 8;
		
		/// <summary>
		/// Field number for get and set indicating the hour of the day.
		/// </summary>
		public const int HOUR_OF_DAY = 9;
		
		/// <summary>
		/// Field number for get and set indicating whether the HOUR is before or after noon.
		/// </summary>
		public const int AM_PM = 10;
		
		/// <summary>
		/// Value of the AM_PM field indicating the period of the day from midnight to just 
		/// before noon.
		/// </summary>
		public const int AM = 11;
		
		/// <summary>
		/// Value of the AM_PM field indicating the period of the day from noon to just before midnight.
		/// </summary>
		public const int PM = 12;
		
		/// <summary>
		/// The hash table that contains the type of calendars and its properties.
		/// </summary>
		static public CalendarHashTable manager = new CalendarHashTable();

		/// <summary>
		/// Internal class that inherits from HashTable to manage the different calendars.
		/// This structure will contain an instance of System.Globalization.Calendar that represents 
		/// a type of calendar and its properties (represented by an instance of CalendarProperties 
		/// class).
		/// </summary>
		public class CalendarHashTable:System.Collections.Hashtable 
		{
			/// <summary>
			/// Gets the calendar current date and time.
			/// </summary>
			/// <param name="calendar">The calendar to get its current date and time.</param>
			/// <returns>A System.DateTime value that indicates the current date and time for the 
			/// calendar given.</returns>
			public System.DateTime GetDateTime(System.Globalization.Calendar calendar)
			{
				if (this[calendar] != null)
					return ((CalendarProperties) this[calendar]).dateTime;
				else
				{
					CalendarProperties tempProps = new CalendarProperties();
					tempProps.dateTime = System.DateTime.Now;
					this.Add(calendar, tempProps);
					return this.GetDateTime(calendar);
				}
			}

			/// <summary>
			/// Sets the specified System.DateTime value to the specified calendar.
			/// </summary>
			/// <param name="calendar">The calendar to set its date.</param>
			/// <param name="date">The System.DateTime value to set to the calendar.</param>
			public void SetDateTime(System.Globalization.Calendar calendar, System.DateTime date)
			{
				if (this[calendar] != null)
				{
					((CalendarProperties) this[calendar]).dateTime = date;
				}
				else
				{
					CalendarProperties tempProps = new CalendarProperties();
					tempProps.dateTime = date;
					this.Add(calendar, tempProps);
				}
			}

			/// <summary>
			/// Sets the corresponding field in an specified calendar with the value given.
			/// If the specified calendar does not have exist in the hash table, it creates a 
			/// new instance of the calendar with the current date and time and then assings it 
			/// the new specified value.
			/// </summary>
			/// <param name="calendar">The calendar to set its date or time.</param>
			/// <param name="field">One of the fields that composes a date/time.</param>
			/// <param name="fieldValue">The value to be set.</param>
			public void Set(System.Globalization.Calendar calendar, int field, int fieldValue)
			{
				if (this[calendar] != null)
				{
					System.DateTime tempDate = ((CalendarProperties) this[calendar]).dateTime;
					switch (field)
					{
						case CalendarManager.DATE:
							tempDate = tempDate.AddDays(fieldValue - tempDate.Day);
							break;
						case CalendarManager.HOUR:
							tempDate = tempDate.AddHours(fieldValue - tempDate.Hour);
							break;
						case CalendarManager.MILLISECOND:
							tempDate = tempDate.AddMilliseconds(fieldValue - tempDate.Millisecond);
							break;
						case CalendarManager.MINUTE:
							tempDate = tempDate.AddMinutes(fieldValue - tempDate.Minute);
							break;
						case CalendarManager.MONTH:
							//Month value is 0-based. e.g., 0 for January
							tempDate = tempDate.AddMonths(fieldValue - (tempDate.Month + 1));
							break;
						case CalendarManager.SECOND:
							tempDate = tempDate.AddSeconds(fieldValue - tempDate.Second);
							break;
						case CalendarManager.YEAR:
							tempDate = tempDate.AddYears(fieldValue - tempDate.Year);
							break;
						case CalendarManager.DAY_OF_MONTH:
							tempDate = tempDate.AddDays(fieldValue - tempDate.Day);
							break;
						case CalendarManager.DAY_OF_WEEK:;
							tempDate = tempDate.AddDays((fieldValue - 1) - (int)tempDate.DayOfWeek);
							break;
						case CalendarManager.HOUR_OF_DAY:
							tempDate = tempDate.AddHours(fieldValue - tempDate.Hour);
							break;

						default:
							break;
					}
					((CalendarProperties) this[calendar]).dateTime = tempDate;
				}
				else
				{
					CalendarProperties tempProps = new CalendarProperties();
					tempProps.dateTime = System.DateTime.Now;
					this.Add(calendar, tempProps);
					this.Set(calendar, field, fieldValue);
				}
			}

			/// <summary>
			/// Sets the corresponding date (day, month and year) to the calendar specified.
			/// If the calendar does not exist in the hash table, it creates a new instance and sets 
			/// its values.
			/// </summary>
			/// <param name="calendar">The calendar to set its date.</param>
			/// <param name="year">Integer value that represent the year.</param>
			/// <param name="month">Integer value that represent the month.</param>
			/// <param name="day">Integer value that represent the day.</param>
			public void Set(System.Globalization.Calendar calendar, int year, int month, int day)
			{
				if (this[calendar] != null)
				{
					this.Set(calendar, CalendarManager.YEAR, year);
					this.Set(calendar, CalendarManager.MONTH, month);
					this.Set(calendar, CalendarManager.DATE, day);
				}
				else
				{
					CalendarProperties tempProps = new CalendarProperties();
					//Month value is 0-based. e.g., 0 for January
					tempProps.dateTime = new System.DateTime(year, month + 1, day);
					this.Add(calendar, tempProps);
				}
			}

			/// <summary>
			/// Sets the corresponding date (day, month and year) and hour (hour and minute) 
			/// to the calendar specified.
			/// If the calendar does not exist in the hash table, it creates a new instance and sets 
			/// its values.
			/// </summary>
			/// <param name="calendar">The calendar to set its date and time.</param>
			/// <param name="year">Integer value that represent the year.</param>
			/// <param name="month">Integer value that represent the month.</param>
			/// <param name="day">Integer value that represent the day.</param>
			/// <param name="hour">Integer value that represent the hour.</param>
			/// <param name="minute">Integer value that represent the minutes.</param>
			public void Set(System.Globalization.Calendar calendar, int year, int month, int day, int hour, int minute)
			{
				if (this[calendar] != null)
				{
					this.Set(calendar, CalendarManager.YEAR, year);
					this.Set(calendar, CalendarManager.MONTH, month);
					this.Set(calendar, CalendarManager.DATE, day);
					this.Set(calendar, CalendarManager.HOUR, hour);
					this.Set(calendar, CalendarManager.MINUTE, minute);
				}
				else
				{
					CalendarProperties tempProps = new CalendarProperties();
					//Month value is 0-based. e.g., 0 for January
					tempProps.dateTime = new System.DateTime(year, month + 1, day, hour, minute, 0);
					this.Add(calendar, tempProps);
				}
			}

			/// <summary>
			/// Sets the corresponding date (day, month and year) and hour (hour, minute and second) 
			/// to the calendar specified.
			/// If the calendar does not exist in the hash table, it creates a new instance and sets 
			/// its values.
			/// </summary>
			/// <param name="calendar">The calendar to set its date and time.</param>
			/// <param name="year">Integer value that represent the year.</param>
			/// <param name="month">Integer value that represent the month.</param>
			/// <param name="day">Integer value that represent the day.</param>
			/// <param name="hour">Integer value that represent the hour.</param>
			/// <param name="minute">Integer value that represent the minutes.</param>
			/// <param name="second">Integer value that represent the seconds.</param>
			public void Set(System.Globalization.Calendar calendar, int year, int month, int day, int hour, int minute, int second)
			{
				if (this[calendar] != null)
				{
					this.Set(calendar, CalendarManager.YEAR, year);
					this.Set(calendar, CalendarManager.MONTH, month);
					this.Set(calendar, CalendarManager.DATE, day);
					this.Set(calendar, CalendarManager.HOUR, hour);
					this.Set(calendar, CalendarManager.MINUTE, minute);
					this.Set(calendar, CalendarManager.SECOND, second);
				}
				else
				{
					CalendarProperties tempProps = new CalendarProperties();
					//Month value is 0-based. e.g., 0 for January
					tempProps.dateTime = new System.DateTime(year, month + 1, day, hour, minute, second);
					this.Add(calendar, tempProps);
				}
			}

			/// <summary>
			/// Gets the value represented by the field specified.
			/// </summary>
			/// <param name="calendar">The calendar to get its date or time.</param>
			/// <param name="field">One of the field that composes a date/time.</param>
			/// <returns>The integer value for the field given.</returns>
			public int Get(System.Globalization.Calendar calendar, int field)
			{
				if (this[calendar] != null)
				{
					int tempHour;
					switch (field)
					{
						case CalendarManager.DATE:
							return ((CalendarProperties) this[calendar]).dateTime.Day;
						case CalendarManager.HOUR:
							tempHour = ((CalendarProperties) this[calendar]).dateTime.Hour;
							return tempHour > 12 ? tempHour - 12 : tempHour;
						case CalendarManager.MILLISECOND:
							return ((CalendarProperties) this[calendar]).dateTime.Millisecond;
						case CalendarManager.MINUTE:
							return ((CalendarProperties) this[calendar]).dateTime.Minute;
						case CalendarManager.MONTH:
							//Month value is 0-based. e.g., 0 for January
							return ((CalendarProperties) this[calendar]).dateTime.Month - 1;
						case CalendarManager.SECOND:
							return ((CalendarProperties) this[calendar]).dateTime.Second;
						case CalendarManager.YEAR:
							return ((CalendarProperties) this[calendar]).dateTime.Year;
						case CalendarManager.DAY_OF_MONTH:
							return ((CalendarProperties) this[calendar]).dateTime.Day;
						case CalendarManager.DAY_OF_WEEK:
							return (int)(((CalendarProperties) this[calendar]).dateTime.DayOfWeek);
						case CalendarManager.HOUR_OF_DAY:
							return ((CalendarProperties) this[calendar]).dateTime.Hour;
						case CalendarManager.AM_PM:
							tempHour = ((CalendarProperties) this[calendar]).dateTime.Hour;
							return tempHour > 12 ? CalendarManager.PM : CalendarManager.AM;

						default:
							return 0;
					}
				}
				else
				{
					CalendarProperties tempProps = new CalendarProperties();
					tempProps.dateTime = System.DateTime.Now;
					this.Add(calendar, tempProps);
					return this.Get(calendar, field);
				}
			}

			/// <summary>
			/// Sets the time in the specified calendar with the long value.
			/// </summary>
			/// <param name="calendar">The calendar to set its date and time.</param>
			/// <param name="milliseconds">A long value that indicates the milliseconds to be set to 
			/// the hour for the calendar.</param>
			public void SetTimeInMilliseconds(System.Globalization.Calendar calendar, long milliseconds)
			{
				if (this[calendar] != null)
				{
					((CalendarProperties) this[calendar]).dateTime = new System.DateTime(milliseconds);
				}
				else
				{
					CalendarProperties tempProps = new CalendarProperties();
					tempProps.dateTime = new System.DateTime(System.TimeSpan.TicksPerMillisecond * milliseconds);
					this.Add(calendar, tempProps);
				}
			}
				
			/// <summary>
			/// Gets what the first day of the week is; e.g., Sunday in US, Monday in France.
			/// </summary>
			/// <param name="calendar">The calendar to get its first day of the week.</param>
			/// <returns>A System.DayOfWeek value indicating the first day of the week.</returns>
			public System.DayOfWeek GetFirstDayOfWeek(System.Globalization.Calendar calendar)
			{
				if (this[calendar] != null && ((CalendarProperties)this[calendar]).dateTimeFormat != null)
				{
					return ((CalendarProperties) this[calendar]).dateTimeFormat.FirstDayOfWeek;
				}
				else
				{
					CalendarProperties tempProps = new CalendarProperties();
					tempProps.dateTimeFormat = new System.Globalization.DateTimeFormatInfo();
					tempProps.dateTimeFormat.FirstDayOfWeek = System.DayOfWeek.Sunday;
					this.Add(calendar, tempProps);
					return this.GetFirstDayOfWeek(calendar);
				}
			}

			/// <summary>
			/// Sets what the first day of the week is; e.g., Sunday in US, Monday in France.
			/// </summary>
			/// <param name="calendar">The calendar to set its first day of the week.</param>
			/// <param name="firstDayOfWeek">A System.DayOfWeek value indicating the first day of the week
			/// to be set.</param>
			public void SetFirstDayOfWeek(System.Globalization.Calendar calendar, System.DayOfWeek  firstDayOfWeek)
			{
				if (this[calendar] != null && ((CalendarProperties)this[calendar]).dateTimeFormat != null)
				{
					((CalendarProperties) this[calendar]).dateTimeFormat.FirstDayOfWeek = firstDayOfWeek;
				}
				else
				{
					CalendarProperties tempProps = new CalendarProperties();
					tempProps.dateTimeFormat = new System.Globalization.DateTimeFormatInfo();
					this.Add(calendar, tempProps);
					this.SetFirstDayOfWeek(calendar, firstDayOfWeek);
				}
			}

			/// <summary>
			/// Removes the specified calendar from the hash table.
			/// </summary>
			/// <param name="calendar">The calendar to be removed.</param>
			public void Clear(System.Globalization.Calendar calendar)
			{
				if (this[calendar] != null)
					this.Remove(calendar);
			}

			/// <summary>
			/// Removes the specified field from the calendar given.
			/// If the field does not exists in the calendar, the calendar is removed from the table.
			/// </summary>
			/// <param name="calendar">The calendar to remove the value from.</param>
			/// <param name="field">The field to be removed from the calendar.</param>
			public void Clear(System.Globalization.Calendar calendar, int field)
			{
				if (this[calendar] != null)
					this.Remove(calendar);
				else
					this.Set(calendar, field, 0);
			}

			/// <summary>
			/// Internal class that represents the properties of a calendar instance.
			/// </summary>
			class CalendarProperties
			{
				/// <summary>
				/// The date and time of a calendar.
				/// </summary>
				public System.DateTime dateTime;
				
				/// <summary>
				/// The format for the date and time in a calendar.
				/// </summary>
				public System.Globalization.DateTimeFormatInfo dateTimeFormat;
			}
		}
	}

	/*******************************/
	/// <summary>
	/// This method returns the literal value received
	/// </summary>
	/// <param name="literal">The literal to return</param>
	/// <returns>The received value</returns>
	public static long Identity(long literal)
	{
		return literal;
	}

	/// <summary>
	/// This method returns the literal value received
	/// </summary>
	/// <param name="literal">The literal to return</param>
	/// <returns>The received value</returns>
	public static ulong Identity(ulong literal)
	{
		return literal;
	}

	/// <summary>
	/// This method returns the literal value received
	/// </summary>
	/// <param name="literal">The literal to return</param>
	/// <returns>The received value</returns>
	public static float Identity(float literal)
	{
		return literal;
	}

	/// <summary>
	/// This method returns the literal value received
	/// </summary>
	/// <param name="literal">The literal to return</param>
	/// <returns>The received value</returns>
	public static double Identity(double literal)
	{
		return literal;
	}

	/*******************************/
	/// <summary>
	/// Writes the exception stack trace to the received stream
	/// </summary>
	/// <param name="throwable">Exception to obtain information from</param>
	/// <param name="stream">Output sream used to write to</param>
	public static void WriteStackTrace(System.Exception throwable, System.IO.TextWriter stream)
	{
		stream.Write(throwable.StackTrace);
		stream.Flush();
	}

	/*******************************/
	/// <summary>
	/// This class contains different methods to manage Collections.
	/// </summary>
	public class CollectionSupport : System.Collections.CollectionBase
	{
		/// <summary>
		/// Creates an instance of the Collection by using an inherited constructor.
		/// </summary>
		public CollectionSupport() : base()
		{			
		}

		/// <summary>
		/// Adds an specified element to the collection.
		/// </summary>
		/// <param name="element">The element to be added.</param>
		/// <returns>Returns true if the element was successfuly added. Otherwise returns false.</returns>
		public virtual bool Add(System.Object element)
		{
			return (this.List.Add(element) != -1);
		}	

		/// <summary>
		/// Adds all the elements contained in the specified collection.
		/// </summary>
		/// <param name="collection">The collection used to extract the elements that will be added.</param>
		/// <returns>Returns true if all the elements were successfuly added. Otherwise returns false.</returns>
		public virtual bool AddAll(System.Collections.ICollection collection)
		{
			bool result = false;
			if (collection!=null)
			{
				System.Collections.IEnumerator tempEnumerator = new System.Collections.ArrayList(collection).GetEnumerator();
				while (tempEnumerator.MoveNext())
				{
					if (tempEnumerator.Current != null)
						result = this.Add(tempEnumerator.Current);
				}
			}
			return result;
		}


		/// <summary>
		/// Adds all the elements contained in the specified support class collection.
		/// </summary>
		/// <param name="collection">The collection used to extract the elements that will be added.</param>
		/// <returns>Returns true if all the elements were successfuly added. Otherwise returns false.</returns>
		public virtual bool AddAll(CollectionSupport collection)
		{
			return this.AddAll((System.Collections.ICollection)collection);
		}

		/// <summary>
		/// Verifies if the specified element is contained into the collection. 
		/// </summary>
		/// <param name="element"> The element that will be verified.</param>
		/// <returns>Returns true if the element is contained in the collection. Otherwise returns false.</returns>
		public virtual bool Contains(System.Object element)
		{
			return this.List.Contains(element);
		}

		/// <summary>
		/// Verifies if all the elements of the specified collection are contained into the current collection.
		/// </summary>
		/// <param name="collection">The collection used to extract the elements that will be verified.</param>
		/// <returns>Returns true if all the elements are contained in the collection. Otherwise returns false.</returns>
		public virtual bool ContainsAll(System.Collections.ICollection collection)
		{
			bool result = false;
			System.Collections.IEnumerator tempEnumerator = new System.Collections.ArrayList(collection).GetEnumerator();
			while (tempEnumerator.MoveNext())
				if (!(result = this.Contains(tempEnumerator.Current)))
					break;
			return result;
		}

		/// <summary>
		/// Verifies if all the elements of the specified collection are contained into the current collection.
		/// </summary>
		/// <param name="collection">The collection used to extract the elements that will be verified.</param>
		/// <returns>Returns true if all the elements are contained in the collection. Otherwise returns false.</returns>
		public virtual bool ContainsAll(CollectionSupport collection)
		{
			return this.ContainsAll((System.Collections.ICollection) collection);
		}

		/// <summary>
		/// Verifies if the collection is empty.
		/// </summary>
		/// <returns>Returns true if the collection is empty. Otherwise returns false.</returns>
		public virtual bool IsEmpty()
		{
			return (this.Count == 0);
		}

		/// <summary>
		/// Removes an specified element from the collection.
		/// </summary>
		/// <param name="element">The element to be removed.</param>
		/// <returns>Returns true if the element was successfuly removed. Otherwise returns false.</returns>
		public virtual bool Remove(System.Object element)
		{
			bool result = false;
			if (this.Contains(element))
			{
				this.List.Remove(element);
				result = true;
			}
			return result;
		}

		/// <summary>
		/// Removes all the elements contained into the specified collection.
		/// </summary>
		/// <param name="collection">The collection used to extract the elements that will be removed.</param>
		/// <returns>Returns true if all the elements were successfuly removed. Otherwise returns false.</returns>
		public virtual bool RemoveAll(System.Collections.ICollection collection)
		{ 
			bool result = false;
			System.Collections.IEnumerator tempEnumerator = new System.Collections.ArrayList(collection).GetEnumerator();
			while (tempEnumerator.MoveNext())
			{
				if (this.Contains(tempEnumerator.Current))
					result = this.Remove(tempEnumerator.Current);
			}
			return result;
		}

		/// <summary>
		/// Removes all the elements contained into the specified collection.
		/// </summary>
		/// <param name="collection">The collection used to extract the elements that will be removed.</param>
		/// <returns>Returns true if all the elements were successfuly removed. Otherwise returns false.</returns>
		public virtual bool RemoveAll(CollectionSupport collection)
		{ 
			return this.RemoveAll((System.Collections.ICollection) collection);
		}

		/// <summary>
		/// Removes all the elements that aren't contained into the specified collection.
		/// </summary>
		/// <param name="collection">The collection used to verify the elements that will be retained.</param>
		/// <returns>Returns true if all the elements were successfully removed. Otherwise returns false.</returns>
		public virtual bool RetainAll(System.Collections.ICollection collection)
		{
			bool result = false;
			System.Collections.IEnumerator tempEnumerator = this.GetEnumerator();
			CollectionSupport tempCollection = new CollectionSupport();
			tempCollection.AddAll(collection);
			while (tempEnumerator.MoveNext())
				if (!tempCollection.Contains(tempEnumerator.Current))
				{
					result = this.Remove(tempEnumerator.Current);
					
					if (result == true)
					{
						tempEnumerator = this.GetEnumerator();
					}
				}
			return result;
		}

		/// <summary>
		/// Removes all the elements that aren't contained into the specified collection.
		/// </summary>
		/// <param name="collection">The collection used to verify the elements that will be retained.</param>
		/// <returns>Returns true if all the elements were successfully removed. Otherwise returns false.</returns>
		public virtual bool RetainAll(CollectionSupport collection)
		{
			return this.RetainAll((System.Collections.ICollection) collection);
		}

		/// <summary>
		/// Obtains an array containing all the elements of the collection.
		/// </summary>
		/// <returns>The array containing all the elements of the collection</returns>
		public virtual System.Object[] ToArray()
		{	
			int index = 0;
			System.Object[] objects = new System.Object[this.Count];
			System.Collections.IEnumerator tempEnumerator = this.GetEnumerator();
			while (tempEnumerator.MoveNext())
				objects[index++] = tempEnumerator.Current;
			return objects;
		}

		/// <summary>
		/// Obtains an array containing all the elements of the collection.
		/// </summary>
		/// <param name="objects">The array into which the elements of the collection will be stored.</param>
		/// <returns>The array containing all the elements of the collection.</returns>
		public virtual System.Object[] ToArray(System.Object[] objects)
		{	
			int index = 0;
			System.Collections.IEnumerator tempEnumerator = this.GetEnumerator();
			while (tempEnumerator.MoveNext())
				objects[index++] = tempEnumerator.Current;
			return objects;
		}

		/// <summary>
		/// Creates a CollectionSupport object with the contents specified in array.
		/// </summary>
		/// <param name="array">The array containing the elements used to populate the new CollectionSupport object.</param>
		/// <returns>A CollectionSupport object populated with the contents of array.</returns>
		public static CollectionSupport ToCollectionSupport(System.Object[] array)
		{
			CollectionSupport tempCollectionSupport = new CollectionSupport();             
			tempCollectionSupport.AddAll(array);
			return tempCollectionSupport;
		}
	}

	/*******************************/
	/// <summary>
	/// This class contains different methods to manage list collections.
	/// </summary>
	public class ListCollectionSupport : System.Collections.ArrayList
	{
		/// <summary>
		/// Creates a new instance of the class ListCollectionSupport.
		/// </summary>
		public ListCollectionSupport() : base()
		{
		}
 
		/// <summary>
		/// Creates a new instance of the class ListCollectionSupport.
		/// </summary>
		/// <param name="collection">The collection to insert into the new object.</param>
		public ListCollectionSupport(System.Collections.ICollection collection) : base(collection)
		{
		}

		/// <summary>
		/// Creates a new instance of the class ListCollectionSupport with the specified capacity.
		/// </summary>
		/// <param name="capacity">The capacity of the new array.</param>
		public ListCollectionSupport(int capacity) : base(capacity)
		{
		}

		/// <summary>
		/// Adds an object to the end of the List.
		/// </summary>          
		/// <param name="valueToInsert">The value to insert in the array list.</param>
		/// <returns>Returns true after adding the value.</returns>
		public virtual bool Add(System.Object valueToInsert)
		{
			base.Insert(this.Count, valueToInsert);
			return true;
		}

		/// <summary>
		/// Adds all the elements contained into the specified collection, starting at the specified position.
		/// </summary>
		/// <param name="index">Position at which to add the first element from the specified collection.</param>
		/// <param name="list">The list used to extract the elements that will be added.</param>
		/// <returns>Returns true if all the elements were successfuly added. Otherwise returns false.</returns>
		public virtual bool AddAll(int index, System.Collections.IList list)
		{
			bool result = false;
			if (list!=null)
			{
				System.Collections.IEnumerator tempEnumerator = new System.Collections.ArrayList(list).GetEnumerator();
				int tempIndex = index;
				while (tempEnumerator.MoveNext())
				{
					base.Insert(tempIndex++, tempEnumerator.Current);
					result = true;
				}
			}
			return result;
		}

		/// <summary>
		/// Adds all the elements contained in the specified collection.
		/// </summary>
		/// <param name="collection">The collection used to extract the elements that will be added.</param>
		/// <returns>Returns true if all the elements were successfuly added. Otherwise returns false.</returns>
		public virtual bool AddAll(System.Collections.IList collection)
		{
			return this.AddAll(this.Count,collection);
		}

		/// <summary>
		/// Adds all the elements contained in the specified support class collection.
		/// </summary>
		/// <param name="collection">The collection used to extract the elements that will be added.</param>
		/// <returns>Returns true if all the elements were successfuly added. Otherwise returns false.</returns>
		public virtual bool AddAll(CollectionSupport collection)
		{
			return this.AddAll(this.Count,collection);
		}

		/// <summary>
		/// Adds all the elements contained into the specified support class collection, starting at the specified position.
		/// </summary>
		/// <param name="index">Position at which to add the first element from the specified collection.</param>
		/// <param name="list">The list used to extract the elements that will be added.</param>
		/// <returns>Returns true if all the elements were successfuly added. Otherwise returns false.</returns>
		public virtual bool AddAll(int index, CollectionSupport collection)
		{
			return this.AddAll(index,(System.Collections.IList)collection);
		}
		
		/// <summary>
		/// Creates a copy of the ListCollectionSupport.
		/// </summary>
		/// <returns> A copy of the ListCollectionSupport.</returns>
		public virtual System.Object ListCollectionClone()
		{
			return MemberwiseClone();
		}


		/// <summary>
		/// Returns an iterator of the collection.
		/// </summary>
		/// <returns>An IEnumerator.</returns>
		public virtual System.Collections.IEnumerator ListIterator()
		{			
			return base.GetEnumerator();
		}

		public virtual object[] ListSelection()
		{
			return base.ToArray();
		}
		
		/// <summary>
		/// Removes all the elements contained into the specified collection.
		/// </summary>
		/// <param name="collection">The collection used to extract the elements that will be removed.</param>
		/// <returns>Returns true if all the elements were successfuly removed. Otherwise returns false.</returns>
		public virtual bool RemoveAll(System.Collections.ICollection collection)
		{ 
			bool result = false;
			System.Collections.IEnumerator tempEnumerator = new System.Collections.ArrayList(collection).GetEnumerator();
			while (tempEnumerator.MoveNext())
			{
				result = true;
				if (base.Contains(tempEnumerator.Current))
					base.Remove(tempEnumerator.Current);
			}
			return result;
		}
		
		/// <summary>
		/// Removes all the elements contained into the specified collection.
		/// </summary>
		/// <param name="collection">The collection used to extract the elements that will be removed.</param>
		/// <returns>Returns true if all the elements were successfuly removed. Otherwise returns false.</returns>
		public virtual bool RemoveAll(CollectionSupport collection)
		{ 
			return this.RemoveAll((System.Collections.ICollection) collection);
		}		

		/// <summary>
		/// Removes the value in the specified index from the list.
		/// </summary>          
		/// <param name="index">The index of the value to remove.</param>
		/// <returns>Returns the value removed.</returns>
		public virtual System.Object RemoveElement(int index)
		{
			System.Object objectRemoved = this[index];
			this.RemoveAt(index);
			return objectRemoved;
		}

		/// <summary>
		/// Removes an specified element from the collection.
		/// </summary>
		/// <param name="element">The element to be removed.</param>
		/// <returns>Returns true if the element was successfuly removed. Otherwise returns false.</returns>
		public virtual bool RemoveElement(System.Object element)
		{

			bool result = false;
			if (this.Contains(element))
			{
				base.Remove(element);
				result = true;
			}
			return result;
		}

		/// <summary>
		/// Removes the first value from an array list.
		/// </summary>          
		/// <returns>Returns the value removed.</returns>
		public virtual System.Object RemoveFirst()
		{
			System.Object objectRemoved = this[0];
			this.RemoveAt(0);
			return objectRemoved;
		}

		/// <summary>
		/// Removes the last value from an array list.
		/// </summary>
		/// <returns>Returns the value removed.</returns>
		public virtual System.Object RemoveLast()
		{
			System.Object objectRemoved = this[this.Count-1];
			base.RemoveAt(this.Count-1);
			return objectRemoved;
		}

		/// <summary>
		/// Removes all the elements that aren't contained into the specified collection.
		/// </summary>
		/// <param name="collection">The collection used to verify the elements that will be retained.</param>
		/// <returns>Returns true if all the elements were successfully removed. Otherwise returns false.</returns>
		public virtual bool RetainAll(System.Collections.ICollection collection)
		{
			bool result = false;
			System.Collections.IEnumerator tempEnumerator = this.GetEnumerator();
			ListCollectionSupport tempCollection = new ListCollectionSupport(collection);
			while (tempEnumerator.MoveNext())
				if (!tempCollection.Contains(tempEnumerator.Current))
				{
					result = this.RemoveElement(tempEnumerator.Current);
					
					if (result == true)
					{
						tempEnumerator = this.GetEnumerator();
					}
				}
			return result;
		}
		
		/// <summary>
		/// Removes all the elements that aren't contained into the specified collection.
		/// </summary>
		/// <param name="collection">The collection used to verify the elements that will be retained.</param>
		/// <returns>Returns true if all the elements were successfully removed. Otherwise returns false.</returns>
		public virtual bool RetainAll(CollectionSupport collection)
		{
			return this.RetainAll((System.Collections.ICollection) collection);
		}		

		/// <summary>
		/// Verifies if all the elements of the specified collection are contained into the current collection.
		/// </summary>
		/// <param name="collection">The collection used to extract the elements that will be verified.</param>
		/// <returns>Returns true if all the elements are contained in the collection. Otherwise returns false.</returns>
		public virtual bool ContainsAll(System.Collections.ICollection collection)
		{
			bool result = false;
			System.Collections.IEnumerator tempEnumerator = new System.Collections.ArrayList(collection).GetEnumerator();
			while (tempEnumerator.MoveNext())
				if(!(result = this.Contains(tempEnumerator.Current)))
					break;
			return result;
		}
		
		/// <summary>
		/// Verifies if all the elements of the specified collection are contained into the current collection.
		/// </summary>
		/// <param name="collection">The collection used to extract the elements that will be verified.</param>
		/// <returns>Returns true if all the elements are contained in the collection. Otherwise returns false.</returns>
		public virtual bool ContainsAll(CollectionSupport collection)
		{
			return this.ContainsAll((System.Collections.ICollection) collection);
		}		

		/// <summary>
		/// Returns a new list containing a portion of the current list between a specified range. 
		/// </summary>
		/// <param name="startIndex">The start index of the range.</param>
		/// <param name="endIndex">The end index of the range.</param>
		/// <returns>A ListCollectionSupport instance containing the specified elements.</returns>
		public virtual ListCollectionSupport SubList(int startIndex, int endIndex)
		{
			int index = 0;
			System.Collections.IEnumerator tempEnumerator = this.GetEnumerator();
			ListCollectionSupport result = new ListCollectionSupport();
			for(index = startIndex; index < endIndex; index++)
				result.Add(this[index]);
			return (ListCollectionSupport)result;
		}

		/// <summary>
		/// Obtains an array containing all the elements of the collection.
		/// </summary>
		/// <param name="objects">The array into which the elements of the collection will be stored.</param>
		/// <returns>The array containing all the elements of the collection.</returns>
		public virtual System.Object[] ToArray(System.Object[] objects)
		{	
			if (objects.Length < this.Count)
				objects = new System.Object[this.Count];
			int index = 0;
			System.Collections.IEnumerator tempEnumerator = this.GetEnumerator();
			while (tempEnumerator.MoveNext())
				objects[index++] = tempEnumerator.Current;
			return objects;
		}

		/// <summary>
		/// Returns an iterator of the collection starting at the specified position.
		/// </summary>
		/// <param name="index">The position to set the iterator.</param>
		/// <returns>An IEnumerator at the specified position.</returns>
		public virtual System.Collections.IEnumerator ListIterator(int index)
		{
			if ((index < 0) || (index > this.Count)) throw new System.IndexOutOfRangeException();			
			System.Collections.IEnumerator tempEnumerator= this.GetEnumerator();
			if (index > 0)
			{
				int i=0;
				while ((tempEnumerator.MoveNext()) && (i < index - 1))
					i++;
			}
			return tempEnumerator;			
		}
	
		/// <summary>
		/// Gets the last value from a list.
		/// </summary>
		/// <returns>Returns the last element of the list.</returns>
		public virtual System.Object GetLast()
		{
			if (this.Count == 0) throw new System.ArgumentOutOfRangeException();
			else
			{
				return this[this.Count - 1];
			}									 
		}
		
		/// <summary>
		/// Return whether this list is empty.
		/// </summary>
		/// <returns>True if the list is empty, false if it isn't.</returns>
		public virtual bool IsEmpty()
		{
			return (this.Count == 0);
		}
		
		/// <summary>
		/// Replaces the element at the specified position in this list with the specified element.
		/// </summary>
		/// <param name="index">Index of element to replace.</param>
		/// <param name="element">Element to be stored at the specified position.</param>
		/// <returns>The element previously at the specified position.</returns>
		public virtual System.Object Set(int index, System.Object element)
		{
			System.Object result = this[index];
			this[index] = element;
			return result;
		} 

		/// <summary>
		/// Returns the element at the specified position in the list.
		/// </summary>
		/// <param name="index">Index of element to return.</param>
		/// <param name="element">Element to be stored at the specified position.</param>
		/// <returns>The element at the specified position in the list.</returns>
		public virtual System.Object Get(int index)
		{
			return this[index];
		}
	}

	/*******************************/
	/// <summary>
	/// Initializes a new instance of the ArrayList class that contains elements copied from the specified collection 
	/// and that has the same initial capacity as the number of elements copied.
	/// </summary>
	/// <param name="collection">The ICollection whose elements are copied to the new list.</param>
	/// <returns>The new instance, if the collection received as parameter was System.Collection.Stack type the new instance 
	/// contains the elements in reverse order.</returns>
	public static ListCollectionSupport CreateCollection(System.Collections.ICollection collection)
	{
		ListCollectionSupport arrayStack = new ListCollectionSupport(collection);
		if (collection is System.Collections.Stack)
			arrayStack.Reverse();
		return arrayStack;
	}


	/*******************************/
	/// <summary>
	/// Give functions to obtain information of graphic elements
	/// </summary>
	public class GraphicsManager
	{
		//Instance of GDI+ drawing surfaces graphics hashtable
		static public GraphicsHashTable manager = new GraphicsHashTable();

		/// <summary>
		/// Creates a new Graphics object from the device context handle associated with the Graphics
		/// parameter
		/// </summary>
		/// <param name="oldGraphics">Graphics instance to obtain the parameter from</param>
		/// <returns>A new GDI+ drawing surface</returns>
		public static System.Drawing.Graphics CreateGraphics(System.Drawing.Graphics oldGraphics)
		{
			System.IntPtr hdc = oldGraphics.GetHdc();
			oldGraphics.ReleaseHdc(hdc);
			return System.Drawing.Graphics.FromHdc(hdc);
		}

		/// <summary>
		/// This method draws a Bezier curve.
		/// </summary>
		/// <param name="graphics">It receives the Graphics instance</param>
		/// <param name="array">An array of (x,y) pairs of coordinates used to draw the curve.</param>
		public static void Bezier(System.Drawing.Graphics graphics, int[] array)
		{
			System.Drawing.Pen pen;
			pen = GraphicsManager.manager.GetPen(graphics);
			graphics.DrawBezier(pen, array[0], array[1], array[2], array[3], array[4], array[5], array[6], array[7]);
		}

		/// <summary>
		/// Gets the text size width and height from a given GDI+ drawing surface and a given font
		/// </summary>
		/// <param name="graphics">Drawing surface to use</param>
		/// <param name="graphicsFont">Font type to measure</param>
		/// <param name="text">String of text to measure</param>
		/// <returns>A point structure with both size dimentions; x for width and y for height</returns>
		public static System.Drawing.Point GetTextSize(System.Drawing.Graphics graphics, System.Drawing.Font graphicsFont, System.String text)
		{
			System.Drawing.Point textSize;
			System.Drawing.SizeF tempSizeF;
			tempSizeF = graphics.MeasureString(text, graphicsFont);
			textSize = new System.Drawing.Point();
			textSize.X = (int) tempSizeF.Width;
			textSize.Y = (int) tempSizeF.Height;
			return textSize;
		}

		/// <summary>
		/// Gets the text size width and height from a given GDI+ drawing surface and a given font
		/// </summary>
		/// <param name="graphics">Drawing surface to use</param>
		/// <param name="graphicsFont">Font type to measure</param>
		/// <param name="text">String of text to measure</param>
		/// <param name="width">Maximum width of the string</param>
		/// <param name="format">StringFormat object that represents formatting information, such as line spacing, for the string</param>
		/// <returns>A point structure with both size dimentions; x for width and y for height</returns>
		public static System.Drawing.Point GetTextSize(System.Drawing.Graphics graphics, System.Drawing.Font graphicsFont, System.String text, System.Int32 width, System.Drawing.StringFormat format)
		{
			System.Drawing.Point textSize;
			System.Drawing.SizeF tempSizeF;
			tempSizeF = graphics.MeasureString(text, graphicsFont, width, format);
			textSize = new System.Drawing.Point();
			textSize.X = (int) tempSizeF.Width;
			textSize.Y = (int) tempSizeF.Height;
			return textSize;
		}


		/// <summary>
		/// Gives functionality over a hashtable of GDI+ drawing surfaces
		/// </summary>
		public class GraphicsHashTable:System.Collections.Hashtable 
		{
			/// <summary>
			/// Gets the graphic color characteristics from a given control
			/// </summary>
			/// <param name="control">Control to obtain the data from</param>
			/// <returns>A graphic object with the control's characteristics</returns>
			public System.Drawing.Graphics GetGraphics(System.Windows.Forms.Control control)
			{
				System.Drawing.Graphics graphic;
				if (control.Visible == true)
				{
					graphic = control.CreateGraphics();
					if (this[graphic] == null)
					{
						GraphicsProperties tempProps = new GraphicsProperties();
						tempProps.color = control.ForeColor;
						tempProps.BackColor = control.BackColor;
						tempProps.TextColor = control.ForeColor;
						tempProps.GraphicFont = control.Font;
						Add(graphic, tempProps);
					}
				}
				else
				{
					graphic = null;
				}
				return graphic;
			}

			/// <summary>
			/// Sets the background color property to the given graphics object in the hashtable. If the element doesn't exist, then it adds the graphic element to the hashtable with the given background color.
			/// </summary>
			/// <param name="graphic">Graphic element to search or add</param>
			/// <param name="color">Background color to set</param>
			public void SetBackColor(System.Drawing.Graphics graphic, System.Drawing.Color color)
			{
				if (this[graphic] != null)
					((GraphicsProperties) this[graphic]).BackColor = color;
				else
				{
					GraphicsProperties tempProps = new GraphicsProperties();
					tempProps.BackColor = color;
					Add(graphic, tempProps);
				}
			}

			/// <summary>
			/// Gets the background color property to the given graphics object in the hashtable. If the element doesn't exist, then it returns White.
			/// </summary>
			/// <param name="graphic">Graphic element to search</param>
			/// <returns>The background color of the graphic</returns>
			public System.Drawing.Color GetBackColor(System.Drawing.Graphics graphic)
			{
				if (this[graphic] == null)
					return System.Drawing.Color.White;
				else
					return ((GraphicsProperties) this[graphic]).BackColor;
			}

			/// <summary>
			/// Sets the text color property to the given graphics object in the hashtable. If the element doesn't exist, then it adds the graphic element to the hashtable with the given text color.
			/// </summary>
			/// <param name="graphic">Graphic element to search or add</param>
			/// <param name="color">Text color to set</param>
			public void SetTextColor(System.Drawing.Graphics graphic, System.Drawing.Color color)
			{
				if (this[graphic] != null)
					((GraphicsProperties) this[graphic]).TextColor = color;
				else
				{
					GraphicsProperties tempProps = new GraphicsProperties();
					tempProps.TextColor = color;
					Add(graphic, tempProps);
				}
			}

			/// <summary>
			/// Gets the text color property to the given graphics object in the hashtable. If the element doesn't exist, then it returns White.
			/// </summary>
			/// <param name="graphic">Graphic element to search</param>
			/// <returns>The text color of the graphic</returns>
			public System.Drawing.Color GetTextColor(System.Drawing.Graphics graphic) 
			{
				if (this[graphic] == null)
					return System.Drawing.Color.White;
				else
					return ((GraphicsProperties) this[graphic]).TextColor;
			}

			/// <summary>
			/// Sets the GraphicBrush property to the given graphics object in the hashtable. If the element doesn't exist, then it adds the graphic element to the hashtable with the given GraphicBrush.
			/// </summary>
			/// <param name="graphic">Graphic element to search or add</param>
			/// <param name="brush">GraphicBrush to set</param>
			public void SetBrush(System.Drawing.Graphics graphic, System.Drawing.SolidBrush brush) 
			{
				if (this[graphic] != null)
					((GraphicsProperties) this[graphic]).GraphicBrush = brush;
				else
				{
					GraphicsProperties tempProps = new GraphicsProperties();
					tempProps.GraphicBrush = brush;
					Add(graphic, tempProps);
				}
			}

			/// <summary>
			/// Gets the SolidBrush property to the given graphics object in the hashtable. If the element doesn't exist, then it returns Black.
			/// </summary>
			/// <param name="graphic">Graphic element to search</param>
			/// <returns>The SolidBrush setting of the graphic</returns>
			public System.Drawing.SolidBrush GetBrush(System.Drawing.Graphics graphic)
			{
				if (this[graphic] == null)
					return new System.Drawing.SolidBrush(System.Drawing.Color.Black);
				else
					return ((GraphicsProperties) this[graphic]).GraphicBrush;
			}

			/// <summary>
			/// Sets the GraphicPen property to the given graphics object in the hashtable. If the element doesn't exist, then it adds the graphic element to the hashtable with the given Pen.
			/// </summary>
			/// <param name="graphic">Graphic element to search or add</param>
			/// <param name="pen">Pen to set</param>
			public void SetPen(System.Drawing.Graphics graphic, System.Drawing.Pen pen) 
			{
				if (this[graphic] != null)
					((GraphicsProperties) this[graphic]).GraphicPen = pen;
				else
				{
					GraphicsProperties tempProps = new GraphicsProperties();
					tempProps.GraphicPen = pen;
					Add(graphic, tempProps);
				}
			}

			/// <summary>
			/// Gets the GraphicPen property to the given graphics object in the hashtable. If the element doesn't exist, then it returns Black.
			/// </summary>
			/// <param name="graphic">Graphic element to search</param>
			/// <returns>The GraphicPen setting of the graphic</returns>
			public System.Drawing.Pen GetPen(System.Drawing.Graphics graphic)
			{
				if (this[graphic] == null)
					return System.Drawing.Pens.Black;
				else
					return ((GraphicsProperties) this[graphic]).GraphicPen;
			}

			/// <summary>
			/// Sets the GraphicFont property to the given graphics object in the hashtable. If the element doesn't exist, then it adds the graphic element to the hashtable with the given Font.
			/// </summary>
			/// <param name="graphic">Graphic element to search or add</param>
			/// <param name="Font">Font to set</param>
			public void SetFont(System.Drawing.Graphics graphic, System.Drawing.Font font) 
			{
				if (this[graphic] != null)
					((GraphicsProperties) this[graphic]).GraphicFont = font;
				else
				{
					GraphicsProperties tempProps = new GraphicsProperties();
					tempProps.GraphicFont = font;
					Add(graphic,tempProps);
				}
			}

			/// <summary>
			/// Gets the GraphicFont property to the given graphics object in the hashtable. If the element doesn't exist, then it returns Microsoft Sans Serif with size 8.25.
			/// </summary>
			/// <param name="graphic">Graphic element to search</param>
			/// <returns>The GraphicFont setting of the graphic</returns>
			public System.Drawing.Font GetFont(System.Drawing.Graphics graphic)
			{
				if (this[graphic] == null)
					return new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
				else
					return ((GraphicsProperties) this[graphic]).GraphicFont;
			}

			/// <summary>
			/// Sets the color properties for a given Graphics object. If the element doesn't exist, then it adds the graphic element to the hashtable with the color properties set with the given value.
			/// </summary>
			/// <param name="graphic">Graphic element to search or add</param>
			/// <param name="color">Color value to set</param>
			public void SetColor(System.Drawing.Graphics graphic, System.Drawing.Color color) 
			{
				if (this[graphic] != null)
				{
					((GraphicsProperties) this[graphic]).GraphicPen.Color = color;
					((GraphicsProperties) this[graphic]).GraphicBrush.Color = color;
					((GraphicsProperties) this[graphic]).color = color;
				}
				else
				{
					GraphicsProperties tempProps = new GraphicsProperties();
					tempProps.GraphicPen.Color = color;
					tempProps.GraphicBrush.Color = color;
					tempProps.color = color;
					Add(graphic,tempProps);
				}
			}

			/// <summary>
			/// Gets the color property to the given graphics object in the hashtable. If the element doesn't exist, then it returns Black.
			/// </summary>
			/// <param name="graphic">Graphic element to search</param>
			/// <returns>The color setting of the graphic</returns>
			public System.Drawing.Color GetColor(System.Drawing.Graphics graphic) 
			{
				if (this[graphic] == null)
					return System.Drawing.Color.Black;
				else
					return ((GraphicsProperties) this[graphic]).color;
			}

			/// <summary>
			/// This method gets the TextBackgroundColor of a Graphics instance
			/// </summary>
			/// <param name="graphic">The graphics instance</param>
			/// <returns>The color value in ARGB encoding</returns>
			public System.Drawing.Color GetTextBackgroundColor(System.Drawing.Graphics graphic)
			{
				if (this[graphic] == null)
					return System.Drawing.Color.Black;
				else 
				{ 
					return ((GraphicsProperties) this[graphic]).TextBackgroundColor;
				}
			}

			/// <summary>
			/// This method set the TextBackgroundColor of a Graphics instace
			/// </summary>
			/// <param name="graphic">The graphics instace</param>
			/// <param name="color">The System.Color to set the TextBackgroundColor</param>
			public void SetTextBackgroundColor(System.Drawing.Graphics graphic, System.Drawing.Color color) 
			{
				if (this[graphic] != null)
				{
					((GraphicsProperties) this[graphic]).TextBackgroundColor = color;								
				}
				else
				{
					GraphicsProperties tempProps = new GraphicsProperties();
					tempProps.TextBackgroundColor = color;				
					Add(graphic,tempProps);
				}
			}

			/// <summary>
			/// Structure to store properties from System.Drawing.Graphics objects
			/// </summary>
			class GraphicsProperties
			{
				public System.Drawing.Color TextBackgroundColor = System.Drawing.Color.Black;
				public System.Drawing.Color color = System.Drawing.Color.Black;
				public System.Drawing.Color BackColor = System.Drawing.Color.White;
				public System.Drawing.Color TextColor = System.Drawing.Color.Black;
				public System.Drawing.SolidBrush GraphicBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
				public System.Drawing.Pen   GraphicPen = new System.Drawing.Pen(System.Drawing.Color.Black);
				public System.Drawing.Font  GraphicFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			}
		}
	}
	/*******************************/
	/// <summary>
	/// Calculates the descent of the font, using the GetCellDescent and GetEmHeight
	/// </summary>
	/// <param name="font">The Font instance used to obtain the Descent</param>
	/// <returns>The Descent of the font </returns>
	public static int GetDescent(System.Drawing.Font font)
	{		
		System.Drawing.FontFamily fontFamily = font.FontFamily;
		int descent = fontFamily.GetCellDescent(font.Style);
		int descentPixel = (int) font.Size * descent / fontFamily.GetEmHeight(font.Style);
		return descentPixel;
	}

	/*******************************/
	/// <summary>
	/// Support class used to handle threads
	/// </summary>
	public class ThreadClass : IThreadRunnable
	{
		/// <summary>
		/// The instance of System.Threading.Thread
		/// </summary>
		private System.Threading.Thread threadField;
	      
		/// <summary>
		/// Initializes a new instance of the ThreadClass class
		/// </summary>
		public ThreadClass()
		{
			threadField = new System.Threading.Thread(new System.Threading.ThreadStart(Run));
		}
	 
		/// <summary>
		/// Initializes a new instance of the Thread class.
		/// </summary>
		/// <param name="Name">The name of the thread</param>
		public ThreadClass(string Name)
		{
			threadField = new System.Threading.Thread(new System.Threading.ThreadStart(Run));
			this.Name = Name;
		}
	      
		/// <summary>
		/// Initializes a new instance of the Thread class.
		/// </summary>
		/// <param name="Start">A ThreadStart delegate that references the methods to be invoked when this thread begins executing</param>
		public ThreadClass(System.Threading.ThreadStart Start)
		{
			threadField = new System.Threading.Thread(Start);
		}
	 
		/// <summary>
		/// Initializes a new instance of the Thread class.
		/// </summary>
		/// <param name="Start">A ThreadStart delegate that references the methods to be invoked when this thread begins executing</param>
		/// <param name="Name">The name of the thread</param>
		public ThreadClass(System.Threading.ThreadStart Start, string Name)
		{
			threadField = new System.Threading.Thread(Start);
			this.Name = Name;
		}
	      
		/// <summary>
		/// This method has no functionality unless the method is overridden
		/// </summary>
		public virtual void Run()
		{
		}
	      
		/// <summary>
		/// Causes the operating system to change the state of the current thread instance to ThreadState.Running
		/// </summary>
		public virtual void Start()
		{
			threadField.Start();
		}
	      
		/// <summary>
		/// Interrupts a thread that is in the WaitSleepJoin thread state
		/// </summary>
		public virtual void Interrupt()
		{
			threadField.Interrupt();
		}
	      
		/// <summary>
		/// Gets the current thread instance
		/// </summary>
		public System.Threading.Thread Instance
		{
			get
			{
				return threadField;
			}
			set
			{
				threadField = value;
			}
		}
	      
		/// <summary>
		/// Gets or sets the name of the thread
		/// </summary>
		public System.String Name
		{
			get
			{
				return threadField.Name;
			}
			set
			{
				if (threadField.Name == null)
					threadField.Name = value; 
			}
		}
	      
		/// <summary>
		/// Gets or sets a value indicating the scheduling priority of a thread
		/// </summary>
		public System.Threading.ThreadPriority Priority
		{
			get
			{
				return threadField.Priority;
			}
			set
			{
				threadField.Priority = value;
			}
		}
	      
		/// <summary>
		/// Gets a value indicating the execution status of the current thread
		/// </summary>
		public bool IsAlive
		{
			get
			{
				return threadField.IsAlive;
			}
		}
	      
		/// <summary>
		/// Gets or sets a value indicating whether or not a thread is a background thread.
		/// </summary>
		public bool IsBackground
		{
			get
			{
				return threadField.IsBackground;
			} 
			set
			{
				threadField.IsBackground = value;
			}
		}
	      
		/// <summary>
		/// Blocks the calling thread until a thread terminates
		/// </summary>
		public void Join()
		{
			threadField.Join();
		}
	      
		/// <summary>
		/// Blocks the calling thread until a thread terminates or the specified time elapses
		/// </summary>
		/// <param name="MiliSeconds">Time of wait in milliseconds</param>
		public void Join(long MiliSeconds)
		{
			lock(this)
			{
				threadField.Join(new System.TimeSpan(MiliSeconds * 10000));
			}
		}
	      
		/// <summary>
		/// Blocks the calling thread until a thread terminates or the specified time elapses
		/// </summary>
		/// <param name="MiliSeconds">Time of wait in milliseconds</param>
		/// <param name="NanoSeconds">Time of wait in nanoseconds</param>
		public void Join(long MiliSeconds, int NanoSeconds)
		{
			lock(this)
			{
				threadField.Join(new System.TimeSpan(MiliSeconds * 10000 + NanoSeconds * 100));
			}
		}
	      
		/// <summary>
		/// Resumes a thread that has been suspended
		/// </summary>
		public void Resume()
		{
			threadField.Resume();
		}
	      
		/// <summary>
		/// Raises a ThreadAbortException in the thread on which it is invoked, 
		/// to begin the process of terminating the thread. Calling this method 
		/// usually terminates the thread
		/// </summary>
		public void Abort()
		{
			threadField.Abort();
		}
	      
		/// <summary>
		/// Raises a ThreadAbortException in the thread on which it is invoked, 
		/// to begin the process of terminating the thread while also providing
		/// exception information about the thread termination. 
		/// Calling this method usually terminates the thread.
		/// </summary>
		/// <param name="stateInfo">An object that contains application-specific information, such as state, which can be used by the thread being aborted</param>
		public void Abort(System.Object stateInfo)
		{
			lock(this)
			{
				threadField.Abort(stateInfo);
			}
		}
	      
		/// <summary>
		/// Suspends the thread, if the thread is already suspended it has no effect
		/// </summary>
		public void Suspend()
		{
			threadField.Suspend();
		}
	      
		/// <summary>
		/// Obtain a String that represents the current Object
		/// </summary>
		/// <returns>A String that represents the current Object</returns>
		public override System.String ToString()
		{
			return "Thread[" + Name + "," + Priority.ToString() + "," + "" + "]";
		}
	     
		/// <summary>
		/// Gets the currently running thread
		/// </summary>
		/// <returns>The currently running thread</returns>
		public static ThreadClass Current()
		{
			ThreadClass CurrentThread = new ThreadClass();
			CurrentThread.Instance = System.Threading.Thread.CurrentThread;
			return CurrentThread;
		}
	}


	/*******************************/
		/// <summary>
		/// Creates an output file stream to write to the file with the specified name.
		/// </summary>
		/// <param name="FileName">Name of the file to write.</param>
		/// <param name="Append">True in order to write to the end of the file, false otherwise.</param>
		/// <returns>New instance of FileStream with the proper file mode.</returns>
		public static System.IO.FileStream GetFileStream(string FileName, bool Append)
		{
			if (Append)
				return new System.IO.FileStream(FileName, System.IO.FileMode.Append);
			else
				return new System.IO.FileStream(FileName, System.IO.FileMode.Create);
		}


	/*******************************/
	/// <summary>
	/// Write an array of bytes int the FileStream specified.
	/// </summary>
	/// <param name="FileStreamWrite">FileStream that must be updated.</param>
	/// <param name="Source">Array of bytes that must be written in the FileStream.</param>
	public static void WriteOutput(System.IO.FileStream FileStreamWrite, sbyte[] Source)
	{
		FileStreamWrite.Write(ToByteArray(Source), 0, Source.Length);
	}


	/*******************************/
	/// <summary>
	/// Checks if the giving File instance is a directory or file, and returns his Length
	/// </summary>
	/// <param name="file">The File instance to check</param>
	/// <returns>The length of the file</returns>
	public static long FileLength(System.IO.FileInfo file)
	{
		if (System.IO.Directory.Exists(file.FullName))
			return 0;
		else 
			return file.Length;
	}

}
