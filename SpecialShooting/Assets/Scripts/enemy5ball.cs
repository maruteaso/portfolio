using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy5ball : MonoBehaviour {

	public int speed = 10;
	GameObject enemy5;
	enemy5cannon enecan;

	// Use this for initialization
	void Start () {
		enemy5 = GameObject.FindWithTag ("enemy5");
		enecan = enemy5.GetComponent<enemy5cannon> ();
		GetComponent<Rigidbody2D> ().velocity = transform.up * speed;
	}

	// Update is called once per frame
	void Update () {
		string layername = LayerMask.LayerToName (gameObject.layer);
		if(layername != "enemybullet")
			Destroy (gameObject,4);
	}

	void OnTriggerEnter2D(Collider2D c){
		string layerName = LayerMask.LayerToName (c.gameObject.layer);
		if (layerName == "player") {
			Vector2 pos = c.transform.position;
			pos.x += 30;
			c.transform.position = pos;
			enecan.bullying ();
		}
		if (layerName == "playerbullet") {
			Destroy (c.gameObject);
		}
	}

}
