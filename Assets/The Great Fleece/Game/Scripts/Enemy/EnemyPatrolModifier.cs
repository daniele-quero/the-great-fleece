using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyPatrolModifier
{
    [SerializeField]
    private Transform jollyWaypoint;
    [SerializeField]
    private int id;

    public void SwapWaypoints(List<Transform> waypoints)
    {
        if(waypoints != null && waypoints.Count > id)
        {
            Transform temp = waypoints[id];
            waypoints[id] = jollyWaypoint;
            jollyWaypoint = temp;
        }
    }
}
