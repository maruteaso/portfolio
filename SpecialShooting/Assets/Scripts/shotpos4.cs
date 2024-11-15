﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotpos4 : MonoBehaviour {

	Vector3 pos;
	public float angle;
	public float change = 1;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 0, angle) * Time.deltaTime * change);
		pos = transform.eulerAngles;
		if (pos.z >= 110 && pos.z <= 270)
			change = -1;
		if (pos.z >= 0 && pos.z <= 90)
			change = 1;
		Destroy (gameObject, 5);
	}
}
