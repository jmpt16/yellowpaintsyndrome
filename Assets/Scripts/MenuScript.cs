using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
	private void Start()
	{
		Debug.Log(Time.timeScale);
		Cursor.lockState = CursorLockMode.None;
		Screen.fullScreen = true;
		Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
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
	public void GoToLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
	}
}
