using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy5cannon : MonoBehaviour {

	public GameObject cannon;
	public GameObject[] bully;
	public float avility;
	enemac ene;
	// Use this for initialization
	void Start () {
		ene = GetComponent<enemac> ();
		StartCoroutine ("Cannon");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Cannon(){
		while (true){
			if (Input.GetKey ("h")|| ene.auto) {
				Instantiate (cannon, transform.position, transform.rotation);
				yield return new WaitForSeconds (avility);
			}
			yield return new WaitForSeconds (0);
		}

	}

	public void bullying(){
		foreach (GameObject a in bully) {
			GameObject bully1 = (GameObject)Instantiate (a, transform.position, Quaternion.identity);
			bully1.transform.parent = transform;
		}
	}

}
