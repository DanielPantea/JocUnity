using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWeapon : MonoBehaviour {

	public GameObject bulletPrefab;

	public Transform bulletSpawn;
	public float bulletSpeed = 30;
	public float lifeTime = 3;
	public float fireRate = 10;
	private float lastFired;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButton (0))
			if (Time.time - lastFired > 1 / fireRate)
			{
				lastFired = Time.time;
				Fire ();
			}
	}

	private void Fire()
	{
		GameObject bullet = Instantiate (bulletPrefab);

		Physics.IgnoreCollision(bullet.GetComponent<Collider>(),
			bulletSpawn.parent.GetComponent<Collider>());

		bullet.transform.position = bulletSpawn.position;

		Vector3 rotation = bullet.transform.rotation.eulerAngles;

		bullet.transform.rotation = Quaternion.Euler (rotation.x, transform.eulerAngles.y, rotation.z);
		bullet.GetComponent<Rigidbody> ().AddForce (bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);
		StartCoroutine (DestroyBulletAfterTime(bullet, lifeTime));
	}

	private IEnumerator DestroyBulletAfterTime( GameObject bullet, float delay)
	{
		yield return new WaitForSeconds (delay);

		Destroy (bullet);
	}
}
