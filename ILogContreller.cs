using System;

	public interface ILogContreller
	{
		/// <summary>
		/// Write the specified string value to log. 
		/// </summary>
		/// <param name='value'>
		/// If set to <c>true</c> value.
		/// </param>
		/// <returns>
		/// eturn true if string was wrote succesfully.
		/// </returns>
		bool Write(string value);
		/// <summary>
		/// Writes the line.
		/// </summary>
		/// <returns>
		/// return true if string was wrote succesfully.
		/// </returns>
		bool WriteLine();
		/// <summary>
		/// Reads the string.
		/// </summary>
		/// <returns>
		/// The string from index.
		/// </returns>
		string ReadString(int index);
		/// <summary>
		/// Reads the last string.
		/// </summary>
		/// <returns>
		/// The last string in log.
		/// </returns>
		string ReadLastString();
		/// <summary>
		/// Gets  the count strings.
		/// </summary>
		/// <value>
		/// The count strings in log.
		/// </value>
		int CountStrings{get;set;}
	}