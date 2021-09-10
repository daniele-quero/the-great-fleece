using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> waypoints;
    public bool isPatrolling;
    private int _currentTargetId = -1;
    private int _direction = 1;
    [SerializeField]
    private NavMeshAgent _agent;

    private WaitForSeconds _idleOnTarget;
    private WaitForSeconds _patroStep;

    void Start()
    {
        _idleOnTarget = new WaitForSeconds(2.0f);
        _patroStep = new WaitForSeconds(0.2f);

        if (waypoints != null && waypoints.Count > 0)
        {
            _currentTargetId = 0;
            _agent.destination = waypoints[_currentTargetId].position;
        }

        StartCoroutine(PatrolCoroutine());
    }
    private int NextTarget()
    {
        int next = _currentTargetId + _direction;
        if (next == waypoints.Count || next == -1)
            _direction *= -1;

        _currentTargetId += _direction;

        return _currentTargetId;
    }

    private IEnumerator PatrolCoroutine()
    {
        while (isPatrolling)
        {
            if (waypoints != null && waypoints.Count > 0)
                if (transform.position == waypoints[_currentTargetId].position)
                {
                    if (_currentTargetId == 0 || _currentTargetId == waypoints.Count - 1)
                        yield return _idleOnTarget;

                    _agent.destination = waypoints[NextTarget()].position;
                }

                else
                    yield return _patroStep;
        }
    }
}
