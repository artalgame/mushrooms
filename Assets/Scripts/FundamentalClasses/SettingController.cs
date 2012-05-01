using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Globalization;
/// <summary>
/// Setting controller class.
/// </summary>
public class SettingController:ISettingController {
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
	/// Initializes a new instance of the <see cref="SettingController"/> class.
	/// </summary>
	/// <param name='settingFilePath'>
	/// Setting file path .
	/// </param>
	public SettingController(string settingFilePath){
		FileInfo settingFile = new  FileInfo(settingFilePath);
		///try to read information from setting file
		try
		{
			using(StreamReader reader =new StreamReader(settingFile.OpenRead()))
			{
				string language = reader.ReadLine();
				Language =(LocalizationLanguages)Enum.Parse(typeof(LocalizationLanguages),language);
				
				string cultInfo = reader.ReadLine();
				UsingCultureInfo = CultureInfo.GetCultureInfo(cultInfo);
				
				string sVolume = reader.ReadLine();
				SoundVolume = Double.Parse(sVolume);
				
				string mVolume = reader.ReadLine();
				MusicVolume = Double.Parse(mVolume);
			}
			_settingFileName = settingFilePath;
		}
		catch(Exception ex)
		{
			Debug.LogError("Don't read settings file!!!"+ex.Message);
			
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
			
			_settingFileName = GlobalConstants.SETTING_FILE_NAME;
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
			using(StreamWriter writer = new StreamWriter(new FileStream(_settingFileName,FileMode.OpenOrCreate)))
			{
				writer.WriteLine(Language.ToString());
				writer.WriteLine(UsingCultureInfo.ToString());
				writer.WriteLine(SoundVolume.ToString());
				writer.WriteLine(MusicVolume.ToString());
			}
		GameCoreSingletone.Singletone.LogController.WriteLine("SettingController closed");
	}
	
}
