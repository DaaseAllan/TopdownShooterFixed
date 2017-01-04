using UnityEngine;
using System.Collections;

public class SmadrMaj : MonoBehaviour {
	IEnumerator Start (){
		yield return new WaitForSeconds (0.1f);
		for (float i = 0; i < 3; i += Time.deltaTime) {
			GetComponent<Renderer> ().material.color = new Color (GetComponent<Renderer> ().material.color.r, GetComponent<Renderer> ().material.color.g, GetComponent<Renderer> ().material.color.b, 1 - (i / 3));
			print (GetComponent<Renderer> ().material.color.a);
			yield return null;
		}
		Destroy (this.gameObject);
	}
}
