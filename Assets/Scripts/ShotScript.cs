using UnityEngine;

public class ShotScript : MonoBehaviour
{
	public int damage = 1;
	public bool isEnemyShot = false;
	public bool isNeverDestroy=false;
	
	void Start()
	{
		if (isNeverDestroy == false) {
						Destroy (gameObject, 2); //xóa đạn trong 2s kể từ khi xuất hiện
				}
	}
}