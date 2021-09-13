using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TossCoin : MonoBehaviour
{
    [SerializeField]
    private GameObject _coin;

    [SerializeField]
    private int _coins = 1;

    [SerializeField]
    private float _maxTossDistance = 1f;

    [SerializeField]
    private Animator _animator;

    public void TossCoinAt(Vector3 position)
    {
        if (_coins > 0)
            if (Vector3.Distance(position, transform.position) < _maxTossDistance)
            {
                GameObject.Instantiate(_coin, position, Quaternion.identity);
                _coins--;
            }
    }
}
