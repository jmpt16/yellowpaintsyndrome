using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTriggerScript : MonoBehaviour
{
    public GameObject endLevel;
	private void OnTriggerEnter(Collider other)
	{
        if (other.GetComponent<PlayerScript>())
        {
			endLevel.SetActive(true);
		}
    }
}
