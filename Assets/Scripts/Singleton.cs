using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Singleton
{
    private Singleton() { }
    public static AmmoHandler readout { get; set; }=GameObject.FindFirstObjectByType<AmmoHandler>();

	private static int paint;
	public static int Paint {
        get 
        {
            return paint;
        } 
        set
        {
            paint = value;
            bool check = paint > 0;
			readout.ammoCount.gameObject.SetActive(check);
			readout.can.gameObject.SetActive(check);
			if (!check)
            {
                return;
            }
            readout.ammoCount.text = "Paint:" + value;
        } 
    }

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
}
