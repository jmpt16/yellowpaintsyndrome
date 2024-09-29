using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableScript : MonoBehaviour
{
    public bool active;
    int id;
    // Start is called before the first frame update
    void Start()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
		if (GetComponent<Animator>())
		{
			if (active)
			{
				GetComponent<Animator>().SetBool("Activate", !GetComponent<Animator>().GetBool("Activate"));
				active = false;
			}
		}
		if (GetComponent<Rigidbody>())
		{
			if (active)
			{
				transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2;
				transform.rotation = Camera.main.transform.rotation;
			}
			GetComponent<Rigidbody>().useGravity = !active;
		}
    }
}
