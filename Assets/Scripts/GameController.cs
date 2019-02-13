using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public StateController[] agents;
	
	// Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < agents.Length; i++)
		{
			agents[i].SetupAI(true);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
