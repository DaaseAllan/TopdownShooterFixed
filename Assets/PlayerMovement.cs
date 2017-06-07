using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public Rigidbody2D rb;
	public GameObject prefab;
	public float speed = 3000;

	void FixedUpdate(){

		Vector2 movement = new Vector2 ();

		if (Input.GetKey(KeyCode.W)) {
			movement.y = speed;

		}
		if (Input.GetKey(KeyCode.S)) {
			movement.y = -speed;

		}
		if (Input.GetKey(KeyCode.A)) {
			movement.x = -speed;

		}
		if (Input.GetKey(KeyCode.D)) {
			movement.x = speed;
//			print ("Mmmh");

		}
		var t = Time.deltaTime;
		//if (t>0.03f){t = 0.03f;}

		//rb.GetComponent<Rigidbody2D>().AddForce(movement*Time.deltaTime, f)


		rb.velocity = movement*Time.fixedDeltaTime;
	}

	/*void Fuck()
	{
		for (int i = 0;i < 10; i+=1) 
		{
			GameObject obj = Instantiate(prefab) as GameObject;
			obj.transform.position = transform.position + new Vector3(Random.value * 3, Random.value * 3, 0);
			obj.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
			obj.transform.localScale = new Vector3(Random.value, Random.value, Random.value);
			obj.GetComponent<Rigidbody>().AddTorque(transform.right * Time.deltaTime * 500);
		}
	}
}
*/
}