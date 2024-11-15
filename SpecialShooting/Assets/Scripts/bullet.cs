using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

	public int speed = 10;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = transform.up * speed;
	}
	
	// Update is called once per frame
	void Update () {
		string layername = LayerMask.LayerToName (gameObject.layer);
		if(layername != "enemybullet")
			Destroy (gameObject,4);
	}
}
