using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> waypoints;
    private int _currentTargetId = -1;
    private int _direction = 1;
    [SerializeField]
    private NavMeshAgent _agent;

    void Start()
    {
        if (waypoints != null && waypoints.Count > 0)
        {
            _currentTargetId = 0;
            _agent.destination = waypoints[_currentTargetId].position;
        }           
    }

    void Update()
    {
        if (waypoints != null && waypoints.Count > 0)
            if (transform.position == waypoints[_currentTargetId].position)
            {
                _agent.destination = waypoints[NextTarget()].position;
            }
    }

    private int NextTarget()
    {
            int next = _currentTargetId + _direction;
            if (next == waypoints.Count || next == -1)
                _direction *= -1;

            _currentTargetId += _direction;

            return _currentTargetId;
    }
}
