using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class epelogue : MonoBehaviour {

	epelogue2 epe;
	AudioSource aud;

	// Use this for initialization
	void Start () {
		GameObject a = GameObject.FindWithTag ("epelogue");
		aud = a.GetComponent<AudioSource> ();
		epe = a.GetComponent<epelogue2> ();
		Invoke ("Continue", 4);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("q"))
			Application.Quit ();
	}

	void Continue(){
		epe.isstart = true;
		aud.Play ();
		Destroy (gameObject);
	}
}
