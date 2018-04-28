using UnityEngine;
using System.Collections;

public class PlayerIsHitted : MonoBehaviour {
	private bool isHitted=false;
	private float transparency = 1f;
	private bool transparencyGoingUp = false;
	private bool currentlyFlashing = true;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (isHitted == true) {
			Color tempColor = gameObject.renderer.material.color;
			tempColor.a = transparency;
			gameObject.renderer.material.color = tempColor;

			//adjust what the alpha will be updated to next time this coroutine is run
			if(transparencyGoingUp)
			{
				transparency += 0.1f;
				if(transparency > 0.95f && transparency < 1.2f && currentlyFlashing) //if(transparency == 1)
					transparencyGoingUp = false;
			}
			else //if transparency is going down
			{
				transparency -= 0.1f;
				if(transparency < 0.2f && transparency > 0.08f) //if(transparency == 0.1f)
					transparencyGoingUp = true;
			}
			
		}

	}
	public void SetHitted()
	{
		gameObject.GetComponent<WeaponScript>().enabled=false;
		gameObject.collider2D.enabled = false;
		gameObject.GetComponent<PlayerScript>().canShoot =false;
		isHitted = true;
		Vector3 tmpPosition= Camera.main.WorldToScreenPoint(gameObject.transform.position);
		gameObject.transform.position	= Camera.main.ScreenToWorldPoint( new Vector3(Screen.width/10, Screen.height/2,tmpPosition.z) );;

	}
	public void SetNotHitted()
	{
		gameObject.GetComponent<WeaponScript>().enabled=true;
		gameObject.GetComponent<PlayerScript>().canShoot =true;
		isHitted = false;
		Color tempColor = gameObject.renderer.material.color;
		tempColor.a = 1;
		gameObject.renderer.material.color = tempColor;
		gameObject.collider2D.enabled = true;

	}

}
