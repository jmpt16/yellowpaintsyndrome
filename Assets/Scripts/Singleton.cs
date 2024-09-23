using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Singleton
{
    private Singleton() { }
    public static int paint { get; set; }
    public static Text readout { get; set; }

    private static Singleton instance = null;

    public static Singleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }

    public static void UpdatePaintReadout()
    {
        //readout.gameObject.SetActive(paint > 0);
        GameObject.FindFirstObjectByType<PlayerScript>().can.SetActive(paint > 0);
        //readout.text = "Paint: " + paint;
    }
}
