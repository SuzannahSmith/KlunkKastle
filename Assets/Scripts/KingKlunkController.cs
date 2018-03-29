using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingKlunkController : MonoBehaviour {

	float lastFired;
	public GameObject spikeBullet;
	// Use this for initialization
	void Start () {
		lastFired = Time.time;
	}

	// Update is called once per frame
	void Update () {
		if (Time.time - lastFired > 3.0f){
			fireProjectile();
		}
	}

	void fireProjectile(){
		Quaternion rotation = transform.rotation;
		float rand = Random.Range(-25f, 25f);
		rotation *= Quaternion.Euler(0, rand, 0);
		GameObject b = Instantiate(spikeBullet, transform.position, rotation);

		rand = Random.Range(-25f, 25f);
		Quaternion rotation2 = transform.rotation;
		rotation2 *= Quaternion.Euler(0, rand, 0);
		GameObject b2 = Instantiate(spikeBullet, transform.position, rotation2);
		//b.GetComponent<BulletController>().InitPosition(transform.position + offsetVector, new Vector3(0, 2f, 0), Quaternion.Euler(0, 0, 0));
		b.GetComponent<Rigidbody>().velocity = b.transform.forward * 25;
		b2.GetComponent<Rigidbody>().velocity = b2.transform.forward * 25;
		lastFired = Time.time;
	}
}
