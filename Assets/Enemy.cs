using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AI_Behaviour : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform Waypoints;
    public List<Transform> targetPos;
    public int wayPointNumber;
    public bool isMoving;


    public Transform player; // Reference to the player's transform
    public float playerFollowRange = 5f; // Range at which the agent follows the player

    public float range;
    public float chaseDuration;
    public float chaseSpeed;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        foreach (Transform tr in Waypoints.GetComponentsInChildren<Transform>())
        {
            targetPos.Add(tr.gameObject.transform);
        }
        //MoveToRandomWaypoint();
    }

   // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
    }

    public void MoveToRandomWaypoint()
    {

        //code if we forgot to add waypoints into the list
        if (targetPos.Count == 0)
        {
            Debug.LogWarning("No waypoints available.");
            return;
        }

        //Make the bool moving true, get a random waypoint number
        isMoving = true;
        int newWaypointIndex = GetRandomWaypointIndex();
        //if waypoint number is not the same as waypoint index, then proceed to destination
        if (newWaypointIndex != wayPointNumber)
        {
            //we make this equal to random way point
            wayPointNumber = newWaypointIndex;
            //Setting the agent new destination
            agent.SetDestination(targetPos[wayPointNumber].position);
        }
        else
        {
            // If the random waypoint is the same as the current one, find another waypoint
            MoveToRandomWaypoint();
        }
    }

    private int GetRandomWaypointIndex()
    {
        return Random.Range(0, targetPos.Count);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
