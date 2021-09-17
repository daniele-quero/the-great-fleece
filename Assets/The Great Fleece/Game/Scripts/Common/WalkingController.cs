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

    [SerializeField]
    private float _animWaitSec = 0.2f;
    private WaitForSeconds _animWait;

    private void Start()
    {
        _animWait = new WaitForSeconds(_animWaitSec);
        StartCoroutine(WalkingRoutine());
    }

    private bool isWalking()
    {
        return _agent.velocity != Vector3.zero;
    }

    private IEnumerator WalkingRoutine()
    {
        while (true)
        {
            _animator.SetBool("isWalking", isWalking());
            yield return _animWait;
        }
    }

    private void OnEnable()
    {
        Start();   
    }
}
