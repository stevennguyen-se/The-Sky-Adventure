using UnityEngine;

public class BossScript : MonoBehaviour
{
		private bool hasSpawn;
		private MoveScript moveScript;
		private WeaponScript[] weapons;
		private Animator animator;
		private SpriteRenderer[] renderers;
		private float aiCooldown;
		private bool isAttacking;
		private bool nearDie = false;
		private bool nearestDie = false;
		private bool die = false;
		private int maxHeath = 200;
		private int curHeath;
		private Vector2 positionTarget;
		private bool activateHeartBar = false;
		public float minAttackCooldown = 0.5f;
		public float maxAttackCooldown = 2f;
		public GameObject explosionParticle;
		public GameObject bossShield = null;

		void Awake ()
		{
				weapons = GetComponentsInChildren<WeaponScript> ();
				moveScript = GetComponent<MoveScript> ();
				animator = GetComponent<Animator> ();
				renderers = GetComponentsInChildren<SpriteRenderer> ();
				bossShield.SetActive (false);

		}
	
		void Start ()
		{

				hasSpawn = false;
				collider2D.enabled = false;
				moveScript.enabled = false;
				foreach (WeaponScript weapon in weapons) {
						weapon.enabled = false;
				}
				isAttacking = false;
				aiCooldown = maxAttackCooldown;
		}
	
		void Update ()
		{


				HealthScript tmpBossHP = gameObject.GetComponent<HealthScript> ();
				curHeath = tmpBossHP.hp;
				//print (curHeath);
				if (curHeath <= 150 && nearDie == false) {
						nearDie = true;
						animator.SetBool ("Normal2NearDie", true);
				}
				if (curHeath <= 100 && nearestDie == false) {
						nearestDie = true;
						animator.SetBool ("NearDie2NearestDie", true);
				}

				if (curHeath <= 50 && die == false) {
						die = true;
						animator.SetBool ("NearestDie2Die", true);
						foreach (WeaponScript weapon in weapons) {
								weapon.ActiveWepon1 ();
								bossShield.SetActive (true);
						}

				}


				if (hasSpawn == false) {
		
						if (renderers [0].IsVisibleFrom (Camera.main)) {
								Spawn ();
						}
				} else {



						aiCooldown -= Time.deltaTime;
			
						if (aiCooldown <= 0f) {
								isAttacking = !isAttacking;
								aiCooldown = Random.Range (minAttackCooldown, maxAttackCooldown);
								positionTarget = Vector2.zero;
								//animator.SetBool ("NearDie", isAttacking);
								if (nearDie == false) {
										animator.SetBool ("Attack", isAttacking);
								}
								if (nearDie == true && die == false) {
										animator.SetBool ("NearDie", isAttacking);
								}
								if (nearestDie == true && die == false) {
										animator.SetBool ("NearestDie", isAttacking);
								}
		
				
			
						}
						if (isAttacking) {
								moveScript.direction = Vector2.zero;
								foreach (WeaponScript weapon in weapons) {
										if (weapon != null && weapon.enabled && weapon.CanAttack) {
												weapon.Attack (true);
												SoundEffectsHelper.Instance.MakeEnemyShotSound (gameObject.transform.position);
										}
								}
						} else {

								if (positionTarget == Vector2.zero) {

										Vector2 randomPoint = new Vector2 (Random.Range (0f, 1f), Random.Range (0f, 1f));
					
										positionTarget = Camera.main.ViewportToWorldPoint (randomPoint);
								}
				
								if (collider2D.OverlapPoint (positionTarget)) {

										positionTarget = Vector2.zero;
								}
				
			
								Vector3 direction = ((Vector3)positionTarget - this.transform.position);
				

								moveScript.direction = Vector3.Normalize (direction);
						}
				}
		}
	
		private void Spawn ()
		{
				if (gameObject.tag == "Boss") {
		


						GameObject tmpGUIController = GameObject.Find ("GUIController");
						GUIController tmpGUIControllerScipt = tmpGUIController.GetComponent<GUIController> ();

						GameObject tmpBossIcon = GameObject.Find ("BossIcon");
						if (tmpBossIcon.guiTexture.enabled == false)
								tmpBossIcon.guiTexture.enabled = true;



					HealthScript tmpHealthScriptScipt = gameObject.GetComponent<HealthScript> ();
					tmpHealthScriptScipt.ActiveHeartBar ();







						//HealthScript tmpHealthScript = gameObject.GetComponent<HealthScript> () as HealthScript;
						//tmpHealthScript.ActiveHeartBar();



				}
				hasSpawn = true;
				collider2D.enabled = true;
				moveScript.enabled = true;
				//mỗi vật thể có thể có nhiều wepon, mỗi wepond sẽ có 1 hướng đạn bay + loại đạn 
				//trong mỗi loại đạn sẽ có Dame riêng + của ai dùng
				foreach (WeaponScript weapon in weapons) {
						weapon.enabled = true;
				}
				//khi Boss được sinh ra, 
				foreach (ScrollingScript scrolling in FindObjectsOfType<ScrollingScript>()) {
						if (scrolling.isLinkedToCamera) {
								scrolling.speed = Vector2.zero;
						}
				}
		}
	
		void OnTriggerEnter2D (Collider2D otherCollider2D)
		{

				// khi gạp va chạm thì sẽ lấy hết viên đạn va chạm 
				ShotScript shot = otherCollider2D.gameObject.GetComponent<ShotScript> ();
				if (shot != null) {
						//kiểm tra nếu không phải do phe ác bắn thì sẽ chạy animation
						if (shot.isEnemyShot == false) {
								SoundEffectsHelper.Instance.MakeBossHittedSound (gameObject.transform.position);
								Quaternion randomRotation = Quaternion.Euler (0f, 0f, Random.Range (0f, 360f));
								Vector3 tmpPosition = gameObject.transform.position;
								tmpPosition.x = otherCollider2D.transform.position.x + 0.01f;
								Instantiate (explosionParticle, tmpPosition, randomRotation);


								aiCooldown = Random.Range (minAttackCooldown, maxAttackCooldown);
								if (die != true) {
										isAttacking = false;
								}
								
								if (nearDie == false)
										animator.SetTrigger ("Hit");
								if (nearDie == true && nearestDie == false)
										animator.SetTrigger ("NearDieHit");
								if (nearestDie == true && die == false)
										animator.SetTrigger ("NearestDieHit");


			
					


						}
				}
		}
}