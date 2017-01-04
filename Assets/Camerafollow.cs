using UnityEngine;
using System.Collections;

public class Camerafollow : MonoBehaviour {
	public GameObject target;
	private Vector2 velocity;
	public float smoothTimeX;
	public float smoothTimeY;


	void start ()
	{
		target = GameObject.FindGameObjectWithTag ("Player");
	}

	void FixedUpdate ()
	{
		float posX = Mathf.SmoothDamp (transform.position.x, target.transform.position.x, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp (transform.position.y, target.transform.position.y, ref velocity.y, smoothTimeY);

		transform.position = new Vector3 (posX, posY, transform.position.z);
	}
}