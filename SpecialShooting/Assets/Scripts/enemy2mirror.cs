using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2mirror : MonoBehaviour {
	enemac ene;
	// Use this for initialization
	void Start () {
		GameObject a = GameObject.FindWithTag ("enemy2");
		ene = a.GetComponent<enemac> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D c){
		if (ene.isplayer (c)) {
			Vector2 mir = new Vector2 (0, -1);
			c.transform.parent.gameObject.GetComponent<Rigidbody2D> ().velocity = mir * 20f;
			c.gameObject.layer = LayerMask.NameToLayer ("enemybullet");
		}

	}

}
