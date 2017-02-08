using UnityEngine;
using System.Collections;

public class robot1 : MonoBehaviour {
	int state = 1 ;
	private GameObject spiller;
	public float speed;
	public float randommultiplier;

	float lengthToPlayer;
	float counter;

	Vector3 finalretning;

	// Use this for initialization
	void Start () {
		spiller = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		lengthToPlayer = Vector3.Distance (transform.position, spiller.transform.position);
		//Debug.Log ("længde til spiller: " + lengthToPlayer);
		//starter state 2
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
			Debug.Log("State 2 boi");
			GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
			counter += Time.deltaTime;
			if (counter > 4)
			{
				//Spil anim

			}else if (counter < 8)
			{
				state = 3;
			}


		}
		if (state == 3) 
		{
			//flækkerbot
			Debug.Log("state 3 boiii");
			Vector3 retningmodspiller = spiller.transform.position - transform.position;
			retningmodspiller.Normalize ();
			finalretning = retningmodspiller;
			GetComponent<Rigidbody2D> ().AddForce (finalretning * speed * Time.deltaTime, ForceMode2D.Impulse);
		}
	}
}
