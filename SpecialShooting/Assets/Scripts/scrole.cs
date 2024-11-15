using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrole : MonoBehaviour {

	public float speed;
	Vector3 move = new Vector3(0,59,0);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (speed * Time.deltaTime, 0, 0);
		if (transform.position.y <= -59)
			transform.position = move;
	}
}
