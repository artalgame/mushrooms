using UnityEngine;
using System.Collections;

public class SplashScreenState : IMainMenuState {
	
	[SerializeField]
		private Texture2D _splashTexture;
	[SerializeField]
		private RealObjectParameters textureParameter;
	
	void Awake(){
	}
	// Use this for initialization
	void Start () {
	base.Start();
	}
	
	// Update is called once per frame
	void Update () {
	}
	public override void OnClick(object Source)
	{
		if(Source is SplashTextureControl)
		{
				if(!_mainMenu.audio.isPlaying)
				{
					_mainMenu.audio.Play();
				}
				_mainMenu._currentState = (IMainMenuState)_mainMenu.GetComponent(typeof(MainMenuState));
				SetEnabledForState();
		}
	}
}
