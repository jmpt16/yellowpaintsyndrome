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
		if (GetComponent<EnemyScript>())
		{
			if (GetComponent<EnemyScript>().target == null)
			{
				EnemyScript[] enemies = FindObjectsByType<EnemyScript>(FindObjectsSortMode.None);
				float distance = 100;
				int index = 0;
                for (int i = 0; i < enemies.Length; i++)
                {
                    if (enemies[i].gameObject.tag!="Painted" && Vector3.Distance(transform.position, enemies[i].transform.position)<distance)
                    {
						distance = Vector3.Distance(transform.position, enemies[i].transform.position);
						index = i;
					}
                }
				GetComponent<EnemyScript>().target = enemies[index].transform;
				active = false;
			}
			if (active)
			{
				GetComponent<EnemyScript>().active = true;
			}
		}
		if (GetComponent<BulletScript>())
		{
			if (active)
			{
				transform.rotation = Quaternion.Inverse(transform.rotation);
				active = false;
			}
		}
	}
	public void PaintObject()
	{
		if (GetComponent<EnemyScript>()) 
		{
			GetComponent<EnemyScript>().active = false;
			GetComponent<EnemyScript>().target = null;
		}
		transform.tag = "Painted";
		transform.GetComponent<Renderer>().material.color = Color.yellow;
		Singleton.Paint--;
	}
}
