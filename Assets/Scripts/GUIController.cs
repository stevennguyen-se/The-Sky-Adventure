using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GUIController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject tmpBossIcon = GameObject.Find ("BossIcon");
		if(tmpBossIcon.guiTexture.enabled==true) tmpBossIcon.guiTexture.enabled =false;


	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void HideBossHeartRoot()
	{
		GameObject tmpBossHeartRoot = GameObject.Find ("BossHeartRoot");
		List<Transform> listGameObject = new List<Transform>();
		for (int i=0; i<tmpBossHeartRoot.transform.childCount; i++) {
			Transform child = tmpBossHeartRoot.transform.GetChild(i) ;
			GameObject tmp = child.gameObject;
			print(tmp.name);
			tmp.SetActive(false);


				}
	}
	public void DisplayBossHeartRoot()
	{
		GameObject tmpBossHeartRoot = GameObject.Find ("BossHeartRoot");
		List<Transform> listGameObject = new List<Transform>();
		for (int i=0; i<tmpBossHeartRoot.transform.childCount; i++) {
			Transform child = tmpBossHeartRoot.transform.GetChild(i) ;
			GameObject tmp = child.gameObject;
			tmp.SetActive(true);
			
			
		}

	}
}
