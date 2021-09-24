using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VOTrigger : MonoBehaviour
{
    [SerializeField]
    AudioSource _audio;

    private bool _alreadyPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            if (!_alreadyPlayed)
            {
                _audio.Play();
                _alreadyPlayed = true;
            }
    }
}
