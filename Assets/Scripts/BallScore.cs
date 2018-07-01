using UnityEngine;
using System.Collections;

public class BallScore : MonoBehaviour {

public GameObject ObjectToDestroy;
public GameObject TheObject;
public GameObject Player;

void OnCollisionEnter(Collision col)    {
    if (col.gameObject == TheObject) {
        ObjectToDestroy.SetActive (false);
    }
}
}
