using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	public Text highScore;
	public Material[] skybox;
	public bool infoVisible;
	public GameObject infoPanel;
	public GameObject mainPanel;

	// Use this for initialization
	void Start () {
		highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString("D2");
		RenderSettings.skybox = skybox[PlayerPrefs.GetInt ("Daytime") % 5];
		infoVisible = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (infoVisible)
		{
			infoPanel.SetActive(true); ;
			mainPanel.SetActive(false); ;

			return;
		}

		infoPanel.SetActive(false); ;
		mainPanel.SetActive(true); ;

		if (Input.GetKey (KeyCode.LeftShift))
			if (Input.GetKeyDown (KeyCode.R))
			{
				PlayerPrefs.DeleteKey("HighScore");
				highScore.text = "HS: 00";
			}
	}
	public void ContinueEvent()
	{
		if (PlayerPrefs.HasKey("currentLevel") == true)
		{
			SceneManager.LoadScene (PlayerPrefs.GetInt("currentLevel"));
		}
			
	}
	public void StartNewEvent()
	{
		PlayerPrefs.SetInt ("currentLevel", 1);
		SceneManager.LoadScene (1);

	}

	public void ShowRules()
    {
		infoVisible = true;
	}

	public void HideRules()
    {
		infoVisible = false;
	}

	public void ExitGameEvent()
	{
		Application.Quit();
	}

}
