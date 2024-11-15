using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy4stealth : MonoBehaviour {
	
	SpriteRenderer sp;
	enemac ene;
	bool a = false;
	// Use this for initialization
	void Start () {
		ene = GetComponent<enemac> ();
		sp = GetComponent<SpriteRenderer> ();
		StartCoroutine ("lets");
	}

	IEnumerator lets(){
		while (true) {
			if(Input.GetKeyDown("h")||ene.a == 1){
				a = true;
				sp.enabled = false;
				yield return new WaitForSeconds (5);
				a = false;
				sp.enabled = true;
			}
			yield return new WaitForSeconds (0);
		}
	}

	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D c){
		if (ene.isplayer (c)) {
			if (a) {
				sp.enabled = true;
				Invoke ("awaker", 0.1f);
			}
		}
	}

	void awaker(){
		sp.enabled = false;
	}

}
