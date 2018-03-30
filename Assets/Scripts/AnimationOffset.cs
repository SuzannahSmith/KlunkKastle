using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationOffset : MonoBehaviour {

	public bool isRandom;
	public string animName;
	public float offset;

	void Start () {
		PlayOffsetAnimation ();
	}

	public void PlayOffsetAnimation() {
		Animator anim = GetComponent<Animator>();
		if (anim != null) {
			if (isRandom) {
				anim.Play (animName, -1, Random.Range (0.0f, 1f));
			} else {
				anim.Play (animName, -1, offset);
			}
		}
	}
}
