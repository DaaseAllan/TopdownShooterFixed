using UnityEngine;
using System.Collections;

public class robot1 : MonoBehaviour {
	int state = 1 ;
	private GameObject spiller;
	public float speed;
	public float randommultiplier;
	int laststate = 1;
	public float Health;


	float lengthToPlayer;
	float counter;

	Vector3 finalretning;

	// Use this for initialization
	void Start () {
		spiller = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		lengthToPlayer = Vector3.Distance (transform.position, spiller.transform.position);
		if (lengthToPlayer < 13) 
		{
			state = 2;
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


		
		}
		if (state == 2) 
		{
			//transform bot
			//counter reset
			if (laststate == 1) 
			{
				counter = 0;
			}
			//Debug.Log("State 2 boi");
			GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
			counter += Time.deltaTime;
			laststate = 2;
			if (counter > 4)
			{
				//Spil anim

			} if (counter > 4)
			{
				state = 3;
			}


		}
		if (state == 3) 
		{
			//flækkerbot
		//	Debug.Log("state 3 boiii");
			Vector3 retningmodspiller = spiller.transform.position - transform.position;
			retningmodspiller.Normalize ();
			finalretning = retningmodspiller;
			GetComponent<Rigidbody2D> ().AddForce (finalretning * speed * 100 * Time.deltaTime, ForceMode2D.Impulse);
			laststate = 3;
		}

	
	}
	void OnTriggerEnter2D(Collider2D Coll)
	{
		Debug.Log (Coll.name);

		if (Coll.tag == "Bullet") 
		{
			Debug.Log ("ramt");
			Health -= Coll.GetComponent<Bulletscript> ().Damage;
			Destroy (Coll.gameObject);

			if (Health <= 0)
				Destroy (gameObject);
		}
	}
}
