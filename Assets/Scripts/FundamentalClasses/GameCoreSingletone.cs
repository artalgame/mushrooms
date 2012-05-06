using UnityEngine;
using System.Collections;
using System;
using System.Xml;
using System.IO;

[Serializable]
public class GameCoreSingletone:IDisposable
{
	
    /// <summary>
    /// static variable - link on singltone
    /// </summary>
    private static GameCoreSingletone _singletone = new GameCoreSingletone();
	/// <summary>
    /// Readonly property for representation singletone object 
    /// </summary>
    public static GameCoreSingletone Singletone 
    { 
        get
        {
            if (_singletone == null)
            {
                _singletone = new GameCoreSingletone();
			}
            return _singletone;	
        }
    }
	/// <summary>
	/// Gets the current platform(Read only).
	/// </summary>
	private ILogContreller _logController;
	/// <summary>
	/// Readonly property. Gets the log controller.
	/// </summary>
	public ILogContreller LogController
	{
		get
		{
			return _logController; 
		}
	}
	/// <summary>
	/// The _setting controller.
	/// </summary>
	private ISettingController _settingController;
	/// <summary>
	/// Gets the setting controller.
	/// </summary>
	public ISettingController SettingController
	{
		get
		{
			return _settingController;
		}
	}
	private ILocalizationController _localizationController;
	public ILocalizationController LocalizationController
	{
		get{
			return _localizationController;
		}
	}
	
	  /// <summary>
    /// Constructor of our singletone 
    /// </summary>
    private GameCoreSingletone()
    {
		_logController = new LogController(GlobalConstants.LOG_FILE_NAME);
		_settingController = new  SettingController(GlobalConstants.SETTING_FILE_NAME);
		_logController.WriteLine("Setting controller created");
		_localizationController = new LocalizationController();
		_logController.WriteLine("Localization controller created");
		_logController.WriteLine("GameCoreCreated");
    }    
	
	
		/// <summary>
	/// Releases all resource used by the <see cref="GameCoreSingletone"/> object.
	/// </summary>
	/// <remarks>
	/// Call <see cref="Dispose"/> when you are finished using the <see cref="GameCoreSingletone"/>. The
	/// <see cref="Dispose"/> method leaves the <see cref="GameCoreSingletone"/> in an unusable state. After calling
	/// <see cref="Dispose"/>, you must release all references to the <see cref="GameCoreSingletone"/> so the garbage
	/// collector can reclaim the memory that the <see cref="GameCoreSingletone"/> was occupying.
	/// </remarks>
	public void Dispose ()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}
	/// <summary>
	/// Releases unmanaged resources and performs other cleanup operations before the <see cref="GameCoreSingletone"/> is
	/// reclaimed by garbage collection.
	/// </summary>
	~GameCoreSingletone()
	{
		Dispose(false);
	}
	/// <summary>
	/// Dispose the specified isDispose.
	/// </summary>
	/// <param name='isDispose'>
	/// Is method was invoked from Dispose.
	/// </param>
  	private void Dispose(bool isDispose)
	{
		if(isDispose)
		{
			_logController.WriteLine("begin dispose GameCore Singletone");	
			
		}
		if(_settingController!=null)
		_settingController.Dispose();
		///It must disposed latest
		if(_logController!=null)
		_logController.Dispose();
	}
  
}
