using UnityEngine;

public class EnemyScript : MonoBehaviour
{
		private MoveScript moveScript;
		private WeaponScript[] weapons;
		private bool hasSpawn;

		void Awake ()
		{
				//lấy các WeaponScript trong các GameObject con
				weapons = GetComponentsInChildren<WeaponScript> ();
				moveScript = GetComponent<MoveScript> ();
		}

		void Start ()
		{
			
				hasSpawn = false;
				moveScript.enabled = false;
				if (gameObject.tag == "Notification") {
						return;
				}
				collider2D.enabled = false;
				
				foreach (WeaponScript weapon in weapons) {
						weapon.enabled = false;
				}
		}
	
		void Update ()
		{
	
				if (hasSpawn == false) {
						if (renderer.IsVisibleFrom (Camera.main)) {
								Spawn ();
						}
				} else {
						foreach (WeaponScript weapon in weapons) {
								// Auto-fire
								if (weapon != null && weapon.CanAttack) {
										weapon.Attack (true);
										SoundEffectsHelper.Instance.MakeEnemyShotSound (gameObject.transform.position);
								}
						}
						if (renderer.IsVisibleFrom (Camera.main) == false) {
								Destroy (gameObject);
						}
				}
		}

		private void Spawn ()
		{

				
				
				// -- Moving
				moveScript.enabled = true;
				
		if (gameObject.tag == "Notification" && hasSpawn == false) {
						SoundEffectsHelper.Instance.MakeWarmingSound (gameObject.transform.position);
			hasSpawn = true;
						return;
				}
		hasSpawn = true;

				collider2D.enabled = true;
				// -- Moving
				moveScript.enabled = true;
				// -- Shooting
				foreach (WeaponScript weapon in weapons) {
						weapon.enabled = true;
				}
		}
}