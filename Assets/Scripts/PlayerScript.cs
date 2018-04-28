using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public Vector2 speed = new Vector2(50, 50);
	private Vector2 movement;
	public bool canShoot =true;

	public bool usingRocket=false;
	public bool usingBoom=false;
	// Use this for initialization
	void Start () {

	}
	
	void Update () {
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		movement = new Vector2(
			speed.x * inputX,
			speed.y * inputY);
		if (canShoot) {
						//dùng GetButton để lấy left click liên tục, GetButtonDown để lấy từng nhịp click
						if (Input.GetButtonDown ("Fire1")) {
								WeaponScript weapon = GetComponent<WeaponScript> ();
								if (weapon != null) {
										//false bởi vì player bắn
										weapon.Attack (false);
					if(usingRocket==false && usingBoom==false)
					{
										SoundEffectsHelper.Instance.MakePlayerShotSound (gameObject.transform.position);
					}
					if(usingRocket==true)
					{
						SoundEffectsHelper.Instance.MakeRocketFuseSound (gameObject.transform.position);
					}
								}
						}
				}

		var dist = (transform.position - Camera.main.transform.position).z;
		
		var leftBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)	).x;
		
		var rightBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(1, 0, dist)
			).x;
		
		var topBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
			).y;
		
		var bottomBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 1, dist)
			).y;
		
		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
			Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
			transform.position.z
			);

	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		bool damagePlayer = false;
		EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
		if (enemy != null)
		{
			// Kill the enemy
			HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
			if (enemyHealth != null) enemyHealth.Damage(enemyHealth.hp);
			
			damagePlayer = true;
		}
		if (damagePlayer)
		{

			HealthScript playerHealth = this.GetComponent<HealthScript>();
			if (playerHealth != null) playerHealth.Damage(1);
		}
	}

	void FixedUpdate()
	{
		rigidbody2D.velocity = movement;
	}
}
