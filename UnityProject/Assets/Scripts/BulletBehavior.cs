using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

	public ParticleSystem hit;
	private ParticleSystem particle;

	private void OnTriggerEnter(Collider other)
	{
		Vector3 hitPos = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 1);
		Instantiate (hit, hitPos, Quaternion.identity);
		if (other.gameObject.tag == "Breakable")
		{
			other.gameObject.GetComponent<BreakableObj> ().health--;
		}
		Destroy (gameObject);
	}
}
