using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		GetComponent<Renderer>().material.color = Color.red;
	}

    // Update is called once per frame
    void Update()
    {
		transform.Translate(Vector3.forward * Time.deltaTime*5);
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.GetComponent<PlayerScript>()) 
		{
			FindFirstObjectByType<UIHandler>().gameOverMenu_Update();
		}
		if (other.gameObject.GetComponent<EnemyScript>())
		{
			Destroy(other.gameObject);
		}
		Destroy(gameObject);
	}
}
