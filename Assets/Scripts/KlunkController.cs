using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KlunkController : MonoBehaviour {

	public Transform target;
	private NavMeshAgent agent;
	public bool move;
	private Animator anim;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
		agent.updatePosition = false;

		setAgentEnabled(false);
	}

	// Update is called once per frame
	void Update () {
		if (agent.enabled == true)
			agent.SetDestination(target.position);
	}

	public void setAgentEnabled(bool b){
		agent.enabled = b;
		// anim.SetBool("move", b);
	}

	void OnAnimatorMove(){
   	transform.position = agent.nextPosition;
	}
}
