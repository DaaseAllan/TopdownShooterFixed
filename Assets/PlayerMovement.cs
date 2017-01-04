using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public Rigidbody2D rb;
	public GameObject prefab;

	void Update(){
		if (Input.GetKey(KeyCode.W)) {
			rb.velocity = new Vector2 (rb.velocity.x, 80);

		}
		if (Input.GetKey(KeyCode.S)) {
			rb.velocity = new Vector2 (rb.velocity.x, -80);

		}
		if (Input.GetKey(KeyCode.A)) {
			rb.velocity = new Vector2 (-80, rb.velocity.y);

		}
		if (Input.GetKey(KeyCode.D)) {
			rb.velocity = new Vector2 (80, rb.velocity.y);

		}


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