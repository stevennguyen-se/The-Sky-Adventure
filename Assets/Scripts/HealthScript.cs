using UnityEngine;

public class HealthScript : MonoBehaviour
{

		public int hp;
		public bool isEnemy = true;
		private Health health = null;
		private GameObject HeartRoot = null;

		void Start ()
		{
		}

		void Update ()
		{
		}

		public void Damage (int damageCount)
		{
		if (hp - damageCount < 0) {
			damageCount = hp;
						hp = 0;
				} else {
						hp -= damageCount;
				}
			
		print (hp);
				if (health != null) {
						health.modifyHealth (-damageCount);
				}
				if (gameObject.tag == "Player") {
						PlayerIsHitted playerIsHittedScipt = gameObject.GetComponent<PlayerIsHitted> ();
						playerIsHittedScipt.SetHitted ();
						PlayerHeartBar playerHeartBarScript = gameObject.GetComponent<PlayerHeartBar> ();
						playerHeartBarScript.DecreaseHeart ();
				
			if(hp>=1)
			{
				SpecialEffectsHelper.Instance.Explosion (transform.position);
				SoundEffectsHelper.Instance.MakeExplosionSound (gameObject.transform.position);
			}
						Invoke ("SetNotHitted", 2.5f);


				}

		
				if (hp <= 0 ) {
						if (gameObject.tag == "Boss" ) {
				SpecialEffectsHelper.Instance.Explosion (transform.position);
				SoundEffectsHelper.Instance.MakeVictorySound(gameObject.transform.position);
				Invoke("GoToEnd",3);
				print("bossdie");
						}
						Destroy (gameObject);

				}
		}
		public void GoToEnd()
	{
		Application.LoadLevel ("InEnd");
		}
		void OnTriggerEnter2D (Collider2D otherCollider)
		{
				ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript> ();
				if (shot != null) {
						// tránh bắn trúng đồng đội
						if (shot.isEnemyShot != isEnemy) {
								Damage (shot.damage);
								if (hp <= 0) {
										SpecialEffectsHelper.Instance.Explosion (transform.position);
					SoundEffectsHelper.Instance.MakeExplosionSound (gameObject.transform.position);
										Destroy (shot.gameObject); 
								} else {
										Destroy (shot.gameObject); 
								}
						}
				}
		}

		public void ActiveHeartBar ()
		{

		GameObject tmpWarming = GameObject.Find ("Warming");
		tmpWarming.SetActive (false);


						GameObject getHealthGameObject = GameObject.Find ("BossHeart");
						health = getHealthGameObject.GetComponent<Health> () as Health;
						health.startHealth = hp;
						health.maxHealth = hp;
						health.AddHearts (health.startHealth / health.healthPerHeart);
						health.modifyHealth (hp);
				
		
		
		}

		public void SetNotHitted ()
		{
				PlayerIsHitted playerIsHittedScipt = gameObject.GetComponent<PlayerIsHitted> ();
				playerIsHittedScipt.SetNotHitted ();

		}



}