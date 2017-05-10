using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot2 : MonoBehaviour {

	int state = 1 ;
	private GameObject spiller;
	public float speed;
	public float randommultiplier;
	int laststate = 1;
	public float Health;


	float lengthToPlayer;
	float counter;

	public GameObject RobotWeapon;
	public GameObject Player;
	public GameObject RobotBullet1;
	public GameObject Firepointobject;

	Transform firepoint;

	Vector3 finalretning;

	// Use this for initialization
	void Awake () {
		firepoint = Firepointobject.transform;
		if (firepoint == null) {
			Debug.LogError ("FirePoint not found");
		}
	}

	void Start () {
		spiller = GameObject.Find ("Player");
	}

	void FixedUpdate () 
	{

		lengthToPlayer = Vector3.Distance (transform.position, spiller.transform.position);
		if (lengthToPlayer < 13) 
		{
			//state = 2;
		}


		if (state == 1) 
		{			

			//chill af bot
			if (counter == 0) {
				Vector3 retningmodspiller = spiller.transform.position - transform.position;
				retningmodspiller.Normalize ();

				float randomretningx = Random.Range (0, 1f) * randommultiplier;
				float randomretningy = Random.Range (0, 1f) * randommultiplier;

				retningmodspiller.x *= randomretningx;
				retningmodspiller.y *= randomretningy;

				retningmodspiller.Normalize ();

				finalretning = retningmodspiller;
				laststate = 1;
			}
			if (counter < 1) {
				GetComponent<Rigidbody2D> ().AddForce (finalretning * speed * Time.deltaTime, ForceMode2D.Impulse);
			}
			else if(counter > 1) {
				GetComponent<Rigidbody2D> ().velocity = Vector3.zero;

			}


			counter += Time.deltaTime;

			if (counter > 2) 
			{
				counter = 0;
			}
				
	
			Vector3 vectorToTarget = Player.transform.position - RobotWeapon.transform.position;
			float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			RobotWeapon.transform.rotation = Quaternion.Slerp(RobotWeapon.transform.rotation, q, Time.deltaTime * 5);
		
		
		}


}

	void Update(){
		ShootBullet();
	}

	void ShootBullet() {
		GameObject RobotBulletPrefab = Instantiate (RobotBullet1) as GameObject;
		RobotBulletPrefab.transform.position = firepoint.transform.position;
		RobotBulletPrefab.transform.up = firepoint.transform.up;
		//RobotBulletPrefab.transform.rotation = Quaternion.Euler(new Vector3 (90,90,0));
		RobotBulletPrefab.GetComponent<Rigidbody2D> ().AddForce (RobotBulletPrefab.transform.right * 1000);
		RobotBulletPrefab.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (RobotBulletPrefab.GetComponent<Rigidbody2D>().velocity.x, RobotBulletPrefab.GetComponent<Rigidbody2D>().velocity.y));
	}
}
