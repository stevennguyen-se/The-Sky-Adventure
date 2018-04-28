using UnityEngine;
using System.Collections;

public class NewGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	void OnMouseEnter() {
		renderer.material.color = Color.yellow;
		SoundEffectsHelper.Instance.MakeMouseEnterSound (transform.position);

		
	}
	void OnMouseExit()
	{
		renderer.material.color = Color.white;
	}
	void OnMouseDown()
	{
		SoundEffectsHelper.Instance.MakeMouseClickSound (transform.position);
		Application.LoadLevel ("InGame");
	}
	// Update is called once per frame
	void Update () {
		
	}
}
