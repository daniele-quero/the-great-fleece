using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertController : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    public void AlertAnimation()
    {
        _animator.SetTrigger("alerted");
    }
}
