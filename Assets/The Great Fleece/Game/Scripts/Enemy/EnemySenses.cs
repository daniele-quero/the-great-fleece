using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySenses : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameoverCutscene,
        _guardsContainer,
        _player;

    [SerializeField]
    private GameObject[] _securityCams;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            DarrenSpotted();
    }

    private void FreezeSecurityCameras()
    {
        foreach (var c in _securityCams)
            c.GetComponent<SecurityCamera>().FreezeCameraOnDarren();
    }

    private void DarrenSpotted()
    {
        _gameoverCutscene.SetActive(true);
        _guardsContainer.SetActive(false);
        _player.SetActive(false);

        if (tag == "securityCam")
            FreezeSecurityCameras();
    }

    public void NoiseHeard(Vector3 pos)
    {
        GetComponent<EnemyPatrol>().StartCoroutine("IdleRoutine", pos);
    }
}
