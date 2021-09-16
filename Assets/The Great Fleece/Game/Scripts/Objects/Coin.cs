using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private float _maxRange = 15f;

    [SerializeField]
    NavMeshAgent _agent;
    void Start()
    {
        Vector3 playerPos = GameObject.Find("Player").transform.position;
        float distance = Vector3.Distance(transform.position, playerPos);
        StartCoroutine(LandingRoutine(distance));
    }

    private IEnumerator LandingRoutine(float distance)
    {
        yield return new WaitForSeconds(distance / 20);
        SetAgent();
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<AudioSource>().Play();
        _agent.enabled = false;

        AlertGuardsInRange();
    }

    private void SetAgent()
    {
        _agent.enabled = false;
        _agent.enabled = true;

        if (!_agent.isOnNavMesh)
        {
            NavMeshHit myNavHit;
            if (NavMesh.SamplePosition(transform.position, out myNavHit, 10f, NavMesh.AllAreas))
                transform.position = myNavHit.position;
        }

        _agent.baseOffset = -1.54f;
    }

    private void AlertGuardsInRange()
    {
        GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard");

        foreach (var g in guards)
        {
            if (Vector3.Distance(transform.position, g.transform.position) <= _maxRange)
                g.GetComponent<EnemySenses>().NoiseHeard(transform.position);
        }
    }
}
