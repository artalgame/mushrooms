using UnityEngine;
using System.Collections;

public class SplashScreenState : IMainMenuState {
	
	void Awake(){
		_mainMenu = (MainMenu)GameObject.FindGameObjectWithTag("MainMenu").GetComponent(typeof(MainMenu));
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnGUI()
	{
		if(GUI.Button(new Rect(10,10,100,100),"Go to main menu"))
		{
			_mainMenu._currentState = (IMainMenuState)_mainMenu.GetComponent(typeof(MainMenuState));
			SetEnabledForState();
		}
	}
}
