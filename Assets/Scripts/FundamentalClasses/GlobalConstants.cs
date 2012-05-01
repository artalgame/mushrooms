using UnityEngine;
using System.Collections;
using System.Globalization;
/// <summary>
/// Localization languages.
/// </summary>
public enum LocalizationLanguages{
	English,Russian
}
/// <summary>
/// Global constants.
/// </summary>
public static class GlobalConstants{
	public static readonly string LOG_FILE_NAME = "log.txt";
	public static readonly string SETTING_FILE_NAME = "settings.txt";
	public static readonly LocalizationLanguages DEFAULT_LANGUAGE = LocalizationLanguages.English;
	public static readonly double DEFAULT_MUSIC_VOLUME = 0.5;
	public static readonly double DEFAULT_SOUND_VOLUME = 0.5;
	public static readonly int IDEAL_X_RESOLUTION = 1600;
	public static readonly int IDEAL_Y_RESOLUTION = 900;
	
	///rows - index of string, column - number of language in LocalizationLangages enum
	public static string[][] STRING_ARRAY =new string[][]{
		/*0*/new string[2]{"New Game","Новая Игра"},
		/*1*/new string[2]{"Quit","Выход"}
	};
	
	/// <summary>
	/// Gets the culture info by language.
	/// </summary>
	/// <returns>
	/// The culture info by language.
	/// </returns>
	/// <param name='language'>
	/// localization Language.
	/// </param>
	public static CultureInfo GetCultureInfoByLanguage(LocalizationLanguages language)
	{
		switch(language)
		{
		case LocalizationLanguages.English:
			return new CultureInfo("en-US");
			break;
		case LocalizationLanguages.Russian:
			return new CultureInfo("ru-RU");
			break;
		default:
			return new CultureInfo("en-US");
		}
	}
}
