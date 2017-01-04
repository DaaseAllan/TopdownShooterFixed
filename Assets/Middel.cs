using UnityEngine;
using System.Collections;

public class Middel : MonoBehaviour {
	public GameObject Weaponbase;
	public float Part1;
	// Use this for initialization
	void Start () 
	{
		Debug.Log ("HEJ");
		GameObject Weaponbase = GameObject.Find ("Weapon");



	}
	void spriteskifer()
	{
		Part1 = Weaponbase.GetComponent<Weapon> ().Del1;
		if (Part1 == 1) 
		{
			Debug.Log ("DET VIRKER xD");
		}
	}


	// Update is called once per frame
	void Update () {

		if (Part1 == 1) 
		{
			Debug.Log ("DET VIRKER xD");
		}
	}
}
