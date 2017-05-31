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
	public GameObject Top;
	float TimeToFire = 0;
	Transform firepoint;
	public Sprite midte1sprite;
	public Sprite midte2sprite;
	public float bulletspread = 0;
	public int amountofbullets = 1;
	public Animator midte2anim;
	public float bulletspeeddif = 0;
	public float bulletspeeddifference;
	public Sprite Rør1sprite;
	public Sprite Rør2sprite;

	private float spreadamount;
	private float bulletsshot;
	private float Minigunspeed = 1;
	private float Minigunfirerate;
	private float MinigunAnimSpd;
	private float newbulletspeed;

	//Crosbowvariabler.
	private float counter;
	private bool bowcharged = false;

	void Awake () {
		firepoint = transform.Find ("FirePoint");
		if (firepoint == null) {
			Debug.LogError ("FirePoint not found");



		}
	}

	void Start()
	{
		Del1 = Random.Range (1, 3);
		Del2 = Random.Range(4, 5);
		Del3 = Random.Range (1, 3);
		Debug.Log ("del1 blev nummer" + Del1);
		Debug.Log ("del2 blev nummer" + Del2);



		if (Del2 == 1) 
		{
			midte2anim.Play ("midte1idle");		
			Firerate = 0;
			SemiFirerate = 5;
			bulletspread = 100;
			bulletspeed = 4000;
			bulletspeeddif = 150;
		
		}
		if (Del2 == 2) 
		{
			Middel.GetComponent<SpriteRenderer> ().sprite = midte2sprite;
			Firerate = 0;
			SemiFirerate = 1;
			amountofbullets += 5;
			bulletspread = 300;
			bulletspeed = 2000;
			bulletspeeddif = 250;

		}
		if (Del2 == 3) 
		{
			midte2anim.Play ("Midte3Idle");
			Firerate = 1;
			Minigunfirerate = 2;
			amountofbullets = 1;
			bulletspread = 200;


		}
		if (Del2 == 4) 
		{
			midte2anim.Play ("Midte4Idle");
			Firerate = 0;
			amountofbullets = 1;
			bulletspread = 200;


		}

		if (Del1 == 1)
		{
			Top.GetComponent<SpriteRenderer> ().sprite = Rør1sprite;
			bulletspread *= 0.25f;
			bulletspeeddif *= 1.5f;
			bulletspeed *= 1.5f;
		}

		if (Del1 == 2)
		{
			Top.GetComponent<SpriteRenderer> ().sprite = Rør2sprite;
				bulletspread *= 2;
			bulletspeeddif *= 3;
			if (amountofbullets > 1)
			{
				amountofbullets *= 2;
			} else {
				amountofbullets = 3;
			}
			Firerate *= 0.5f;
			SemiFirerate *= 0.5f;
			Minigunfirerate *= 0.33f;

		}

	
	}


	void Update ()
	{
//		Debug.Log ("Minigunspeed" + Minigunspeed);
		if (Firerate == 0) {

			if (Del2 == 4) {

				if (bowcharged == true) {
					Debug.Log (counter);

					if (counter < 5) {
						counter += Time.deltaTime;
					

					}
					if (Input.GetButtonDown ("Fire1") && bowcharged == false) {
						bowcharged = true;
						midte2anim.Play ("Midte4");
					}


					if (Input.GetButtonUp ("Fire1")) {
						Debug.Log ("Der er skudt");
						bowcharged = false;
						counter = 0;
						midte2anim.Play ("Midte4Idle");
					}

				} else {
					if (Input.GetButtonDown ("Fire1") && Time.time > TimeToFire) {
						TimeToFire = Time.time + 1 / SemiFirerate;

						ShootBullet (amountofbullets);
						Debug.Log (bulletsshot);
			
						if (Del2 == 2) {

							midte2anim.Play ("Midte2");
							midte2anim.speed = 1;

						} else if (Del2 == 1) {
							midte2anim.Play ("midte1");
						}
					} 
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
		
			}





		}
			

}
		

	void ShootRay() {
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
			bulletspeeddifference = Random.Range (-bulletspeeddif, bulletspeeddif);
			newbulletspeed = bulletspeed + bulletspeeddifference;
			GameObject BulletPrefab = Instantiate (Bullet) as GameObject;
			BulletPrefab.transform.position = firepoint.transform.position;
			BulletPrefab.transform.up = transform.up;
			//	BulletPrefab.transform.rotation = Quaternion.Euler(new Vector3 (90,90,0));
			BulletPrefab.GetComponent<Rigidbody2D> ().AddForce (BulletPrefab.transform.up * newbulletspeed);
			spreadamount = Random.Range (-bulletspread, bulletspread);
			BulletPrefab.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (spreadamount, BulletPrefab.GetComponent<Rigidbody2D>().velocity.y));
			newbulletspeed = bulletspeed;
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
