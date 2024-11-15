using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotpos1 : MonoBehaviour {

	Vector3 pos;
	public float angle;
	public float change = 1;
	// Use this for initialization
	void Start () {
		transform.eulerAngles = pos;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 0, angle) * Time.deltaTime * change);
		pos = transform.eulerAngles;
		if (pos.z >= angle && pos.z <= 180) {
			change = -1;
		}
		else if(pos.z >= 180 && pos.z <= (360-angle)){
			change = 1;
		}
	}
}
