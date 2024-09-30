using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Singleton
{
    private Singleton() { }

	private static int paint;
	public static int Paint {
        get 
        {
            return paint;
        } 
        set
        {
            paint = value;
            UIHandler readout = GameObject.FindFirstObjectByType<UIHandler>();
            readout.UI_Update(value);
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
