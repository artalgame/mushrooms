using UnityEngine;
using System.Collections;
using System.IO;

/// <summary>
/// Create and dispose game core. This object don't destroyed.
/// </summary>
///
public class GameCore : MonoBehaviour
{
	void Awake()
	{
		///don't destroy this fundamental object
		GameObject.DontDestroyOnLoad(this);
		///create Singletone of Game Core
		var t =	GameCoreSingletone.Singletone;		
	}
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
	/// <summary>
	/// don't remove it
	/// </summary>
	void OnApplicationQuit()
	{
		GameCoreSingletone.Singletone.Dispose();
	}
}