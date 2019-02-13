using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public static bool isPaused = false;

	public GameObject pauseMenuUI;

	private void Start()
	{
		Resume();
	}

	// Update is called once per frame
	void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(isPaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}
    }

	public void Resume()
	{
		pauseMenuUI.SetActive(false);
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		Time.timeScale = 1f;
		isPaused = false;
	}

	void Pause()
	{
		pauseMenuUI.SetActive(true);
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		Time.timeScale = 0f;
		isPaused = true;
	}

	public void LoadMenu()
	{
		Debug.Log("Loading Menu");
		Time.timeScale = 1f;
		SceneManager.LoadScene(0);
	}

	public void QuitGame()
	{
		Debug.Log("Quitting Game");
		Application.Quit();
	}
}
