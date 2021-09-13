using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySenses : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameoverCutscene,
        _guardsContainer,
        _player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            DarrenSpotted();
    }

    public void DarrenSpotted()
    {
        _gameoverCutscene.SetActive(true);
        _guardsContainer.SetActive(false);
        _player.SetActive(false);
    }

    public void NoiseHeard(Vector3 pos)
    {
        //play voice
        GetComponent<EnemyPatrol>().StartCoroutine("IdleRoutine", pos);
    }
}
