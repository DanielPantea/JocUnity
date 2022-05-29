using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public GameObject playerObj;
	private PlayerCarCtrl playerCtrl;
	public Material[] skybox;
	private bool canChange = true;

	public int daytime;


	// Use this for initialization
	void Start () {
		playerCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCarCtrl>();
		daytime = PlayerPrefs.GetInt ("Daytime") % 5;
		RenderSettings.skybox = skybox[PlayerPrefs.GetInt ("Daytime") % 5];
	}
	
	// Update is called once per frame
	void Update () {


		StartCoroutine (ChangeDayTime ());

	}

	private IEnumerator ChangeDayTime()
	{
		if (canChange)
		{
			canChange = false;
			yield return new WaitForSeconds (15f);
			daytime++;
			daytime = daytime % 5;
			RenderSettings.skybox = skybox [daytime];
			canChange = true;
		}
	}
	public void PlayerDied()
	{
		PlayerPrefs.SetInt ("Daytime", daytime);
		if(playerCtrl.score > PlayerPrefs.GetInt("HighScore"))
			PlayerPrefs.SetInt ("HighScore", (int) playerCtrl.score);
		SceneManager.LoadScene (0);
	}

}
