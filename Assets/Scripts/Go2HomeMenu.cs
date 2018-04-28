using UnityEngine;
using System.Collections;

public class Go2HomeMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseEnter() {
		SoundEffectsHelper.Instance.MakeMouseEnterSound (transform.position);

		
	}
	void OnMouseExit()
	{
	}
	void OnMouseDown()
	{
		SoundEffectsHelper.Instance.MakeMouseClickSound (transform.position);
		
		Application.LoadLevel ("InMenu");
	}
}
