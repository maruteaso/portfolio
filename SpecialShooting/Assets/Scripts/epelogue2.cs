using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class epelogue2 : MonoBehaviour {

	public float speed; 
	Vector2 pos;
	RectTransform rec;
	public bool isstart;

	// Use this for initialization
	void Start () {
		rec = GetComponent<RectTransform> ();
		pos = rec.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("q"))
			Application.Quit ();
		if (isstart) {
			Vector2 direction = new Vector2 (0, 1);
			pos += direction * speed * Time.deltaTime;
			rec.localPosition = pos;
			Vector3 judge = rec.localPosition;
			if (judge.y >= 105 || Input.GetKeyDown("space"))
				SceneManager.LoadScene ("title");
		}
	}
}
