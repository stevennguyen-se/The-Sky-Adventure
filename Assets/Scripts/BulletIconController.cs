using UnityEngine;
using System.Collections;

public class BulletIconController : MonoBehaviour {
	public GUITexture nomarlBullet;
	public GUITexture  x3Bullet;
	public GUITexture rocketlBullet;
	public GUITexture boomlBullet;

	private Color orgizinalColor;

	private Color clickColor;
	// Use this for initialization
	void Start () {
		orgizinalColor = nomarlBullet.color;

		Color tmpColor; 
		tmpColor.r=10;
		tmpColor.g=10;
		tmpColor.b=10;
		tmpColor.a = 1f;
		clickColor = tmpColor;
	}
	
	// Update is called once per frame
	void Update () {
	

	

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			ReturnAll();
			nomarlBullet.color=clickColor;

			GameObject tmpPlayer = GameObject.Find("Player");
			tmpPlayer.GetComponent<WeaponScript>().ActiveWepon1();
			return;

				}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			ReturnAll();
			x3Bullet.color=clickColor;
			GameObject tmpPlayer = GameObject.Find("Player");
			tmpPlayer.GetComponent<WeaponScript>().ActiveWepon2();
			return;
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			ReturnAll();
			GameObject.Find("Player").GetComponent<PlayerScript>().usingRocket=true;
			rocketlBullet.color=clickColor;
			GameObject tmpPlayer = GameObject.Find("Player");
			tmpPlayer.GetComponent<WeaponScript>().ActiveWepon3();
			return;
		}

		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			ReturnAll();
			GameObject.Find("Player").GetComponent<PlayerScript>().usingBoom=true;
			boomlBullet.color=clickColor;
			GameObject tmpPlayer = GameObject.Find("Player");
			tmpPlayer.GetComponent<WeaponScript>().ActiveWepon4();
			return;
		}
	
	}
	public void ReturnAll()
	{
		GameObject.Find("Player").GetComponent<PlayerScript>().usingRocket=false;
		GameObject.Find("Player").GetComponent<PlayerScript>().usingBoom=false;
		nomarlBullet.color = orgizinalColor;
		rocketlBullet.color = orgizinalColor;
		boomlBullet.color = orgizinalColor;
		x3Bullet.color = orgizinalColor;

		SoundEffectsHelper.Instance.ChangeWeponSound (gameObject.transform.position);
	}
}
