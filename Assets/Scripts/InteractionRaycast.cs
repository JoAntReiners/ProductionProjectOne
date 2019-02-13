using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionRaycast : MonoBehaviour
{
	private GameObject raycastedObject;

	[SerializeField] private int rayLength = 10;
	[SerializeField] private LayerMask layerMaskInteract;
	[SerializeField] private Image Crosshair;

	private InteractionTest test;

	private void Update()
	{
		RaycastHit hit;
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		Debug.DrawRay(transform.position, fwd * rayLength, Color.green);

		if(Physics.Raycast(transform.position, fwd, out hit, rayLength, layerMaskInteract.value))
		{
			if(hit.collider.CompareTag("Switch"))
			{
				raycastedObject = hit.collider.gameObject;
				test = raycastedObject.GetComponent<InteractionTest>();

				if(Input.GetKeyDown(KeyCode.E))
				{
					test.Interact();
				}

			}
		}


	}
}
