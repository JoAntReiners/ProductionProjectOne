using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
	public float speed = 10f;
	public Animator anim;

	private float speedhold;
    // Start is called before the first frame update
    void Start()
    {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		anim = GetComponent<Animator>();
		speedhold = speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		//Movement Stuff
		float forward = Input.GetAxis("Vertical") * speed;
		float horizontal = Input.GetAxis("Horizontal") * speed;

		transform.Translate(horizontal * Time.deltaTime, 0, forward * Time.deltaTime);

		//Crouching
		if(Input.GetKey(KeyCode.LeftControl))
		{
			Crouch();
		}
		else
		{
			Stand();
		}

    }

	void Crouch()
	{
		gameObject.transform.localScale = new Vector3(1, .5f, 1);
		//Ask Peter, seems like a bad way to do it
		gameObject.transform.position = new Vector3(gameObject.transform.position.x, .5f, gameObject.transform.position.z);
		speed = speedhold/2;
	}

	void Stand()
	{
		gameObject.transform.localScale = new Vector3(1, 1, 1);
		//Ask Peter, seems like a bad way to do it
		gameObject.transform.position = new Vector3(gameObject.transform.position.x, 1, gameObject.transform.position.z);
		speed = speedhold;
	}

}
