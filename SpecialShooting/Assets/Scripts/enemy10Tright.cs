using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy10Tright : MonoBehaviour {
	wave10 wave10;
	enemac ene;
	float x;
	float y;
	bool isboost = false;
	public float speed;
	// Use this for initialization
	void Start () {
		GameObject a = GameObject.FindWithTag ("wave10");
		wave10 = a.GetComponent<wave10> ();
		ene = GetComponent<enemac> ();
		StartCoroutine ("right");
		speed = ene.speed;
	}

	// Update is called once per frame
	void Update () {
		if (!ene.auto) {
			x = Input.GetAxisRaw ("Horizontalright");
			y = Input.GetAxisRaw ("Verticalright");
		}
		if (isboost) {
			if (y > 0)
				y = 0;
			if (x < 0)
				x = 0;
		}
		if (ene.isbig)
			y = 0;

		Vector2 direction = new Vector2 (x, y).normalized;
		if(!isboost)
			Move (direction);
		if (isboost)
			SpecialMove (direction);
	}

	void Move(Vector2 direction){
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0.7f));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		if (ene.auto) {
			max = Camera.main.ViewportToWorldPoint (new Vector2 (0.3f, 1));
		}
		Vector2 pos = transform.position;
		pos += direction * Time.deltaTime * speed;
		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);
		transform.position = pos;
	}

	void SpecialMove(Vector2 direction){
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		Vector2 pos = transform.position;
		pos += direction * Time.deltaTime * speed;
		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);
		transform.position = pos;
	}

	IEnumerator right(){
		while (true) {
			if (Input.GetKeyDown ("s")) {
				Vector2 spos = transform.position;
				ene.isspecial = true;
				speed = 20;
				isboost = true;
				yield return new WaitForSeconds (3.5f);
				speed = ene.speed;
				isboost = false;
				transform.position = spos;
				ene.isspecial = false;
				yield return new WaitForSeconds (5);
			}
			yield return new WaitForSeconds (0);
		}

	}

	void OnTriggerEnter2D(Collider2D c){
		if (ene.isplayer(c)) {
			if (ene.hp < 2) {
				wave10.isrightlive = false;
			}
			ene.destruction (c);
		}

	}

	public void lastlaze(){}
}
