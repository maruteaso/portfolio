using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class machine : MonoBehaviour {

	public GameObject explosion;
	public GameObject bullet;
	public float shotdelay;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void shot(Transform here){
		Instantiate (bullet, here.position, here.rotation);
	}

	public void bang(){
		Instantiate (explosion, transform.position, transform.rotation);
	}
}
