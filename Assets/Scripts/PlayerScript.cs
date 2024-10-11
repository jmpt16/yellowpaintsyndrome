using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript: MonoBehaviour
{
    CharacterController controller;
	Vector3 playerVelocity;
	float xRot;
	bool groundedPlayer;
	public float playerSpeed = 2.0f;
	public UIHandler handler;
	private void Start()
    {
		handler = FindFirstObjectByType<UIHandler>();
		controller = gameObject.GetComponent<CharacterController>();
		Camera.main.transform.parent = transform;
		Camera.main.transform.position = transform.position + transform.up * .5f;
		Cursor.lockState = CursorLockMode.Locked;
    }
	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if(hit.transform.tag=="Damaging")
		{
			handler.gameOverMenu_Update();
		}
	}
	void Update()
    {
        if (transform.position.y<-10)
        {
            handler.gameOverMenu_Update();
        }
        if (Input.GetKeyDown(KeyCode.Return))
		{
			handler.pauseMenu_Update();
		}
		if (Singleton.Paint>0 && Input.GetMouseButtonDown(1))
        {
			if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward,out RaycastHit hit,2)&& (hit.transform.tag != "Painted" && hit.transform.tag!="Unpaintable"))
			{
				hit.transform.GetComponent<InteractableScript>().PaintObject();
			}
        }
		if (Input.GetMouseButtonDown(0))
		{
			if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 2) && hit.transform.tag == "Painted")
			{

				if (hit.transform.GetComponent<InteractableScript>())
				{
					hit.transform.GetComponent<InteractableScript>().active = true;
                }
			}
		}
		//mouse/camera stuff
		float mouseX=Input.GetAxis("Mouse X") * 1000 * Time.deltaTime;
		float mouseY=Input.GetAxis("Mouse Y") * 1000 * Time.deltaTime;

		xRot -= mouseY;
		xRot=Mathf.Clamp(xRot, -90f, 90f);
		
		Camera.main.transform.localRotation=Quaternion.Euler(xRot,0,0);
		transform.Rotate(mouseX * Vector3.up);

		groundedPlayer = controller.isGrounded;
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

		Vector3 moveDir = transform.right * moveInput.x + transform.forward * moveInput.z;
		moveDir *= playerSpeed;
		
		playerVelocity = new Vector3(moveDir.x, playerVelocity.y, moveDir.z);

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y = Mathf.Sqrt(-3.0f * Physics.gravity.y);
            groundedPlayer = false;

		}
        if (!groundedPlayer)
		{
			controller.stepOffset = 0f;
			playerVelocity.y += Physics.gravity.y * Time.deltaTime;
        }
		else 
		{
			playerVelocity.y = -1f;
			controller.stepOffset = .5f;
        }

		
		controller.Move(playerVelocity * Time.deltaTime);
    }
}