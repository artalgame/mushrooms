using UnityEngine;
using System.Collections;
using System;

public class IMainMenuState:MonoBehaviour{
	[SerializeField]
	protected internal MainMenu _mainMenu;
	
	protected internal void SetEnabledForState()
	{
		this.enabled = false;
		_mainMenu._currentState.enabled = true;
	}
}
