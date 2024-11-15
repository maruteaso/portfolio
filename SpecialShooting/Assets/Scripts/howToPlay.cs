using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class howToPlay : MonoBehaviour {

	Text howto;

	// Use this for initialization
	void Start () {
		howto = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space"))
			howto.text = "スペースキーで飛ばせます";
	}
}
