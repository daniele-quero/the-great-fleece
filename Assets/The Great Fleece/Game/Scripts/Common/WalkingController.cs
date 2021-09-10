using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkingController : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private NavMeshAgent _agent;

    void Update()
    {
        _animator.SetBool("isWalking", isWalking());
    }

    private bool isWalking()
    {
        return _agent.velocity != Vector3.zero;
    }
}
