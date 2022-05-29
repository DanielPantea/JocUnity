using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

	public GameObject[] TilePrefabs;

	private List<GameObject> Tiles = new List<GameObject>();

	private Transform playerTransform;
	private float spawnZ = 0;
	private float safezone = 10;
	private float tileLength = 10;
	private int tileNumberOnScreen = 7;
	private int lastPrefabIndex = 0;

	// Use this for initialization
	void Start () {
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		for (int i = 0; i < tileNumberOnScreen; i++)
		{
			if (i < 2)
				SpawnTile (true);
			else
				SpawnTile (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (playerTransform.position.z - safezone> (spawnZ - tileNumberOnScreen * tileLength))
		{
			SpawnTile (false);
			DeleteTile ();
		}
	}

	private void SpawnTile(bool obstacleFree)
	{
		GameObject newTile;
		if(obstacleFree == true)
			newTile = Instantiate (TilePrefabs [0]) as GameObject;
		else
			newTile = Instantiate (TilePrefabs [RandomPrefabIndex()]) as GameObject;
		newTile.transform.SetParent (transform);
		newTile.transform.position = Vector3.forward * spawnZ;
		spawnZ += tileLength;
		Tiles.Add (newTile);
	}
	private void DeleteTile()
	{
		Destroy (Tiles [0]);
		Tiles.RemoveAt (0);
	}

	private int RandomPrefabIndex()
	{
		if (TilePrefabs.Length == 1)
			return 0;
		int randomIndex = lastPrefabIndex;
		while (randomIndex == lastPrefabIndex)
		{
			randomIndex = Random.Range (0, TilePrefabs.Length);
		}
		lastPrefabIndex = randomIndex;
		return randomIndex;
	}
}
