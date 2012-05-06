using UnityEngine;
using System.Collections;
using System;

public class IMainMenuState:MonoBehaviour{
	[SerializeField]
	protected internal MainMenu _mainMenu;
	[SerializeField]
	protected internal UIPanel _panel;
	protected void Start()
	{
		_mainMenu = (MainMenu)GameObject.FindGameObjectWithTag("MainMenu").GetComponent(typeof(MainMenu));
	}
	/// <summary>
	/// Set new state enabled = true, and this enabled = false.
	/// </summary>
	///
	protected internal void SetEnabledForState()
	{
		///make gui of current state not visible
		if(this._panel != null){
			this._panel.gameObject.SetActiveRecursively(false);
		/*	this._panel.gameObject.active = false;
			///deactive all children objects
			foreach(Transform child in this._panel.gameObject.transform)
				child.gameObject.active = false;
		*/
		}
		///make gui of new state visible
		if(_mainMenu._currentState._panel!=null)
		{
			
			_mainMenu._currentState._panel.gameObject.SetActiveRecursively(true);
			///activate all children components
		/*	foreach(Transform child in _mainMenu._currentState._panel.gameObject.transform)
				child.gameObject.active = true;
		*/
		}
		///disable current state 
		this.enabled = false;
		///enable new state
		_mainMenu._currentState.enabled = true;
	}
	public virtual void OnClick(object Source)
	{
	}
}
