using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent _agent;

    public void Move(Vector3 pos)
    {
        _agent.destination = pos;
    }

}
