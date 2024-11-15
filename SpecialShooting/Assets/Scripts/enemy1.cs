using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour  {

	enemac ene;
	enemy1mother e1;
	// Use this for initialization
	void Start () {
		ene = GetComponent<enemac> ();
		GameObject a = GameObject.FindWithTag ("mother");
		e1 = a.GetComponent<enemy1mother> ();
		//StartCoroutine ("afterE");
	}

	// Update is called once per frame
	void Update () {
		if (e1.motherdeath)
			Destroy (gameObject);
	}

	/*IEnumerator afterE(){
		ene.StopCoroutine ("shooter");
		while (true) {
			if (Input.GetKey ("space")) {
				for (int i = 0; i < transform.childCount; i++) {
					Transform childtrans = transform.GetChild (i);
					mac.shot (childtrans);
				}
				yield return new WaitForSeconds (mac.shotdelay);
			}
			yield return new WaitForSeconds (0);
		}
	}*/

	void OnTriggerEnter2D(Collider2D c){
		if (ene.isplayer(c)) {
			
			ene.destruction (c);
		}
	}
}
