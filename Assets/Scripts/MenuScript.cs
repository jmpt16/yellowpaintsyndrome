using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
	public AudioMixer mixer;
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

	public void UpdateMouseSens(Slider slider)
	{
		Singleton.mouseSens = Convert.ToInt32(slider.value);
	}
	public void UpdateVolume(Slider slider)
	{
		mixer.SetFloat("Volume", slider.value);
		Singleton.mouseSens = Convert.ToInt32(slider.value);
	}
}
