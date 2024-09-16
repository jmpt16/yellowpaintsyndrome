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
	public void GoToScene(string sceneName)
	{
		Time.timeScale = 1.0f;
		SceneManager.LoadScene(sceneName);
	}

	public void Retry()
	{
		GoToScene(SceneManager.GetActiveScene().name);
	}
}
