using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSound : MonoBehaviour {

	public AudioClip hit;
	public AudioClip bounce;

	void OnCollisionEnter(Collision col)    {
		AudioSource audio = GetComponent<AudioSource> ();
		if (col.gameObject.tag == "Ball") {
			audio.clip = hit;
		} else {
			audio.clip = bounce;
		}
		audio.Play ();
	}
}
