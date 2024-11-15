using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy3tough : MonoBehaviour {

	enemac ene;

	// Use this for initialization
	void Start () {
		ene = GetComponent<enemac> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D c){
		if (ene.isplayer (c)) {
				ene.destruction (c);
		}
	}
}
