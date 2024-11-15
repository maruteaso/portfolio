using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy10T : MonoBehaviour {
	public GameObject lazer3;
	public GameObject lazer4;
	wave10 wave10;
	enemac ene;
	Animator anime;
	public float delay;
	public Vector3 nowpos;
	// Use this for initialization
	void Start () {
		GameObject a = GameObject.FindWithTag ("wave10");
		wave10 = a.GetComponent<wave10> ();
		ene = GetComponent<enemac> ();
		anime = GetComponent<Animator> ();
		StartCoroutine ("Lazer10");
	}

	IEnumerator Lazer10(){
		while (true) {
			if (Input.GetKeyDown ("h")|| ene.a ==1) {
				anime.SetTrigger ("lazer10");
				yield return new WaitForSeconds (delay);
			}
			yield return new WaitForSeconds (0);
		}

	}

	public void lastlaze(){
		Vector3 pos = transform.position;
		pos.y -= 18;
		pos.x += 2f;
		Instantiate (lazer3, pos, Quaternion.identity);
		pos.x -= 3f;
		Instantiate (lazer4, pos, Quaternion.identity);
	}

	// Update is called once per frame
	void Update () {
		nowpos = transform.position;
		if (ene.auto) {
			Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0.4f, 0.7f));
			Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (0.6f, 1));
			nowpos.x = Mathf.Clamp (nowpos.x, min.x, max.x);
			nowpos.y = Mathf.Clamp (nowpos.y, min.y, max.y);
			transform.position = nowpos;
		}
	}

	void OnTriggerEnter2D(Collider2D c){
		if (ene.isplayer(c)) {
			if (ene.hp < 2) {
				wave10.islive = false;
			}
			ene.destruction (c);
		}

	}
}
