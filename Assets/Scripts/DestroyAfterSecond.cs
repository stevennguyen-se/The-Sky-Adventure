using UnityEngine;
using System.Collections;

public class DestroyAfterSecond : MonoBehaviour {
	public float second;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, second);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
