using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave10 : MonoBehaviour {

	public bool islive = true;
	public bool isrightlive = true;
	public bool isleftlive = true;
	AudioSource aud;
	public AudioClip next;

	// Use this for initialization
	void Start () {
		aud = GetComponent<AudioSource> ();
		aud.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (aud.isPlaying == false) {
			aud.clip = next;
			aud.loop = true;
			aud.Play ();
		}
	}


}
