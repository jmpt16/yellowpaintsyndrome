using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CollectableScript : MonoBehaviour
{
	public int paint;
	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<PlayerScript>())
		{
			Singleton.paint=paint;
			Singleton.UpdatePaintReadout();
            Destroy(gameObject);
		}
	}
}
