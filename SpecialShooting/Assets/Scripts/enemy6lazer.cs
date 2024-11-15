using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy6lazer : MonoBehaviour {

	public GameObject lazer;
	enemac ene;
	Animator anime;
	public float delay;
	public Vector3 nowpos;

	// Use this for initialization
	void Start () {
		ene = GetComponent<enemac> ();
		anime = GetComponent<Animator> ();
		StartCoroutine ("Lazer");
	}
	
	// Update is called once per frame
	void Update () {
		nowpos = transform.position;

	}

	IEnumerator Lazer(){
		while (true) {
			if (Input.GetKeyDown ("h")|| ene.a ==1) {
				anime.SetTrigger ("lazer");
				yield return new WaitForSeconds (delay);
			}
			yield return new WaitForSeconds (0);
		}

	}

	public void shoot(){
		Vector3 pos = transform.position;
		pos.y -= 16f;
		pos.x += 0.1f;
		Instantiate (lazer, pos, Quaternion.identity);
	}
}
