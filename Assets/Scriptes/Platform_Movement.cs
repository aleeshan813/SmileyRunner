using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Movement : MonoBehaviour
{
    [SerializeField] GameObject[] Waypoints;
    int CurrentWaypointIndex = 0;

    [SerializeField] float speed = 2.0f;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(Waypoints[CurrentWaypointIndex].transform.position, transform.position) < 0.1f)
        {
            CurrentWaypointIndex++;
            if(CurrentWaypointIndex >= Waypoints.Length)
            {
                CurrentWaypointIndex = 0; 
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, Waypoints[CurrentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
