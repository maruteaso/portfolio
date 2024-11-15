using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scenechange : MonoBehaviour {

	public Text t;
	nowwave nw;
	GameObject title;
	public int a = 0;

	void Start(){
		title = GameObject.FindWithTag ("Title");
		GameObject a = GameObject.FindWithTag ("nowwave");
		nw = a.GetComponent<nowwave> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			if (a == 1) {
				SceneManager.LoadScene ("Main");
			}
			if (a == 0) {
				Destroy (title);
				a = 1;
			}
		}
		if (Input.GetKeyDown ("q")) {
			Application.Quit();
		}
		if (Input.GetKeyDown ("a")) {
			if (nw.s == 0) {
				nw.s = 1;
			} else {
				nw.s = 0;
			}
		}
		if (nw.s == 1) {
			t.text = "AUTO";
		} else {
			t.text = "";
		}
}
}
