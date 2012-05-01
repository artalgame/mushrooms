using System;
 /// <summary>
/// I log contreller interface - it inheritance from IDisposable - for manual closing file or other stream
/// </summary>
///
	public interface ILogContreller:IDisposable
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
		void Write(string value, bool isError=false);
		/// <summary>
		/// Writes the line.
		/// </summary>
		/// <returns>
		/// return true if string was wrote succesfully.
		/// </returns>
		void WriteLine(string value, bool isError=false);
		/// <summary>
		/// Gets  the count strings.
		/// </summary>
		/// <value>
		/// The count strings in log.
		/// </value>
	    int CountStrings{get;}
	/// <summary>
	/// Gets or sets a value indicating whether all log information is write to console.
	/// </summary>
	/// <value>
	/// <c>true</c> if all log information will wrote to console; otherwise, <c>false</c>.
	/// </value>
	    bool IsWriteToConsole{get;set;}

	}