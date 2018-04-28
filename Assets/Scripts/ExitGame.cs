using UnityEngine;
using System.Collections;

public class ExitGame : MonoBehaviour {
	public GameObject playWordPrefab=null;
	private GameObject clone=null;

	// Use this for initialization
	void Start () {
	
	}
	void OnMouseEnter() {
		renderer.material.color = Color.green;
		SoundEffectsHelper.Instance.MakeMouseEnterSound (transform.position);
		Vector3 tmp;
		tmp.x = gameObject.transform.position.x;
		tmp.y = gameObject.transform.position.y;
		tmp.z = playWordPrefab.transform.position.z;
		clone = Instantiate(playWordPrefab,tmp,Quaternion.identity) as GameObject;
		
	}
	void OnMouseExit() {
		renderer.material.color = Color.white;

		Destroy (clone);
		
	}
	void OnMouseDown()
	{
		SoundEffectsHelper.Instance.MakeMouseClickSound (transform.position);
		Application.Quit();

	}
	// Update is called once per frame
	void Update () {
		

		
	}
}
