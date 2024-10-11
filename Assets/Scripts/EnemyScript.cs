using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
	public Transform target;
    CharacterController controller;
    public float speed,timer,timerShift,countdown=5;
    public bool shootReady=false;
    public GameObject bullet;
    public bool active = true;
    // Start is called before the first frame update
    void Start()
    {
        target= GameObject.FindFirstObjectByType<PlayerScript>().transform;
        controller= GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
		if (transform.position.y < -10)
		{
			Destroy(gameObject);
		}
		if (active)
        {
			RaycastHit hit;
			Vector3 lookDir = target.position - transform.position;
			lookDir.y = 0; // keep only the horizontal direction
			transform.rotation = Quaternion.LookRotation(lookDir);
			if (Physics.Linecast(transform.position, target.position, out hit) && hit.transform == target.transform)
			{
				if (shootReady)
				{
					countdown = 1;
					controller.SimpleMove(Vector3.zero);
				}
				else
				{
					countdown = 5;
					controller.SimpleMove(transform.forward * speed);
				}
				if (timer > countdown)
				{
					if (shootReady)
					{
						transform.rotation = Quaternion.LookRotation(target.position - transform.position);
						GameObject bllt = Instantiate(bullet, transform.position + transform.forward, transform.rotation);
					}
					timer = 0;
					shootReady = !shootReady;
				}
				timer += Time.deltaTime;
			}
		}
    }
}
