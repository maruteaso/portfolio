using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class prologue : MonoBehaviour {

	public float speed; 
	Vector2 pos;
	RectTransform rec;
	GameObject scene;
	scenechange ispro;
	// Use this for initialization
	void Start () {
		scene = GameObject.FindWithTag ("manage");
		ispro = scene.GetComponent<scenechange> ();
		rec = GetComponent<RectTransform> ();
		pos = rec.localPosition;
	}
	// Update is called once per frame
	void Update () {
		if (ispro.a == 1) {
			Vector2 direction = new Vector2 (0, 1);
			pos += direction * speed * Time.deltaTime;
			rec.localPosition = pos;
			Vector3 judge = rec.localPosition;
			if (judge.y >= 1000)
				SceneManager.LoadScene ("Main");
		}
	}
}
