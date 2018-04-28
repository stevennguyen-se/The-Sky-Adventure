using UnityEngine;
using System.Collections;

public class PlayerHeartBar : MonoBehaviour {
	public GUITexture image;
	public Texture2D image_0;
	public Texture2D image_1;
	public Texture2D image_2;
	public Texture2D image_3;
	public Texture2D image_4;
	public Texture2D image_5;

	private int maxHeart = 5;
	private int curHeart = 0;
	// Use this for initialization
	void Start () {
		curHeart = maxHeart;
		image.texture = image_5;
	}
	
	// Update is called once per frame
	void Update () {
	}
	public void DecreaseHeart()
	{
		curHeart -= 1;
		if (curHeart == 4) {
			image.texture = image_4;
			return;
				}
		if (curHeart == 3) {
			image.texture = image_3;
			return;
		}
		if (curHeart == 2) {
			image.texture = image_2;
			return;
		}
		if (curHeart == 1) {
			image.texture = image_1;
			return;
		}
		if (curHeart == 0) {
			image.texture = image_0;
			return;
		}
	}
}
