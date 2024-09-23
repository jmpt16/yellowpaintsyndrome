using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	public CharacterController controller;
	public Vector3 playerVelocity;
	float xRot;
	public bool groundedPlayer;
	public float playerSpeed = 2.0f;
	public float runMultiplier = 1.4f;
	public float jumpHeight = 1.0f;
	public float gravityValue = -9.81f;
	public float turnSmoothTime;
	public GameObject can,pause;
	private void Start()
	{
		controller = gameObject.GetComponent<CharacterController>();
		Camera.main.transform.parent = transform;
		Camera.main.transform.position = transform.position + transform.up * .5f;
		Cursor.lockState = CursorLockMode.Locked;
	}

	void PaintThing()
	{
		if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 2) && hit.transform.tag == "Clear")
		{
			hit.transform.tag = "Painted";
			hit.transform.GetComponent<Renderer>().material.color = Color.yellow;
			Singleton.paint--;
            Singleton.UpdatePaintReadout();
            if (Singleton.paint <= 0)
			{
				can.SetActive(false);
			}
		}
	}

	void InteractThing()
	{
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 2) && hit.transform.tag == "Painted")
        {
            //hit.transform.tag = "Activated";
            //hit.transform.GetComponent<Animation>().Play();
            hit.transform.GetComponent<Animator>().SetBool("Activate", !hit.transform.GetComponent<Animator>().GetBool("Activate"));
        }
    }

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Return))
		{
			pause.SetActive(!pause.activeSelf);
			pause.GetComponent<PauseScript>().enabled = pause.activeSelf;
		}
		if (Singleton.paint> 0 && Input.GetMouseButtonDown(1))
        {
			PaintThing();
        }
		if (Input.GetMouseButtonDown(0))
		{
			InteractThing();
        }
		float mouseX=Input.GetAxis("Mouse X")* 1000 * Time.deltaTime;
		float mouseY=Input.GetAxis("Mouse Y")* 1000 * Time.deltaTime;

		xRot -= mouseY;
		xRot=Mathf.Clamp(xRot, -90f, 90f);
		
		Camera.main.transform.localRotation=Quaternion.Euler(xRot,0,0);
		transform.Rotate(mouseX * Vector3.up);

		groundedPlayer = controller.isGrounded;
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

		Vector3 moveDir = transform.right * moveInput.x + transform.forward * moveInput.z;
		moveDir *= playerSpeed;
		
		playerVelocity = new Vector3(moveDir.x, playerVelocity.y, moveDir.z);

        if (Input.GetButtonDown("Jump")&& groundedPlayer)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            groundedPlayer = false;

		}
        if (!groundedPlayer)
		{
			controller.stepOffset = 0f;
			playerVelocity.y += gravityValue * Time.deltaTime;
			//Debug.Log(controller.velocity.y + " | " + playerVelocity.y);
			if (controller.velocity.y==0 && playerVelocity.y>0)
            {
				
			}
        }
		else 
		{
			playerVelocity.y = -1f;
			controller.stepOffset = 1f;
        }

		controller.Move(playerVelocity * Time.deltaTime);
    }
}