using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CollectableScript : MonoBehaviour
{
	public int ammo;
	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<PlayerScript>())
		{
			PlayerScript player = other.GetComponent<PlayerScript>();
			player.ammo = ammo;
			player.can.SetActive(true);
			player.text.gameObject.SetActive(true);
			player.text.text = "Ammo: " + ammo;
			Destroy(gameObject);
		}
	}
}
