using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
	public float bombRadius = 10f;			// Bán kính vụ nổ
	public float bombForce = 100f;			// Lực để ném đi
	public AudioClip boom;					// Âm thanh hiệu ứng nổ
	public AudioClip fuse;					// Âm thanh hiệu ứng gần nổ
	public float fuseTime = 1.5f;			//Thời gian chờ của bom nổ
	public GameObject explosion;			// Prefab cho hiệu ứng ứng nổ.
	public int boomDame;

	private ParticleSystem explosionFX;		


	void Awake ()
	{
		explosionFX = GameObject.FindGameObjectWithTag("ExplosionFX").GetComponent<ParticleSystem>();
	}
	void Update()
	{


	}
	void Start ()
	{
		SoundEffectsHelper.Instance.MakeBoomFuseSound (gameObject.transform.position);
		//if(transform.root == transform) 	StartCoroutine(BombDetonation());
	}

//	IEnumerator BombDetonation()
//	{
//		// Play the fuse audiocSlip.
//		AudioSource.PlayClipAtPoint(fuse, transform.position);
//
//		// Wait for 2 seconds.
//		yield return new WaitForSeconds(fuseTime);
//
//		// Explode the bomb.
//		Explode();
//	}

	void OnTriggerEnter2D (Collider2D col) 
	{
		
		if (col.tag == "Boss" || col.tag == "Enemy") {
			Explode ();
		} 
	}
	public void Explode()
	{
		// Lấy tất cả các Game Object trong bán kính vụ nổ
		Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, bombRadius, 1 << LayerMask.NameToLayer("Default"));

		foreach(Collider2D en in enemies)
		{
			Rigidbody2D rb = en.rigidbody2D;
			if(rb != null && (rb.tag == "Enemy" || rb.tag == "Boss")  )
			{
				HealthScript tmpHealthScript = rb.GetComponent<HealthScript>();
				tmpHealthScript.Damage(boomDame);

//				Vector3 deltaPos = rb.transform.position - transform.position;
//				Vector3 force = deltaPos.normalized * bombForce;
//				rb.AddForce(force);
			}
		}

		explosionFX.transform.position = transform.position;
		explosionFX.Play();
		SoundEffectsHelper.Instance.MakeBoomExplosionSound (gameObject.transform.position);
		Instantiate(explosion,transform.position, Quaternion.identity);



		Destroy (gameObject);
	}
}
