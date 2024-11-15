using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemac : MonoBehaviour {

	machine mac;
	private Animator anime;
	public float speed;
	public int hp = 10;
	public int a;
	public bool auto = false;
	public bool isspecial;
	public bool isbig;
	float x;
	float y;
	// Use this for initialization
	void Start () {
		mac = GetComponent<machine> ();
		anime = GetComponent<Animator> ();
		StartCoroutine ("shooter");
		if (auto)
			StartCoroutine ("Automove");
	}
	
	// Update is called once per frame
	void Update () {
		if (!auto) {
			x = Input.GetAxisRaw ("Horizontal2");
			y = Input.GetAxisRaw ("Vertical2");
		}
			if (isbig)
			y = 0;
		
		Vector2 direction = new Vector2 (x, y).normalized;
		if(!isspecial)
			Move (direction);
	}

	void Move(Vector2 direction){
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0.1f, 0.7f));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (0.9f, 1));
		Vector2 pos = transform.position;
		pos += direction * Time.deltaTime * speed;
		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);
		transform.position = pos;
	}

	IEnumerator shooter(){
		while (true) {
			if ((Input.GetKey ("space")) || (auto)) {
				/*mac.shot (transform);
				yield return new WaitForSeconds (mac.shotdelay);*/
				for (int i = 0; i < transform.childCount; i++) {
					Transform childtrans = transform.GetChild (i);
					if(childtrans.tag != "mirror")
						mac.shot (childtrans);
				}
				yield return new WaitForSeconds (mac.shotdelay);
			}
			yield return new WaitForSeconds (0);
		}
	}

	IEnumerator Automove(){
		while (true) {
			Vector2 now = transform.position;
			Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0.7f));
			Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
			a = Random.Range (1, 3);
			float b = (float)a;
			x = (float)Random.Range (-1, 2);
			y = (float)Random.Range (-1, 2);
			if (b == 1) {
				if (now.x == min.x) {
					x = 1;
				}
				if (now.x == max.x) {
					x = -1;
				}
				if (now.y == min.y) {
					y = 1;
				}
				if (now.y == max.y) {
					y = -1;
				}
			}
			yield return new WaitForSeconds (b);
		}
	}

	public void move(Vector2 direction){
		GetComponent<Rigidbody2D> ().velocity = direction * speed;
	}

	public bool isplayer(Collider2D c){
		string layerName = LayerMask.LayerToName (c.gameObject.layer);
		if (layerName == "playerbullet") {
			
			return true;
		}
		else
			return false;
	}

	public void destruction(Collider2D c){
		Destroy (c.gameObject);
		hp -= 1;
		anime.SetTrigger ("damage");
		if (hp <= 0) {
			mac.bang ();
			Destroy (gameObject);
		}
		}
	}
