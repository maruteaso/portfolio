using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1mother : MonoBehaviour {

	enemac ene;
	public GameObject enemy1;
	public float delay;
	public bool motherdeath;

	// Use this for initialization
	void Start () {
		ene = GetComponent<enemac> ();
		StartCoroutine ("enemyborn");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D c){
		if (ene.isplayer (c)) {
			if (ene.hp < 2) {
				motherdeath = true;
			}
			ene.destruction (c);
		}
	}

	IEnumerator enemyborn(){
		while (true) {
			if (Input.GetKey ("space")|| ene.auto) {
				Instantiate (enemy1, transform.position, Quaternion.identity);
				yield return new WaitForSeconds (delay);
			}
			yield return new WaitForSeconds (0);
		}
	}
}
