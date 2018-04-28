using UnityEngine;
using System.Collections;

public class DestroyAfterAnimationEnd : MonoBehaviour {
	public float timeToWait = 0.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	private IEnumerator KillOnAnimationEnd() {
		yield return new WaitForSeconds (timeToWait);
		Destroy (gameObject);
	}
	
	void Update () {
		StartCoroutine (KillOnAnimationEnd ());
	}
}
