using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObj : MonoBehaviour {

	public int health;

	void Update () {
		if (health == 0)
		{
			Destroy (gameObject);
		}
	}
}
