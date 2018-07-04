using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRespawn : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		Debug.Log ("Trigger");
		GameObject.Find ("GameManager").GetComponent<MapLoader> ().respawnBall (other.gameObject);
	}
}
