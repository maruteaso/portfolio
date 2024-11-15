using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy9kaneboss : MonoBehaviour {

	public GameObject lazer1;
	public GameObject lazer2;
	enemac ene;
	Animator anime;
	public float delay;
	public Vector3 nowpos;
	// Use this for initialization
	void Start () {
		anime = GetComponent<Animator> ();
		ene = GetComponent<enemac> ();
		StartCoroutine ("eyelazer");
	}

	IEnumerator eyelazer(){
		while (true) {
			if (Input.GetKeyDown ("h")|| ene.a == 1) {
				anime.SetTrigger ("lazer9");
				yield return new WaitForSeconds (delay);
			}
			yield return new WaitForSeconds (0);
		}
	}

	public void eyelaze(){
		Vector3 pos = transform.position;
		pos.y -= 17;
		pos.x += 1.3f;
		Instantiate (lazer1, pos, Quaternion.identity);
		pos.x -= 2.6f;
		Instantiate (lazer2, pos, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		nowpos = transform.position;
	}

	void OnTriggerEnter2D(Collider2D c){
		if (ene.isplayer (c)) {
			ene.destruction (c);
		}

	}

}
