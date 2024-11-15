using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazer4 : MonoBehaviour {

	enemy10T e10;
	public float power;
	// Use this for initialization
	void Start () {
		GameObject a = GameObject.FindWithTag ("enemy10");
		e10 = a.GetComponent<enemy10T> ();
	}

	// Update is called once per frame
	void Update () {
		Vector3 pos = e10.nowpos;
		pos.x -= 1f;
		pos.y -= 18f;
		Vector3 newpos = new Vector3 (pos.x, pos.y, transform.position.z);
		transform.position = newpos;
		Destroy (gameObject, power);
	}
}
