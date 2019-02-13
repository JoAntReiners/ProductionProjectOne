using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour
{

	public State currentState;
	public EnemyStats enemyStats;
	public Transform eyes;
	public State remainState;
	public List<Transform> wayPointList;

	[HideInInspector] public NavMeshAgent navMeshAgent;
	[HideInInspector] public int nextWayPoint;
	[HideInInspector] public Transform chaseTarget;
	[HideInInspector] public float stateTimeElapsed;

	private bool aiActive;


	void Awake()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
	}

	public void SetupAI(bool isActive)
	{
		aiActive = isActive;
		if (aiActive)
		{
			navMeshAgent.enabled = true;
		}
		else
		{
			navMeshAgent.enabled = false;
		}
	}

	private void Update()
	{
		if (!aiActive)
		{
			return;
		}
		else
		{
			currentState.UpdateState(this);
		}
	}

	private void OnDrawGizmos()
	{
		if (currentState != null && eyes != null)
		{
			Gizmos.color = currentState.sceneGizmoColor;
			Gizmos.DrawWireSphere(eyes.position, enemyStats.lookSphereCastRadius);
		}
	}

	public void TransitionToState(State nextState)
	{
		if (nextState != remainState)
		{
			currentState = nextState;
			OnExitState();
		}
	}

	public bool CheckIfCountDownElapsed(float duration)
	{
		stateTimeElapsed += Time.deltaTime;
		return (stateTimeElapsed >= duration);
	}

	private void OnExitState()
	{
		stateTimeElapsed = 0;
	}
}