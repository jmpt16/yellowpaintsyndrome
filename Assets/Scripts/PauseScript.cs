using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
	public void OnEnable()
	{
		Time.timeScale = 0.0f;
		Cursor.lockState = CursorLockMode.None;
	}
	public void OnDisable()
	{
		Time.timeScale = 1.0f;
		Cursor.lockState = CursorLockMode.Locked;
		gameObject.SetActive(false);
	}
	public void DisableSelf(GameObject menu)
	{
		menu.SetActive(false);
	}
	public void ChangeMenu(GameObject menu)
	{
		menu.SetActive(true);
	}
	public void ExitGame()
	{
		Application.Quit();
	}

	public void GoToThisScene(string sceneName)
	{
		Time.timeScale = 1.0f;
		SceneManager.LoadScene(sceneName);
	}
	public void GoToNextScene()
	{
		Time.timeScale = 1.0f;
		//SceneManager.LoadScene(sceneName);
		if(SceneManager.GetActiveScene().buildIndex +1 == SceneManager.sceneCountInBuildSettings)
		{
			SceneManager.LoadScene(0);
			return;
		}
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
	}

	public void Retry()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
