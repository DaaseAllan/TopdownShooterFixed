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

	Vector3 finalretning;

	// Use this for initialization
	void Start () {
		spiller = GameObject.Find ("Player");
	}

	void FixedUpdate () 
	{
		lengthToPlayer = Vector3.Distance (transform.position, spiller.transform.position);
		if (lengthToPlayer < 13) 
		{
			Debug.Log ("Robot 2 er i 13 længde");
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

			if (counter > 1) 
			{
				counter = 0;
			}
	}
}
}
