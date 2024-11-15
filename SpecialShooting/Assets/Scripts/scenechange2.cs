using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechange2 : MonoBehaviour {

	nowwave nw;
	public int wavenum;

	void Start(){
		GameObject a = GameObject.FindWithTag ("nowwave");
		nw = a.GetComponent<nowwave> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("q"))
			Application.Quit ();
		if(Input.GetKeyDown("n")){
			nw.nowWave = 0;
			SceneManager.LoadScene ("title");
		}
		if (Input.GetKeyDown ("y")) {
			SceneManager.LoadScene ("Main");
		}
	}
}
