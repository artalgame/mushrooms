using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Xml;
[Serializable]
/// <summary>
/// Log controller. Write information to log file
/// </summary>
public class LogController:ILogContreller
{
	/// <summary>
	/// The log file varible.
	/// </summary>
	private StreamWriter _logFileWriter;	
	/// <summary>
	/// The _full name of log file.
	/// </summary>
	private string _fileNameFull;
	/// <summary>
	/// Gets the file name full.
	/// </summary>
	public string FileNameFull{
		get{
			return _fileNameFull;
		}
	}
	/// <summary>
	/// The write to console. Is true - all information from log will translate to console
	/// </summary> 
	private bool _isWriteToConsole = true;
	/// <summary>
	/// Gets or sets a value indicating whether this instance is write to console.
	/// </summary>

	public bool IsWriteToConsole{
		get
		{
			return _isWriteToConsole;
		}
		set
		{
			_isWriteToConsole = value;
		}
	}
	
	/// <summary>
	/// The _count of strings in log file.
	/// </summary>
	private int _countOfString = 0;
	/// <summary>
	/// Gets the count strings.
	/// </summary>
	public int CountStrings {
		get {
				return _countOfString;
		}
	}
	
	/// <summary>
	/// Initializes a new instance of the <see cref="LogControllerSingletone"/> class.
	/// </summary>
	public LogController(string logFilePath)
	{
		FileInfo logFileInfo = new FileInfo(logFilePath);
		FileStream logFile;
		///logfile is exist - create FileStream
		try
		{
 			logFile = new FileStream(logFilePath,FileMode.Create);
			_fileNameFull = logFileInfo.FullName;
		}
		catch
		{
			Debug.LogError("Can not create or open log file");
			logFile = null;
		}
		///if error with log File
		if(logFile == null)
			_logFileWriter = null;
		else
		{
		///make buffered stream with 100KB buffer memory
			_logFileWriter = new StreamWriter(new BufferedStream(logFile,100000));
		}
			WriteLine("log created");
	}	
	/// <summary>
	/// Write the specified value.
	/// </summary>
	/// <param name='value'>
	/// If set to <c>true</c> value.
	/// </param>
	/// <exception cref='NotImplementedException'>
	/// Is thrown when the not implemented exception.
	/// </exception>
	public void Write (string value,bool isError=false)
	{
		///if logFile == null then we don't write information
		if(_logFileWriter != null)
		{
			if(isError)
			{
				_logFileWriter.Write("ERROR:"+value+"! Time:"+DateTime.Now.ToLongTimeString());
			}
			else
				_logFileWriter.Write(value+"! Time:"+DateTime.Now.ToLongTimeString());
		}
		if(IsWriteToConsole)
		{
			Debug.Log(value);
		}
	}
	/// <summary>
	/// Writes the line.
	/// </summary>
	/// <returns>
	/// The line.
	/// </returns>
	/// <exception cref='NotImplementedException'>
	/// Is thrown when the not implemented exception.
	/// </exception>
	public void WriteLine (string value,bool isError=false)
	{
		///if logFile == null then  don't write information
		if(_logFileWriter != null)
		{
			if(isError)
			{
				_logFileWriter.WriteLine("ERROR:"+value+"! Time:"+DateTime.Now.ToLongTimeString());
			}
			else
				_logFileWriter.WriteLine(value+"! Time:"+DateTime.Now.ToLongTimeString());
			
			_countOfString++;
		}
		if(IsWriteToConsole)
		{
			if(isError)
				Debug.LogError(value);
			else
				Debug.Log(value);
		}
	}
	/// <summary>
	/// Releases all resource used by the <see cref="LogController"/> object.
	/// </summary>
	/// <remarks>
	/// Call <see cref="Dispose"/> when you are finished using the <see cref="LogController"/>. The <see cref="Dispose"/>
	/// method leaves the <see cref="LogController"/> in an unusable state. After calling <see cref="Dispose"/>, you must
	/// release all references to the <see cref="LogController"/> so the garbage collector can reclaim the memory that the
	/// <see cref="LogController"/> was occupying.
	/// </remarks>
	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}
	/// <summary>
	/// Releases unmanaged resources and performs other cleanup operations before the <see cref="LogController"/> is
	/// reclaimed by garbage collection.
	/// </summary>
	~LogController()
	{
		Dispose(false);
	}
	/// <summary>
	/// Dispose the specified isDispose.
	/// </summary>
	/// <param name='isDispose'>
	/// Is invoke method Dispose.
	/// </param>
	private void Dispose(bool isDispose)
	{
		if(isDispose)
		{
			WriteLine("Log file is correctly closed from Dispose method");
			WriteLine("Log file ended on "+DateTime.Now.ToLongDateString()+" "+DateTime.Now.ToLongTimeString());
			if(_logFileWriter!=null)
				_logFileWriter.Close();
			GC.Collect();
		}
		else
		{
			WriteLine("Log file is correctly closed from Finalizator");
			WriteLine("Log file ended on "+DateTime.Now.ToLongDateString()+" "+DateTime.Now.ToLongTimeString());
			if(_logFileWriter!=null)
			_logFileWriter.Close();
		}
	}
}
