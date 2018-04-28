using UnityEngine;

public class GreenDragonScript : MonoBehaviour
{

	private WeaponScript[] weapons;
	private bool hasSpawn;
	
	void Awake ()
	{
		//lấy các WeaponScript trong các GameObject con
		weapons = GetComponentsInChildren<WeaponScript> ();

	}
	
	void Start ()
	{
		hasSpawn = false;
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
					SoundEffectsHelper.Instance.MakeEnemyShotSound(gameObject.transform.position);
				}
			}
			if (renderer.IsVisibleFrom (Camera.main) == false) {
				Destroy (gameObject);
			}
		}
	}
	
	private void Spawn ()
	{
		hasSpawn = true;
		
		collider2D.enabled = true;
	
		// -- Shooting
		foreach (WeaponScript weapon in weapons) {
			weapon.enabled = true;
		}
	}
}