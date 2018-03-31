using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingKlunkController : MonoBehaviour {

	public GameObject spikeBullet;
	private float reloadTime = 0.25f;
	public bool firingEnabled;

	// Use this for initialization
	void Start () {
		firingEnabled = true;
	}

	public IEnumerator ShootBurst() {
		fireProjectile(-20f);
		yield return new WaitForSecondsRealtime(reloadTime);
		fireProjectile(0);
		yield return new WaitForSecondsRealtime(reloadTime);
		fireProjectile(20f);
		yield return new WaitForSecondsRealtime(3.0f);
		if (firingEnabled)
			StartCoroutine(ShootBurst());
	}

	void fireProjectile(float offsetAngle) {
		Quaternion rotation = Quaternion.Euler(0, (transform.rotation.eulerAngles.y + offsetAngle), 0);
		Vector3 bulletPosition = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
		GameObject b = Instantiate(spikeBullet, bulletPosition, rotation);
		b.GetComponent<Rigidbody>().velocity = b.transform.forward * 25;
	}

	public void beginFiring(){
		StartCoroutine(ShootBurst());
	}
}
