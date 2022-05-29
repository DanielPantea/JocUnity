using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemAutoDestroy : MonoBehaviour {

	// Use this for initialization

	private ParticleSystem ps;

	void Start () {
		ps = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (ps)
		if (!ps.IsAlive ())
			Destroy (gameObject);
	}
}
