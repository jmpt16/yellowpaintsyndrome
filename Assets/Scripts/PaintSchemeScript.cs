using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintSchemeScript : MonoBehaviour
{
    // Start is called before the first frame update
    float hueValue;

	public Text text;
	void Start()
    {
		GameObject[] allObjects = FindObjectsOfType<GameObject>();
		foreach (GameObject go in allObjects)
		{
			if (go.GetComponent<Renderer>())
				switch (go.tag)
				{
					case "Damaging":
						go.GetComponent<Renderer>().material.color = Color.red;
						break;
					case "Unpaintable":
						go.GetComponent<Renderer>().material.color = Color.white * 0.2f;
						break;
					case "Painted":
						go.GetComponent<Renderer>().material.color = Color.yellow;
						break;
				}
		}
		Singleton.readout = text;
		//GetComponent<Renderer>().material = new Material(Shader.Find("Standard"));
	}
}
