using UnityEngine;
using System.Collections;
using System;
using System.Globalization;

public interface ISettingController:IDisposable,IChangeMusicSender,IChangeSoundSender{
	/// <summary>
	/// Gets or sets the ideal resolution.
	/// </summary>
	/// <value>
	/// The ideal resolution.
	/// </value>
	Resolution IdealResolution{get;set;}
	/// <summary>
	/// The size of the _ideal font.
	/// </summary>
	int IdealFontSize{get;set;}
	/// <summary>
	/// Gets or sets the current resolution.
	/// </summary>
	/// <value>
	/// The current resolution.
	/// </value>
	Resolution CurrentResolution{get;set;}
	/// <summary>
	/// Gets or sets the height proportional coeficient.
	/// </summary>
	/// <value>
	/// The new height proportional coeficient.
	/// </value>
	double ProportionalHeightCoeficient{get;set;}
	/// <summary>
	/// Gets or sets the proportional width coeficient.
	/// </summary>
	/// <value>
	/// The proportional width coeficient.
	/// </value>
	double ProportionalWidthCoeficient{get;set;}
	/// <summary>
	/// The name of the _setting file.
	/// </summary>
	///
    CultureInfo UsingCultureInfo{get;set;}
	/// <summary>
	/// Gets or sets the language.
	/// </summary>
	/// <value>
	/// The language.
	/// </value>
	LocalizationLanguages Language{get;set;}
	/// <summary>
	/// Gets or sets the sound volume.
	/// </summary>
	/// <value>
	/// The sound volume.
	/// </value>
    double SoundVolume{get;set;}
	/// <summary>
	/// Gets or sets the music volume.
	/// </summary>
	/// <value>
	/// The music volume.
	/// </value>
	double MusicVolume{get;set;}
	/// <summary>
	/// Saves the preferences.
	/// </summary>
	/// <returns>
	/// True if operation ended ok.
	/// </returns>
	bool SavePreferences();
}
