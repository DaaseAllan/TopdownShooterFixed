using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotKugle : MonoBehaviour {
	public float DestroyAfterSeconds = 3;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, DestroyAfterSeconds);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
