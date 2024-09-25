using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
	//public int ammo;
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag=="Player")
		{
			Singleton.Paint += 2;
			Destroy(gameObject);
		}
	}
}
