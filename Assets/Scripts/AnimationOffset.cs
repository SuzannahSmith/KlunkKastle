using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationOffset : MonoBehaviour {

	void Start () {
		Animator anim = GetComponent<Animator>();
		anim.Play("hammer", -1, 0.5f);
	}

}
