using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour {

	Text text;
	emitter emi;

	// Use this for initialization
	void Start () {
		GameObject emit = GameObject.FindWithTag ("emitter");
		emi = emit.GetComponent<emitter> ();
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("p")) {
			if (!text.enabled) {
				Time.timeScale = 0;
				text.enabled = true;
			} else {
				Time.timeScale = 1;
				text.enabled = false;
			}
		}
		if (emi.isdeath == true) {
			Time.timeScale = 0;
			text.text = "Are you going next? Y/N";
			text.enabled = true;
			if (Input.GetKeyDown ("y")) {
				text.text = "Pause";
				text.enabled = false;
				Time.timeScale = 1;
				emi.isdeath = false;
			}
			if (Input.GetKeyDown ("n")) {
				Time.timeScale = 1;
				emi.isdeath = false;
				SceneManager.LoadScene ("title");
			}
		}
	}
}
