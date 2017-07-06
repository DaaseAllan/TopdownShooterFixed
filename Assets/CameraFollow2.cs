using UnityEngine;
using System.Collections;

public class CameraFollow2 : MonoBehaviour {

	public GameObject player;       //Public variable to store a reference to the player game object


	private Vector3 offset;         //Private variable to store the offset distance between the player and camera

	private Vector3 LastPos;

	public float smoothing;

	// Use this for initialization
	void Start () 
	{
		//Calculate and store the offset value by getting the distance between the player's position and camera's position.
	
	}

	// LateUpdate is called after Update each frame
	void FixedUpdate () 
	{
		// Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.

		LastPos.z = -10;

		transform.position = Vector3.Lerp(transform.position, LastPos, Time.fixedDeltaTime*smoothing);

		LastPos = player.transform.position;
	}
}