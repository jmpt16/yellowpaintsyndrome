using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
	//public int ammo;
	public AudioClip grabSound;
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag=="Player")
		{
			other.GetComponent<AudioSource>().clip = grabSound;
			other.GetComponent<AudioSource>().Play();
			Singleton.Paint += 2;
			Destroy(gameObject);
		}
	}
}
