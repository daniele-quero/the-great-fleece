using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent _agent;

    [SerializeField]
    private Animator _animator;
    private void Update()
    {
        _animator.SetBool("isWalking", isWalking());
    }

    public void Move(Vector3 pos)
    {
        _agent.destination = pos;
    }

    private bool isWalking()
    {
        return _agent.velocity != Vector3.zero;
    }
}
