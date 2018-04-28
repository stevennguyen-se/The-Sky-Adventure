using UnityEngine;
using System.Collections;

public class GoToInfo : MonoBehaviour {
	public GameObject playWordPrefab=null;
	private GameObject clone=null;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
		Application.LoadLevel ("InInfomation");
		
	}
}
