using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public static bool gameIsPaused = false;
	public GameObject pauseMenuUI;
	public GameObject playerObject;
	public GameObject BlurObj;
	public Image PauseSprite;
	public Text ResumeText;

	/*public Button resumeButton;
	public Button saveButton;
	public Button deleteSavesButton;
	public int currentSelected = 0;
*/


	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update ()
	{
		
		if (Input.GetKeyDown (KeyCode.Escape))
			//if i was paused, then resume
			if (gameIsPaused == true)
				Resume ();
			//if i was active, then pause
			else
			{
				//isGrounded will remember if I was o the ground when I pressed escape
				Pause ();
			}
			
	}

	public void Resume()
	{
		//make the pause UI panel not visible
		pauseMenuUI.SetActive (false);
		BlurObj.SetActive (false);
		//make the time go back to normal
		Time.timeScale = 1f;

		gameIsPaused = false;
	}

	void Pause()
	{
		//make the pause UI panel visible
		pauseMenuUI.SetActive (true);
		BlurObj.SetActive (true);
		//stop the time

		Time.timeScale = 0f;

		gameIsPaused = true;
	}
	public void ExitToMainScene()
	{
		SceneManager.LoadScene (0);
	}

}
