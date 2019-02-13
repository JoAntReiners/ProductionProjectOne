using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
	public Transform teleportLocation;

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			other.gameObject.transform.position = teleportLocation.position;
		}
	}
}
