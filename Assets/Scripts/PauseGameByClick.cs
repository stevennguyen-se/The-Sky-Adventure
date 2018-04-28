using UnityEngine;
using System.Collections;

public class PauseGameByClick : MonoBehaviour {
	private bool isPausing=false;
	public Texture2D playing;
	public Texture2D pausing;
	public bool paused = false;
	// Use this for initialization
	void Start () {
		gameObject.guiTexture.texture=playing;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("p")) {
									if (!paused) {
											paused = true;
									} else {
											paused = false;
									}
							}
		if (paused) {
			if (Time.timeScale == 0)
				return;
			if (Time.timeScale >= 0.01) {
				Time.timeScale -= 0.01f;
			} 
			if (AudioListener.volume > 0) {
				AudioListener.volume -= 0.01f;
			} 
		}
		if (!paused) {
			if (Time.timeScale == 1)
				return;
			if (Time.timeScale <= 1f - 0.01f) {
				Time.timeScale += 0.01f;
			}
			if (AudioListener.volume <= 1f - 0.01f) {
				
				AudioListener.volume += 0.01f;
				
			}
		}
	}
	void OnMouseEnter()
	{
	}
	void OnMouseDown()
	{


			if (!paused) {
				paused = true;
			} else {
				paused = false;
			}








	}
}
