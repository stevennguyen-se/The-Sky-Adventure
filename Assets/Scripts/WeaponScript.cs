using UnityEngine;

/// <summary>
/// Launch projectile
/// </summary>
public class WeaponScript : MonoBehaviour
{
	public Transform shotPrefab;
	public Transform bullet1=null;
	public Transform bullet2=null;
	public Transform bullet3=null;
	public Transform bullet4=null;
	public Transform bossFinalBullet=null;
	//dung de luu khong thoi gian toi thieu cho cac lan ban dan
	public float shootingRate = 0.25f;
	//dung de gan gia tri cua shootingRate va tru tu tu xuong 0
	private float shootCooldown;
	
	void Start()
	{
		shootCooldown = 0f;
	}
	
	void Update()
	{
		if (shootCooldown > 0)
		{
			shootCooldown -= Time.deltaTime;
		}
	}
	// biến biến isEnemy dùng để xác định player bắn hay enymy bắn 
	public void Attack(bool isEnemy)
	{
		if (CanAttack)
		{
			shootCooldown = shootingRate;
			
			//tao prefab vien dan
			var shotTransform = Instantiate(shotPrefab) as Transform;
			//đặt viên đạn tại vị trí player
			Vector3 tmpPosition = shotTransform.transform.position;
			tmpPosition.x=gameObject.transform.position.x;
			tmpPosition.y=gameObject.transform.position.y;
			shotTransform.position = tmpPosition;
			// lấy script của viên đạn
			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
			if (shot != null)
			{
				shot.isEnemyShot = isEnemy;
			}
			//chinh huong cho dan vi player co thể xoay qua tray hay qua phải
			MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
			if (move != null)
			{
				move.direction = this.transform.right; // lúc nào cũng từ hướng đầu tàu bay ra
			}
		}
	}

	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}
	public void ActiveWepon1()
	{if (gameObject.tag=="Boss") {
						shotPrefab = bossFinalBullet;
			GameObject.Find("Box Boss").GetComponent<BossScript>().minAttackCooldown=GameObject.Find("Box Boss").GetComponent<BossScript>().maxAttackCooldown;
				} else {
						shotPrefab = bullet1;
				}

	}
	public void ActiveWepon2()
	{
		shotPrefab = bullet2;
	}
	public void ActiveWepon3()
	{
		shotPrefab = bullet3;
	}
	public void ActiveWepon4()
	{
		shotPrefab = bullet4;
	}
}