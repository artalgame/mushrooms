using UnityEngine;
using System.Collections;
using System;

public interface ISettingController:IDisposable{
	LocalizationLanguages Language{get;set;}
    double SoundVolume{get;set;}
	double MusicVolume{get;set;}
}
