using UnityEngine;
using System.Collections;

public class MuteMusic : MonoBehaviour {
	private bool isMuting=false;
	public Texture2D muting;
	public Texture2D music;
	// Use this for initialization
	void Start () {
		gameObject.guiTexture.texture=music;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseEnter()
	{
	}
	void OnMouseDown()
	{
		if (isMuting == true) {
			isMuting=false;
			gameObject.guiTexture.texture=music;
			AudioListener.pause = false;
		} else {
			isMuting=true;
			gameObject.guiTexture.texture=muting;
			AudioListener.pause = true;
		}
	}
}
