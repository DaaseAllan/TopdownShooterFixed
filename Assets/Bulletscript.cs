using UnityEngine;
using System.Collections;

public class Bulletscript : MonoBehaviour {
	
	public float DestroyAfterSeconds = 3;

	// Use this for initialization
	void Start () {

		Destroy (gameObject, DestroyAfterSeconds);
	
	}
	
	// Update is called once per frame
	void Update () {


	}
}
