using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;
using System.Globalization;
/// <summary>
/// Preferences keys for read and write from PlayerPrefs.
/// </summary>
public enum PreferencesKeys{
	PREFS_LANGUAGE,
	PREFS_CULTURE,
	PREFS_MUSIC_VOLUME,
	PREFS_SOUND_VOLUME
}

/// <summary>
/// Setting controller.
/// </summary>
/// <summary>
/// Setting controller class.
/// </summary>
public class SettingController:ISettingController {
	/// <summary>
	/// The _changes music listeners.
	/// </summary>
	private List<IChangeMusicListener> _musicListeners= new List<IChangeMusicListener>();
	/// <summary>
	/// The _changes sounds listeners.
	/// </summary>
	private List<IChangeSoundListener> _soundListeners= new List<IChangeSoundListener>();

	/// <summary>
	/// The _ideal resolution.
	/// </summary>
	private Resolution _idealResolution;
	/// <summary>
	/// Gets the ideal resolution.
	/// </summary>
	public Resolution IdealResolution{
		get{
			return _idealResolution;
		}
	    set
		{
			_idealResolution = value;
		}
	}
	
	/// <summary>
	/// The size of the _ideal font.
	/// </summary>
	private int _idealFontSize;
	/// <summary>
	/// Gets or sets the size of the ideal font.
	/// </summary>
	/// <value>
	/// The size of the ideal font.
	/// </value>
	public int IdealFontSize{
		get{
			return _idealFontSize;
		}
		set{
			_idealFontSize = value;
		}
	}
	
	/// <summary>
	/// Current screen resolution.
	/// </summary>
	private Resolution _currentResolution;
	/// <summary>
	/// Gets the current resolution.
	/// </summary>
	public Resolution CurrentResolution{
		get{
			return _currentResolution;
		}
		set{
			_currentResolution = value;
		}
	}
	
	/// <summary>
	/// The height_proportional coeficient between ideal screen and current screen(Calculate from heightes).
	/// </summary>
	private double _proportionalHeightCoeficient;
	/// <summary>
	/// Gets or sets the height proportional coeficient.
	/// </summary>
	/// <value>
	/// The new height proportional coeficient.
	/// </value>
	public double ProportionalHeightCoeficient{
		get{
			return _proportionalHeightCoeficient;
		}
		set{
			_proportionalHeightCoeficient = value;
		}
	}
	
	/// <summary>
	/// The _proportional coeficient between ideal screen and current screen(Calculate from heightes).
	/// </summary>
	private double _proportionalWidthCoeficient;
	/// <summary>
	/// Gets or sets the width proportional coeficient.
	/// </summary>
	/// <value>
	/// The new Width proportional coeficient.
	/// </value>
	public double ProportionalWidthCoeficient{
		get{
			return _proportionalWidthCoeficient;
		}
		set{
			_proportionalWidthCoeficient = value;
		}
	}
	
	/// <summary>
	/// The name of the _setting file.
	/// </summary>
	private string _settingFileName;
	
	/// <summary>
	/// The _language of game.
	/// </summary>
	private LocalizationLanguages _language;
	/// <summary>
	/// Gets or sets the language.
	/// </summary>
	/// <value>
	/// The language.
	/// </value>
	public LocalizationLanguages Language{
		get{
			return _language;
		}
		set{
			_language = value;
			UsingCultureInfo = GlobalConstants.GetCultureInfoByLanguage(_language);
		}
	}
	/// <summary>
	/// The _sound volume of game range between 0..1 - it's coeficient of volume, it use with sound working.
	/// </summary>
	/// 
	
	private double _soundVolume;
	/// <summary>
	/// Gets or sets the sound volume.
	/// </summary>
	/// <value>
	/// The sound volume.
	/// </value>
	public double SoundVolume{
		get{
			return _soundVolume;
		}
		set{
			if(value<=0)
				_soundVolume = 0;
			else
				if(value>=1)
					_soundVolume = 1;
			else
				_soundVolume = value;
			SendSoundVolume();
		}
	}
	
	/// <summary>
	/// The _music volume of game range between 0..1 - it's coeficient of volume, it use with music working.. 
	/// </summary>
	private double _musicVolume;
	/// <summary>
	/// Gets or sets the music volume.
	/// </summary>
	/// <value>
	/// The music volume.
	/// </value>
	public double MusicVolume{
		get{
			return _musicVolume;
		}
		set{
			if(value<=0)
				_musicVolume = 0;
			else
				if(value>=1)
					_musicVolume = 1;
			else
				_musicVolume = value;
			SendMusicVolume();
		}
	}
	
	/// <summary>
	/// The _using culture info.
	/// </summary>
	private CultureInfo _usingCultureInfo;
	/// <summary>
	/// Gets or sets the using culture info.
	/// </summary>
	/// <value>
	/// The using culture info.
	/// </value>
	public CultureInfo UsingCultureInfo{
		get{
			return _usingCultureInfo;
		}
		set{
			if(value!=null)
				_usingCultureInfo = value;
		}
	}
	/// <summary>
	/// Sets the default settings.
	/// </summary>
	void SetDefaultSettings()
	{
		try{
				LocalizationLanguages lang =(LocalizationLanguages)Enum.Parse(typeof(LocalizationLanguages),Application.systemLanguage.ToString());
				Language = lang;	
			}
		catch
			{
				Language = GlobalConstants.DEFAULT_LANGUAGE;
			}
			
		UsingCultureInfo = GlobalConstants.GetCultureInfoByLanguage(Language);
		
		SoundVolume = GlobalConstants.DEFAULT_SOUND_VOLUME;
		MusicVolume = GlobalConstants.DEFAULT_MUSIC_VOLUME;
	}
	/// <summary>
	/// Initializes a new instance of the <see cref="SettingController"/> class.
	/// </summary>
	/// <param name='settingFilePath'>
	/// Setting file path .
	/// </param>
	public SettingController(string settingFilePath){
		try{
		///read prefs language 	
		string locLanguage = PlayerPrefs.GetString(PreferencesKeys.PREFS_LANGUAGE.ToString());
		_language = (LocalizationLanguages)Enum.Parse(typeof(LocalizationLanguages),locLanguage);
			
		///read culture info
		string culInfo = PlayerPrefs.GetString(PreferencesKeys.PREFS_CULTURE.ToString());
			if(culInfo == "")
				_usingCultureInfo = GlobalConstants.GetCultureInfoByLanguage(Language);
		_usingCultureInfo = new CultureInfo(culInfo);
			
		///read volume of music
		_musicVolume = (double)PlayerPrefs.GetFloat(PreferencesKeys.PREFS_MUSIC_VOLUME.ToString(),0.5f);
		///read volume of sound
		_soundVolume = (double)PlayerPrefs.GetFloat(PreferencesKeys.PREFS_SOUND_VOLUME.ToString(),0.5f);	
		}
		catch(Exception ex)
		{
			Debug.LogError("error with read preferences "+ex.Message);
			SetDefaultSettings();
		}
		///it's a dynamically calculating preferences and they are not saved to file, but may be futher 
		///some from them will be saved
		_settingFileName = GlobalConstants.SETTING_FILE_NAME;
		_idealResolution = new Resolution();
		_idealResolution.width = GlobalConstants.IDEAL_X_RESOLUTION;
		_idealResolution.height = GlobalConstants.IDEAL_Y_RESOLUTION;
		_currentResolution = new Resolution();
		_currentResolution.height = Screen.height;
		_currentResolution.width = Screen.width;
		try{
			ProportionalHeightCoeficient = (double)CurrentResolution.height/(double)_idealResolution.height;				
		}
		catch(Exception ex){
			Debug.LogError("can not calculate hight Proportional Coeficient "+ex.Message);
			_proportionalHeightCoeficient=0;
		}

		try{
			ProportionalWidthCoeficient = (double)CurrentResolution.width/(double)_idealResolution.width;				
		}
		catch(Exception ex){
			Debug.LogError("can not calculate width Proportional Coeficient "+ex.Message);
			_proportionalWidthCoeficient=0;
		}		
	}
	
	/// <summary>
	/// Releases all resource used by the <see cref="SettingController"/> object.
	/// </summary>
	/// <remarks>
	/// Call <see cref="Dispose"/> when you are finished using the <see cref="SettingController"/>. The
	/// <see cref="Dispose"/> method leaves the <see cref="SettingController"/> in an unusable state. After calling
	/// <see cref="Dispose"/>, you must release all references to the <see cref="SettingController"/> so the garbage
	/// collector can reclaim the memory that the <see cref="SettingController"/> was occupying.
	/// </remarks>
	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}
	/// <summary>
	/// Releases unmanaged resources and performs other cleanup operations before the <see cref="SettingController"/> is
	/// reclaimed by garbage collection.
	/// </summary>
	~SettingController(){
		Dispose(false);
	}
	
	public bool SavePreferences()
	{
		try{
			///Save all preferences to PlayerPrefs
			PlayerPrefs.SetString(PreferencesKeys.PREFS_LANGUAGE.ToString(),Language.ToString());
			PlayerPrefs.SetString(PreferencesKeys.PREFS_CULTURE.ToString(),UsingCultureInfo.ToString());
			PlayerPrefs.SetFloat(PreferencesKeys.PREFS_MUSIC_VOLUME.ToString(),(float)_musicVolume);
			PlayerPrefs.SetFloat(PreferencesKeys.PREFS_SOUND_VOLUME.ToString(),(float)_soundVolume);
			
		if((Application.platform == RuntimePlatform.WindowsPlayer)||
			(Application.platform == RuntimePlatform.WindowsEditor))
		{
			try{
			using(StreamWriter writer = new StreamWriter(new FileStream(_settingFileName,FileMode.OpenOrCreate)))
			{
				writer.WriteLine(Language.ToString());
				writer.WriteLine(UsingCultureInfo.ToString());
				writer.WriteLine(SoundVolume.ToString());
				writer.WriteLine(MusicVolume.ToString());
			}
				}
				catch{
					GameCoreSingletone.Singletone.LogController.WriteLine("can not save preferences to file");
				}
		}
			GameCoreSingletone.Singletone.LogController.WriteLine("Preferences saved");
			return true;
		}
		catch{
			GameCoreSingletone.Singletone.LogController.WriteLine("Can not save preferences",true);
			return false;
		}
		
	}
	/// <summary>
	/// Dispose the specified isDispose.
	/// </summary>
	/// <param name='isDispose'>
	/// Is method will invoke from dispose.
	/// </param>
	private void Dispose(bool isDispose)
	{
		if(isDispose)
		{
			GameCoreSingletone.Singletone.LogController.WriteLine("Close setting Controller from Dispose");
		}
		else
		{
			GameCoreSingletone.Singletone.LogController.WriteLine("Close setting Controller from Finalizator");
		}
		
		if(SavePreferences())
		{
			GameCoreSingletone.Singletone.LogController.WriteLine("preferences save without problem");
		}
		else
		{
			GameCoreSingletone.Singletone.LogController.WriteLine("preferences save with problem");
		}
		
		GameCoreSingletone.Singletone.LogController.WriteLine("SettingController closed");
	}
	
	
	public void AddNewMusicListener (IChangeMusicListener listener)
	{
		if(_musicListeners == null)
			_musicListeners = new List<IChangeMusicListener>();
		if(!_musicListeners.Contains(listener))
		{
			_musicListeners.Add(listener);
		}
	}

	public void RemoveMusicListener (IChangeMusicListener listener)
	{
		if((_musicListeners != null)&&(_musicListeners.Contains(listener)))
		{
			_musicListeners.Remove(listener);
		}
	}

	public void SendMusicVolume ()
	{
		if(_musicListeners != null){
		foreach(var listener in _musicListeners)
			{
				listener.SetNewMusicVolume((float)_musicVolume);
			}
		}
	}
	
	
	public void AddNewSoundListener (IChangeSoundListener listener)
	{
		if(_soundListeners == null)
			_soundListeners = new List<IChangeSoundListener>();
		if(!_soundListeners.Contains(listener))
		{
			_soundListeners.Add(listener);
		}
	}

	public void RemoveSoundListener (IChangeSoundListener listener)
	{
		if((_soundListeners != null)&&(_soundListeners.Contains(listener)))
		{
			_soundListeners.Remove(listener);
		}
	}

	public void SendSoundVolume ()
	{
		if(_soundListeners != null){
		foreach(var listener in _soundListeners)
			{
				listener.SetNewSoundVolume((float)_soundVolume);
			}
		}
	}

}
