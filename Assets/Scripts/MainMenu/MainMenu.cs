using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class MainMenu : MonoBehaviour {
	[SerializeField]
	public IMainMenuState _currentState;
	void Awake(){
		foreach(IMainMenuState state in this.GetComponents(typeof(IMainMenuState)))
		{
			state.enabled = false;
		}
		_currentState = (IMainMenuState)this.GetComponent(typeof(SplashScreenState));
		_currentState.enabled = true;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
