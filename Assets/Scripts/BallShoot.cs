using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShoot : MonoBehaviour {
	public Texture2D shootBG;
	public Texture2D shootFG;
	public int speedMulti = 25;
	public float power = 5;
	public GameObject line;


	private bool mouselook = false;
	private float dist;
	private Vector2 mouseOnScreen;
	private Vector2 positionOnScreen;

     void Update () 
     {
		if (mouselook) {
			mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint (Input.mousePosition);
			positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);
			dist = Vector2.Distance (mouseOnScreen, positionOnScreen);
			float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
			transform.rotation =  Quaternion.Euler (new Vector3(0f,90-angle,0f));
			line.GetComponent<LineRenderer> ().SetPosition (1,new Vector3(0,0,dist/100));
		}

		if (Input.GetMouseButtonDown (0)) {
			mouselook = true;
		}
		if (Input.GetMouseButtonUp (0)) {
			gameObject.GetComponent<Rigidbody> ().velocity = transform.forward * dist * speedMulti;
			mouselook = false;
			dist = 0;
			line.GetComponent<LineRenderer> ().SetPosition (1,new Vector3(0,0,0));
		}
	}
 
     float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
     	return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
     }
}
