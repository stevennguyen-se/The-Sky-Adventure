using UnityEngine;
using System.Collections;

public class SoundEffectsHelper : MonoBehaviour
{

		public static SoundEffectsHelper Instance;
		public float volume = 1f;
		public AudioClip backgroundMusic;
		public AudioClip explosionSound;
		public AudioClip playerShotSound;
		public AudioClip enemyShotSound;
		public AudioClip rocketFuseSound;
		public AudioClip warmingSoud;
		public AudioClip playerHittedSound;
		public AudioClip boomExplosionSound;
		public AudioClip boomFuseSound;
		public AudioClip warmingSound;
		public AudioClip  weponSound;
		public AudioClip  bossFightingSound;
		public AudioClip  bossHittedSound;
		public AudioClip  mouseClickSound ;
		public AudioClip  mouseEnterSound;
		public AudioClip 	victorySound;
		private float TS = 0;
		public bool paused = false;

		void Awake ()
		{
				if (Instance != null) {
						Debug.LogError ("Multiple instances of SoundEffectsHelper!");
				}
				Instance = this;
		}

		void Start ()
		{
				AudioSource.PlayClipAtPoint (backgroundMusic, new Vector3 (0, 0, 0), volume);

		}

		void Update ()
		{
//				if (Input.GetKeyDown ("p")) {
//						if (!paused) {
//								paused = true;
//						} else {
//								paused = false;
//						}
//				}
//				if (paused) {
//						if (Time.timeScale == 0)
//								return;
//						if (Time.timeScale >= 0.01) {
//								Time.timeScale -= 0.01f;
//						} 
//						if (AudioListener.volume > 0) {
//								AudioListener.volume -= 0.01f;
//						} 
//				}
//				if (!paused) {
//						if (Time.timeScale == 1)
//								return;
//						if (Time.timeScale <= 1f - 0.01f) {
//								Time.timeScale += 0.01f;
//						}
//						if (AudioListener.volume <= 1f - 0.01f) {
//								
//								AudioListener.volume += 0.01f;
//
//						}
//				}

		}

		public void MakeExplosionSound (Vector3 position)
		{
				AudioSource.PlayClipAtPoint (explosionSound, position);
		}
	
		public void MakePlayerShotSound (Vector3 position)
		{
				AudioSource.PlayClipAtPoint (playerShotSound, position);
		}
	
		public void MakeEnemyShotSound (Vector3 position)
		{
				AudioSource.PlayClipAtPoint (enemyShotSound, position);
		}

		public void MakePlayerHittedSound (Vector3 position)
		{
				AudioSource.PlayClipAtPoint (playerHittedSound, position);
		}

		public void MakeBoomExplosionSound (Vector3 position)
		{
				AudioSource.PlayClipAtPoint (boomExplosionSound, position);
		}

		public void MakeBoomFuseSound (Vector3 position)
		{
				AudioSource.PlayClipAtPoint (boomFuseSound, position);
		}

		public void MakeRocketFuseSound (Vector3 position)
		{
				AudioSource.PlayClipAtPoint (rocketFuseSound, position);
		}

		public void ChangeWeponSound (Vector3 position)
		{
				
				AudioSource.PlayClipAtPoint (weponSound, position);
		}

		public void MakeWarmingSound (Vector3 position)
		{
				AudioSource.PlayClipAtPoint (warmingSound, gameObject.transform.position);
		}

		public void MakeBossHittedSound (Vector3 position)
		{
				AudioSource.PlayClipAtPoint (bossHittedSound, gameObject.transform.position);
		}

		public void MakeMouseEnterSound (Vector3 position)
		{
				AudioSource.PlayClipAtPoint (mouseEnterSound, gameObject.transform.position);
		}

		public void MakeMouseClickSound (Vector3 position)
		{
				AudioSource.PlayClipAtPoint (mouseClickSound, gameObject.transform.position);

		}

		public void MakeVictorySound (Vector3 position)
		{
				AudioSource.PlayClipAtPoint (victorySound, gameObject.transform.position);
		
		}

}