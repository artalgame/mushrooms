using UnityEngine;
using System.Collections;
using System;

public class MainMenuState : IMainMenuState {
	// Use this for initialization
	void Start () {
	 base.Start();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/// <summary>
	/// Raises the click event.
	/// </summary>
	/// <param name='Source'>
	/// Source.
	/// </param>
	public override void OnClick(object Source){
		if(Source is GameButtonControl)
		{
			try{
				_mainMenu._currentState = (IMainMenuState)_mainMenu.GetComponent(typeof(PrepareToGameState));
			}
			catch(Exception ex)
			{
				Debug.LogError("can not set current set in _mainMenu becouse _mainMenu don't exist "+ex.Message);
			}
				SetEnabledForState();
		}
		else
			if(Source is SettingButtonControl){
				try{
				_mainMenu._currentState = (IMainMenuState)_mainMenu.GetComponent(typeof(SettingsState));
			}
			catch(Exception ex)
			{
				Debug.LogError("can not set current set in _mainMenu becouse _mainMenu don't exist "+ex.Message);
			}
				SetEnabledForState();

			}
		else
			if(Source is QuitButtonControl){
				try{
				Application.Quit();
			}
			catch(Exception ex)
			{
				Debug.LogError("can not set current set in _mainMenu becouse _mainMenu don't exist "+ex.Message);
			}
				SetEnabledForState();

			}
	}
	void OnEnable(){
		if(!audio.isPlaying){
			audio.Play();
		}
			
	}
}
