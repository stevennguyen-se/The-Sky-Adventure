using UnityEngine;
using System.Collections;

public class AutoNotActiveGameObj : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void SetActiveForObject(bool value)
	{
		gameObject.SetActive (value);

	}


}
