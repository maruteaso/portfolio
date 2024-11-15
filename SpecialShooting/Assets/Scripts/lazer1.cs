using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazer1 : MonoBehaviour {

	enemy9kaneboss e9;
	public float power;

	// Use this for initialization
	void Start () {
		GameObject a = GameObject.FindWithTag ("enemy9");
		e9 = a.GetComponent<enemy9kaneboss> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = e9.nowpos;
		pos.x += 1.3f;
		pos.y -= 17f;
		Vector3 newpos = new Vector3 (pos.x, pos.y, transform.position.z);
		transform.position = newpos;
		Destroy (gameObject, power);
	}
}
