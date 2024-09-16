using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintSchemeScript : MonoBehaviour
{
    // Start is called before the first frame update
    float hueValue;

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
		//GetComponent<Renderer>().material = new Material(Shader.Find("Standard"));
	}

    // Update is called once per frame
    void Update()
    {
	}
}
