using UnityEngine;
using System.Collections;
/// <summary>
/// I localization controller interface.
/// </summary>
public interface ILocalizationController{
	/// <summary>
	/// Gets the string from global string array by index and language.
	/// </summary>
	/// <returns>
	/// The string.
	/// </returns>
	/// <param name='index'>
	/// Index of string.
	/// </param>
	/// <param name='language'>
	/// Language of string.
	/// </param>
	string GetString(int index, LocalizationLanguages language);
	/// <summary>
	/// Gets the string by index and current localization language.
	/// </summary>
	/// <returns>
	/// The string.
	/// </returns>
	/// <param name='index'>
	/// Index of string.
	/// </param>
	string GetString(int index);
}
