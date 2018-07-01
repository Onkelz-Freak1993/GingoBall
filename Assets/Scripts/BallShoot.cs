using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShoot : MonoBehaviour {
	public Texture2D shootBG;
	public Texture2D shootFG;
	public int speedMulti = 25;


	private float dist;
     void Update () 
     {
		
		Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
		Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);
		dist = Vector2.Distance (mouseOnScreen, positionOnScreen);

		if (Input.GetMouseButtonDown(0))
			gameObject.GetComponent<Rigidbody>().velocity = transform.forward * dist * speedMulti;
        	float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
			transform.rotation =  Quaternion.Euler (new Vector3(0f,90-angle,0f));
     }
 
     float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
         return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
     }

	void OnGUI(){

	}
}
