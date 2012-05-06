using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class MainMenu : MonoBehaviour,IChangeMusicListener {
	[SerializeField]
	public IMainMenuState _currentState;
	[SerializeField]
	protected IMainMenuState _firstState;
	void Awake(){
		///registration to get music volume's changes
		GameCoreSingletone.Singletone.SettingController.AddNewMusicListener(this);
		foreach(IMainMenuState state in this.GetComponents(typeof(IMainMenuState)))
		{
			state.enabled = false;
			if(state._panel!=null)
			state._panel.gameObject.SetActiveRecursively(false);
		}
		if(_firstState != null)
		{
			_currentState = _firstState;
		}
		else
		{
			_currentState = (IMainMenuState)this.GetComponent(typeof(SplashScreenState));
		}
		_currentState.enabled = true;
		_currentState._panel.gameObject.SetActiveRecursively(true);
		
		SetNewMusicVolume((float)GameCoreSingletone.Singletone.SettingController.MusicVolume);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void SetNewMusicVolume (float volume)
	{
		if(volume == 0)
		{
			audio.Stop();
		}
		else
			if((!audio.isPlaying)&&(gameObject.active))
				audio.Play();
			audio.volume = volume;
	}
	
}
