using UnityEngine;
using System.Collections;

public class MainMenuState : IMainMenuState {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		if(GUI.Button(new Rect(100,100,100,50),LocalizationLanguages.English.ToString()))
		{
			GameCoreSingletone.Singletone.SettingController.Language = LocalizationLanguages.English;
		}
		if(GUI.Button(new Rect(100,200,100,50),LocalizationLanguages.Russian.ToString()))
		{
			GameCoreSingletone.Singletone.SettingController.Language = LocalizationLanguages.Russian;
		}
		if(GUI.Button(new Rect(0,0,70,50),GameCoreSingletone.Singletone.LocalizationController.GetString(1)))
		{
			Application.Quit();
		}
	}
}
