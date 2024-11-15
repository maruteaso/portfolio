using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy8missile : MonoBehaviour {
	public GameObject missile;
	public float delay;
	enemac ene;
	Vector2 pos;
	// Use this for initialization
	void Start () {
		ene = GetComponent<enemac> ();
		StartCoroutine ("Missile");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Missile(){
		while (true) {
			if (Input.GetKey ("h")||ene.auto) {
				pos = transform.position;
				pos.y += 15;
				Instantiate (missile, pos, Quaternion.identity);
				yield return new WaitForSeconds (delay);
			}
			yield return new WaitForSeconds (0);
		}
	}

}
