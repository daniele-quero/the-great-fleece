using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VOTrigger : MonoBehaviour
{
    [SerializeField]
    AudioSource _audio;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            _audio.Play();
    }
}
