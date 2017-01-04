using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public float Firerate = 0;
	public float SemiFirerate = 3;
	public float Damage = 10;
	public float Bulletrange = 100;
	public float bulletspeed = 10;
	public LayerMask WhatToHit;
	public GameObject Bullet;
	public float Del1 = 0;
	public float Del2 = 0;
	public float Del3 = 0;
	public GameObject Middel;
	float TimeToFire = 0;
	Transform firepoint;
	public Sprite midte1sprite;
	public Sprite midte2sprite;
	public float bulletspread = 0;
	public int amountofbullets = 1;
	public Animator midte2anim;

	private float spreadamount;
	private float bulletsshot;
	private float Minigunspeed = 1;
	private float Minigunfirerate;
	private float MinigunAnimSpd;

	void Awake () {
		firepoint = transform.FindChild ("FirePoint");
		if (firepoint == null) {
			Debug.LogError ("FirePoint not found");



		}
	}

	void Start()
	{
		Del1 = Random.Range (1, 3);
		Del2 = Random.Range(1, 4);
		Del3 = Random.Range (1, 3);
		Debug.Log ("del" + Del2);

		if 

		if (Del2 == 1) 
		{
			midte2anim.Play ("midte1idle");		
			Firerate = 0;
			SemiFirerate = 3;
			bulletspread = 3;
			bulletspeed = 4000;
		
		}
		if (Del2 == 2) 
		{
			Middel.GetComponent<SpriteRenderer> ().sprite = midte2sprite;
			Firerate = 0;
			SemiFirerate = 1;
			amountofbullets += 5;
			bulletspread = 500;

		}
		if (Del2 == 3) 
		{
			midte2anim.Play ("Midte3Idle");
			Firerate = 1;
			Minigunfirerate = 2;
			amountofbullets = 1;
			bulletspread = 200;


		}
	}


	void Update ()
	{
		Debug.Log ("Minigunspeed" + Minigunspeed);

		if (Firerate == 0) 
		{
			if (Input.GetButtonDown("Fire1")&& Time.time > TimeToFire)
			{
				TimeToFire = Time.time + 1/SemiFirerate;

				ShootBullet (amountofbullets);
					Debug.Log (bulletsshot);
			
				if (Del2 == 2) 
				{

					midte2anim.Play ("Midte2");
					midte2anim.speed = 1;

				} else if (Del2 == 1)
				{
					midte2anim.Play ("midte1");
				}
			} 

	}
		else 
		{
			if (Input.GetButton("Fire1") && Time.time > TimeToFire) 
			{

				TimeToFire = Time.time + 1/Firerate;
				ShootBullet (amountofbullets);

				if (Del2 == 3) {
					midte2anim.Play ("Midte3");

					if (Input.GetButton("Fire1"))
					{
						Minigunshot ();
					} 
				}
			}
			if (Input.GetButtonUp ("Fire1")) 
			{
				Minigunspeed = 1;
				Firerate = Minigunfirerate;
				Debug.Log ("FJERNET");
			}
		}



}
	void SshootRay() {
		Debug.Log ("Der er skudt");
		Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
		Vector2 firePointPosition = new Vector2 (firepoint.position.x, firepoint.position.y);
		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePosition - firePointPosition, Bulletrange, WhatToHit);
		Debug.DrawLine (firePointPosition, (mousePosition-firePointPosition)*100, Color.blue);
		if (hit.collider != null) 
		{
			Debug.Log ("sollid ramt");
			Debug.DrawLine (firePointPosition, hit.point, Color.red);
			Debug.Log ("Ramte " + hit.collider.name + " og gjorde " + Damage + " skade");
		}

	}
	void ShootBullet(int BulletCount){
		for (int i = BulletCount; i > 0; i -= 1) {
			GameObject BulletPrefab = Instantiate (Bullet) as GameObject;
			BulletPrefab.transform.position = firepoint.transform.position;
			BulletPrefab.transform.up = transform.up;
			//	BulletPrefab.transform.rotation = Quaternion.Euler(new Vector3 (90,90,0));
			BulletPrefab.GetComponent<Rigidbody2D> ().AddForce (BulletPrefab.transform.up * bulletspeed);
			spreadamount = Random.Range (-bulletspread, bulletspread);
			BulletPrefab.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (spreadamount, BulletPrefab.GetComponent<Rigidbody2D>().velocity.y));
		}
	
	}
	void Minigunshot ()
	{
		if (Minigunspeed < 16)
		{
			Minigunspeed *= 2;
			Firerate = Minigunspeed * Minigunfirerate/2;
		}
	}
}
