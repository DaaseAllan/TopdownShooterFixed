using UnityEngine;
using System.Collections;

public class Bulletscript : MonoBehaviour {
	Vector3 lastPosition = Vector3.zero;
	public float DestroyAfterSeconds = 3;
	public float speed;
	public float Damage;

	// Use this for initialization
	void Start () {

		Destroy (gameObject, DestroyAfterSeconds);
	
	}
	
	// Update is called once per frame
	void Update () {
		


	}

			void FixedUpdate()
			{
				speed = (transform.position - lastPosition).magnitude;
				lastPosition = transform.position;
		Damage = speed * 100;
	}
}
