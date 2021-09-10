using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> waypoints;
    public bool isPatrolling;
    public float idleTime = 3.5f;
    public bool hasRandomPath;
    [SerializeField]
    private NavMeshAgent _agent;

    public List<EnemyPatrolModifier> modifiers;

    private int _currentTargetId = -1;
    private int _direction = -1;
    private WaitForSeconds _idleOnTarget;
    private WaitForSeconds _patrolStep;

    void Start()
    {
        _idleOnTarget = new WaitForSeconds(idleTime);
        _patrolStep = new WaitForSeconds(0.2f);

        if (WaypointsGood())
        {
            _currentTargetId = 0;
            _agent.destination = waypoints[_currentTargetId].position;
        }

        StartCoroutine(PatrolCoroutine());
    }

    private int NextTarget()
    {
        int next = _currentTargetId + _direction;
        if (OnWaypointsLimits())
            _direction *= -1;

        _currentTargetId += _direction;

        return _currentTargetId;
    }

    private void RecalculateRandomPath()
    {
        if (_currentTargetId == 0)
        {
            foreach (var mod in modifiers)
                if (hasRandomPath && Random.Range(0, 2) == 1)
                    mod.SwapWaypoints(waypoints);
        }
    }

    private IEnumerator PatrolCoroutine()
    {
        while (isPatrolling)
        {
            if (WaypointsGood())
            {
                if (transform.position == waypoints[_currentTargetId].position)
                {
                    if (OnWaypointsLimits())
                    {
                        RecalculateRandomPath();
                        yield return _idleOnTarget;
                    }

                    _agent.destination = waypoints[NextTarget()].position;
                }

                else
                    yield return _patrolStep;
            }
        }
    }

    #region Checks
    private bool WaypointsGood()
    {
        return waypoints != null && waypoints.Count > 0;
    }

    private bool OnWaypointsLimits()
    {
        return _currentTargetId == 0 || _currentTargetId == waypoints.Count - 1;
    }

    private bool OutsideWaypointsLimits(int next)
    {
        return next == waypoints.Count || next == -1;
    }
    #endregion
}
