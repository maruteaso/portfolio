using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour {

	void Update(){
		if (Input.GetKeyDown ("q"))
			Application.Quit ();
	}

	void OnTriggerExit2D(Collider2D c){
		string layername = LayerMask.LayerToName (c.gameObject.layer);
		if ((layername != "player")&&(layername != "enemy")) {
			Destroy (c.gameObject);
		}
	}
}
