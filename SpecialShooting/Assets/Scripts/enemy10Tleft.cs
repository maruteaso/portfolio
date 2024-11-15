using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy10Tleft : MonoBehaviour {
	machine mac;
	enemac ene;
	wave10 wave10;
	public GameObject boss;
	public GameObject right;
	GameObject shotpos;
	Vector3 pos;
	float x;
	float y;
	// Use this for initialization
	void Start () {
		shotpos = GameObject.FindWithTag ("special");
		GameObject a = GameObject.FindWithTag ("wave10");
		wave10 = a.GetComponent<wave10> ();
		ene = GetComponent<enemac> ();
		mac = GetComponent<machine> ();
		StartCoroutine ("live");
		StartCoroutine ("rightlive");
		if (ene.auto)
			mac.shotdelay = 0.15f;
		if (!ene.auto)
			Destroy (shotpos);
	}

	// Update is called once per frame
	void Update () {
		if (!ene.auto) {
			x = Input.GetAxisRaw ("Horizontalleft");
			y = Input.GetAxisRaw ("Verticalleft");
		}
		if (ene.isbig)
			y = 0;

		Vector2 direction = new Vector2 (x, y).normalized;
		Move (direction);
	}

	void Move(Vector2 direction){
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0.7f));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		if (ene.auto) {
			min = Camera.main.ViewportToWorldPoint (new Vector2 (0.7f, 0.7f));
		}
		Vector2 pos = transform.position;
		pos += direction * Time.deltaTime * ene.speed;
		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);
		transform.position = pos;
	}

	void OnTriggerEnter2D(Collider2D c){
		if (ene.isplayer(c)) {
			if (ene.hp < 2) {
				wave10.isleftlive = false;
			}
			ene.destruction (c);
		}

	}

	IEnumerator live(){
		while (true) {
			if (Input.GetKeyDown ("x") || ene.a == 1) {
				if (wave10.islive == false) {
					pos = transform.position;
					pos.x -= 18;
					GameObject bos = (GameObject)Instantiate (boss, pos, Quaternion.identity);
					bos.transform.parent = wave10.transform;
					wave10.islive = true;
					yield return new WaitForSeconds (10);
				}

			}
			yield return new WaitForSeconds (0);
		}
	}

	IEnumerator rightlive(){
		while (true) {
			if (Input.GetKeyDown ("x")|| ene.a == 1) {
				if (wave10.isrightlive == false) {
					pos = transform.position;
					pos.x -= 36;
					GameObject r = (GameObject)Instantiate (right, pos, Quaternion.identity);
					r.transform.parent = wave10.transform;
					wave10.isrightlive = true;
					yield return new WaitForSeconds (10);
				}
			}
			yield return new WaitForSeconds (0);
		}
	}

	public void lastlaze(){
	}
}
