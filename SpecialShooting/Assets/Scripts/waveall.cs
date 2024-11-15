using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveall : MonoBehaviour {

	public AudioClip next;
	AudioSource aud;

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
