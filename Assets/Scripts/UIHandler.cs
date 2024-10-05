using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public Text ammoCount;
    public GameObject can;
    public GameObject pauseMenu,gameOverMenu;

    public void UI_Update(int value) 
    {
        bool check = value > 0;
        ammoCount.gameObject.SetActive(check);
        can.gameObject.SetActive(check);
        if (!check)
        {
            return;
        }
        ammoCount.text = "Paint:" + value;
    }

    public void pauseMenu_Update()
    {
		pauseMenu.SetActive(!pauseMenu.activeSelf);
		pauseMenu.GetComponent<PauseScript>().enabled = pauseMenu.activeSelf;
	}

	public void gameOverMenu_Update()
	{
		gameOverMenu.SetActive(true);
		Singleton.Paint = 0;
	}
}
