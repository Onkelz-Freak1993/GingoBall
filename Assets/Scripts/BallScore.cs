using UnityEngine;
using System.Collections;

public class BallScore : MonoBehaviour {
	private GameObject gameManager;

	void start(){
	}

	void OnCollisionEnter(Collision col)    {
		if (col.gameObject.GetComponent<Renderer> ().material.GetColor ("_Color") == gameObject.GetComponent<Renderer> ().material.GetColor ("_Color") && col.gameObject.tag != "Ball") {

			GameObject.Find ("GameManager").GetComponent<MapLoader> ().onScore ();
			DestroyObject (gameObject);
		}
	}

}