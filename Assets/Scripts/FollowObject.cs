using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour {

	public Transform followTarget;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = followTarget.position - transform.position;
	}

	// Update is called once per frame
	void Update () {
		transform.position = followTarget.position - offset;
	}
}
