using UnityEngine;
using System.Collections;
using System;

public class LocalizationController :ILocalizationController{
	
	/// <summary>
	/// The _strings of game.
	/// </summary>
	private string [][] _strings;
	/// <summary>
	/// Gets the string.
	/// </summary>
	/// <returns>
	/// The string.
	/// </returns>
	/// <param name='index'>
	/// Index of string .
	/// </param>
	/// <param name='language'>
	/// current localization Language.
	/// </param>
	public string GetString(int index, LocalizationLanguages language){
		string answ;
		try{
			answ = _strings[index][(int)language];
		}
		catch{
			GameCoreSingletone.Singletone.LogController.WriteLine("Don't find string by index="+index.ToString()+" for language="
				+language.ToString());
			answ = ":)";
		}
		Debug.Log("Returned string = " + answ);
    	return answ;
	}
	public string GetString(int index)
	{
		return GetString(index, GameCoreSingletone.Singletone.SettingController.Language);
	}
 	/// <summary>
	/// Initializes a new instance of the <see cref="LocalizationController"/> class.
	/// </summary>
	public LocalizationController(){
		_strings = GlobalConstants.STRING_ARRAY;
	}
}
