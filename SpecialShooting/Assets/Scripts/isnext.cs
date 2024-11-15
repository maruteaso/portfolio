using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class isnext : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown ("q"))
			Application.Quit ();
		if(Input.GetKeyDown("n")){
			SceneManager.LoadScene ("title");
		}
		if (Input.GetKeyDown ("y")) {
			SceneManager.LoadScene ("Main");
		}
	}
}
